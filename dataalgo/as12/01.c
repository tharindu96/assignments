#include <stdio.h>
#include <stdlib.h>

int linsearch(int a, int *arr, int n);

int main() {

    int n = 0;

    printf("Enter the number of elements: ");
    scanf("%d", &n);

    if(n < 1) {
	printf("Must be greater than 0\n");
	return 1;
    }

    int *arr = (int *) malloc(sizeof(int) * n);
    for(int i = 0; i < n; i++) {
	printf("Enter element number %d: ", i+1);
	scanf("%d", &arr[i]);
    }

    int a;
    printf("Enter the value to search: ");
    scanf("%d", &a);

    int r = linsearch(a, arr, n);

    if(r) {
	printf("%d Found\n", a);
    } else {
	printf("%d Not Found\n", a);
    }

    free(arr);

    return 0;
}

int linsearch(int a, int *arr, int n) {
    for(int i = 0; i < n; i++) {
	if(arr[i] == a) {
	    return 1;
	}
    }
    return 0;
}
