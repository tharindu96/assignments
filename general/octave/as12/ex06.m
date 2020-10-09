clear;

i = 2;

vs = 0;

do

  v = 1:i;
  vs = sum(v.^2);
  
  disp(v);
  disp(vs);
  
  if(vs >= 100) 
    break;
  endif
  
  i += 1;
  
until(vs >= 100)

fprintf("greatest sum of squares less than 100 is: %d\n", i-1);

