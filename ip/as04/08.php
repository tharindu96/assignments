<?php

// a)

$num = 1.958883;

echo $num . "<br/>";
echo "nearest integer: " . round($num) . "<br/>";
echo "2 decimal places: " . round($num, 2) . "<br/>";

echo "<br/><br/>";
// b)

$arr = [];
for ($i = 0; $i < 6; $i++) {
    $arr[$i] = rand(1, 100);
}

echo "maximum: " . max($arr);

echo "<br/><br/>";

// c)

$arr = [0, 30, 45, 60, 90, 180, 360];

echo "<table border=\"1\">";
echo "<thead><th>Angle</th><th>Sin</th><th>Cos</th><th>Tan</th></thead>";
echo "<tbody>";
foreach ($arr as $n) {
    $r = $n * (pi() / 180);
    echo "<tr><td>$n</td><td>". round(sin($r), 2) ."</td><td>". round(cos($r), 2) ."</td><td>". round(tan($r), 2) ."</td></tr>";
}
echo "</tbody>";
echo "</table>";

echo "<br/><br/>";

// d)

function volSphere($r) {
    return (4/3) * (pi() * pow($r, 3));
}

echo "volume: " . round(volSphere(4), 2);