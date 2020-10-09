<?php

$arr = [1,2,3,4,5,6,7,8,9,10];

$fd = fopen("array.txt", "a+");
foreach ($arr as $v) {
    fwrite($fd, $v."\n");
}
fclose($fd);