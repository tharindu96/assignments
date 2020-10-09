<?php

$the_array = [1, 0, 5, 12, 8];

function reverse_array($arr) {
    $narr = [];
    $c = count($arr);
    for ($i = 0; $i < $c; $i++) {
        $narr[$i] = $arr[$c - $i - 1];
    }
    return $narr;
}

$reverse = reverse_array($the_array);

foreach($reverse as $x) {
    echo $x . " ";
}
