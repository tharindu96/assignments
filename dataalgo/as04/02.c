#include <stdio.h>
#include <stdlib.h>

typedef struct ListNode {
    int data;
    struct ListNode *next;
} Node;

typedef struct Stack {
    Node *top;
} Stack;

void init(Stack *s);
void push(Stack *s, int d);
int pop(Stack *s);
void display(Stack *s);



int main() {

    int n;
    printf("Enter how many numbers to input: ");
    scanf("%d", &n);
    int t;

    Stack s;

    init(&s);

    for(int i = 0; i < n; i++) {
	printf("Enter a number: ");
	scanf("%d", &t);
	push(&s, t);
    }

    display(&s);
    
    return 0;
}

void init(Stack *s) {
    s->top = NULL;
}

void push(Stack *s, int d) {
    Node *n = (Node *)malloc(sizeof(Node));
    n->data = d;
    n->next = s->top;
    s->top = n;
}

int pop(Stack *s) {
    Node *tmp;
    tmp = s->top;
    if(tmp == NULL) {
	printf("Error: stack is empty\n");
	return -1;
    }
    int d = tmp->data;
    s->top = tmp->next;
    free(tmp);
}


void display(Stack *s) {
    Node *tmp;
    tmp = s->top;
    while(tmp != NULL) {
	printf("%d ", tmp->data);
	tmp = tmp->next;
    }
    printf("\n");
}
