#include <stdio.h>


int main()
{
    int i;
    printf("Enter a number between 1 and 4: ");
    scanf("%d", &i);
    switch (i)
    {
    case 1:
        printf("one\n");
        break;
    case 2:
        printf("two\n");
        break;
    case 3:
        printf("three\n");
        break;
    case 4:
        printf("four\n");
        break;
    default:
        printf("unrecognized number\n");
    } /* end of switch */
    return 0;
}
