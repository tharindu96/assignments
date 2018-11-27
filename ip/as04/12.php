<?php

function calcDiscrminant($a, $b, $c) {
    return pow($b, 2) - 4 * $a * $c;
}

function solveQuadratic($a, $b, $c) {
    $disc = calcDiscrminant($a, $b, $c);
    if ($disc < 0) return FALSE;
    if ($disc == 0) {
        $x = (-$b)/(2*$a);
        return [$x];
    } else {
        $ss = sqrt($disc);
        $x = (-$b-$ss)/2*$a;
        $y = (-$b+$ss)/2*$a;
        return [$x, $y];
    }
}

print_r(solveQuadratic(5, 6, 1));
print_r(solveQuadratic(1, -2, 1));