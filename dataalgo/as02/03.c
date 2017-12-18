#include <stdio.h>
#include <stdlib.h>

#define STACK_SIZE 10

typedef struct _stack {
    int data[STACK_SIZE];
    int top;
} stack;

void initialize(stack *s);
int isFull(stack *s);
int isEmpty(stack *s);
void push(stack *s, int d);
int pop(stack *s);
int top(stack *s);
void display(stack *s);

int main() {

    stack s;
    stack *ps = &s;

    initialize(ps);

    if(isEmpty(ps)) {
	fprintf(stderr, "stack is empty!\n");
    }

    if(isFull(ps)) {
	fprintf(stderr, "stack is full!\n");
    }

    push(ps, 5);

    if(isFull(ps)) {
	fprintf(stderr, "stack is full!\n");
    }

    push(ps, 10);

    push(ps, 20);

    display(ps);

    pop(ps);

    display(ps);

    return 0;
}

void initialize(stack *s) {
    s->top = -1;
}

int isFull(stack *s) {
    if(s->top >= STACK_SIZE - 1)
	return 1;
    return 0;
}

int isEmpty(stack *s) {
    if(s->top <= -1)
	return 1;
    return 0;
}

void push(stack *s, int d) {
    if(isFull(s)) {
	fprintf(stderr, "Stack is full!\n");
	return;
    }
    s->data[++s->top] = d;
}

int pop(stack *s) {
    if(isEmpty(s)) {
	fprintf(stderr, "Stack is empty!\n");
	return -1;
    }
    return s->data[s->top--];
}

int top(stack *s) {
    if(isEmpty(s)) {
	fprintf(stderr, "Stack is empty!\n");
	return -1;
    }
    return s->data[s->top];
}

void display(stack *s) {
    int t = s->top;
    for(; t > -1; t--) {
	printf("%d ", s->data[t]);
    }
    printf("\n");
}
