#include <stdio.h> 
typedef struct xampl { 
    int x; 
}xampl;

int main(){   
    xampl structure; 
    xampl *ptr; 
    structure.x = 12; 
    ptr = &structure; // & is needed when dealing with structures 
    printf("x is=%d\n",ptr->x); 
    return 0;              
} 
