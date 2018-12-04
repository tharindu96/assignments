<?php

$fd = fopen("array.txt", "w+");
fwrite($fd, "");

if (strcasecmp("George", "george") == 0) {
    fwrite($fd, "true");
} else {
    fwrite($fd, "false");
}
fclose($fd);