#!/bin/bash

if [[ $# -lt 1 ]]; then
	echo "$0 [time in seconds]"
	exit 1
fi

S=$1
M=$((($S / 60) % 60))
H=$(($S / (60 * 60)))
S=$(($S % 60))

echo -e "H: $H\nM: $M\nS: $S"
