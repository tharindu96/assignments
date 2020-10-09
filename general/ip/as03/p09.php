<?php

$the_array = [1, 4, 5, 12, 8];

function array_max($arr) {
    $m = $arr[0];
    foreach($arr as $a) {
        if ($a > $m)
            $m = $a;
    }
    return $m;
}

function array_min($arr) {
    $m = $arr[0];
    foreach($arr as $a) {
        if ($a < $m)
            $m = $a;
    }
    return $m;
}

function array_avg($arr) {
    $c = count($arr);
    $t = 0;
    foreach($arr as $a) {
        $t += $a;
    }
    return $t / $c;
}

echo "max: " . array_max($the_array) . "<br>";
echo "min: " . array_min($the_array) . "<br>";
echo "avg: " . array_avg($the_array) . "<br>";
