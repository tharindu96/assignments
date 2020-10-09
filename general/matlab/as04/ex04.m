prices = [ 50.60 40.50 90 20.30 ];
count = [ 3 2 1 5 ];

total = sum(prices .* count);

fprintf('Total Price: %.2f\n', total);