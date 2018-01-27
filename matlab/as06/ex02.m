I = imread('ex_02.JPG');

IG = rgb2gray(I);

IB1 = im2bw(IG, 0.25);
IB2 = im2bw(IG, 0.5);
IB3 = im2bw(IG, 0.75);
IB4 = im2bw(IG, 0.9);

subplot(2, 2, 1), subimage(IB1), title('0.25');
subplot(2, 2, 2), subimage(IB2), title('0.5');
subplot(2, 2, 3), subimage(IB3), title('0.75');
subplot(2, 2, 4), subimage(IB4), title('0.9');