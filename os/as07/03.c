#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/wait.h>


int main(int argc, char const *argv[])
{
    int pid;
    pid = fork();

    if (pid>0) /* parent */
    {
        wait(0);
        printf("ls completed\n"); exit(0);
    }
    if (pid==0) /* child */
    {
        execl("/bin/ls","ls","-l", NULL); exit(1);
    }
    /* getting here means pid is negative. So an
    error has occurred */
    printf("fork failed\n"); exit(1);

    return 0;
}
