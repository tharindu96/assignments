<?php

$host = 'localhost';
$db   = 'lunahlabs';
$user = 'root';
$pass = '';
$charset = 'utf8mb4';

$options = [
    PDO::ATTR_ERRMODE            => PDO::ERRMODE_EXCEPTION,
    PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
    PDO::ATTR_EMULATE_PREPARES   => false,
];
$dsn = "mysql:host=$host;dbname=$db;charset=$charset";

header('Content-Type: application/json');

if(!array_key_exists("name", $_POST) || !array_key_exists("email", $_POST) || !array_key_exists("phone", $_POST) || !array_key_exists("msg", $_POST)) {
    echo json_encode(["status" => 1]);
    return;
}

$name = $_POST['name'];
$email = $_POST['email'];
$phone = $_POST['phone'];
$message = $_POST['msg'];

try {
    $pdo = new PDO($dsn, $user, $pass, $options);

    $sql = "INSERT INTO messages (name, email, phone, message) VALUES (?,?,?,?)";
    $stmt= $pdo->prepare($sql);
    $stmt->execute([$name, $email, $phone, $message]);

    echo json_encode(["status" => 0]);

} catch (\PDOException $e) {
    throw new \PDOException($e->getMessage(), (int)$e->getCode());
}
