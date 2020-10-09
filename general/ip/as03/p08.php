<?php


$the_array = [7, 5, 0, 3, 16];

function reverse_array($arr) {
    $narr = [];
    $c = count($arr);
    for ($i = 0; $i < $c; $i++) {
        $narr[$i] = $arr[$c - $i - 1];
    }
    return $narr;
}

function is_palindrome($arr) {
    $rev = reverse_array($arr);
    for($i = 0; $i < count($arr); $i++) {
        if ($arr[$i] != $rev[$i])
            return false;
    }
    return true;
}

echo (is_palindrome($the_array) ? "Is a" : "Not a") . " Palindrome";
