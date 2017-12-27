#include <stdio.h>
#include <stdlib.h>

void quicksort(int *arr, int left, int right, int n);

void disp(int *arr, int n);

int binsearch(int a, int *arr, int n);

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

    quicksort(arr, 0, n-1, n);

    printf("Displaying the list...\n");
    disp(arr, n);

    int a;
    printf("Enter the value to search: ");
    scanf("%d", &a);

    int r = binsearch(a, arr, n);

    if(r == -1) {
	printf("%d Not Found\n", a);
    } else {
	printf("%d Found | index: %d\n", a, r);
    }

    free(arr);

    return 0;
}

void disp(int *arr, int n) {
    for(int i = 0; i < n; i++) {
	printf("%d ", arr[i]);
    }
    printf("\n");
}

int binsearch(int a, int *arr, int n) {
    int l = 0;
    int r = n - 1;
    int mid;
    
    while(l <= r) {
	mid = (l + r) / 2;
	if(arr[mid] == a) return mid;
	else if(arr[mid] > a)
	    r = mid - 1;
	else if(arr[mid] < a)
	    l = mid + 1;
    }
    
    return -1;
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
