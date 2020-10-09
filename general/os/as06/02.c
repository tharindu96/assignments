#include <stdio.h>

int main() {

    int count;
    count=0;
    while (count < 20) {
        ++count;
        printf("Hello, Linux! %d\n", count);
    }

    return 0;
}