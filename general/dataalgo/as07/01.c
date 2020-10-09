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

void addFirst(List *l, int x);
void addEnd(List *l, int x);
void addAt(List *l, int x, int loc);

int delete(List *l, int num);

boolean search(List *l, int x);

int length(List *l);

int main() {
    List l, *lp;
    lp = &l;
    initialize(lp);
    addEnd(lp, 4);
    addEnd(lp, 10);
    addFirst(lp, 24);
    addAt(lp, 7, 3);

    display(lp);

    delete(lp, 10);
    delete(lp, 7);

    display(lp);

    boolean x = search(lp, 4);
    printf("found: %d\n", x);

    int len = length(lp);
    printf("length: %d\n", len);
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

void addFirst(List *l, int x) {
    Node *n = (Node *) malloc(sizeof(Node));
    n->data = x;
    n->next = l->head;
    l->head = n;
}

void addEnd(List *l, int x) {
    Node *n = (Node *) malloc(sizeof(Node));
    n->data = x;
    n->next = NULL;
    if(isEmpty(l) == true) {
	l->head = n;
	return;
    }
    Node *t = l->head;
    while(t->next != NULL) {
	t = t->next;
    }
    t->next = n;
}

void addAt(List *l, int x, int loc) {
    int len = length(l);
    if(loc > len + 1 || loc < 1) {
	printf("Error: invalid location\n");
	return;
    }
    if(loc == len + 1) {
	addEnd(l, x);
	return;
    }
    if(loc == 1) {
	addFirst(l, x);
	return;
    }
    
    Node *n = (Node *) malloc(sizeof(Node));
    n->data = x;

    loc--;

    Node *t = l->head;
    while(loc > 1) {
	t = t->next;
	loc--;
    }

    n->next = t->next;
    t->next = n;
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
