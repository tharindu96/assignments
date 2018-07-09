#include <stdio.h>

int main()
{
    int t;
    for ( ; ; ) {
        scanf("%d" , &t);
        if ( t==10 ) break;
        printf("Looping until t=10 \n", t);
    }
    printf("End of an infinite loop...\n");
    return 0;
}