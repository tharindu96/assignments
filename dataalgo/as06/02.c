#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct {
    char id[50];
    int number;
} Taxi;

typedef struct _Node {
    Taxi data;
    struct _Node *next;
} Node;

typedef struct {
    Node *front;
    Node *rear;
    int size;
} Queue;

void init(Queue *q) {
    q->front = NULL;
    q->rear = NULL;
    q->size = 0;
}

int isEmpty(Queue *q) {
    return q->size == 0;
}

void enQueue(Queue *q, Taxi d) {
    Node *n = (Node*) malloc(sizeof(Node));
    n->data = d;
    n->next = NULL;

    if(isEmpty(q)) {
	q->front = n;
	q->rear = n;
    } else {
	q->rear->next = n;
	q->rear = n;
    }
    q->size++;
}

Taxi deQueue(Queue *q) {
    Taxi ret;

    if(isEmpty(q)) {
	printf("Queue is Empty!\n");
	return ret;
    }
    Node *t = q->front;
    ret = t->data;
    q->front = q->front->next;
    if(q->front == NULL)
	q->rear = NULL;
    q->size--;
    free(t);
    printf("Taxi Served\n");
    printf("Taxi id: %s, number: %d\n", ret.id, ret.number);
    printf("\n");
    return ret;
}

void displayTaxi(Taxi *t) {
    printf("Taxi: %s\n", t->id);
    printf("    number: %d\n", t->number);
    printf("\n");
}

void displayQueue(Queue *q) {
    Node *t = q->front;
    printf("Taxi -- listing\n");
    while(t != NULL) {
	displayTaxi(&(t->data));
	t = t->next;
    }
    printf("number of taxies: %d\n", q->size);
}

int main() {
    int i;
    Taxi t;
    Queue q;

    init(&q);

    strcpy(t.id, "shgeg");
    t.number = 4;
    enQueue(&q, t);

    strcpy(t.id, "shgegaegaeg");
    t.number = 10;
    enQueue(&q, t);

    displayQueue(&q);

    t = deQueue(&q);

    displayQueue(&q);

    // free the queue
    Node *n, *m;
    m = q.front;
    n = m;
    while(n != NULL) {
	m = n->next;
	free(n);
	n = m;
    }
    
    return 0;
}
