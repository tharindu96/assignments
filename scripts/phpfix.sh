#!/bin/bash

if [[ $# -lt 1 ]]
then
    echo "must provide the php.ini file"
    exit 1
fi

PHPINI=$1

sudo cp $PHPINI $PHPINI.backup

sudo sed -i -e 's/^error_reporting = .*/error_reporting = E_ALL/' $PHPINI
sudo sed -i -e 's/^display_errors = .*/display_errors = On/' $PHPINI

sudo systemctl restart apache2
