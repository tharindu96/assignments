#include <stdio.h>

int main()
{
    int a, b;
    char ch;
    printf("Do you want to:\n");
    printf("Add, subtract, Multiply, or Divide?\n");
    /* force user to enter valid response */
    do {
        printf("Enter first letter: ");
        ch = getchar();
        printf("\n");
    }
    while (ch!='A' && ch!='S' && ch!='M' && ch!='D');
    printf("Enter first number: ");
    scanf("%d", &a);
    printf("Enter second number: ");
    scanf("%d", &b);
    printf("Answer: ");
    if (ch=='A') printf("%d\n", a + b);
    else if (ch=='S') printf("%d\n", a - b);
    else if (ch=='M') printf("%d\n", a * b);
    else if (ch=='D' && b!=0) printf("%d\n", a / b);

    return 0;
}