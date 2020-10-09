#include <unistd.h>
#include <stdio.h>
#include <signal.h>

void sigkey();

int main(int argc, char const *argv[])
{
    printf("process id: %d\n", getpid());
    signal(SIGQUIT, sigkey);
    for(;;);
    return 0;
}

void sigkey()
{
    printf("OK!\n");
}
