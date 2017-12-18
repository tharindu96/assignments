#include <stdio.h>

void bubbleSort(int *array, int len);
float average(int *array, int len);
void displayAboveAverage(int *array, int len, float average);


int main() {
    int marks[] = {
	100, 22, 55, 12, 75, 80, 150, 10, 99, 40
    };

    int len = 10;
    
    bubbleSort(marks, len);

    float avg = average(marks, len);

    printf("average: %.2f\n", avg);

    displayAboveAverage(marks, len, avg);

    return 0;
}

void swap(int *a, int *b) {
    int t = *a;
    *a = *b;
    *b = t;
}

void bubbleSort(int *array, int len) {
    for(int i = 0; i < len - 1; i++) {
	for(int j = 0; j < len - 1 - i; j++) {
	    if(array[j] > array[j+1]) {
		swap(&array[j], &array[j+1]);
	    }
	}
    }
}

float average(int *array, int len) {
    int t = 0;
    for(int i = 0; i < len; i++) {
	t += array[i];
    }
    float avg = t / (float) len;
    return avg;
}

void displayAboveAverage(int *array, int len, float average) {
    int j = -1;
    for(int i = 0; i < len; i++) {
	if(array[i] > average) {
	    j = i;
	    break;
	}
    }
    for(int i = j; i < len; i++) {
	printf("%d ", array[i]);
    }
    printf("\n");
}
