#include <stdio.h>

int main()
{

    int count;
    count = 0;

    do
    {
        ++count;
        printf("Hello, %d\n", count);
    } while (count < 20);

    return 0;
}