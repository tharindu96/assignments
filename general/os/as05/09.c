#include <stdio.h>

int main() {
	float f, c;
	printf("|  Fahrenheit  |  Celsius  |\n");
	for (f=0; f <= 300; f++) {
		c = (5.0f / 9.0f) * (f - 32.f);
		printf("|  %10.2f  |  %7.2f  |\n", f, c);
	}
}
