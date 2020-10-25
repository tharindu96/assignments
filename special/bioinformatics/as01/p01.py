INPUT = input()

def tlate(x):
    if x == "A":
        return "T"
    if x == "T":
        return "A"
    if x == "G":
        return "C"
    if x == "C":
        return "G"

ret = "".join(map(tlate, reversed(INPUT)))

print(ret)