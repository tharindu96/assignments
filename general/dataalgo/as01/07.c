#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define COUNT 2

typedef struct {
    char title[50];
    char author[50];
    int isbn;
    int price;
} Book;

void insertBook(Book *book) {
    printf("Title: ");
    scanf("%s", book->title);
    printf("Author: ");
    scanf("%s", book->author);
    printf("ISBN: ");
    scanf("%d", &book->isbn);
    printf("Price: ");
    scanf("%d", &book->price);
}

void printBook(Book *book) {
    printf("Title: %s\nAuthor: %s\nISBN: %d\nPrice: %d\n", book->title, book->author, book->isbn, book->price);
}

void printBooksUnder(int limit, Book *books, int count) {
    Book *book = books;
    printf("Titles of the books less than %d\n", limit);
    int found = 0;
    for(int i = 0; i < count; i++) {
	if(book->price < limit) {
	    printf("%s\n", book->title);
	    if(!found) found = 1;
	}
	book++;
    }
    if(!found) {
	printf("None found!\n");
    }
}

void printBooksByAuthor(char *author, Book *books, int count) {
    Book *book = books;
    printf("Books by %s\n", author);
    int found = 0;
    for(int i = 0; i < count; i++) {
	if(strcmp(author, book->author) == 0) {
	    printf("Title: %s\nPrice: %d\n", book->title, book->price);
	    if(!found) found = 1;
	}
	book++;
    }
    if(!found) {
	printf("None Found!\n");
    }
}

int main() {

    Book *books;
    books = malloc(COUNT * sizeof(Book));

    for(int i = 0; i < COUNT; i++) {
	printf("Insert Book (%d)\n", i+1);
	insertBook(books+i);
    }

    printBooksUnder(2000, books, COUNT);

    printBooksByAuthor("Kernighan", books, COUNT);

    free(books);

    return 0;
}
