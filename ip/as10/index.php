<?php
require 'init.php';
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

    <?php
    if (isset($_SESSION['user_id'])) {
        ?>
        <p><a href="logout.php">Sign Out</a></p>
        <p><a href="profile.php">Profile</a></p>
        <p><a href="viewitem.php">View Item</a></p>
        <?php
    } else {
        ?>
        <p><a href="login.php">Log In</a></p>
        <?php
    }
    ?>

</body>
</html>