<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
</head>
<body>
    <form action="" method="get">
        <div>
            <label>Enter No.s: </label>
            <input type="text" name="a" id="a" value="<?php if (isset($_GET["a"])) echo $_GET["a"]; ?>"/>
            <input type="text" name="b" id="b" value="<?php if (isset($_GET["b"])) echo $_GET["b"]; ?>"/>
        </div>
        <div>
            <input type="submit" value="Submit">
            <input type="button" value="Clear">
        </div>
        <div>
            <label>Result: </label>
            <textarea><?php
            if (isset($_GET["a"]) && isset($_GET["b"])) {
                if (is_numeric($_GET["a"]) && is_numeric($_GET["b"])) {
                    $a = (int)$_GET["a"];
                    $b = (int)$_GET["b"];
                    $r = $a % $b;
                    echo "$a % $b = $r";
                }
            }
            ?></textarea>
        </div>
    </form>
</body>
</html>