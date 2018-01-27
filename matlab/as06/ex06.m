I1 = imread('ex_06.jpg');
I2 = imread('ex_03.gif');

I1 = rgb2gray(I1);
I2 = rgb2gray(I2);

I2 = imresize(I2, size(I1));

I3 = I2 - I1;

imshow(I3);