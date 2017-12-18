#include <stdio.h>
#include <stdlib.h>

#define STACK_SIZE 512

typedef struct _stack {
    char data[STACK_SIZE];
    int top;
} stack;

void initialize(stack *s);
int isFull(stack *s);
int isEmpty(stack *s);
void push(stack *s, char d);
char pop(stack *s);
char top(stack *s);
void display(stack *s);

int main() {

    stack s;

    initialize(&s);

    int n;

    printf("Enter a number: ");

    scanf("%d", &n);

    char t;

    while(n >= 0) {
	t = '0' + n % 2;
	n = n / 2;
	if(isFull(&s)) {
	    fprintf(stderr, "Stack Overflow!\n");
	    return 1;
	}
	push(&s, t);
	if(n == 0) n = -1;
    }

    printf("binary: ");

    while(!isEmpty(&s)) {
	t = pop(&s);
	printf("%c", t);
    }

    printf("\n");

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

void push(stack *s, char d) {
    if(isFull(s)) {
	fprintf(stderr, "Stack is full!\n");
	return;
    }
    s->data[++s->top] = d;
}

char pop(stack *s) {
    if(isEmpty(s)) {
	fprintf(stderr, "Stack is empty!\n");
	return -1;
    }
    return s->data[s->top--];
}

char top(stack *s) {
    if(isEmpty(s)) {
	fprintf(stderr, "Stack is empty!\n");
	return -1;
    }
    return s->data[s->top];
}

void display(stack *s) {
    char t = s->top;
    for(; t > -1; t--) {
	printf("%c ", s->data[t]);
    }
    printf("\n");
}
