/**
 * 
 * Readers Writers Problem
 * 
 **/

#include <stdio.h>
#include <sys/mman.h>
#include <sys/types.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/wait.h>

#define P_COUNT 10
#define WAIT_TIME 1

int mutex = 0;
int* shared_mem;

int main(int argc, char const *argv[])
{
    int ids[P_COUNT];
    int exit_code;

    shared_mem = mmap(0, sizeof(int), PROT_WRITE | PROT_READ, MAP_ANONYMOUS | MAP_SHARED, -1, 0);
    if (shared_mem == (void *) -1) {
        perror("mmap");
        exit(1);
    }
    
    *shared_mem = (int) 0;

    for (int i = 0; i < P_COUNT; i++) {
        ids[i] = fork();
        if (ids[i] == -1) {
            perror("fork");
            exit(1);
        } else if (ids[i] == 0) {

            int pid;
            pid = getpid();

            for (int t = 0; t < P_COUNT; t++) {
                while (mutex != 0) {}
                mutex = 1;
                if (ids[t] == 0) {
                    *shared_mem = pid;
                }
                printf("pid: %d  |  shared memory: %d\n", pid, (int)(*shared_mem));
                mutex = 0;
                sleep(WAIT_TIME);
            }

            exit(0);
        }
    }

    for (int i = 0; i < P_COUNT; i++) {
        wait(&exit_code);
        printf("%d: %d\n", ids[i], exit_code);
    }

    munmap(shared_mem, sizeof(int));

    return 0;
}
