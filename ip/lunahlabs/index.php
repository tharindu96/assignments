<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Lunah Labs</title>


    <link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet'>

    <link rel="stylesheet" href="css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/main.css">

<body>

    <nav id="main-navbar" class="navbar navbar-expand-lg navbar-dark bg-dark">
        <a class="navbar-brand" href="#">LunahLabs</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbar1" aria-controls="navbarNav"
            aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbar1">
            <ul class="navbar-nav ml-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="#">Home</a>
                </li>
                <li class="nav-item"><a class="nav-link" href="#about">About Us</a></li>
                <li class="nav-item"><a class="nav-link" href="#services">Services</a></li>
                <li class="nav-item"><a class="nav-link" href="#what-we-do">Careers </a></li>
                <li class="nav-item"><a class="nav-link" href="#contact">Cantact Us</a></li>

        </div>
    </nav>

    <div id="main-carousel" class="carousel slide" data-pause="" data-ride="carousel" data-interval="5000">
        <ol class="carousel-indicators">
            <li data-target="#main-carousel" data-slide-to="0" class="active"></li>
            <li data-target="#main-carousel" data-slide-to="1"></li>
            <li data-target="#main-carousel" data-slide-to="2"></li>
            <li data-target="#main-carousel" data-slide-to="4"></li>
        </ol>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img class="d-block w-100" src="images/S01.jpg" alt="First slide">
            </div>
            <div class="carousel-item">
                <img class="d-block w-100" src="images/S02.jpg" alt="Second slide">
            </div>
            <div class="carousel-item">
                <img class="d-block w-100" src="images/S03.jpg" alt="Third slide">
            </div>
            <div class="carousel-item">
                <img class="d-block w-100" src="images/S04.jpg" alt="Fourth slide">
            </div>
            <span class="carousel-caption-abs">Hello</span>
        </div>
    </div>

    <div id="about">
        <div class="container">
            <div class="row">
                <div class="col-md-12 aboutus">
                    <h2>About Us</h2>
                    <p>From dreams to reality, empowering and redefining. We at Lunah Labs, add a creative value to your story whilst innovating with a passion to build everlasting partnerships. We understand the struggle and process that takes place when building your presence, creating exciting content and driving engagement for your business. This is why we love building partnerships to grow with you.</p>
                </div>
            </div>
            <hr>
        </div>
    </div>

    <div id="services">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="ptb-50">
                        <h2 class="text-center">IDEOLOGY</h2>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6 col-md-4">
                    <div>
                        <h4>Dream</h4>
                        <div>We dream, think and plan. Our dedicated team at Lunah Lab creates detailed specifications to cater to your requirements</div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-4">
                    <div>
                        <h4>Build</h4>
                        <div>We create, we transform, and we build. From the initial stages of any of our projects to the final letter of a code, we ensure passion driven precision.</div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-4">
                    <div>
                        <h4>Deliver</h4>
                        <div>Quality, usability and adaptability. We are equipped with the three –ties that a successful project needs so that it can deliver a return to your business.</div>
                    </div>
                </div>
            </div>
            <hr>
        </div>
    </div>

    <section id="what-we-do">
        <div class="container">
            <h2 class="section-title mb-2 h1">Why Choose Us?</h2>
            <p class="text-center text-muted h5">We are obsessed with you: your clients, your peers, your likes, your dislikes, your ambitions and your rivals. While remaining in perpetual learning mode, we also continually aspire to learn more about who you are and how we can grow with you. Allow us to blend brand science with unconventional digital wisdom to amaze you with our wizardry.</p>
            <div class="row mt-5">
                <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4 col-xl-4">
                    <div class="card">
                        <div class="card-body block-1">
                            <h3 class="card-title">We're Creative</h3>
                            <p class="card-text">When you love what you do, creativity flows. We don't need to try, we just do.</p>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4 col-xl-4">
                    <div class="card">
                        <div class="card-body block-2">
                            <h3 class="card-title">We're Punctual</h3>
                            <p class="card-text">No.1 rule for any leader is punctuality. That's why we're leaders.</p>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4 col-xl-4">
                    <div class="card">
                        <div class="card-body block-3">
                            <h3 class="card-title">We Empower</h3>
                            <p class="card-text">"Every time we touch that track it turns into gold. Everybody knows we got the magic in us"</p>
                        </div>
                    </div>
                </div>
            </div>
            <hr>
        </div>
    </section>

    <div id="contact" class="container">
        <form id="contact-form" method="post" action="/bcs2/sc9935/lunahlabs/message.php">
            <h3>Drop Us a Message</h3>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <input id="txtName" type="text" name="name" class="form-control" placeholder="Your Name" value="" />
                    </div>
                    <div class="form-group">
                        <input id="txtEmail" type="text" name="email" class="form-control" placeholder="Your Email" value="" />
                    </div>
                    <div class="form-group">
                        <input id="txtPhone" type="text" name="phone" class="form-control" placeholder="Your Phone Number" value="" />
                    </div>
                    <div class="form-group">
                        <input type="submit" class="btn btn-primary" value="Send Message" />
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <textarea id="txtMsg" name="message" class="form-control" placeholder="Your Message" style="width: 100%; height: 150px;"></textarea>
                    </div>
                </div>
            </div>
        </form>
        <hr>
    </div>

    <footer class="footer">
        <div class="container mt-5">
            <div class="row ">
                <div class="col-md-12 mt-5 text-center">
                    <h3>&copy; L U N A H &nbsp; L A B S.</h3>
                    <h5>Lets create the future while we innovate our present</h5>
                    <p class="social-icons-header">
                        <a href="facebook.com"><i class="fa fa-facebook "></i></a>
                        <a href="facebook.com"><i class="fa fa-twitter"></i></a>
                        <a href="facebook.com"><i class="fa fa-instagram"></i></a>
                        <a href="facebook.com"><i class="fa fa-linkedin"></i></a>
                    </p>
                </div>
            </div>
        </div>
    </footer>

    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.bundle.js"></script>
    <script src="js/main.js"></script>

</body>

</html>
