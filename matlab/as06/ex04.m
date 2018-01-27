I = imread('ex_01.jpg');

IG = rgb2gray(I);

imhist(IG);

%J = imadjust(IG, stretchlim(IG), []);

%imshow(J);