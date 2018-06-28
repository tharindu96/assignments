@echo off

set i=0
:start
set /a i=%i% + 1
if %i% LEQ %1 (
	echo %i%
	goto :start
)