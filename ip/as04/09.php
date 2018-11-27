<?php

$data = array("Donald", "Jim", "Tom","Mark","Jude");

print_r($data);
echo "<br/>";
echo "<br/>";

array_push($data, "Harry");

print_r($data);
echo "<br/>";
echo "<br/>";

reset($data);

while (($a = next($data)) != FALSE) {
    echo "$a<br/>";
}