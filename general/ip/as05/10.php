<?php

$str = "The flag was red white and blue.";

$str = str_replace("red", "black", $str);
$str = str_replace("white", "red", $str);
$str = str_replace("blue", "yellow", $str);

$token = strtok($str, " ");

while ($token !== false) {
    echo "$token<br/>";
    $token = strtok(" ");
}