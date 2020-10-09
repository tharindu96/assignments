#include <stdio.h>

int calsum(int, int);

int main()
{
    int n1, n2;
    printf("enter number 1: ");
    scanf("%d", &n1);
    printf("enter number 2: ");
    scanf("%d", &n2);
    printf("Sum = %d\n",calsum(n1,n2));
    return 0;
}

int calsum(int var1, int var2)
{
    int result;
    result = var1 + var2;
    return (result);
}