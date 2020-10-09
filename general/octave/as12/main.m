
clear;

## Question 1

a1 = log10(100)/log10(10);

a2 = floor((1 + tan(1.2)) / 1.2);

a3 = sqrt(3^2 + 4^2);


## Question 2

A = [-5 2 3 4;
      5 6 7 8;
      9 10 11 12;
      7 0 5 4];
      
a = A(:, 3);

b = A(:, [2 3]);

c = A(4, :);

## Question 3

x = -4:0.01:9;

y = (x.^2) .* cos(x);

plot(x, y);
xlabel('x');
ylabel('x^2cos(x)');

## Question 4

x = 0:0.1:10;

y = sin(x)./x;
u = (1./((x-1).^2)).+x;
v = (x.^2+1)./(x.^2-4);
w = ((10-x).^(1/3)-2)./(4-x.^2).^(1/2);

subplot(2, 2, 1);
plot(x, y);
xlabel('x');
ylabel('sin(x)/x)');

subplot(2, 2, 2);
plot(x, u);
xlabel('x');
ylabel('(1/(x-1)^2)+x');

subplot(2, 2, 3);
plot(x, v);
xlabel('x');
ylabel('(x^2+1)/(x^2-4)');

subplot(2, 2, 4);
plot(x, w);
xlabel('x');
ylabel('((10-x)^(1/3)-2)/((4-x^2)^(1/2))');

## Question 5

clf;

x = -2:0.1:2;
y = (-2:0.1:2)';
z = -x*y*exp(-2*(x.^2 + y.^2));

surf(x, y, z);

## Question 7

area = areaOfTriangle(24, 30, 18);

## Question 8

#fid = fopen("data.txt", 'r');

#x = fread(fid, '2*char=>char');

#disp(x);

#fclose(fid);

## Question 9

x = -1:.05:1;
y = sin(3*pi*x).*exp(-x.^2);
plot(x, y, ':');
k = find(y > 0.2);