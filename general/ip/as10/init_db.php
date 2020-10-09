<?php

$conn = mysqli_connect("localhost", "root", "");
if (!$conn) {
    echo "DB Error: " . mysqli_error($conn);
    die();
}

$res = mysqli_query($conn, "DROP DATABASE IF EXISTS emarket");
if (!$res) {
    echo "DB Error: " . mysqli_error($conn);
    die();
}

$res = mysqli_query($conn, "CREATE DATABASE emarket");
if (!$res) {
    echo "DB Error: " . mysqli_error($conn);
    die();
}

if (!mysqli_select_db($conn, "emarket")) {
    echo "DB Error: " . mysqli_error($conn);
    die();
}

$res = mysqli_query($conn, "CREATE TABLE IF NOT EXISTS item(
    itemcode VARCHAR(255) PRIMARY KEY,
    itemname VARCHAR(255) NOT NULL,
    price INT NOT NULL,
    seller INT NOT NULL
)");

if (!$res) {
    echo "DB Error: " . mysqli_error($conn);
    die();
}

$res = mysqli_query($conn, "CREATE TABLE IF NOT EXISTS user(
    user_id INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(255) UNIQUE NOT NULL,
    password VARCHAR(32) NOT NULL,
    role ENUM('buyer', 'seller') NOT NULL
)");

if (!$res) {
    echo "DB Error: " . mysqli_error($conn);
    die();
}

$res = mysqli_query($conn, "CREATE TABLE IF NOT EXISTS cart(
    buyer_id INT NOT NULL,
    itemcode VARCHAR(255) NOT NULL,
    seller_id INT NOT NULL,
    PRIMARY KEY (buyer_id, itemcode, seller_id),
    FOREIGN KEY (itemcode) REFERENCES item(itemcode),
    FOREIGN KEY (seller_id) REFERENCES user(user_id)
)");

if (!$res) {
    echo "DB Error: " . mysqli_error($conn);
    die();
}

$pwd1 = md5("buyer123");
$pwd2 = md5("seller123");
$res = mysqli_query($conn, "INSERT INTO user(username, password, role) VALUES ('buyer', '$pwd1', 'buyer'), ('seller', '$pwd2', 'seller')");
if (!$res) {
    echo "DB Error: " . mysqli_error($conn);
    die();
}

mysqli_close($conn);