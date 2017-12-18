#include <stdio.h>
#include <stdlib.h>

typedef enum { false = 0, true = 1 } boolean;

typedef struct _Node {
    int data;
    struct _Node *next;
} Node;

typedef struct {
    Node *head;
} List;

void initialize(List *l);
boolean isEmpty(List *l);
void display(List *l);

void add(List *l, int x);

int delete(List *l, int num);

boolean search(List *l, int x);

int length(List *l);

int main() {
    List l, *lp;
    lp = &l;
    initialize(lp);

    add(lp, 2);
    add(lp, 1);
    add(lp, 3);

    display(lp);

    delete(lp, 2);

    display(lp);

    add(lp, 5);
    add(lp, 4);

    display(lp);
}

void initialize(List *l) {
    l->head = NULL;
}

boolean isEmpty(List *l) {
    if(l->head == NULL)
	return true;
    return false;
}

void display(List *l) {
    Node *t = l->head;
    while(t != NULL) {
	printf("%d ", t->data);
	t = t->next;
    }
    printf("\n");
}

void add(List *l, int x) {
    Node *n = (Node *) malloc(sizeof(Node));
    n->data = x;
    Node *p = NULL;
    Node *t = l->head;
    while(t != NULL && t->data < x) {
	p = t;
	t = t->next;
    }
    if(p == NULL) {
	// must add x to head
	n->next = l->head;
	l->head = n;
    } else {
	// must add x to next of p
	n->next = p->next;
	p->next = n;
    }
}

int delete(List *l, int num) {
    boolean in = search(l, num);
    if(!in) {
	printf("Item not found!\n");
	return -1;
    }
    Node *t = l->head;
    Node *p = NULL;
    while(t->data != num) {
	p = t;
	t = t->next;
    }
    int d;
    d = t->data;
    if(p == NULL) {
	// element is at the head
	l->head = t->next;
    } else {
	// element is not at the head
	p->next = t->next;
    }
    free(t);
    return d;
}

boolean search(List *l, int x) {
    Node *t = l->head;
    boolean found = false;
    while(t != NULL) {
	if(t->data == x) {
	    found = true;
	    break;
	}
	t = t->next;
    }
    return found;
}

int length(List *l) {
    int len = 0;
    Node *t = l->head;
    while(t != NULL) {
	len += 1;
	t = t->next;
    }
    return len;
}
