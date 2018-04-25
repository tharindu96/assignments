#!/bin/bash


if [[ $# -lt 1 ]]
then
    echo "Specify Directory"
    exit 1
fi

for f in $1/*.java
do
    classfile=${f/.java/.class}
    rm -vf $classfile
done

