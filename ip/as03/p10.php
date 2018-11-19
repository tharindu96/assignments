<?php

$books = [
    [
        "type" => "Comic",
        "title" => "Superman",
        "author" => "Jerry Siegel and Joe Shuster",
        "pubdate" => 1938
    ],
    [
        "type" => "Science Fiction",
        "title" => "Dune",
        "author" => "Frank Herbert",
        "pubdate" => 1965
    ],
    [
        "type" => "Fantasy",
        "title" => "The Hobbit",
        "author" => "Jerry Siegel and Joe Shuster",
        "pubdate" => 1938
    ],
    [
        "type" => "Horror",
        "title" => "Carrie",
        "author" => "Stephen King",
        "pubdate" => 1974
    ]
];

$types = [

];

foreach($books as $row) {
    $types[$row["type"]] = 1;
}

foreach($types as $type => $d) {
    echo "Type: " . $type . "<br>";
    echo "-------------------------<br>";
    foreach($books as $row) {
        if ($row["type"] == $type) {
            echo "Title: " . $row["title"] . "<br>";
            echo "Author: " . $row["author"] . "<br>";
            echo "Publication Date: " . $row["pubdate"] . "<br>";
            echo "<br>";
        }
    }
    echo "-------------------------<br>";
}
