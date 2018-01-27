function f = func13(a)
%FUNC13 Summary of this function goes here
%   Detailed explanation goes here

p = sqrt((a - 2).^2)./pi;
q = sin((10*pi).*a);

f = p .* q;

end

