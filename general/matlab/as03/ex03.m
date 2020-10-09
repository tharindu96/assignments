n=100;
t=linspace(0,6*pi,n);

y1 = sin(t);
y2 = cos(t);

subplot(2, 2, 1);
plot3(y1, y2, t);
title('XYZ view');

subplot(2, 2, 2);
plot3(y1, y2, t);
title('XY view');
view([0 0 1]);

subplot(2, 2, 3);
plot3(y1, y2, t);
title('XZ view');
view([0 1 0]);

subplot(2, 2, 4);
plot3(y1, y2, t);
title('YZ view');
view([1 0 0]);