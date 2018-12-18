<?php
$UNIT_PRICE = 45;

$SHOW = false;
$TOTAL = 0;
$AMOUNT = 0;

if (isset($_GET["amount"])) {
    $a = $_GET["amount"];
    $AMOUNT = (int)$a;
    $SHOW = true;
    $TOTAL = $UNIT_PRICE * $AMOUNT;
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
</head>
<body>
    <form method="get">
        <?php
        if ($SHOW) {
        ?>
        <p>Order Processed on: <?php echo date("d/m/Y"); ?></p>
        <?php
        }
        ?>
        <div>
            <label for="amount">Amount</label>
            <input type="text" name="amount" id="amount" value="<?php echo $AMOUNT; ?>">
        </div>
        <p>Unit Price: Rs. <?php echo $UNIT_PRICE; ?></p>
        <?php
        if (!$SHOW) {
        ?>
        <input type="submit" value="order">
        <input type="button" value="clear">
        <?php
        } else {
        ?>
        <div>
            <label for="total_price">Total Price</label>
            <input type="text" id="total_price" readonly="true" value="<?php echo $TOTAL; ?>">
        </div>
        <?php
        }
        ?>
    </form>
</body>
</html>