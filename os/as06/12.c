#include <stdio.h>

int add(int a, int b) {
    return a + b;
}

int sub(int a, int b) {
    return a - b;
}

int mul(int a, int b) {
    return a * b;
}

int div(int a, int b) {
    if (b == 0) return 0;
    return a / b;
}

int main()
{
    int a, b;
    char ch;
    int answer;
    printf("Do you want to:\n");
    printf("Add, Subtract, Multiply, or Divide?\n");
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
    
    if (ch=='A') answer = add(a, b);
    else if (ch=='S') answer = sub(a, b);
    else if (ch=='M') answer = mul(a, b);
    else if (ch=='D') answer = div(a, b);

    printf("Answer: %d\n", answer);

    return 0;
}