<?php

$fname = "file.txt";

$fd = fopen($fname, "w+");
fwrite($fd, "Tharindu Hasthika\n");
fclose($fd);

file_put_contents($fname, "39", FILE_APPEND);

$c = file_get_contents($fname);

print($c);

unlink($fname);