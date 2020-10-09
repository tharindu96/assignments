#include <stdio.h>

void selectionSort(char *arr, int n);

void dispList(char *arr, int n) {
    for(int i = 0; i < n; i++) {
	printf("%c ", arr[i]);
    }
    printf("\n");
}

int main() {

    char arr[] = {
	'H','S','A','F','R','P','E','C','Z','W','G','J','B','Q','L' 
    };

    int n = 15;

    selectionSort(arr, n);
    
    dispList(arr, n);
    
    return 0;
}

void swap(char *a, char *b) {
    char t = *a;
    *a = *b;
    *b = t;
}

void findMin(char *arr, int i, int j, int *ind) {
    int in = i;
    for(;i <= j; i++) {
	if(arr[in] > arr[i]) {
	    in = i;
	}
    }
    *ind = in;
}

void selectionSort(char *arr, int n) {
    int j = 0;
    int min;
    for(int i = 0; i < n; i++) {
	j = i;
	findMin(arr, j, n-1, &min);
	swap(&arr[j], &arr[min]);
    }
}
