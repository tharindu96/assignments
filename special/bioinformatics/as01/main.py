#!/usr/bin/env python

import re

MAPPING_FILE='mapping.txt'

# Read mapping file
def read_mapping_file():
    protein_array = []
    with open(MAPPING_FILE, 'r') as reader:
        lines = reader.readlines()
        for line in lines:
            x = line.strip().split(" ", 2)
            exprs = expand_compact_neucleotide(x[1])
            protein = x[0]
            protein_array.append([protein, exprs])
    return protein_array

# expand the sequence to multiple items
# AA[AU] -> AAA AAU
def expand_compact_neucleotide(expr):
    m = re.compile(r"([AUGC]{2})\[([AUGC]+)\]").findall(expr)
    if len(m) == 0:
        return [expr]
    prefix = m[0][0]
    augs = m[0][1]
    res = []
    for aug in augs:
        res.append("{}{}".format(prefix, aug))
    return res

# Build a amino acid dictionary
# eg : { "AAA": Phe } }
def build_protein_dictionary(protein_array):
    res = {}
    for protein_info in protein_array:
        for expr in protein_info[1]:
            res[expr] = protein_info[0]
    return res

def process_input_string(s, dic):
    nframes = len(s) % 3
    frames = []
    count = len(s) // 3
    for i in range(0, nframes+1):
        tarr = []
        for j in range(0, count):
            sp = i + (j * 3)
            ep = i + ((j+1) * 3)
            sstr = s[sp:ep]
            tr = dic[sstr]
            tarr.append(tr)
        frames.append(" ".join(tarr))
    return frames


if __name__ == "__main__":
    arr = read_mapping_file()
    dic = build_protein_dictionary(arr)
    s = input("Input Sequence: ")
    frames = process_input_string(s, dic)
    print("Nucleotide sequence: {}".format(s))
    for num, frame in enumerate(frames, start=0):
        print("Reading frame {}: {}".format(num, frame))
