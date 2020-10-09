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

    printf("%d %d\n", q.front, q.rear);

    display(&q);

    dequeue(&q);
    dequeue(&q);
    dequeue(&q);

    printf("%d %d\n", q.front, q.rear);

    display(&q);

    enqueue(&q, 10);
    enqueue(&q, 11);
    enqueue(&q, 12);
    enqueue(&q, 13);
    enqueue(&q, 14);

    enqueue(&q, 15);
    enqueue(&q, 16);
    enqueue(&q, 17);
    enqueue(&q, 18);
    enqueue(&q, 19);

    printf("%d %d\n", q.front, q.rear);

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
    if(q->rear == q->front - 1 && q->size > 0)
	return 1;
    return 0;
}

void enqueue(queue *q, int d) { 
    if(isFull(q) == 1)
	return;
    q->size++;
    if(q->rear + 1 >= QUEUE_SIZE)
	q->rear = -1;
    q->items[++q->rear] = d;
}

int dequeue(queue *q) {
    if(isEmpty(q) == 1)
	return -1;
    q->size--;
    int p = q->front;
    q->front++;
    if(q->front == QUEUE_SIZE)
	q->front = 0;
    return q->items[p];
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
    int c = q->size;
    for(;c > 0; c--) {
	if(t == QUEUE_SIZE)
	    t = 0;
	printf("%d ", q->items[t++]);
    }
    printf("\n");
}
