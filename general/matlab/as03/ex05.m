[X, Y] = meshgrid(-1:.01:1);
Z = Y.^2 - X.^2;
figure;
mesh(Z);