p = [0:pi/60:8*pi];
A = 2;
x = A*cos(p/2);
y = A*sin(p/2);
z = (1 + 0.2 * cos(2*pi)) .* p;

comet3(x, y, z);