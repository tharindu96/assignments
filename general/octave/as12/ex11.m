
n = input("Enter the number of numbers: ");

A = zeros(n, 1);

while(n > 0)

  s = input("Enter a number: ");
  
  A(n, 1) = s;

  n -= 1;
end

avg = sum(A)/size(A, 1);

fprintf("Average: %.2f\n", avg);