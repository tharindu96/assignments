
n = input("Enter the number of scores: ");

A = zeros(n, 1);

while(n > 0)

  s = input("Enter the score: ");
  
  A(n, 1) = s;

  n -= 1;
end

[S, i] = sort(A);

disp("Higest 2 Scores are: ");
disp(S([end, end-1], 1));