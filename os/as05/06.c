#include <stdio.h>

int flushStdin() {
	int c;
	while ((c = getchar()) != '\n' && c != EOF);
}

int main() {
	int a, b;
	char op;
	
	printf("Enter first number: ");
	scanf("%d", &a);

	flushStdin();
	printf("Enter second number: ");
	scanf("%d", &b);

	flushStdin();
	printf("What is the operation (+, -, /, *): ");
	scanf("%c", &op);

	switch (op) {
		case '+':
			a = a + b;
			break;
		case '-':
			a = a - b;
			break;
		case '/':
			if (b == 0) {
				fprintf(stderr, "Error: division by zero!\n");
				return 1;
			}
			a = a / b;
			break;
		case '*':
			a = a * b;
			break;
		default:
			fprintf(stderr, "Error: unknown operation!\n");
			return 1;
	}

	printf("Answer: %d\n", a);

}
