#!/bin/bash
# Script to see whether given argument is positive

if test $1 -ge 0 -a $2 -ge 0
then
	echo "$1 and $2 are positive"
elif test $1 -lt 0 -a $2 -lt 0
then
	echo "$1 and $2 are negative"
else
	echo "$1 and $2 are opposites"
fi
