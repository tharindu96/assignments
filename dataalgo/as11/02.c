#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void mergesort(int *arr, int l, int r);
void merge(int *arr, int ll, int lr, int rl, int rr);

void disp(int *arr, int n) {
    for(int i = 0; i < n; i++) {
	printf("%d ", arr[i]);
    }
    printf("\n");
}

int main() {

    int arr[] = {
	32, 6, 3, 45, 5, 46, 7, 8, 9, 10, 2
    };

    int n = 11;

    disp(arr, n);

    mergesort(arr, 0, n-1);

    disp(arr, n);

    return 0;
}

void swap(int *a, int *b) {
    int t = *a;
    *a = *b;
    *b = t;
}

void merge(int *arr, int ll, int lr, int rl, int rr) {

    int size = rr - ll + 1;
    int ol = ll;

    int *tarr = (int*) malloc(sizeof(int) * size);
    int tl = 0;

    while(ll <= lr && rl <= rr) {
	if(arr[ll] < arr[rl]) {
	    tarr[tl++] = arr[ll++];
	} else {
	    tarr[tl++] = arr[rl++];
	}
    }
    while(ll <= lr) {
	tarr[tl++] = arr[ll++];
    }
    while(rl <= rr) {
	tarr[tl++] = arr[rl++];
    }
    
    memcpy(&arr[ol], tarr, sizeof(int) * size);

    free(tarr);
}

void mergesort(int *arr, int l, int r) {
    int mid = (l+r)/ 2;
    if(l < mid)
	mergesort(arr, l, mid);
    if(mid + 1 < r)
	mergesort(arr, mid+1, r);
    merge(arr, l, mid, mid+1, r);
}
