#!/bin/bash


if [[ $# -lt 1 ]]
then
    echo "Specify Directory"
    exit 1
fi

for f in $1/*.c
do
    binfile=${f/.c/}
    rm -vf $binfile
done

