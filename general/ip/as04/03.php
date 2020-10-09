<?php

function maxim($a, $b) {
    return ($a > $b) ? $a : $b;
}

$a = 5;
$b = 6;

echo "max of $a, $b is ";
echo maxim($a, $b);