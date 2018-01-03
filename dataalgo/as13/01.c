#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct
{
    char name[50];
    int id;
    int pages;
} Printjob;

typedef struct
{
    Printjob *data;
    int size;
    int front;
    int rear;
} PrintjobQueue;

int QueueInit(PrintjobQueue *queue, int size);
void QueueDelete(PrintjobQueue *queue);

int QueueInsert(PrintjobQueue *queue, Printjob *printjob);
int QueueRemove(PrintjobQueue *queue, Printjob *printjob);
void QueueDisplay(PrintjobQueue *queue);
int QueueCount(PrintjobQueue *queue);

int QueueIsFull(PrintjobQueue *queue);
int QueueIsEmpty(PrintjobQueue *queue);

void PrintjobDisplay(Printjob *printjob);

void PrintjobGet(Printjob *printjob)
{   
    printf("Enter Name: ");
    scanf("%s", printjob->name);

    printf("Enter ID: ");
    scanf("%d", &(printjob->id));

    printf("Enter Page Count: ");
    scanf("%d", &(printjob->pages));
}

int main()
{
    PrintjobQueue queue;
    Printjob p;
    int count;

    QueueInit(&queue, 5);

    for(int i = 0; i < 3; i++)
    {
	PrintjobGet(&p);
	QueueInsert(&queue, &p);
    }

    QueueDisplay(&queue);

    printf("\nRemoved one printjob!\n");
    
    QueueRemove(&queue, &p);

    PrintjobDisplay(&p);

    printf("\n");

    for(int i = 0; i < 3; i++)
    {
	PrintjobGet(&p);
	QueueInsert(&queue, &p);
    }

    count = QueueCount(&queue);

    printf("\n%d jobs in the queue\n", count);
    
    QueueDelete(&queue);
    
    return 0;
}

int QueueInit(PrintjobQueue *queue, int size)
{
    queue->front = -1;
    queue->rear = -1;
    queue->size = size;
    queue->data = (Printjob*) malloc(sizeof(Printjob)*size);
}

void QueueDelete(PrintjobQueue *queue)
{
    free(queue->data);
    queue->data = NULL;
    queue->rear = -1;
    queue->front = -1;
    queue->size = 0;
}

int QueueIsFull(PrintjobQueue *queue)
{
    if(queue->rear >= queue->size - 1)
	return 1;
    return 0;
}

int QueueIsEmpty(PrintjobQueue *queue)
{
    if(queue->front == queue->rear)
	return 1;
    return 0;
}

int QueueInsert(PrintjobQueue *queue, Printjob *printjob)
{
    if(QueueIsFull(queue))
    {
	printf("Queue is Full!\n");
	return 0;
    }

    memcpy(&(queue->data[queue->rear + 1]), printjob, sizeof(Printjob));
    queue->rear += 1;
    return 1;
}

int QueueRemove(PrintjobQueue *queue, Printjob *printjob)
{
    if(QueueIsEmpty(queue))
    {
	printf("Queue is Empty!\n");
	return 0;
    }

    memcpy(printjob, &(queue->data[queue->front + 1]), sizeof(Printjob));
    queue->front += 1;
    return 1;
}

void QueueDisplay(PrintjobQueue *queue)
{
    printf("============= QUEUE ==========\n");
    for(int i = queue->front + 1; i <= queue->rear; i++)
    {
	PrintjobDisplay(&queue->data[i]);
    }
}

void PrintjobDisplay(Printjob *printjob)
{
    printf("NAME: %s\nID: %d\nPAGE_COUNT: %d\n", printjob->name, printjob->id, printjob->pages);
}

int QueueCount(PrintjobQueue *queue)
{
    return queue->rear - queue->front;
}
