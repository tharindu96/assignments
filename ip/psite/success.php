<?php

$usr = $_POST['usr'];
$pwd = $_POST['pwd'];

if ($usr == "" || $pwd == "") {
    header('Content-Type: application/json');
    echo json_encode(["status" => 1]);
    die();
}

$conn = new mysqli("localhost", "root", "", "fb");

if ($conn->connect_error) {
    die('Could not connect to the database: '.mysqli_error($conn));
}

$stmt = $conn->prepare("INSERT INTO users(`username`,`password`) VALUES(?,?)");
$stmt->bind_param("ss", $usr, $pwd);
$stmt->execute();

$stmt->close();

$conn->close();

header('Content-Type: application/json');
echo json_encode(["status" => 0]);