<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
</head>
<body>
    <?php
    if (!isset($_GET["type"])) {
    ?>
    <form>
        <input type="hidden" name="type" value="score">
        <ol>
            <li><b>What does PHP Stand for?</b></li>
            <ul style="list-style: none;">
                <li><input type="radio" name="q1" value="1" checked> Preprocessed Hytertext Page</li>
                <li><input type="radio" name="q1" value="2"> Hytertext Markup Language</li>
                <li><input type="radio" name="q1" value="3"> PHP: Hypertext Preprocessor</li>
                <li><input type="radio" name="q1" value="4"> None of the above</li>
            </ul>
            <li><b>Which of the following is the way to create comments in PHP?</b></li>
            <ul style="list-style: none;">
                <li><input type="radio" name="q2" value="1" checked> // commented code to end of line</li>
                <li><input type="radio" name="q2" value="2"> /* commented code here */</li>
                <li><input type="radio" name="q2" value="3"> # commented code to end of line</li>
                <li><input type="radio" name="q2" value="4"> all of the above</li>
            </ul>
            <li><b>A value that has no defined value is expressed in PHP with the following keyword:</b></li>
            <ul style="list-style: none;">
                <li><input type="radio" name="q3" value="1" checked> undef</li>
                <li><input type="radio" name="q3" value="2"> Null</li>
                <li><input type="radio" name="q3" value="3"> None</li>
                <li><input type="radio" name="q3" value="4"> There is no such concept in PHP</li>
            </ul>
        </ol>
        <input type="submit" value="Score Quiz!">
    </form>
    <?php
    } else {
        if ($_GET["type"] == "score") {
            $ANSWERS = [
                "q1" => [3],
                "q2" => [1, 2],
                "q3" => [2]
            ];
            $s = 0;
            $TS = 3;
            $sols = [];
            foreach ($ANSWERS as $k => $v) {
                if (in_array($_GET[$k], $v)) {
                    $s += 1;
                } else {
                    array_push($sols, $k);
                }
            }
        ?>
        <h1>Score: <?php echo $s; ?>/<?php echo $TS; ?></h1>
        <?php
        foreach ($sols as $s) {
            echo "<p>".$s . " <a href='p05.php?type=answer&q=".$s."'>answer</a></p>";
        }
        } else if ($_GET["type"] == "answer") {
            $q = $_GET["q"];
            if($q == "q1") {
                echo "<h1>Question: What does PHP Stand for?</h1>";
                echo "<h2>Answer: PHP: Hypertext Preprocessor</h2>";
            } else if ($q == "q2") {
                echo "<h1>Question: Which of the following is the way to create comments in PHP?</h1>";
                echo "<h2>Answer: // commented code to end of line OR /* commented code here */</h2>";
            } else if ($q == "q3") {
                echo "<h1>Question: A value that has no defined value is expressed in PHP with the following keyword:</h1>";
                echo "<h2>Answer: Null</h2>";
            }
        }
    }
    ?>
</body>
</html>