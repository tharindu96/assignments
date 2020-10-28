MISMATCH = 0
MATCH = 1
GAP = -1


class NWMatrix:

    def __init__(self, A, B):
        self.rows = len(B) + 1
        self.cols = len(A) + 1
        self.A = A
        self.B = B
        self.M = [[None for _ in range(self.cols)] for _ in range(self.rows)] 
        self.set(0, 0, 0)
        for i in range(max(self.rows, self.cols)):
            try:
                self.set(0, i, GAP * i)
            except:
                pass
            try:
                self.set(i, 0, GAP * i)
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

def calculate_score(a, b):
    if a == b:
        return MATCH
    else:
        return MISMATCH

def calculate_matrix_values(M):
    for i in range(1, M.rows):
        for j in range(1, M.cols):
            val = max(
                M.get(i - 1, j - 1) + calculate_score(M.A[j - 1], M.B[i - 1]),
                M.get(i, j - 1) + GAP,
                M.get(i - 1, j) + GAP
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
    space = [(i-1, j), (i, j-1)]
    bmax = None
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
    

def find_paths(M):
    """
    find paths from lower right (N-1, M-1) to upper left (0, 0)
    for a given index if not (0, 0):
        add the highest of the 3 neighbours to the potential list
        if in the given index the strings match add the diagonal to the potential list if not present
        [((i, j), (pi, pj)), ...]
        (i_maxtrix_column, j_matrix_row)
    """
    i, j = M.rows - 1, M.cols - 1
    END = (0, 0)
    START = (i, j)
    path_queue = [START]
    paths = []
    while len(path_queue) > 0:
        p = path_queue.pop(0)
        if p == END:
            continue
        (i, j) = p
        pp = get_possible_indexes(M, i, j)
        for x in pp:
            px = (x, p)
            if not px in paths:
                paths.append(px)
            path_queue.append(x)
    return paths

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
    S1 = input("Enter Sequence 1: ")
    S2 = input("Enter Sequence 2: ")
    M = NWMatrix(S1, S2)
    calculate_matrix_values(M)
    seqs = find_sequences(M)
    print("Matches:")
    if len(seqs) == 0:
        print("No Matches Found!")
    for (i, seq) in enumerate(seqs):
        print("Match: {}".format(i+1))
        print("Sequence 1: {}".format(seq[0]))
        print("Sequence 2: {}".format(seq[1]))
        print("---------------------------")


# paths = find_paths(M)


# for p in paths:
#     print("{} -> {} | {} -> {}".format(p[1], p[0], M.get(p[1][0], p[1][1]), M.get(p[0][0], p[0][1])))

