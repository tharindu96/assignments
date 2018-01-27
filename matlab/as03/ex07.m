% [x, y, z] = peaks;

% pcolor(x, y, z);
% mesh(x, y, z);
% surf(x, y, z);
% contour3(x, y, z);
% waterfall(x, y, z);

% shading flat
% shading interp
% shading faceted

[x, y, z] = peaks(30);

a = figure;
hold on;
mesh(x,y,z);
contour3(x,y,z)
waterfall(x,y,z);
hold off;

b = figure;
hold on;
pcolor(x, y, z);
colormap(b, 'bone');
[c, h] = contour(x, y, z);
clabel(c, h);
hold off;