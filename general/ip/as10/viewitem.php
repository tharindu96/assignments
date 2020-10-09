<?php

require 'init.php';

only_logged_in('any', $ROOT);

function handle_post_request() {
    global $ROOT;
    global $CONN;

    if (!isset($_POST['itemcode'])) {
        return;
    }

    $itemcode = mysqli_real_escape_string($CONN, trim($_POST['itemcode']));
    $seller = mysqli_real_escape_string($CONN, trim($_POST['seller']));

    $buyer = $_SESSION['user_id'];
    if ($_SESSION['user_role'] === 'seller')
        return;

    db_add_item_to_cart($buyer, $itemcode, $seller);
    
}

handle_post_request();

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>View Items</title>
</head>
<body>
    <h1>View Items</h1>

    <p><a href="logout.php">Sign Out</a></p>
    <? if ($_SESSION['user_role'] === 'seller') { ?>
    <p><a href="additem.php">Add Item</a></p>
    <? } ?>
    <p><a href="profile.php">Profile</a></p>

    <? if ($_SESSION['user_role'] === 'seller') {
        $ITEMS = db_seller_get_items($_SESSION['user_id']);   
    ?>
    <table border="1">
        <thead>
            <tr>
                <th>Item Code</th>
                <th>Item Name</th>
                <th>Price</th>
            </tr>
        </thead>
        <tbody>
            <?php
            if (count($ITEMS) == 0) {
                ?>
                <tr><td colspan="3">No Items.</td></tr>
                <?php
            } else {
                foreach($ITEMS as $item) {
                    ?>
                    <tr>
                        <td><? echo $item['itemcode']; ?></td>
                        <td><? echo $item['itemname']; ?></td>
                        <td><? echo $item['price']; ?></td>
                    </tr>   
                    <?php
                }
            }
            ?>
        </tbody>
    </table>
    <? } else if ($_SESSION['user_role'] === 'buyer') {
        $ITEMS = db_get_all_items();    
    ?>
    <table border="1">
        <thead>
            <tr>
                <th>Item Code</th>
                <th>Item Name</th>
                <th>Price</th>
                <th>Seller</th>
            </tr>
        </thead>
        <tbody>
            <?php
            if (count($ITEMS) == 0) {
                ?>
                <tr><td colspan="3">No Items.</td></tr>
                <?php
            } else {
                foreach($ITEMS as $item) {
                    ?>
                    <tr>
                        <td><? echo $item['itemcode']; ?></td>
                        <td><? echo $item['itemname']; ?></td>
                        <td><? echo $item['price']; ?></td>
                        <td><? echo $item['seller']; ?></td>
                        <td>
                            <form action="" method="post">
                                <input type="hidden" name="itemcode" value="<? echo $item['itemcode']; ?>">
                                <input type="hidden" name="seller" value="<? echo $item['seller']; ?>">
                                <input type="submit" value="Buy">
                            </form>
                        </td>
                    </tr>   
                    <?php
                }
            }
            ?>
        </tbody>
    </table>
    <? } ?>
</body>
</html>