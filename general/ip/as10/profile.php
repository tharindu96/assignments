<?php
require 'init.php';

only_logged_in('any', $ROOT);


?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Profile</title>
</head>
<body>
    <h1>Profile</h1>

    <p><a href="logout.php">Sign Out</a></p>
    <p><a href="viewitem.php">View Item</a></p>

    <?
    if ($_SESSION['user_role'] === 'seller') {
        $ITEMS = db_seller_get_bought_items($_SESSION['user_id']);
    ?>
    <table border="1">
        <thead>
            <tr>
                <th>Buyer ID</th>
                <th>Item Code</th>
            </tr>
        </thead>
        <tbody>
            <?php
            if (count($ITEMS) == 0) {
                ?>
                <tr><td colspan="2">No Items Bought.</td></tr>
                <?php
            } else {
                foreach($ITEMS as $item) {
                    ?>
                    <tr>
                        <td><? echo $item['buyer_id']; ?></td>
                        <td><? echo $item['itemcode']; ?></td>
                    </tr>   
                    <?php
                }
            }
            ?>
        </tbody>
    </table>
    <?
    } else if ($_SESSION['user_role'] === 'buyer') {
        $ITEMS = db_buyer_get_cart_items($_SESSION['user_id']);
    ?>
    <table border="1">
        <thead>
            <tr>
                <th>Seller ID</th>
                <th>Item Code</th>
            </tr>
        </thead>
        <tbody>
            <?php
            if (count($ITEMS) == 0) {
                ?>
                <tr><td colspan="2">No Items in Cart.</td></tr>
                <?php
            } else {
                foreach($ITEMS as $item) {
                    ?>
                    <tr>
                        <td><? echo $item['seller_id']; ?></td>
                        <td><? echo $item['itemcode']; ?></td>
                    </tr>   
                    <?php
                }
            }
            ?>
        </tbody>
    </table>
    <?
    }
    ?>
</body>
</html>