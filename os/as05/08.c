#include <stdio.h>
#include <stdlib.h>

#define MAX_TRIES 10

int main() {
	int again, guess, target, tries;

	again = 1;
	
	while (again) {
		tries = 0;
		target = rand() % 100;
		do {
			printf("Guess the number (%d tries remaning): ", MAX_TRIES - tries);
			scanf("%d", &guess);
			if (guess < target) printf("Too low\n");
			else printf("Too high\n");
			tries++;
		} while (target != guess && MAX_TRIES > tries);
		if (target == guess) {
			printf("You found it!\n");
		} else {
			printf("You lose!\n");
		}
		printf("Do you wanna play again? (1=yes, 0=no): ");
		scanf("%d", &again);
	}
}
