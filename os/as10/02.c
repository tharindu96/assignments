#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include <signal.h>

void handler(int sign);

char *message;
int atime = 5;

int main(int argc, char *argv[])
{
    if (argc < 2) {
        printf("%s [alarm time] [message]\n", argv[0]);
        return 1;
    }

    atime = atoi(argv[1]);
    message = argv[2];

    printf("process id: %d\n", getpid());
    signal(SIGALRM, handler);
    alarm(atime);
    for(;;);
    return 0;
}

void handler(int sign)
{
    printf("message: %s\n", message);
    alarm(atime);
}
