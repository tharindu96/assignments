t = linspace(0, 10*pi, 1000);
z = t;
x = sin(t);
y = cos(t);
plot3(x, y, z);
xlabel('sin(t)');
ylabel('cos(t)');
zlabel('t');