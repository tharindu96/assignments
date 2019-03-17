<?php

require 'init.php';

only_logged_in('seller', $ROOT);

$ERRORS = [];

function handle_post_request() {
    
    global $ERRORS;
    global $CONN;
    global $ROOT;
    
    if (!isset($_POST['itemcode']) || !isset($_POST['itemname']) || !isset($_POST['price'])) {
        return;
    }

    $itemcode = mysqli_real_escape_string($CONN, trim($_POST['itemcode']));
    $itemname = mysqli_real_escape_string($CONN, trim($_POST['itemname']));
    $price = mysqli_real_escape_string($CONN, trim($_POST['price']));
    
    if (!$itemcode || !$itemname || !$price) {
        array_push($ERRORS, "All fields must not be empty!");
        return;
    }

    if (!filter_var($price, FILTER_VALIDATE_INT)) {
        array_push($ERRORS, "Price must be a number");
        return;
    }

    $user_id = $_SESSION['user_id'];

    if (db_item_exists($itemcode)) {
        array_push($ERRORS, "Item Code already exists use another code!");
        return;
    }

    if (!db_item_create($itemcode, $itemname, $price, $user_id)) {
        array_push($ERRORS, "Unknown Error!");
        return;
    }

    header("Location: $ROOT/viewitem.php");
}

handle_post_request();

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Add Item</title>
</head>
<body>
    <h1>Add Item</h1>

    <p><a href="logout.php">Sign Out</a></p>
    <p><a href="viewitem.php">View Item</a></p>
    <p><a href="profile.php">Profile</a></p>

    <form action="" method="POST">
        <div>
            <label for="itemcode">Item Code: </label>
            <input type="text" name="itemcode" id="itemcode"/>
        </div>
        <div>
            <label for="itemname">Item Name</label>
            <input type="text" name="itemname" id="itemname"/>
        </div>
        <div>
            <label for="price">Price: </label>
            <input type="text" name="price" id="price"/>
        </div>
        <div>
            <input type="submit" value="Add Item">
            <input type="reset" value="Clear">    
        </div>
        <div>
            <ul>
                <?php
                foreach($ERRORS as $err) {
                    echo "<li style=\"color: red;\">$err</li>";
                }
                ?>
            </ul>
        </div>
    </form>
</body>
</html>