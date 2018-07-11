#include <stdio.h>

int main()
{
    int x ;
    for ( x=0 ; x<=10 ; x++) {
        if (x%2) continue;
        printf("For count %d\n" , x);
    }
    return 0;
}