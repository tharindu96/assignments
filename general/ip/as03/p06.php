<?php

$table = array(
    array(
        "name" => "Dulani",
        "physics" => 35,
        "maths" => 67,
        "chemistry" => 60
    ),
    array(
        "name" => "Rada",
        "physics" => 37,
        "maths" => 56,
        "chemistry" => 43
    ),
    array(
        "name" => "Dulani",
        "physics" => 57,
        "maths" => 62,
        "chemistry" => 58
    )
);


foreach($table as $row) {
    echo "     Name: " . $row["name"] . "<br>";
    echo "  Physics: " . $row["physics"] . "<br>";
    echo "    Maths: " . $row["maths"] . "<br>";
    echo "Chemistry: " . $row["chemistry"] . "<br>";
    echo "------------------------------------------<br>";
}
