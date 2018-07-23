#include <sys/types.h>
#include <unistd.h>          
#include <stdio.h>
#include <stdlib.h>
#include <sys/wait.h>
#include <sys/mman.h>

#define SIZE sizeof(int)   /* size of [int] integer */
#define run_length 10       /* number of iterations in test run */


int main(int argc, char const *argv[])
{
    
    pid_t pid;

    caddr_t shared_memory;   /* shared memory base address */
    int i_parent, i_child;   /* index variables */
    int value;               /* value read by child */

    shared_memory=mmap(0, SIZE, PROT_READ | PROT_WRITE, MAP_ANONYMOUS | MAP_SHARED, -1, 0);
    if (shared_memory == (caddr_t) -1)
    {
        perror("mmap");
        exit(-1);
    }

    if ((pid = fork()) < 0)
    {
        perror("fork");
        exit(-1);
    }

    if (pid == 0)
    {
        printf("The child process begins.\n");
        for (i_child = 0; i_child < run_length; i_child++)
        {
            sleep(1);  /* wait for memory to be updated */
            value = *shared_memory;
            printf ("Child's report:  current value = %2d\n", value);
        }
        printf ("The child is done\n");
        exit(0);
    }

    printf ("The parent process begins.\n");
    for (i_parent = 0; i_parent < run_length; i_parent++)
    {
        *shared_memory = i_parent * i_parent;/* square into shared memory */
        printf ("Parent's report: current index = %2d\n", i_parent); 
        sleep(1);  /* wait for child to read value */
    }
    wait(&pid);
    printf ("The parent is done\n");
    
    return 0;
}
