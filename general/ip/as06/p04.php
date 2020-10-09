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
        <input type="number" name="n">
        <input type="submit" value="fib!">
    </form>
    <?php
    function fib($n=1) {
        $a = 0;
        $b = 1;
        $i = 0;
        echo "<ul>";
        while ($i < $n) {
            $f = $a + $b;
            $a = $b;
            $b = $f;
            echo "<li>".($i+1).": ".$f."</li>";
            $i++;
        }
    }
    if (isset($_GET["n"])) {
        $n = (int)$_GET["n"];
        fib($n);
    }
    ?>
</body>
</html>