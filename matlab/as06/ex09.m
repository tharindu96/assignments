I = imread('ex_01.jpg');
%I = rgb2gray(I);
I = im2bw(I);

S = strel ('disk', 5);

D = imdilate(I, S);

imshowpair(D, I, 'montage');