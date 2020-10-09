function quadratic(a,b,c)
%quadratic finds the roots of a quadratic equation.
discriminant = 4*a*c;
denom = 2*a;
rootdis = sqrt(b^2 - discriminant);
x1 = (-b + rootdis)/denom;
x2 = (-b - rootdis)/denom;
x = [x1, x2];
disp('Solution are: ')
disp(x)
end