<?php

$text = "Internet Programming Practical";

$colors = [
    '#ff0000',
    '#00ff00',
    '#0000ff',
    '#ffff00',
    '#ff00ff',
    '#00ffff'
];

function print_title($text, $color) {
    echo "<p style='color:$color'>$text</p>";
}

$c = $colors[rand(0, count($colors) - 1)];

print_title($text, $c);

echo substr($text, 5, 3) . "<br/>";

echo strpos($text, "Pr") . "<br/>";

echo strrpos($text, "Pr") . "<br/>";

echo strrev($text) . "<br/>";

echo strlen($text) . "<br/>";

echo strtoupper($text) . "<br/>";

echo strtolower($text) . "<br/>";

$words = explode(" ", $text);

foreach($words as $w) {
    echo "$w<br/>";
}