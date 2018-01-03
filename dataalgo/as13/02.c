#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_STRING_SIZE 100

typedef struct _ListItem
{
    char data;
    struct _ListItem *next;
} ListItem;

typedef struct
{
    ListItem *top;
    ListItem *base;
    int size;
} Stack;

void StackInit(Stack *stack);
void StackDestroy(Stack *stack);
void StackPush(Stack *list, char c);
char StackPop(Stack *list);

int IsPalindrome(char *str);

int main()
{
    char str[MAX_STRING_SIZE];
    int len, mid;
    int i, flag = 1;
    char c;

    Stack stack;
    StackInit(&stack);

    printf("Enter a string: ");
    scanf("%s", str);

    len = strlen(str);
    mid = len / 2;

    for(i = 0; i < mid; i++)
    {
    	StackPush(&stack, str[i]);
    }

    if(len % 2 == 1)
    {
    	i += 1;
    }

    for(; i < len; i++)
    {
    	c = StackPop(&stack);
	if(c != str[i])
	{
	    printf("Not a Palindrome!\n");
	    flag = 0;
	    break;
	}
    }

    if(flag)
    {
	printf("Is a Palindrome!\n");
    }

    StackDestroy(&stack);

    return 0;
}

void StackInit(Stack *stack)
{
    stack->top = NULL;
    stack->base = NULL;
    stack->size = 0;
}

void StackDestroy(Stack *stack)
{
    stack->top = NULL;
    stack->size = 0;
    if(stack->base == NULL)
	return;
    ListItem *t = stack->base;
    ListItem *p;
    while(t != NULL)
    {
	p = t;
	t = t->next;
	free(p);
    }
    stack->base = NULL;
}

void StackPush(Stack *stack, char c)
{
    ListItem *tmp = (ListItem*) malloc(sizeof(ListItem));
    tmp->data = c;
    tmp->next = NULL;

    if(stack->base == NULL)
    {
	stack->base = tmp;
	stack->top = stack->base;
    }
    else
    {
	stack->top->next = tmp;
	stack->top = stack->top->next;
    }
    stack->size++;
}

char StackPop(Stack *stack)
{
    if(stack->base == NULL)
    {
	printf("Stack is empty!\n");
	return '\0';
    }

    ListItem *tmp = stack->base;
    ListItem *tmpPrev = NULL;
    while(tmp->next != NULL)
    {
	tmpPrev = tmp;
	tmp = tmp->next;
    }

    char c = tmp->data;
    free(tmp);

    stack->top = tmpPrev;
    if(tmpPrev == NULL)
	stack->base = NULL;
    else
	tmpPrev->next = NULL;

    stack->size--;

    return c;
}

int IsPalindrome(char *str)
{
    return 0;
}
