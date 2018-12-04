<?php

$text = "internet programming \n practical";

echo "UPPER CASE: " . strtoupper($text) . "<br/>";
echo "LOWER CASE: " . strtolower($text) . "<br/>";
echo "FIRST LETTER UPPER: " . ucfirst($text) . "<br/>";
echo "FIRST LETTER WORD: " . ucwords($text) . "<br/>";

$strs = explode("\n", $text);
echo "SPLIT WORD: <br/>";
foreach ($strs as $s) {
    echo $s;
    echo "<br/>";
}

echo "MD5: " . md5($text);