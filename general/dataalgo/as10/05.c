#include <stdio.h>
#include <string.h>

void bubbleSort(char **arr, int n, int isASC);
void selectionSort(char **arr, int n, int isASC);
void disp(char **arr, int n);
void swap(char **a, char **b);

int main() {

    char *arr[] = {
	"Palmtop",
	"Desktop",
	"Laptop",
	"Notebook",
	"Mainframe"
    };

    int n = 5;

    printf("UNSORTED --\n");
    disp(arr, n);
    printf("\n");

    /* bubbleSort(arr, n, 1); */
    selectionSort(arr, n, 1);

    printf("SORTED --\n");
    disp(arr, n);
    printf("\n");
    
    return 0;
}

void disp(char **arr, int n) {
    for(int i = 0; i < n; i++) {
	printf("%s\n", arr[i]);
    }
}

void swap(char **a, char **b) {
    char *t = *a;
    *a = *b;
    *b = t;
}

void bubbleSort(char **arr, int n, int isASC) {
    int flag = 0;
    int s = 0;
    for(int i = 0; i < n; i++) {
	for(int j = 0; j < n - 1 - i; j++) {
	    s = strcmp(arr[j], arr[j+1]);
	    if(isASC) {
		flag = (s > 0);
	    } else {
		flag = (s < 0);
	    }
	    if(flag) {
		swap(&arr[j], &arr[j+1]);
	    }
	}
    }
}

void selectionSort(char **arr, int n, int isASC) {
    int flag = -1;
    int s = 0;
    for(int i = 0; i < n; i++) {
	flag = i;
	for(int j = i+1; j < n; j++) {
	    s = strcmp(arr[flag], arr[j]);
	    if(isASC) {
		if(s > 0) {
		    flag = j;
		}
	    } else {
		if(s < 0) {
		    flag = j;
		}
	    }
	}
	swap(&arr[flag], &arr[i]);
    }
}
