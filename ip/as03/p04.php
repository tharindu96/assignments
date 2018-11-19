<?php

$people = array(
    "Sajani" => 78,
    "Gayani" => 56,
    "Menali" => 85,
    "Ruvini" => 42
);

asort($people);


foreach($people as $name => $age) {
    echo $name . " " . $age . "<br>";
}
