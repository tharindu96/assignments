<?php
$DATA = [
    [
        "name" => "Tom Cruise"
    ],[
        "name" => "Saman Perera"
    ]
];
function displayName($name, $title="Mr") {
    echo "<p>Dear $title. $name</p>";
}
function display($name, $title="Mr") {
    ?>
    <div class="address_holder">
        <p>Registrar</p>
        <p>University of Ruhuna</p>
        <p>Matara</p>
    </div>

    <div class="header">
        <h1>Student Registration</h1>
    </div>

    <div class="content">
    <?php displayName($name, $title); ?>
    <p>We are happy to inform you that you are selected to the <b>Computer Awareness Course</b></p>

    <p>Thank You.</p>
    </div>
    <hr>
    <?php
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>

    <link rel="stylesheet" href="01.css"/>
</head>
<body>

    <?php
    foreach ($DATA as $d) {
        $title = (key_exists("title", $d)) ? $d["title"] : "Mr";
        display($d["name"], $title);
    }
    ?>
    
</body>
</html>