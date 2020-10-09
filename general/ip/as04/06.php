<?php

function factorial($n) {
    $f = $n;
    while ($n > 1) {
        $f *= (--$n);
    }
    return $f;
}

echo factorial(10);