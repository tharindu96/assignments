#include <stdio.h>
#include <string.h>
#include <stdlib.h>

#define MAX_ID 10
#define STUDENT_COUNT 10

typedef struct
{
    char id[MAX_ID + 1];
    float math;
    float chem;
} Student;

void StudentInsert(Student *std);
void StudentDisplay(Student *std);
void StudentSearch(Student *arr, char *id);
void StudentAboveAvg(Student *arr, float expected);

int main()
{
    Student arr[STUDENT_COUNT];
    int i;

    printf("INSERT ALL THE STUDENT DETAILS\n");
    for(i = 0; i < STUDENT_COUNT; i++)
    {
	StudentInsert(&arr[i]);
    }

    /* printf("DISPLAYING") */
    /* for(i = 0; i < STUDENT_COUNT; i++) */
    /* { */
    /* 	StudentDisplay(&arr[i]); */
    /* } */

    char id[MAX_ID + 1];
    printf("\n\nEnter ID to search: ");
    scanf("%s", id);
    id[MAX_ID] = '\0';

    StudentSearch(arr, id);

    float exp;
    printf("\n\nEnter Expected Average: ");
    scanf("%f", &exp);

    printf("\n****** Students with above average marks ********\n");
    StudentAboveAvg(arr, exp);
    
    return 0;
}


void StudentInsert(Student *std)
{
    printf("\n******** INSERT STUDENT DETAILS **************\n");
    printf("Student ID:      ");
    scanf("%s", std->id);
    printf("Math Marks:      ");
    scanf("%f", &std->math);
    printf("Chemistry Marks: ");
    scanf("%f", &std->chem);

    std->id[MAX_ID] = '\0';
}

void StudentDisplay(Student *std)
{
    printf("\n******* Student Details *********\n");
    printf("Student ID:      %s\n", std->id);
    printf("Math Marks:      %.2f\n", std->math);
    printf("Chemistry Marks: %.2f\n", std->chem);
}

void StudentSearch(Student *arr, char *id)
{
    for(int i = 0; i < STUDENT_COUNT; i++)
    {
	if(strcmp((&arr[i])->id, id) == 0)
	{
	    StudentDisplay(&(arr[i]));
	    return;
	}
    }
    printf("Student Not Found!\n");
}

void StudentAboveAvg(Student *arr, float expected)
{
    float avg;
    for(int i = 0; i < STUDENT_COUNT; i++)
    {
	avg = (arr[i].math + arr[i].chem) / 2.f;
	if(avg > expected)
	{
	    StudentDisplay(&(arr[i]));
	}
    }
}
