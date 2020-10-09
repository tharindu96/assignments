<?php

$start = 10;

while ($start >= 0) {
    if ($start % 2 == 0) {
        echo "$start is even<br/>";
    } else {
        echo "$start is odd<br/>";
    }
    $start--;
}