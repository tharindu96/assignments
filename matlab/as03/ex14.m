clear;

[x, y, z] = sphere(500);
surf(x, y, z);
xlabel('x');
ylabel('y');
zlabel('z');
shading interp
colormap 'hsv'

light('Position',[0.8 0 0.5])

light('Position',[-1 0 0])