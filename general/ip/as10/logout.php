<?php
require 'init.php';

only_logged_in($ROOT);

unset_user_session();

header("Location: $ROOT");