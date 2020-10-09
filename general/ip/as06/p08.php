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
    if (isset($_GET["age"])) {
        $age = $_GET["age"];
        if (!preg_match('/[0-9]+/', $age)) {
            echo "<p style='color: red;'>age must be an integer!</p>";
        }
    }
    ?>
    <form action="" method="get">
        <div>
            <label for="">Enter Your Name: </label>
            <input type="text" name="name" id=""/>
        </div>
        <div>
            <label for="">Enter Your Age: </label>
            <input type="text" name="age" id=""/>
        </div>
        <div>
            <label for="">Comment about this web site: </label>
            <textarea name="" id=""></textarea>
        </div>
        <input type="submit" value="Submit">
    </form>
</body>
</html>