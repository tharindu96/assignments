<?php

function set_user_session($user_id, $user_role) {
    $_SESSION['user_id'] = $user_id;
    $_SESSION['user_role'] = $user_role;
}

function unset_user_session() {
    unset($_SESSION['user_id']);
    unset($_SESSION['user_role']);
}

// check if user is logged in and if not redirect to given url
function only_logged_in($role='any', $redirect='/') {
    if (!isset($_SESSION['user_id'])) {
        header("Location: $redirect");
        return;
    }
    $id = $_SESSION['user_id'];
    if (!db_user_exists($id)) {
        header("Location: $redirect");
        return;
    }
    if ($role == 'any')
        return;
    if ($_SESSION['user_role'] !== $role)
        header("Location: $redirect");
}

// opposite of the above function
function only_logged_out($redirect = '/') {
    if (isset($_SESSION['user_id'])) {
        $id = $_SESSION['user_id'];
        if(db_user_exists($id)) {
            header("Location: $redirect");
        }
    }
}

function db_connect() {
    $conn = mysqli_connect("localhost", "root", "", "emarket");
    if (!$conn) {
        echo "DB Error: " . mysqli_error($conn);
        die();
    }
    return $conn;
}

function db_get_user($username, $password) {
    global $CONN;
    $res = mysqli_query($CONN, "SELECT user_id, password, role FROM user WHERE username = '$username'");
    if (!$res) {
        return false;
    }

    $arr = mysqli_fetch_assoc($res);

    mysqli_free_result($res);

    if ($arr['password'] !== md5($password)) {
        return false;
    }

    return [$arr['user_id'], $arr['role']];
}

function db_user_exists($user_id) {
    global $CONN;
    $res = mysqli_query($CONN, "SELECT COUNT(*) FROM user WHERE user_id = '$user_id'");
    if (!$res) {
        return false;
    }

    $arr = mysqli_fetch_array($res);

    if ($arr && $arr[0] == 1)
        return true;
    return false;
}

function db_user_username_exists($username) {
    global $CONN;
    $res = mysqli_query($CONN, "SELECT COUNT(*) FROM user WHERE username = '$username'");
    if (!$res) {
        return false;
    }

    $arr = mysqli_fetch_array($res);

    if ($arr && $arr[0] == 1)
        return true;
    return false;
}

function db_user_create($username, $password, $role) {
    global $CONN;
    $pwd = md5($password);
    $res = mysqli_query($CONN, "INSERT INTO user(username, password, role) VALUE ('$username', '$pwd', '$role')");
    if (!$res) {
        return false;
    }

    return true;
}

function db_item_exists($itemcode) {
    global $CONN;
    $res = mysqli_query($CONN, "SELECT COUNT(*) FROM item WHERE itemcode = '$itemcode'");
    if (!$res) {
        return false;
    }

    $arr = mysqli_fetch_array($res);

    if ($arr && $arr[0] == 1)
        return true;
    return false;
}

function db_item_create($itemcode, $itemname, $price, $seller) {
    global $CONN;

    $res = mysqli_query($CONN, "INSERT INTO item(itemcode, itemname, price, seller) VALUE ('$itemcode', '$itemname', '$price', '$seller')");
    if (!$res) {
        return false;
    }

    return true;
}

function db_seller_get_items($seller) {
    global $CONN;

    $res = mysqli_query($CONN, "SELECT itemcode, itemname, price FROM item WHERE seller = '$seller'");
    if (!$res) {
        return [];
    }

    $items = [];

    while ($row = mysqli_fetch_assoc($res)) {
        array_push($items, $row);
    }

    return $items;
}

function db_get_all_items() {
    global $CONN;

    $res = mysqli_query($CONN, "SELECT itemcode, itemname, price, seller FROM item");
    if (!$res) {
        return [];
    }

    $items = [];

    while ($row = mysqli_fetch_assoc($res)) {
        array_push($items, $row);
    }

    return $items;
}

function db_add_item_to_cart($buyer, $itemcode, $seller) {
    global $CONN;

    $res = mysqli_query($CONN, "SELECT COUNT(*) FROM cart WHERE buyer_id = '$buyer' AND seller_id = '$seller' AND itemcode = '$itemcode'");
    if (!$res) {
        return false;
    }

    $arr = mysqli_fetch_array($res);

    if ($arr && $arr[0] == 1)
        return false;
    
    $res = mysqli_query($CONN, "INSERT INTO cart(buyer_id, itemcode, seller_id) VALUES ('$buyer', '$itemcode', '$seller')");
    if (!$res) {
        return false;
    }

    return true;
}

function db_seller_get_bought_items($seller) {
    global $CONN;

    $res = mysqli_query($CONN, "SELECT itemcode, buyer_id FROM cart WHERE seller_id = '$seller'");
    if (!$res) {
        return false;
    }

    $items = [];

    while ($row = mysqli_fetch_assoc($res)) {
        array_push($items, $row);
    }

    return $items;
}

function db_buyer_get_cart_items($buyer) {
    global $CONN;

    $res = mysqli_query($CONN, "SELECT itemcode, seller_id FROM cart WHERE buyer_id = '$buyer'");
    if (!$res) {
        return false;
    }

    $items = [];

    while ($row = mysqli_fetch_assoc($res)) {
        array_push($items, $row);
    }

    return $items;
}