I = imread('ex_01.jpg');

IG = rgb2gray(I);

h = imhist(IG);

IJ = histeq(IG, h);

hq = imhist(IJ);

IJ = imadjust(IJ, stretchlim(IJ), []);

hd = imhist(IJ);

subplot(1, 3, 1);
plot(h);

subplot(1, 3, 2);
plot(hq);

subplot(1, 3, 3);
plot(hd);

figure

imshow(IJ);