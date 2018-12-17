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
$PAGE=1;
if (isset($_REQUEST["page"])) {
    $PAGE = (int)$_REQUEST["page"];
}

showNavigation();

switch($PAGE) {
    case 1:
        showPage1();
    break;
    case 2:
        showPage2();
    break;
    case 3:
        showPage3();
    break;
    default:
        showPageNotFound();
}

function showPage1() {
?>
<h1>Introdution</h1>
<?php
}

function showPage2() {
?>
<h1>Arrays</h1>
<?php
}

function showPage3() {
?>
<h1>Summary</h1>
<?php
}

function showNavigation() {
?>
<header>
    <nav>
        <ul>
            <li><a href="?page=1">Introduction</a></li>
            <li><a href="?page=2">Arrays</a></li>
            <li><a href="?page=3">Summary</a></li>
        </ul>
    </nav>
</header>
<?php
}

function showPageNotFound() {
    echo "<h1>Page Not Found!</h1>";
}

?>

</body>
</html>