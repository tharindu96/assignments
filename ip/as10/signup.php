<?php
require 'init.php';

only_logged_out($ROOT);

$ERRORS = [];

function handle_post_request() {
    global $ERRORS;
    global $ROOT;
    global $CONN;

    if (!isset($_POST['username']) || !isset($_POST['password'])) {
        return;
    }

    $username = mysqli_real_escape_string($CONN, trim($_POST['username']));
    $password = mysqli_real_escape_string($CONN, trim($_POST['password']));
    $role = mysqli_real_escape_string($CONN, trim($_POST['role']));

    if (!$username || !$password || !$role) {
        array_push($ERRORS, "Username and Password must not be empty!");
        return;
    }

    if (db_user_username_exists($username)) {
        array_push($ERRORS, "User with that username already exists!");
        return;
    }

    if (!db_user_create($username, $password, $role)) {
        array_push($ERRORS, "Unexpected error occured!");
        return;
    }

    header("Location: $ROOT/login.php");
}

handle_post_request();

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Sign Up</title>
</head>
<body>
    <h1>Sign Up</h1>
    <form action="" method="POST">
        <div>
            <label for="username">Username: </label>
            <input type="text" name="username" id="username">
        </div>
        <div>
            <label for="password">Password: </label>
            <input type="password" name="password" id="password">
        </div>
        <div>
            <label for="role">Role: </label>
            <select name="role" id="role">
                <option value="seller">Seller</option>
                <option value="buyer">Buyer</option>
            </select>
        </div>
        <div>
            <input type="submit" value="Sign Up">
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