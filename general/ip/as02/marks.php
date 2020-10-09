<?php

$marks = 67;

if ($marks > 50) {
    echo "PASS";
} else {
    echo "FAIL";
}

echo "<br/>";

echo "Grade: ";

if ($marks >= 75) {
    echo "A";
} else if ($marks >= 65) {
    echo "B";
} else if ($marks >= 55) {
    echo "C";
} else if ($marks >= 35) {
    echo "S";
} else {
    echo "F";
}