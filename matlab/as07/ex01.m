a = input('a: ');
b = input('b: ');
c = input('c: ');

denom = 2 * a;
discriminant = 4 * a * c;
rootdis = sqrt(b^2 - discriminant);

x1 = (-b + rootdis) / denom;
x2 = (-b - rootdis) / denom;

x = [x1, x2];

disp('solutions are: ');
disp(x);