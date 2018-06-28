@echo off

set /p Name= Enter username :

if [%Name%]==[%username%] (
	echo Username is correct
) else (
	echo Incorrect username
)