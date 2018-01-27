M = zeros(1, 5);

for i=1:5
    m1 = input('Enter marks of the student: ');
    M(i) = m1;
end

for i=1:5
    g = 'E';
    m = M(i);
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

    fprintf('Student %d Grade: %s\n', i, g);
end