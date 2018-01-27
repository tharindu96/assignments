
curr = input('Enter current balance: ');

i = 5;
if curr >= 5000 && curr < 10000
    i = 6;
elseif curr >= 10000
    i = 7;
end

newbalance = curr * (i / 100) + curr;

fprintf('New Balance: Rs. %.2f\n', newbalance);