t = 0:pi/100:2*pi;
x = cos(t);
y = sin(t);
h1=plot(x,y,'r');
set(h1,'LineWidth',3.25);
xlabel('x');
h = get(gca,'xlabel');
set(h,'FontSize',12)
ylabel('y')
h = get(gca,'ylabel');
set(h,'FontSize',12)
title('Graph of Ellipse')
h = get(gca,'Title');
set(h,'FontSize',14)