#include <stdio.h>
#include <string.h>

#define MAX_SIZE 100
#define MAX_INPUT 200

typedef struct
{
    int data[MAX_SIZE];
    int top;
} Stack;

void StackInit(Stack *stack);

int StackPush(Stack *stack, int c);
int StackPop(Stack *stack, int *c);

int StackIsFull(Stack *stack);
int StackIsEmpty(Stack *stack);

int StackPeek(Stack *stack, int *c);

int main()
{
    Stack s;

    char input[MAX_INPUT + 1];
    printf("Enter the postfix expression: ");
    scanf("%[^\n]s", input);
    input[MAX_INPUT] = '\0';

    StackInit(&s);

    printf("%s\n", input);

    int slen = strlen(input);

    int a, b;
    char op;

    for(int i = 0; i < slen; i++)
    {
	if(input[i] >= '0' && input[i] <= '9')
	{
	    a = input[i] - '0';
	    if(StackPush(&s, a) == 0)
	    {
		printf("Error: Stack is full!\n");
		return -1;
	    }
	}
	if(input[i] == '*' || input[i] == '/' || input[i] == '+' || input[i] == '-')
	{
	    op = input[i];
	    if(StackPop(&s, &b) == 0)
	    {
		printf("Error: Stack is empty!\n");
		return -1;
	    }
	    if(StackPop(&s, &a) == 0)
	    {
		printf("Error: Stack is empty!\n");
		return -1;
	    }

	    switch(op)
	    {
	    case '+':
		a = a + b;
		break;
	    case '-':
		a = a - b;
		break;
	    case '*':
		a = a * b;
		break;
	    case '/':
		if(b == 0)
		{
		    printf("Error: Divison by zero is undefined!\n");
		    return -1;
		}
		a = a / b;
		break;
	    }

	    if(StackPush(&s, a) == 0)
	    {
		printf("Error: Stack is full!\n");
		return -1;
	    }
	}
    }

    if(StackPop(&s, &a) == 0)
    {
	printf("Error: Stack is empty!\n");
	return -1;
    }

    printf("Answer: %d\n", a);
    
    return 0;
}


void StackInit(Stack *stack)
{
    stack->top = -1;
}

int StackPush(Stack *stack, int c)
{
    if(StackIsFull(stack))
	return 0;
    stack->top += 1;
    stack->data[stack->top] = c;
    return 1;
}

int StackPop(Stack *stack, int *c)
{
    if(StackIsEmpty(stack))
	return 0;
    *c = stack->data[stack->top];
    stack->top -= 1;
    return 1;
}

int StackIsFull(Stack *stack)
{
    if((stack->top + 1) >= MAX_SIZE)
	return 1;
    return 0;
}

int StackIsEmpty(Stack *stack)
{
    if(stack->top < 0)
	return 1;
    return 0;
}

int StackPeek(Stack *stack, int *c)
{
    if(StackIsEmpty(stack))
	return 0;
    *c = stack->data[stack->top];
    return 1;
}
