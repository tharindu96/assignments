#include <stdio.h>
#include <signal.h>
#include <stdlib.h>
#include <unistd.h>

void intproc(int);
void quitproc(int);

int main(int argc, char **argv) {
    int i;
    signal(SIGINT, intproc);
    signal(SIGQUIT, quitproc);

    printf("ctrl+c is disabled, use ctrl+\\ to quit\n");

    for (i = 0;; ++i) {
        printf("in an infinite loop...\n");
        sleep(2);
    }
}

void intproc(int s) {
    signal(SIGINT, intproc); // reset handler
    printf("You have pressed ctrl+c\n");
    printf("signal Number: %d\n", s);
}

void quitproc(int s) {
    printf("You have pressed ctrl+\\, quitting...\n");
    printf("Signal number: %d\n", s);
    exit(0);
}