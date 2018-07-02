#include <stdio.h>

int main() {
	int a, b, c;
	printf("Enter first number: ");
	scanf("%d", &a);
	printf("Enter second number: ");
	scanf("%d", &b);
	printf("Enter third number: ");
	scanf("%d", &c);
	if (b > a) a = b;
	if (c > a) a = c;
	printf("Largest number: %d\n", a);
	return 0;
}
