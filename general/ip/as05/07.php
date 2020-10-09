<?php

// a

$t = file_get_contents("./article.html");

echo $t;

// b

function valid_date($str) {
    $c = preg_match("/([\d]{4})-([\d]{2})-([\d]{2})/", $str, $ma);
    if ($c == 0) {
        return false;
    }
    $year = (int)$ma[1];
    $month = (int)$ma[2];
    $day = (int)$ma[3];
    if ($month > 12 || $month <= 0) {
        return false;
    }
    if ($day > 31 || $day <= 0) {
        return false;
    }
    return true;
}

$d = "2010-12-30";
if (valid_date($d)) {
    echo $d . " is valid!<br/>";
} else {
    echo $d . " is invalid!<br/>";
}