#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/wait.h>


int main(int argc, char const *argv[])
{
    int pid;
    pid = fork();
    if (pid < 0) { /* error occurred */
        fprintf(stderr, "Fork failed!\n");
        exit(-1);
    } else if (pid==0) { /* child process */
        printf("I am the child, return from fork=%d\n", pid);
        execv("/home/bcs2/sc9935/assignments/os/as07/01", (char * const*)"");
    } else { /* parent process */
        printf("I am the parent, return from fork, child pid=%d\n", pid);
        wait(&pid);
        printf("Parent exiting!\n");
        exit(0);
    }
    return 0;
}
