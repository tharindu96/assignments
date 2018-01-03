#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_LIST_SIZE 5

typedef struct
{
    char type[50];
    int qty;
    int unit_price;
} pcdata;

void pcdataInsert(pcdata *data);
int pcdataSearch(pcdata *data, char *type);
void pcdataSort(pcdata *data, int l, int r);
void pcdataDisplay(pcdata *data);

int main()
{
    pcdata pclist[MAX_LIST_SIZE] = { 0 };
    char str[50];

    for(int i = 0; i < MAX_LIST_SIZE; i++)
    {
	pcdataInsert(&pclist[i]);
    }

    printf("\n\n");

    printf("Enter a type to search: ");
    scanf("%s", str);
    pcdataSearch(pclist, str);

    pcdataSort(pclist, 0, MAX_LIST_SIZE - 1);

    printf("\n\n");

    pcdataDisplay(pclist);
    
    return 0;
}

void pcdataInsert(pcdata *data)
{
    printf("Enter PC Type: ");
    scanf("%s", data->type);

    printf("Enter Quantity: ");
    scanf("%d", &data->qty);

    printf("Enter Unit Price: ");
    scanf("%d", &data->unit_price);
}

int pcdataSearch(pcdata *data, char *type)
{
    for(int i = 0; i < MAX_LIST_SIZE; i++)
    {
	if(strcmp(type, data[i].type) == 0)
	{
	    printf("Found a Match!\n");
	    printf("Quantity: %d\nUnit Price: %d\n", data[i].qty, data[i].unit_price);
	    return 1;
	}
    }

    printf("No matches found!\n");
    return 0;
}

void pcdataSort(pcdata *data, int l, int r)
{
    if(l >= r) return;
    int min = l;
    for(int i = l+1; i <= r; i++)
    {
	if(strcmp(data[i].type, data[min].type) < 0)
	    min = i;
    }

    pcdata t = data[l];
    data[l] = data[min];
    data[min] = t;

    pcdataSort(data, l+1, r);
}

void pcdataDisplay(pcdata *data)
{
    for(int i = 0; i < MAX_LIST_SIZE; i++)
    {
	printf("Type: %s\t\tQuantity: %d\t\tUnit Price: %d\n", data[i].type, data[i].qty, data[i].unit_price);
    }
}
