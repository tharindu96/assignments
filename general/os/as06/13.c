#include <stdio.h>

void recurse(int i);

void main(void)
{
    recurse(0);
}

void recurse(int i)
{
    if (i<10) {
        printf("Befour %2d\n",i);
        recurse(i+1);
        printf("After  %2d\n",i);
    }
}