<?php

$FNAME = "votes.txt";

$SHOWS = [
    "Doramadalawa" => 0,
    "Live at 8" => 0,
    "Atapattama" => 0,
    "Loka sithiyama" => 0
];

if (file_exists($FNAME)) {
    $arr = unserialize(file_get_contents($FNAME));
    if (is_array($arr)) {
        foreach ($arr as $key => $value) {
            if (array_key_exists($key, $SHOWS)) {
                $SHOWS[$key] = $value;
            }
        }
    }
}

if (isset($_POST["program"])) {
    $name = $_POST["program"];
    if (array_key_exists($name, $SHOWS)) {
        $SHOWS[$name] += 1;
        $string = serialize($SHOWS);
        $f = fopen($FNAME, "w+");
        fwrite($f, $string);
        fclose($f);
    }
}

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
    <div>
        <form action="" method="post">
            <label for="pp">Which is your favorite TV Program?</label>
            <select name="program" id="pp">
                <?php
                foreach ($SHOWS as $name => $votes) {
                    echo "<option value=".$name.">".$name."</option>";
                }
                ?>
            </select>
            <input type="submit" value="Vote">
        </form>
    </div>
    <div>
        <h1>Votes</h1>
        <ul>
        <?php
        foreach ($SHOWS as $name => $votes) {
            echo "<li>$votes: $name</li>";
        }
        ?>
        </ul>
    </div>
</body>
</html>