<?php

$MARKS = array(
    "Asanka" => 59,
    "Gayan" => 86,
    "Namal" => 47,
    "Ruwan" => 68,
    "Dinuka" => 23
);

foreach($MARKS as $name => $mark) {
    echo "Name: " . $name . "<br>";
    echo "Marks: " . $mark . "<br>";
    echo "Result: " . (($mark > 50) ? "Passed" : "Failed") . "<br>";
    echo "-----------------------<br>";
}
