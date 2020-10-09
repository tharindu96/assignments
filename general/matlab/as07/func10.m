function t  = func10(n)
%FUNC10 Returns values

t = 0;
v = 1;

while v <= n
    t = t + 1;
    v = v * (2 * t - 1);
end

end

