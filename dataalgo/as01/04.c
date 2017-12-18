#include <stdio.h>

int main() {

    int a, b;
    int *p, *q;

    a = 2;
    b = 8;

    p = &a;
    q = &b;

    printf("a -> address: %p ; value: %d\n", &a, a);
    printf("p -> p: %p ; *p: %d\n", p, *p);
    printf("b -> address: %p ; value: %d\n", &b, b);
    printf("q -> q: %p ; *q: %d\n", q, *q);
    printf("p -> address: %p\n", &p);
    printf("q -> address: %p\n", &q);

    return 0;
}
