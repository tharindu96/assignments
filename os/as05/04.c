#include <stdio.h>

int main() {
	float a, b;
	printf("Enter first number: ");
	scanf("%f", &a);
	printf("Enter second number: ");
	scanf("%f", &b);
	printf("%.5f + %.5f = %.5f\n", a, b, a + b);
	printf("%.5f - %.5f = %.5f\n", a, b, a - b);
	printf("%.5f * %.5f = %.5f\n", a, b, a * b);
	if (b == 0) {
		printf("Cannot divide by 0\n");
		return 1;
	}
	printf("%.5f / %.5f = %.5f\n", a, b, a / b);
	return 0;
}
