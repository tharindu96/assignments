#include <stdlib.h>
#include <stdio.h>
#include <string.h>


typedef struct
{
    char name[50];
    char accn[50];
} Customer;

typedef struct _Node
{
    Customer customer;
    struct _Node *next;
} Node;

typedef struct
{
    Node *head;
    Node *tail;
    int count;
} Queue;

void QueueInit(Queue *q);
void QueueDestroy(Queue *q);

int QueueEnqueue(Queue *q, Customer *c);
int QueueDequeue(Queue *q, Customer *c);

int QueueIsEmpty(Queue *q);
int QueueCount(Queue *q);

void QueueDisplay(Queue *q);

int main()
{

    return 0;
}


void QueueInit(Queue *q)
{
    q->head = NULL;
    q->tail = NULL;
    q->count = 0;
}

void QueueDestroy(Queue *q)
{
    if(QueueIsEmpty(q) == 0)
    {
	Node *r = q->head;
	Node *s = r;
	while(s != NULL)
	{
	    r = s->next;
	    free(s);
	    s = r;
	}
    }
    q->head = NULL;
    q->tail = NULL;
    q->count = 0;
}

int QueueEnqueue(Queue *q, Customer *c)
{
    Node *n = (Node *)malloc(sizeof(Node));
    memcpy(&n->customer, c, sizeof(Customer));
    n->next = NULL;
    q->tail->next = n;
    q->tail = n;
    q->count++;
    return 1;
}

int QueueDequeue(Queue *q, Customer *c)
{
    if(QueueIsEmpty(q) == 1)
	return 0;
    Node *n = q->head;
    memcpy(c, &n->customer, sizeof(Customer));
    q->head = q->head->next;
    if(q->tail == n)
	q->tail = NULL;
    q->count--;
    free(n);
    return 1;
}

int QueueIsEmpty(Queue *q)
{
    if(q->count == 0)
	return 1;
    return 0;
}

int QueueCount(Queue *q)
{
    return q->count;
}

void CustomerDisplay(Customer *c)
{
    printf("**** Customer ****\n");
    printf("Name: %s\n", c->name);
    printf("ACCN: %s\n", c->accn);
}

void QueueDisplay(Queue *q)
{
    
}
