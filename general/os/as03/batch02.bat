@echo off
cls
rem lable & goto
echo Now Start!
goto :lable2
:lable1
echo Now Section 1
goto :end
goto :
:lable2
echo Now Section 2
goto :lable1
:end
echo Now End!