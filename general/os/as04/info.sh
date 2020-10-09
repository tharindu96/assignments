# print user information who is currently logged in, current date & time
clear
d=$(date)
cl=$(who | wc -l)
echo "Hello $USER"
echo "I am $HOSTNAME"
echo "Today is $d"
echo "Number of users currently logged in: $cl"
echo "Calendar"
cal
date +"%A, %B %d, %Y"
exit
