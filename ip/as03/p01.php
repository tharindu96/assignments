<?php

$DAYS_OF_WEEK = array(
    "Monday",
    "Tuesday",
    "Wednesday",
    "Thursday",
    "Friday",
    "Saturday",
    "Sunday"
);

for($i = 0; $i < count($DAYS_OF_WEEK); $i++) {
    echo $DAYS_OF_WEEK[$i] . "<br>";
}

for($i = 0; $i < 100; $i++) {
    echo "-";
}
echo "<br>";

$DAYS_OF_WEEK = array();

$DAYS_OF_WEEK[0] = "Monday";
$DAYS_OF_WEEK[1] = "Tuesday";
$DAYS_OF_WEEK[2] = "Wednesday";
$DAYS_OF_WEEK[3] = "Thursday";
$DAYS_OF_WEEK[4] = "Friday";
$DAYS_OF_WEEK[5] = "Saturday";
$DAYS_OF_WEEK[6] = "Sunday";

foreach($DAYS_OF_WEEK as $day) {
    echo $day . "<br>";
}

?>
