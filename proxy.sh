#!/bin/sh

FILE="/etc/apt/apt.conf.d/98proxy"

cat $FILE <<EOF
Acquire::http::Proxy "http://192.248.48.9:3128";
Acquire::https::Proxy "http://192.248.48.9:3128";
EOF
