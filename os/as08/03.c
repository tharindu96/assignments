/* A simple readers/writers program using a shared buffer and 
spinlocks  */

#include <sys/types.h>
#include <unistd.h>
#include <stdio.h>
#include <sys/mman.h>
#include <stdlib.h>
#include <sys/wait.h>

#define BUF_SIZE 5                                   /* logical size of buffer */
#define SHARED_MEM_SIZE (BUF_SIZE + 2) * sizeof(int) /* size of shared memory */
#define run_length 10                                /* number of iterations in test run */

int main(int argc, char const *argv[])
{
    pid_t pid; // variable to record id of child
    caddr_t shared_memory; // shaerd memory base

    int *in;
    int *out;
    int *buffer; // logical base of buffer

    int i_child, j_child;
    int value; // value read by child

    shared_memory = mmap(0, SHARED_MEM_SIZE, PROT_READ | PROT_WRITE, MAP_ANONYMOUS | MAP_SHARED, -1, 0);

    if (shared_memory == (caddr_t)-1)
    {
        perror("error in mmap");
        exit(1);
    }

    /*
    0...n-1| n  | n+1
    buffer | in | out
    */

    buffer = (int *)shared_memory;
    in = (int *)shared_memory + BUF_SIZE * sizeof(int);
    out = (int *)shared_memory + (BUF_SIZE + 1) * sizeof(int);

    *in = *out = 0;

    if (-1 == (pid = fork()))
    {
        perror("error in fork");
        exit(1);
    }

    if (0 == pid)
    {
        printf("The reader process begins.\n");
        for (i_child = 0; i_child < run_length; i_child++)
        {
            while (*in == *out);
            value = buffer[*out];
            *out = (*out + 1) % BUF_SIZE;
            printf("Reader's report: item %2d == %2d\n", i_child, value);
        }
        printf("Reader done.\n");
    } else {
        printf("The writer process begins.\n");
        for (j_child = 0; j_child < run_length; j_child++)
        {
            while ((*in + 1) % BUF_SIZE == *out);
            buffer[*in] = j_child*j_child;
            *in = (*in + 1) % BUF_SIZE;
            printf("Writer's report: item %2d put in buffer\n", j_child);
        }
        wait(&pid);
        printf("Writer done.\n");
    }
    return 0;
}
