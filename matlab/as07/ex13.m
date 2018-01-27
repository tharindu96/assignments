x = linspace(-2*pi, 2*pi, 100);

f = func13(x);

T = table(x(:), f(:));
T.Properties.VariableNames = {'x','f'};

disp(T);