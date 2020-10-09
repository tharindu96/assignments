#include <stdio.h>
#include <stdlib.h>

void insertSort(int *arr, int n);

void getArray(int **arr, int *n);

void dispList(int *arr, int n);

float mean(int *arr, int n);

float median(int *arr, int n);

int main() {

    int *arr;
    int n;

    getArray(&arr, &n);

    insertSort(arr, n);

    dispList(arr, n);

    float m = mean(arr, n);

    printf("mean: %.2f\n", m);

    float mid = median(arr, n);

    printf("median: %.2f\n", mid);
    
    return 0;
}

void swap(int *a, int *b) {
    int t = *a;
    *a = *b;
    *b = t;
}

float mean(int *arr, int n) {
    float t = .0f;
    for(int i = 0; i < n; i++) {
	t += arr[i];
    }
    return (t/n);
}

float median(int *arr, int n) {
    float m = 0;
    int mid = n / 2;
    if(n % 2 == 0) {
	m = (arr[mid-1] + arr[mid]) / 2.f;
    } else {
	m = arr[mid];
    }
    return m;
}

void dispList(int *arr, int n) {
    for(int i = 0; i < n; i++) {
	printf("%d ", arr[i]);
    }
    printf("\n");
}

void getArray(int **arr, int *n) {
    printf("Enter array length: ");
    scanf("%d", n);
    *arr = (int *) malloc(sizeof(int) * (*n));
    for(int i = 0; i < (*n); i++) {
	printf("Enter value (%d): ", i + 1);
	scanf("%d", (*arr+i));
    }
}

void insertSort(int *arr, int n) {
    for(int i = 1; i < n; i++) {
	int j = i - 1;
	int v = arr[i];
	while(j >= 0 && arr[j] > v) {
	    arr[j+1] = arr[j];
	    j--;
	}
	arr[j+1] = v;
    }
}
