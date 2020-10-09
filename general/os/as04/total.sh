#!/bin/bash

SUB1=0
SUB2=0
SUB3=0
echo -n "Enter marks for subject 1 -> "
read SUB1
echo -n "Enter marks for subject 2 -> "
read SUB2
echo -n "Enter marks for subject 3 -> "
read SUB3

echo "Total: $((SUB1 + SUB2 + SUB3))"
