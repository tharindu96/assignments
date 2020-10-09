<?php

$array = ["cat","dog","horse","rat","cat","pig","cow"];

$fd = fopen("animal.txt", "w+");
foreach ($array as $v) {
    fwrite($fd, $v . "\n");
}
fclose($fd);

$text = file_get_contents("animal.txt");

$x = preg_match("/cat/", $text, $matches);

echo "occurences of cat: " . $x;