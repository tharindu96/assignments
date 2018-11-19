<?php

$m = array(
    array(1, 2, 3),
    array(4, 5, 6),
    array(7, 8, 9)
);

foreach($m as $r) {
    foreach($r as $v) {
        echo $v . " ";
    }
    echo "<br>";
}
