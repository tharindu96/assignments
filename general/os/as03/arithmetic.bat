@echo off

set a=%1
set b=%2

set /a c = %a% + %b%
echo Addition: %a% + %b% = %c%

set /a c = %a% - %b%
echo Subtraction: %a% - %b% = %c%

set /a c = %a% * %b%
echo Multiplication: %a% * %b% = %c%

if %b% EQU 0 (
	echo Cannot divide by zero.
) else (
	set /a c = %a% / %b%
	echo Division: %a% / %b% = %c%
)