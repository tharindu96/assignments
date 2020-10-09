#include <stdio.h>
#include <stdlib.h>

typedef struct _Node {
    int data;
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

void enQueue(Queue *q, int d) {
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

int deQueue(Queue *q) {
    if(isEmpty(q)) {
	printf("Queue is Empty!\n");
	return 0;
    }
    Node *t = q->front;
    int ret = t->data;
    q->front = q->front->next;
    if(q->front == NULL)
	q->rear = NULL;
    q->size--;
    free(t);
    return ret;
}

void displayQueue(Queue *q) {
    Node *t = q->front;
    printf("Queue -- listing\n");
    while(t != NULL) {
	printf("%d\n", t->data);
	t = t->next;
    }
    printf("size: %d\n", q->size);
}

int main() {
    int i, t;
    Queue q;

    init(&q);
    
    for(i = 0; i < 5; i++) {
	printf("Enter a number: ");
	scanf("%d", &t);
	enQueue(&q, t);
	printf("EnQueued: %d\n", t);
    }

    displayQueue(&q);

    for(i = 0; i < 2; i++) {
	t = deQueue(&q);
	printf("DeQueued: %d\n", t);
    }

    displayQueue(&q);

    for(i = 0; i < 6; i++) {
	printf("Enter a number: ");
	scanf("%d", &t);
	enQueue(&q, t);
	printf("EnQueued: %d\n", t);
    }

    displayQueue(&q);

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
