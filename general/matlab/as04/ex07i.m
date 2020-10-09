m = input('Enter marks of the student: ');

g = 'E';

if m > 84
    g = 'A+';
elseif m >= 70
    g = 'A';
elseif m >= 65
    g = 'A-';
elseif m >= 60
    g = 'B+';
elseif m >= 55
    g = 'B';
elseif m >= 50
    g = 'B-';
elseif m >= 45
    g = 'C+';
elseif m >= 40
    g = 'C';
elseif m >= 35
    g = 'C-';
elseif m >= 30
    g = 'D+';
elseif m >= 25
    g = 'D';
end

fprintf('Grade: %s\n', g);