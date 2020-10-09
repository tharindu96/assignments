<?php
    $COLORS = ["#000", "#f00", "#0f0", "#00f", "#ff0", "#f0f", "#0ff", "#fff"];
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
</head>
<body>
    <form method="get" action="p03_bg.php">
        <input type="hidden" name="color" value="<?php echo $COLORS[rand(0, count($COLORS) - 1)]; ?>">
        <input type="submit" value="GO!">
    </form>
</body>
</html>