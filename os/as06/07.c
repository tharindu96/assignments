#include <stdio.h>

void myfun(); // function prototype

int main()
{
    printf("Hello! by main function:\n ");
    myfun(); // function call
    return 0;
}

void myfun() // function definition
{
    printf("Hello! by sub function:");
}