I = imread('ex_01.jpg');

imshow(I), colorbar;

% I

whos I

I2 = I(50:201, 50:201, :);

imshow(I2), colorbar;

% imsave

figure;
subplot(1, 2, 1), subimage(I);
subplot(1, 2, 2), subimage(I2);