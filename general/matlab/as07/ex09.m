n = 100;

p = 1:n;

Y = zeros(n)';

for i = p
    y = func09(i);
    Y(i) = y;
end

disp(Y)