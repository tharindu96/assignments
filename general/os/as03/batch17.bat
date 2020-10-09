@echo off
REM all parameters on command line using shift
:LOOP
if "%1"=="" goto DONE
echo %1
shift
goto loop
:DONE