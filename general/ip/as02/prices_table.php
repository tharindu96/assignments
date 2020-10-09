<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
    <!-- <style type="text/css">
    th {
        border: 1px solid #333;
    }
    </style> -->
</head>
<body>
    <table border="1">
        <thead>
            <tr>
                <th>Quantity</th>
                <th>Price(Rs)</th>
            </tr>
        </thead>
        <tbody>
            <?php
                $pen_price = 1000;
                $i = 1;
                while ($i <= 50) {
                    if ($i % 10 != 0) {
                        $i++;
                        continue;
                    }
                echo "<tr>
                    <td>$i</td>
                    <td>".($pen_price * $i)."</td>
                </tr>";
                    $i++;
                }
                // for ($i = 1; $i <= 50; $i++) {
                //     if ($i % 10 != 0) continue;
                // echo "<tr>
                //     <td>$i</td>
                //     <td>".($pen_price * $i)."</td>
                // </tr>";
                // }
            ?>
        </tbody>
    </table>
</body>
</html>