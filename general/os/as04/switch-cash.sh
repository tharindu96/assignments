#!/bin/bash

case $1 in
	PC)
		echo "OK!"
		;;
	AC)
		echo "DONE!"
		;;
	DC)
		echo "FIND!"
		;;
	*)
		echo "sorry"
		;;
esac
