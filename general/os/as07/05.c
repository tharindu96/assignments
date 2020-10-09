#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/wait.h>


int main(int argc, char const *argv[])
{
    int des_p[2];
    pid_t pid;

    if (pipe(des_p) == -1) {
        perror("pipe");
        return -1;
    }

    pid = fork();
    if (pid == -1) {
        perror("fork");
        return -1;
    }
    if (pid == 0) {
        close(STDOUT_FILENO);
        dup(des_p[1]);
        close(des_p[0]);
        close(des_p[1]);

        const char* prog1[] = {"ls", NULL};
        execvp(prog1[0], prog1);
        perror("execvp failed!");
        exit(1);
    }

    pid = fork();
    if (pid == -1) {
        perror("fork");
        return -1;
    }
    if (pid == 0) {
        close(STDIN_FILENO);
        dup(des_p[0]);
        close(des_p[0]);
        close(des_p[1]);

        const char* prog2[] = {"tr", "'a-z'", "'A-Z'", NULL};
        execvp(prog2[0], prog2);
        perror("execvp failed!");
        exit(1);
    }

    close(des_p[0]);
    close(des_p[1]);

    wait(0);
    wait(0);

    return 0;
}
