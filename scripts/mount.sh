#!/bin/bash

if [ $# -lt 2 ]
then
	echo must specify device and mount directory
	exit 1
fi

uid=$(id -u)
gid=$(id -g)

sudo umount $2
mkdir -p $2
sudo umount $1
sudo mount -o gid=$gid,uid=$uid,umask=0022 $1 $2
