<?php

$gm = " Good morning ";

$name = "Tharindu";

print($gm . $name . "<br/>");
print(trim($gm) . $name . "<br/>");
print(rtrim($gm) . $name . "<br/>");

$str = ltrim($gm) . $name . "<br/>";
$str = str_replace($name, "Keshan", $str);
print($str);

$str = substr($str, 4);
print($str);

$string = "university";

echo substr($string, 4) . "<br/>";
echo substr($string, -4) . "<br/>";
echo substr($string, 4, 3) . "<br/>";
echo substr($string, 4, -3) . "<br/>";