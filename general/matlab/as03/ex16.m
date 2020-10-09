f1=inline('3.5*sin(t/2)');
f2=inline('3.5*cos(t/2)');
f3=inline('1.2*t');

t = [0:0.1:20];
x = f1(t);
y = f2(t);
z = f3(t);
figure;
plot3(x, y, z);