
MEM = {
    0: 0,
    1: 1
}

def prod(k, n):
    if n in MEM:
        return MEM[n]
    p = prod(k, n - 1) + k * prod(k, n - 2)
    MEM[n] = p
    return p

INPUT = input()
xarr = INPUT.split(" ")
N = int(xarr[0])
K = int(xarr[1])

print(prod(K, N))