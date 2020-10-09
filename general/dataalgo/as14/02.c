#include <stdlib.h>
#include <stdio.h>
#include <string.h>

#define MAX_NAME 50
#define MAX_ACCN 50

typedef struct
{
    char name[MAX_NAME + 1];
    char accn[MAX_ACCN + 1];
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

void CustomerDisplay(Customer *c);
void CustomerInsert(Customer *c);

int main()
{
    Queue q;
    Customer c;
    int i;
    
    QueueInit(&q);

    for(i = 0; i < 5; i++)
    {
	CustomerInsert(&c);
	QueueEnqueue(&q, &c);
    }

    QueueDisplay(&q);
    printf("Count: %d\n", QueueCount(&q));

    printf("\n********** Dequeue One Customer ************\n");
    QueueDequeue(&q, &c);
    CustomerDisplay(&c);

    QueueDisplay(&q);
    printf("Count: %d\n", QueueCount(&q));

    printf("\n********* Two more customers *************\n");
    
    for(i = 0; i < 2; i++)
    {
	CustomerInsert(&c);
	QueueEnqueue(&q, &c);
    }

    QueueDisplay(&q);
    printf("Count: %d\n", QueueCount(&q));    
    
    QueueDestroy(&q);

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
    if(q->count == 0)
    {
	q->head = n;
	q->tail = n;
    }
    else
    {
	q->tail->next = n;
	q->tail = n;
    }
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
    printf("ACCN: %s\n\n", c->accn);
}

void QueueDisplay(Queue *q)
{
    Node *n = q->head;
    printf("\n********** Displaying the Queue ***********\n");
    while(n != NULL)
    {
	CustomerDisplay(&n->customer);
	n = n->next;
    }
}

void CustomerInsert(Customer *c)
{
    
    printf("\n********** Insert Customer ***********\n");
    printf("Enter Customer Name: ");
    scanf("%[^\n]s", c->name);
    printf("Enter Customer ACCN: ");
    scanf("%s", c->accn);
    c->name[MAX_NAME] = '\0';
    c->accn[MAX_ACCN] = '\0';

    char k;
    while ((k = getchar()) != '\n' && k != EOF) { }
}
