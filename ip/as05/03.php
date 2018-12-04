<?php

$arr = [1, 1, 1, [1, 1, 1, [1, 1, 1]]];

function sumNestedArray($arr) {
    $sum = 0;
    for ($i = 0; $i < count($arr); $i++) {
        $p = $arr[$i];
        if (is_numeric($p)) {
            $sum += $p;
        } else if(is_array($p)) {
            $sum += sumNestedArray($p);
        }
    }
    return $sum;
}

function flatten($arr, $res = []) {
    for ($i = 0; $i < count($arr); $i++) {
        $p = $arr[$i];
        if (is_array($p)) {
            $res = flatten($p, $res);
        } else {
            array_push($res, $p);
        }
    }
    return $res;
}

echo "SUM: " . sumNestedArray($arr) . "<br/>";

$flatarr = flatten($arr);
$str = implode(",", $flatarr);

print("array string: " . $str);

$fname = "array.txt";

$fd = fopen($fname, "w+");
foreach (explode(",", $str) as $a) {
    fwrite($fd, $a."\n");
}
fclose($fd);