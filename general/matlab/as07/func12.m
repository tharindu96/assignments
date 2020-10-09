function func12
%FUNC12: Marks a spot on a simple graph
p=[1 2 3];
q=[1 2 3];
plot(p,q);
hold on
disp('Click on the point where you want to plot an x')
[x, y]=ginput(1); %Gives x and y coordinates to point
plot(x,y,'Xk')
end