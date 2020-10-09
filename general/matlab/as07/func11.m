function func11(N)
%FUNC11 

for i = 1:N
   if mod(i, 2) == 0
       fprintf('%d is divisible by 2\n', i);
   elseif mod(i, 3) == 0
       fprintf('%d is divisible by 3\n', i);
   elseif mod(i, 3) == 0 && mod(i, 2) == 0
       fprintf('%d is divisible by 2 and 3\n', i);
   else
       fprintf('%d is not divisible by 2 or 3\n', i);
   end
end


end

