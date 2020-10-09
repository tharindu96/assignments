
s = 0;
n = 0;
while s < 1000
    s = 0;
    n = n + 1;
    for i=1:n
        s = s + i;
    end
end

disp(n);