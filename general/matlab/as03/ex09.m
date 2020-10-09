X = linspace(0, 10, 1000);
Y = X/2;
Z = sin(X) + cos(Y);

stem3(X, Y, Z);

xlabel('X');
ylabel('Y = X/2');
zlabel('Z = sin(X) + cos(Y)');