#!/bin/bash

if [ $# -lt 1 ]
then
	echo specify a program number eg:- 01
	exit 1
fi

DIR=$(dirname "${1}")
JAVAFILE=$(basename "${1}")
CLASSFILE=${JAVAFILE/.java/}

cd $DIR

javac $JAVAFILE
java $CLASSFILE