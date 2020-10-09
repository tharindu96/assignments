<?php

$vegetable_bun = 25;
$fish_bun = 35;
$hamburg = 50;

$item = "Vegetable bun";

echo "Price: ";

switch ($item) {
    case 'Vegetable bun':
        echo $vegetable_bun;
        break;
    case 'Fish bun':
        echo $fish_bun;
        break;
    case 'Hamburg':
        echo $hamburg;
        break;
}