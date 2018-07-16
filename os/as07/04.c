#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <string.h>
#include <stdlib.h>


int main(int argc, char const *argv[])
{
    int fd[2], nbytes;
    pid_t childpid;
    char string[] = "Hello, World!\0";
    char readBuffer[80];

    pipe(fd);

    if ((childpid = fork()) == -1) {
        perror("fork");
        exit(1);
    }

    if (childpid == 0) {
        write(fd[1], string, strlen(string));
        exit(0);
    } else {
        close(fd[1]);
        nbytes = read(fd[0], readBuffer, sizeof(readBuffer));
        printf("Received: %s\n", readBuffer);
    }

    return 0;
}