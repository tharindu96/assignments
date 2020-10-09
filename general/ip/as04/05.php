<?php

function ypower($n, $p=2) {
    $t = $n;
    for ($i = 1; $i < $p; $i++) {
        $t *= $n;
    }
    return $t;
}