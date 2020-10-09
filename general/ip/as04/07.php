<?php

function swap_ref(&$a, &$b) {
    $t = $a;
    $a = $b;
    $b = $t;
}

function swap_val($a, $b) {
    $t = $a;
    $a = $b;
    $b = $t;
}


$p = 1;
$q = 2;

echo $p . " " . $q;
echo "<br/>";

swap_ref($p, $q);

echo $p . " " . $q;
echo "<br/>";

swap_val($p, $q);

echo $p . " " . $q;
echo "<br/>";