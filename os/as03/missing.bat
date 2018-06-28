@echo off
set /a RN =%random%
if %1 equ %RN% echo Entered number is equal to random number
if %1 neq %RN% echo Entered number is not equal to random number
if %1 lss %RN% echo Entered no is less than the random number
if %1 gtr %RN% echo Entered no is greater than the random number
