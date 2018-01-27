nums = [];

for i=1:10
    x = input('Enter a number: ');
    nums = [nums, x];
end

total = sum(nums);
average = total / length(nums);

fprintf('Total: %.2f\nAverage: %.2f\n', total, average);

pause;