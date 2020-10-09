#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX 10

typedef struct {
    char id[7];
    float math;
    float chem;
} StudentInfo;

void displayStudent(StudentInfo *s);
void insertStudent(StudentInfo *s);
int searchStudent(StudentInfo *arr, char *id);
float studentAvg(StudentInfo *s);
void displayStudentsAbove(StudentInfo *arr, float avg);

int main() {

    StudentInfo arr[MAX];

    for(int i = 0; i < MAX; i++) {
	printf("Insert student %d\n", i+1);
	insertStudent(&arr[i]);
    }

    char id[7];
    printf("Enter the ID to search: ");
    scanf("%s", id);
    id[6] = '\0';

    int r = searchStudent(arr, id);
    if(r != -1) {
	printf("Student Found!\n");
	displayStudent(&arr[r]);
    } else {
	printf("Student Not Found!\n");
    }

    float avg;
    printf("Enter the lower bound of the search: ");
    scanf("%f", &avg);

    displayStudentsAbove(arr, avg);

    
    return 0;
}


void displayStudent(StudentInfo *s) {
    printf("----------- %s -----------\n", s->id);
    printf("Math:      %.2f\n", s->math);
    printf("Chemistry: %.2f\n", s->chem);
    printf("\n");
}

void insertStudent(StudentInfo *s) {
    printf("Enter Student ID: ");
    scanf("%s", s->id);
    printf("Enter Math Marks: ");
    scanf("%f", &s->math);
    printf("Enter Chemistry Marks: ");
    scanf("%f", &s->chem);
    s->id[6] = '\0';
}

int searchStudent(StudentInfo *arr, char *id) {
    for(int i = 0; i < MAX; i++) {
	if(strcmp((&arr[i])->id, id) == 0) {
	    return i;
	}
    }
    return -1;
}

float studentAvg(StudentInfo *s) {
    float avg = (s->math + s->chem) / 2.f;
    return avg;
}

void displayStudentsAbove(StudentInfo *arr, float avg) {

    printf("Students above the %.2f average\n", avg);
    for(int i = 0; i < MAX; i++) {
	if(avg < studentAvg(&arr[i])) {
	    displayStudent(&arr[i]);
	}
    }
}
