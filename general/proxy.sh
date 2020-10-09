#!/bin/sh

FILE="/etc/apt/apt.conf.d/98proxy"

echo "Acquire::http::Proxy \"http://192.248.48.9:3128\";\nAcquire::https::Proxy \"http://192.248.48.9:3128\";" > $FILE
