I = imread('ex_10.jpg');
I = rgb2gray(I);

BW = im2bw(I);

S = strel('disk', 15);

D = imdilate(BW, S);

T = D - BW;

imshow(T);