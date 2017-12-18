#include <stdio.h> 

int numb_array[] ={15,8,22,35,18,15,28,22,8,7,15,8,15,4,35};   

int count = 0, max = 0;

int findMax(int *ptr) {
    int x = *ptr;
    for(int i = 1; i < 15; i++) {
	ptr++;
	if(*ptr > x) {
	    x = *ptr;
	}
    }
    max = x;
}

int maxCount(int x, int *ptr) {
    int c = 0;
    for(int i = 0; i < 15; i++) {
	if(*ptr == x) {
	    c++;
	}
	ptr++;
    }
    return c;
}

int main(){
    
    int *ptr = numb_array;

    max = findMax(ptr);
    
    printf("The maximum value is %d\n",max); 

    count = maxCount(max, numb_array); 

    printf("The count of the maximum value is %d\n",count); 

    return 0;
} 
