#include <stdio.h>
#include <string.h>

int linsearch(char *key, char **arr, int n);

int main() {

    char *arr[] = {
	"Palmtop", "Desktop", "Laptop", "Notebook", "Mainframe"
    };

    char key[50];
    
    printf("Enter the type to search for: ");
    scanf("%s", key);

    int r = linsearch(key, arr, 5);

    if(r != -1) {
	printf("%s found!\n", key);
    } else {
	printf("%s not found!\n", key);
    }
    
    return 0;
}

int linsearch(char *key, char **arr, int n) {

    for(int i = 0; i < n; i++) {
	if(strcmp(arr[i], key) == 0) {
	    return i;
	}
    }

    return -1;
    
}
