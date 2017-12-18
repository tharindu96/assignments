#include <stdio.h>

#define QUEUE_SIZE 10

typedef struct {
    int items[QUEUE_SIZE];
    int rear, front;
    int size;
} queue;

void init(queue *q);
int isEmpty(queue *q);
int isFull(queue *q);
void enqueue(queue *q, int d);
int dequeue(queue *q);
int getFront(queue *q);
void display(queue *q);

int main() {

    queue q;

    init(&q);
    
    enqueue(&q, 5);
    enqueue(&q, 2);
    enqueue(&q, 4);
    enqueue(&q, 7);
    enqueue(&q, 6);
    enqueue(&q, 9);

    display(&q);

    dequeue(&q);
    dequeue(&q);
    dequeue(&q);

    display(&q);

    enqueue(&q, 10);
    enqueue(&q, 11);
    enqueue(&q, 12);
    enqueue(&q, 13);
    enqueue(&q, 14);

    display(&q);

    return 0;
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
    if(q->rear >= QUEUE_SIZE - 1)
	return 1;
    return 0;
}

void enqueue(queue *q, int d) { 
    if(isFull(q) == 1)
	return;
    q->size++;
    q->items[++q->rear] = d;
}

int dequeue(queue *q) {
    if(isEmpty(q) == 1)
	return -1;
    q->size--;
    return q->items[q->front++];
}

int getFront(queue *q) {
    if(isEmpty(q) == 1)
	return -1;
    return q->items[q->front];
}

void display(queue *q) {
    if(isEmpty(q) == 1) {
	printf("Queue is Empty!\n");
	return;
    }
    int t = q->front;
    for(;t <= q->rear; t++) {
	printf("%d ", q->items[t]);
    }
    printf("\n");
}
