[x, y] = meshgrid(0:0.1:10);

z = (x + y)^2;

a = figure;
mesh(x, y, z);

b = figure;
surface(x, y, z);