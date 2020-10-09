clear;
[X, Y] = meshgrid(-25:0.2:25);
R = abs(sqrt((2.*X).^2 + Y.^2));
Z = R.^2 .* sin(R);

surface(X, Y, Z);