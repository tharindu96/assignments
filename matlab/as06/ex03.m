I = imread('ex_03.gif');

IG = rgb2gray(I);

TG = imnoise(IG,'salt & pepper', 0.1);

KG = medfilt2(TG);

imshowpair(TG,KG,'montage')
