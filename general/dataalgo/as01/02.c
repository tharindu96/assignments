#include <stdio.h>

int main() {

    char name[50] = {0};

    printf("Enter name: ");
    scanf("%s", name);

    printf("Your name: ");

    for(int i = 0; i < 50; i++) {
	if(name[i] == '\0')
	    break;
	printf("%c", name[i]);
    }
    printf("\n");
    return 0;
}
