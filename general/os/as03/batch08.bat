@echo off
set score=0
:start
set /a score=%score% + 1
echo %score%
if %score% LEQ 10 goto :start
echo done !