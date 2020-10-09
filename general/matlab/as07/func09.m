function y = func09(n)
%FUNC05 Returns the value

if n == 0
    y = 0;
else
    t = 0:n-1;
    t = 1 + ((0.2) .* t);
    y = prod(t);
end


end

