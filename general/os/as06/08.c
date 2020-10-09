#include <stdio.h>

int calsum(int, int);

int main()
{
    printf("Sum = %d\n", calsum(5, 5));
    return 0;
}

int calsum(int a, int b)
{
    int result;
    result = a + b;
    return (result);
}