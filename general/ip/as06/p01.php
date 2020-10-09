<?php
if(isset($_GET["name"])) {
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Result</title>
</head>
<body>
    <h1>Result</h1>

    <div>Name: <?php echo $_GET["name"]; ?></div>
    <div>Phone: <?php echo $_GET["phone"]; ?></div>
    <div>Sex: <?php echo ucfirst($_GET["sex"]); ?></div>
    <div>Address: <?php echo $_GET["address"]; ?></div>
</body>
</html>
<?php
} else {
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
    <style type="text/css">
        .form-line {
            display: block;
            margin: 5px 0px;
        }
        .form-label {
            width: 80px;
            display: inline-block;
            vertical-align: top;
        }
    </style>
</head>
<body>
    <div>
        <form method="get">
            <div class="form-line">
                <label class="form-label" for="name">Name</label>
                <input type="text" name="name" id="name">
            </div>
            <div class="form-line">
                <label class="form-label" for="phone">Phone</label>
                <input type="text" name="phone" id="phone">
            </div>
            <div class="form-line">
                <label class="form-label" for="name">Sex</label>
                <input type="radio" name="sex" value="male" id="sexMale"><label for="sexMale"> Male</label>
                <input type="radio" name="sex" value="female" id="sexFemale"><label for="sexFemale"> Female</label>
            </div>
            <div class="form-line">
                <label class="form-label" for="address">Address</label>
                <textarea name="address" id="address" cols="30" rows="5"></textarea>
            </div>
            <div class="form-line">
                <input type="submit" value="Register">
            </div>
        </form>
    </div>    
</body>
</html>
<?php
}
?>