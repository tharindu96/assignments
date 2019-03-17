<?php
require 'init.php';

only_logged_out($ROOT);

$ERRORS = [];

function handle_post_request() {

    global $ERRORS;
    global $CONN;
    global $ROOT;

    if (!isset($_POST['username']) || !isset($_POST['password'])) {
        return;
    }
    $username = mysqli_real_escape_string($CONN, trim($_POST['username']));
    $password = mysqli_real_escape_string($CONN, trim($_POST['password']));

    if (!$username || !$password) {
        array_push($ERRORS, "Username and Password must not be empty!");
        return;
    }

    $user = db_get_user($username, $password);
    if (!$user) {
        array_push($ERRORS, "Invalid Username and Password");
        return;
    }

    set_user_session($user[0], $user[1]);
    header("Location: $ROOT");
}

handle_post_request();

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Log In</title>
</head>
<body>
    <h1>Log In</h1>
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
            <input type="submit" value="Log In">
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
    <p>If you are a new user create an account from <a href="signup.php">here</a></p>
</body>
</html>