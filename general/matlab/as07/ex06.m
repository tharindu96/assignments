x = input('Enter a number: ');
o = isodd(x);

if o == 1
    fprintf('%.2f is odd\n', x);
else
    fprintf('%.2f is even\n', x);
end