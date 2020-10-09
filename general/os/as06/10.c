#include <stdio.h>

void readdat(int a[], int n);
void sort(int a[], int n);
void scan(int a[], int n, int *done);
void swap(int *a, int *b);

int main()
{
    int i;
    int a[20];
    readdat(a, 20);
    sort(a, 20);
    for (i = 0; i < 20; ++i)
        printf("%d\n", a[i]);
    return 0;
}

void readdat(int a[], int n)
{
    int i, nu;
    for (i = 0; i < n; ++i)
    {
        printf("Enter number %d\t", i, "\n");
        scanf("%d", &nu);
        a[i] = nu;
    }
}

void sort(int a[], int n)
{
    int done;
    done = 1;
    while (done == 1)
        scan(a, n, &done);
}

void scan(int a[1], int n, int *done)
{
    int i;
    *done = 0;
    for (i = 0; i < n - 1; ++i)
    {
        if (a[i] < a[i + 1])
        {
            swap(&a[i], &a[i + 1]);
            *done = 1;
        }
    }
}

void swap(int *a, int *b)
{
    int temp;
    temp = *a;
    *a = *b;
    *b = temp;
}