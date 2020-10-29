
class NWMatrix:

    def __init__(self, A, B, match_score, missmatch_score, gap_penalty):
        
        self.rows = len(B) + 1
        self.cols = len(A) + 1
        self.A = A
        self.B = B
        self.score = match_score
        self.mscore = missmatch_score
        self.gap = gap_penalty

        self.M = [[None for _ in range(self.cols)] for _ in range(self.rows)] 
        self.set(0, 0, 0)
        for i in range(max(self.rows, self.cols)):
            try:
                self.set(0, i, self.gap * i)
            except:
                pass
            try:
                self.set(i, 0, self.gap * i)
            except:
                pass

    def get(self, i, j):
        if i > self.rows:
            raise Exception("invalid index access")
        if j > self.cols:
            raise Exception("invalid index access")
        return self.M[i][j]

    def set(self, i, j, v):
        if i > self.rows:
            raise Exception("invalid index access")
        if j > self.cols:
            raise Exception("invalid index access")
        self.M[i][j] = v

def calculate_score(M, a, b):
    if a == b:
        return M.score
    else:
        return M.mscore

def calculate_matrix_values(M):
    for i in range(1, M.rows):
        for j in range(1, M.cols):
            val = max(
                M.get(i - 1, j - 1) + calculate_score(M, M.A[j - 1], M.B[i - 1]),
                M.get(i, j - 1) + M.gap,
                M.get(i - 1, j) + M.gap
            )
            M.set(i, j, val)

def get_possible_indexes(M, i, j):
    # if M.A[j-1] == M.B[i-1]:
    #     return [(i-1, j-1)]
    # indexes = []
    # space = [(i-1, j), (i-1, j-1), (i, j-1)]
    # m = max(list(map(lambda s: M.get(s[0], s[1]), space)))
    # for s in space:
    #     if M.get(s[0], s[1]) == m:
    #         indexes.append(s)
    # return indexes

    indexes = []
    space = []
    if i - 1 >= 0:
        space.append((i-1, j))
    if j - 1 >= 0:
        space.append((i, j - 1))
    bmax = None
    if not (i, j) == (0, 0):
        if M.A[j-1] == M.B[i-1] and not (i-1,j-1) in indexes:
            indexes.append((i-1, j-1))
            bmax = M.get(i-1, j-1)
        else:
            space.append((i-1, j-1))
    m = max(list(map(lambda s: M.get(s[0], s[1]), space)))
    if bmax != None and bmax >= m:
        return indexes
    for s in space:
        if M.get(s[0], s[1]) == m:
            indexes.append(s)
    return indexes

def get_direction(p, q):
    x = abs(p[0] - q[0])
    y = abs(p[1] - q[1])
    if x == 1 and y == 1:
        return "M"
    if x == 1:
        return "V"
    if y == 1:
        return "H"

def get_next_index(d):
    return len(d) + 1

def print_status(n):
    print("# of paths in stack: {}".format(n))

def find_sequences(M):

    i, j = M.rows - 1, M.cols - 1
    END = (0, 0)
    START = (i, j)

    seq_stack = [(START, ("", ""))]
    seqs = []

    while len(seq_stack) > 0:
        p = seq_stack.pop(0)
        ((i, j), (sA, sB)) = p
        if (i, j) == END:
            seqs.append([sA[::-1], sB[::-1]])
            continue
        p_paths = get_possible_indexes(M, i, j)
        for p_path in p_paths:
            nsA = sA
            nsB = sB
            d = get_direction((i, j), p_path)
            if d == "M":
                nsA += M.A[j-1]
                nsB += M.B[i-1]
            elif d == "V":
                nsA += "-"
                nsB += M.B[i-1]
            elif d == "H":
                nsA += M.A[j-1]
                nsB += "-"
            seq_stack.append((p_path, (nsA, nsB)))

    return seqs

def print_matrix(M):
    for l in M.M:
        x = " | ".join(map(lambda y: "{: d}".format(y), l))
        print(x)

if __name__ == "__main__":

    sc = int(input("Enter Match Score: "))
    msc = int(input("Enter Miss Match Score: "))
    gp = int(input("Enter Gap Penalty: "))
    
    S1 = input("Enter Sequence 1: ")
    S2 = input("Enter Sequence 2: ")
    print("Generating Matrix...", end="")
    M = NWMatrix(S1, S2, sc, msc, gp)
    print("Done")
    print("Calculating Matrix Values...", end="")
    calculate_matrix_values(M)
    print("Done")
    print("Finding Sequences...", end="")
    seqs = find_sequences(M)
    print("Done")
    print("Matches:")
    if len(seqs) == 0:
        print("No Matches Found!")
    for (i, seq) in enumerate(seqs):
        print("Match: {}".format(i+1))
        print("Sequence 1: {}".format(seq[0]))
        print("Sequence 2: {}".format(seq[1]))
        print("---------------------------")