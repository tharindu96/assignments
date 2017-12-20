#!/bin/bash

if [ $# -lt 1 ]
then
	echo specify a program number eg:- 01
	exit 1
fi

n=$1

gcc -o $n -g -g3 $n.c
./$n
