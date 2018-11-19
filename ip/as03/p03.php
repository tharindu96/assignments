<?php

$donations = array(
    12, 34, 45, 34, 48, 35, 15, 87, 40, 68, 34
);

sort($donations);

foreach ($donations as $d) {
    echo $d . "<br>";
}
