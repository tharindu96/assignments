#include <stdio.h>
#include <stdlib.h>

typedef struct {
    char name[50];
    int user_id;
    int page_count;
} Printjob;

typedef struct _Node {
    Printjob data;
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

void enQueue(Queue *q, Printjob d) {
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

Printjob deQueue(Queue *q) {
    Printjob ret;
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
    return ret;
}

void displayQueue(Queue *q) {
    Node *t = q->front;
    printf("Print Job -- listing\n");
    while(t != NULL) {
	printf("%s %d %d\n", t->data.name, t->data.user_id, t->data.page_count);
	t = t->next;
    }
    printf("size: %d\n", q->size);
}

int main() {
    int i, t;
    Queue q;

    init(&q);

    

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
