<?php

$str = "234567890123456789012345678901234567890";
$lastPos = 0;
$positions = [];
while (($lastPos = strpos($str, "5", $lastPos)) != false) {
    $positions[] = $lastPos;
    $lastPos = $lastPos + 1;
}

foreach ($positions as $value) {
    echo $value ."<br />";
}

$email = "user@example.com";

echo "LENGTH: " . strlen($email) . "<br/>";

echo "First e: " . strstr($email, "e") . "<br/>";

echo "Last e: " . strrchr($email, "e") . "<br/>";

$tom = "tom";
$TOM = "TOM";

echo "$tom | $TOM " . strcmp($tom, $TOM) . "<br/>";

echo "$tom | $TOM " . strcasecmp($tom, $TOM) . "<br/>";

echo "$tom | lower($TOM) " . strcmp($tom, strtolower($TOM)) . "<br/>";