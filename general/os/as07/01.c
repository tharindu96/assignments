#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

int main(int argc, char const *argv[])
{
    int opid, pid, ppid;
    opid = getpid();
    pid = getpid();
    printf("Just one process so far\n");
    printf("calling fork...\n");
    for (int i = 0; i < 10; i++) {
        if (opid != pid) {
            break;
        }
        pid = fork();
        if (pid == -1) {
            perror("fork");
            return 1;
        }
        if (pid == 0) {
            printf("Child: I am the child process\n");
            pid = getpid();
            ppid = getppid();
            printf("Child: pid: %d\nppid: %d\n", pid, ppid);
        } else {
            printf("Parent: This is the parent, child pid: %d\n", pid);
            pid = getpid();
            ppid = getpid();
            printf("Parent: pid: %d\nppid: %d\n", pid, ppid);
        }
    }
    return 0;
}
