#!/bin/bash

i=1
while (( i <= 10 ))
do
	echo -ne "$i\t"
	i=$(($i+1))
done
echo
