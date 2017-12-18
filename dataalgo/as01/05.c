#include <stdio.h> 
#define size 3 
typedef struct _student{ 
    char name[50]; 
    int mark; 
} student; 
void print_list(student list[]); 
void read_list(student list[]); 
int main(){ 
    student list[size]; 
    read_list(list); 
    print_list(list); 
    return 0; 
} 
void read_list(student list[]){ 
    int i; 
    printf("Please enter the student information:\n"); 
    for(i = 0; i < size;i++){ 
	printf("Name and the marks:"); 
	scanf("%s %d",list[i].name,&list[i].mark); 
    } 
}
void print_list(student list[]){ 
    int i; 
    printf("Students' information:\n"); 
    for(i = 0; i < size;i++){ 
	printf("name: %s, mark: %d\n",list[i].name,list[i].mark); 
    } 
} 
