I = imread('ex_08.jpg');
I = rgb2gray(I);

[~, threshold] = edge(I, 'sobel');
fudgeFactor = .7;
Isobel = edge(I,'sobel', threshold * fudgeFactor);


[~, threshold] = edge(I, 'canny');
fudgeFactor = .7;
Icanny = edge(I,'canny', threshold * fudgeFactor);

subplot(1, 3, 1);
subimage(I);

subplot(1, 3, 2);
subimage(Isobel);

subplot(1, 3, 3);
subimage(Icanny);
