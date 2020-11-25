#include <mpi.h>
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char *argv[])
{
    int numtasks, taskid;

    MPI_Init(&argc, &argv);
    MPI_Comm_size(MPI_COMM_WORLD, &numtasks);
    MPI_Comm_rank(MPI_COMM_WORLD, &taskid);

    

    printf("task process id: %d | number of processors: %d!\n", taskid, numtasks);
    if (taskid == 0)
        printf("process 0: Hello World\n");
    MPI_Finalize();
}