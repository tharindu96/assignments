#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct {
    char id[6];
    float math;
    float chem;
} StudentInfo;

void displayStudent(StudentInfo *s);
void insertStudent(StudentInfo *s);
int searchStudent(StudentInfo *s, char id[6]);
float studentAvg(StudentInfo *s);

int main() {

    StudentInfo arr[10];

    insertStudent(&arr[0]);
    displayStudent(&arr[0]);

    
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
    scanf("%6s", s->id);
    printf("Enter Math Marks: ");
    scanf("%f", &s->math);
    printf("Enter Chemistry Marks: ");
    scanf("%f", &s->chem);
}
