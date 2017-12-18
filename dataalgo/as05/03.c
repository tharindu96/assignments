#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define OK       0
#define NO_INPUT 1
#define TOO_LONG 2
#define STR_LENGTH 256

typedef struct ListNode {
    char data;
    struct ListNode *next;
} Node;

typedef struct Stack {
    Node *top;
} Stack;

void init(Stack *s);
void push(Stack *s, char d);
int pop(Stack *s);
void display(Stack *s);

int getLine (char *prmpt, char *buff, size_t sz);

int main() {

    char buffer[STR_LENGTH] = { 0 };

    int rc = getLine("Enter a string: ", buffer, STR_LENGTH);

    if(rc == NO_INPUT) {
	printf("There was no input\n");
	return 1;
    }

    if(rc == TOO_LONG) {
	printf("Too Long!\n");
	return 2;
    }

    char *cp = buffer;

    Stack s;
    init(&s);

    char t;
    int match = 1;

    while(*cp != '\0') {
	
	if(*cp == '{' || *cp == '(' || *cp =='[') {
	    push(&s, *cp);
	}
	if(*cp == '}' || *cp == ')' || *cp == ']') {
	    t = pop(&s);
	    if(t == -1 || (t != '{' || *cp != '}') && (t != '(' || *cp != ')') && (t != '[' || *cp != ']')) {
		match = 0;
		break;
	    }
	}
	cp++;
    }

    if(s.top != NULL) {
	match = 0;
    }
    if(match == 1) {
	printf("Parentheses are balanced!\n");
    } else {
	printf("Parentheses are not balanced!\n");
    }
    return 0;
}

int getLine (char *prmpt, char *buff, size_t sz) {
    int ch, extra;

    // Get line with buffer overrun protection.
    if (prmpt != NULL) {
        printf ("%s", prmpt);
        fflush (stdout);
    }
    if (fgets (buff, sz, stdin) == NULL)
        return NO_INPUT;

    // If it was too long, there'll be no newline. In that case, we flush
    // to end of line so that excess doesn't affect the next call.
    if (buff[strlen(buff)-1] != '\n') {
        extra = 0;
        while (((ch = getchar()) != '\n') && (ch != EOF))
            extra = 1;
        return (extra == 1) ? TOO_LONG : OK;
    }

    // Otherwise remove newline and give string back to caller.
    buff[strlen(buff)-1] = '\0';
    return OK;
}

void init(Stack *s) {
    s->top = NULL;
}

void push(Stack *s, char d) {
    Node *n = (Node *)malloc(sizeof(Node));
    n->data = d;
    n->next = s->top;
    s->top = n;
}

int pop(Stack *s) {
    Node *tmp;
    tmp = s->top;
    if(tmp == NULL) {
	return -1;
    }
    char d = tmp->data;
    s->top = tmp->next;
    free(tmp);
    return d;
}


void display(Stack *s) {
    Node *tmp;
    tmp = s->top;
    while(tmp != NULL) {
	printf("%c", tmp->data);
	tmp = tmp->next;
    }
    printf("\n");
}
