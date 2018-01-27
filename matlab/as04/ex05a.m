m = input('Enter number of the month: ');

d = 30;

if m < 1 || m > 12
    fprintf('Enter a valid month\n');
end

if ismember(m, [1 3 5 7 8 10 12]) == 1
    d = 31;
elseif m == 2
    d = 28;
end

fprintf('The month has %d days\n', d);

pause