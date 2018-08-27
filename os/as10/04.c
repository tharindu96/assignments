#include <stdio.h>
#include <signal.h>
#include <stdlib.h>
#include <unistd.h>

void myhupproc(int);
void myintproc(int);
void myquitproc(int);

int main(int argc, char **argv) {

    int pid;
    if ((pid = fork()) < 0) {
        perror("fork");
        exit(1);
    }

    if (pid == 0) { // child
        signal(SIGHUP, myhupproc);
        signal(SIGINT, myintproc);
        signal(SIGQUIT, myquitproc);
        for(;;);
    } else { // parent
        printf("PARENT: sending SIGHUP\n");
        kill(pid, SIGHUP);
        sleep(3);

        printf("PARENT: sending SIGINT\n");
        kill(pid, SIGINT);
        sleep(3);

        printf("PARENT: sending SIGQUIT\n");
        kill(pid, SIGQUIT);
        sleep(3);
    }
}

void myhupproc(int s) {
    signal(SIGHUP, myhupproc); // reset handler
    printf("CHILD: Received a SIGHUP\n");
}

void myintproc(int s) {
    signal(SIGINT, myintproc); // reset handler
    printf("CHILD: Received a SIGINT\n");
}

void myquitproc(int s) {
    printf("CHILD: Oh dear! My parent has killed me!\n");
    exit(0);
}