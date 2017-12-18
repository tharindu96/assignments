#include <stdio.h>

void selectionSort(int *arr, int n);

void dispList(int *arr, int n) {
    for(int i = 0; i < n; i++) {
	printf("%d ", arr[i]);
    }
    printf("\n");
}

int main() {

    int arr[] = {
	100, 22, 55, 12, 75, 80, 150, 10, 99, 40
    };

    int n = 10;

    selectionSort(arr, n);

    dispList(arr, n);
    
    return 0;
}

void swap(int *a, int *b) {
    int t = *a;
    *a = *b;
    *b = t;
}

void findMin(int *arr, int i, int j, int *ind) {
    int in = i;
    for(;i <= j; i++) {
	if(arr[in] > arr[i]) {
	    in = i;
	}
    }
    *ind = in;
}

/* void selectionSort(int *arr, int n) { */
/*     int j = 0; */
/*     int min; */
/*     for(int i = 0; i < n; i++) { */
/* 	j = i; */
/* 	findMin(arr, j, n-1, &min); */
/* 	swap(&arr[j], &arr[min]); */
/*     } */
/* } */

void selectionSort(int *arr, int n) {
    int flag;
    for(int i = 0; i < n; i++) {
	flag = i;
	for(int j = i; j < n; j++) {
	    if(arr[flag] > arr[j]) {
		flag = j;
	    }
	}
	swap(&arr[i], &arr[flag]);
    }
}
