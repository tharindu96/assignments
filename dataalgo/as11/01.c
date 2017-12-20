#include <stdio.h>
#include <stdlib.h>

void quicksort(int *arr, int left, int right, int n);

void disp(int *arr, int n) {
    for(int i = 0; i < n; i++) {
	printf("%d ", arr[i]);
    }
    printf("\n");
}

int main() {

    int arr[] = {
	32, 6, 3, 45, 5, 46, 7, 8, 9, 10, 5
    };

    int n = 11;

    disp(arr, n);

    quicksort(arr, 0, n-1, n);

    disp(arr, n);

    return 0;
}

void swap(int *a, int *b) {
    int t = *a;
    *a = *b;
    *b = t;
}

void quicksort(int *arr, int left, int right, int n) {
    int pivot = left;

    int r = right;

    left++;

    while(left <= right) {
	if(arr[left] < arr[pivot]) {
	    left++;
	    continue;
	}
	if(arr[right] > arr[pivot]) {
	    right--;
	    continue;
	}
	swap(&arr[left], &arr[right]);
	left++;
	right--;
    }

    swap(&arr[pivot], &arr[right]);

    int ll = 0;
    int lr = right-1;

    int rl = right+1;
    int rr = r;

    if(ll < lr)
    	quicksort(arr, ll, lr, n);
    
    if(rl < rr)
    	quicksort(arr, rl, rr, n);
}
