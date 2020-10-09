#include <stdio.h>
#include <string.h>

#define QUEUE_SIZE 5

typedef struct {
    char name[256];
    int user_id;
    int page_count;
} printjob;

typedef struct {
    printjob items[QUEUE_SIZE];
    int rear, front;
    int size;
} queue;

void getPrintjob(printjob *d);
void displayPrintjob(printjob *d);

void init(queue *q);
int isEmpty(queue *q);
int isFull(queue *q);
void enqueue(queue *q, printjob *d);
void dequeue(queue *q, printjob *d);
void getFront(queue *q, printjob *d);
void display(queue *q);

int main() {

    queue q;
    printjob p;

    init(&q);

    for(int i = 0; i < 5; i++) {
	getPrintjob(&p);
	enqueue(&q, &p);
    }

    display(&q);

    return 0;
}

void getPrintjob(printjob *d) {
    printf("Enter Print Job Details\n");
    printf("Enter document name: ");
    scanf("%s", d->name);
    printf("Enter user id: ");
    scanf("%d", &d->user_id);
    printf("Enter page count: ");
    scanf("%d", &d->page_count);
}

void displayPrintjob(printjob *d) {
    printf("Print Job Details\n");
    printf("name: %s\nuser id: %d\npage count: %d\n\n", d->name, d->user_id, d->page_count);
}

void init(queue *q) {
    q->rear = -1;
    q->front = 0;
    q->size = 0;
}

int isEmpty(queue *q) {
    if(q->size == 0)
	return 1;
    return 0;
}

int isFull(queue *q) {
    if(q->rear == q->front - 1 && q->size > 0)
	return 1;
    return 0;
}

void enqueue(queue *q, printjob *d) {
    if(isFull(q) == 1)
	return;
    q->size++;
    if(q->rear + 1 >= QUEUE_SIZE)
	q->rear = -1;
    q->rear++;
    memcpy(&q->items[q->rear], d, sizeof(printjob));
}

void dequeue(queue *q, printjob *d) {
    if(isEmpty(q) == 1) {
	d = 0;
	return;
    }
    q->size--;
    int p = q->front;
    q->front++;
    if(q->front == QUEUE_SIZE)
	q->front = 0;
    memcpy(d, &q->items[p], sizeof(printjob));
}

void getFront(queue *q, printjob *d) {
    if(isEmpty(q) == 1) {
	d = 0;
	return;
    }
    memcpy(d, &q->items[q->front], sizeof(printjob));
}

void display(queue *q) {
    if(isEmpty(q) == 1) {
	printf("Queue is Empty!\n");
	return;
    }
    int t = q->front;
    int c = q->size;
    printjob *p;
    for(;c > 0; c--) {
	if(t == QUEUE_SIZE)
	    t = 0;
	p = &q->items[t++];
	displayPrintjob(p);
    }
    printf("\n");
}
