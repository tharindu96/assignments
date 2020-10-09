I = imread('ex_07.jpg');
IG = rgb2gray(I);

h = ones(5, 5) / 25;

IJ = imfilter(IG, h);

imshow(IJ);