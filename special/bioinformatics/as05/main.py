#!/bin/env python3

INPUT = "a 12 b 14 c 14.5 d 17 e 18"

def create_table(l):
    mr = [0.0 for _ in range(0, l)]
    return [ mr.copy() for _ in range(0, l) ]

def table_set(m, i, j, v):
    m[i][j] = v

def table_get(m, i, j):
    return m[i][j]

def table_min(m):
    mi = float("inf")
    i, j = -1, -1
    for a in range(0, len(m)):
        for b in range(0, a):
            c = table_get(m, a, b)
            if c < mi:
                mi = c
                i, j = a, b
    return (i, j)

def get_cluster_list(label):
    return label.replace(")", "").replace("(", "").split(",")

def calculate_average(a_cluster, b_cluster, i_cluster, lookup):
    t = 0
    for ix in i_cluster:
        for ax in a_cluster:
            t += lookup[ix][ax]
        for bx in b_cluster:
            t += lookup[ix][bx]
    d = len(a_cluster)+len(b_cluster)
    print(t, d)
    return t / (len(a_cluster)+len(b_cluster))

def table_join(m, labels, a, b, lookup):

    if a > b:
        a, b = b, a

    a_cluster = get_cluster_list(labels[a])
    b_cluster = get_cluster_list(labels[b])

    row = [0.0 for _ in range(0, len(m))]
    for i in range(0, a):
        i_cluster = get_cluster_list(labels[i])
        row[i] = calculate_average(a_cluster, b_cluster, i_cluster, lookup)
    m[a] = row

    for i in range(a+1, len(m)):
        i_cluster = get_cluster_list(labels[i])
        m[i][a] = calculate_average(a_cluster, b_cluster, i_cluster, lookup)
    
    for i in range(0, len(m)):
        del m[i][b]

    del m[b]

    return m

def make_input_dict(inp):
    names = []
    values = []
    tokens = inp.split(" ")
    assert len(tokens) % 2 == 0
    for i in range(0, len(tokens) // 2):
        name = tokens[i*2]
        value = float(tokens[(i*2)+1])
        names.append(name)
        values.append(value)
    return (names, values)

def gen_table(inp):
    (labels, values) = make_input_dict(inp)
    m = create_table(len(labels))
    lookup = {}
    for i in range(0, len(labels)):
        il = labels[i]
        lookup[il] = {}
        lookup[il][il] = 0
        for j in range(0, i):
            jl = labels[j]
            vi = values[i]
            vj = values[j]
            v = abs(vi - vj)
            lookup[il][jl] = v
            if not jl in lookup:
                lookup[jl] = {}
            lookup[jl][il] = v
            table_set(m, i, j, v)
    return (m, labels, lookup)

def label_join(labels, a, b):
    if a > b:
        a, b = b, a
    labels[a] = "({},{})".format(labels[a],labels[b])
    del labels[b]
    return labels

def UPGMA(inp):
    (table, labels, lookup) = gen_table(inp)

    while (len(labels) > 1):
        (mi, mj) = table_min(table)
        table = table_join(table, mi, mj, lookup)
        labels = label_join(labels, mi, mj)

    return labels[0]


(table, labels, lookup) = gen_table(INPUT)

table = [
    [0.0, 0.0, 0.0, 0.0, 0.0],
    [10.0, 0.0, 0.0, 0.0, 0.0],
    [12.0, 4.0, 0.0, 0.0, 0.0],
    [8.0, 4.0, 6.0, 0.0, 0.0],
    [7.0, 14.0, 16.0, 12.0, 0.0]
]

labels = ['a', 'b', 'c', 'd', 'e']

lookup = {}
for (i, li) in enumerate(labels):
    lookup[li] = {}
    for (j, lj) in enumerate(labels):
        lookup[li][lj] = max(table[i][j], table[j][i])

(i, j) = table_min(table)
table = table_join(table, labels, i, j, lookup)
labels = label_join(labels, i, j)
print(labels, table)

(i, j) = table_min(table)
table = table_join(table, labels, i, j, lookup)
labels = label_join(labels, i, j)
print(labels, table)

(i, j) = table_min(table)
table = table_join(table, labels, i, j, lookup)
labels = label_join(labels, i, j)
print(labels, table)

(i, j) = table_min(table)
table = table_join(table, labels, i, j, lookup)
labels = label_join(labels, i, j)
print(labels, table)

# print(x)

# if __name__ == "__main__":
#     inp = input("Enter Sequences: ")
#     l = UPGMA(inp)
#     print(l)