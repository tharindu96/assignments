#include "mpi.h"
#include <stdio.h>
#include <stdlib.h>

#define WORK_PER_TASK 5

int main(int argc, char *argv[])
{
    int numtasks, rank, dest, source, rc, count, tag = 1;
    MPI_Status Stat; // required variable for receive routines

    MPI_Init(&argc, &argv);
    MPI_Comm_size(MPI_COMM_WORLD, &numtasks);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);

    int *gArray = malloc(sizeof(int) * numtasks * WORK_PER_TASK);
    int *lArray = malloc(sizeof(int) * WORK_PER_TASK);
    int lsum = 0;
    int gsum = 0;

    MPI_Status status;

    if (rank == 0)
    {
        for (int i = 0; i < numtasks * WORK_PER_TASK; i++)
        {
            gArray[i] = i + 1;
        }

        for (int i = 0; i < WORK_PER_TASK; i++) {
            lArray[i] = gArray[i];
        }

        for (int i = 1; i < numtasks; i++) {
            int *offset = gArray + i * WORK_PER_TASK;
            MPI_Send(offset, WORK_PER_TASK, MPI_INT, i, 1, MPI_COMM_WORLD);
        }
    } else {
        MPI_Recv(lArray, WORK_PER_TASK, MPI_INT, 0, 1, MPI_COMM_WORLD, &status);
    }

    lsum = 0;
    for (int i = 0; i < WORK_PER_TASK; i++)
    {
        lArray[i] += rank + 1;
        lsum += lArray[i];
    }

    if (rank == 0)
    {
        for (int i = 0; i < WORK_PER_TASK; i++) {
            gArray[i] = lArray[i];
        }

        for (int i = 1; i < numtasks; i++) {
            int *offset = gArray + i * WORK_PER_TASK;
            MPI_Recv(offset, WORK_PER_TASK, MPI_INT, i, 1, MPI_COMM_WORLD, &status);
        }
    } else {
        MPI_Send(lArray, WORK_PER_TASK, MPI_INT, 0, 1, MPI_COMM_WORLD);
    }

    MPI_Reduce(&lsum, &gsum, 1, MPI_INT, MPI_SUM, 0, MPI_COMM_WORLD);

    if (rank == 0)
    {
        printf("Array: [");
        for (int i = 0; i < numtasks * WORK_PER_TASK; i++)
        {
            printf("%d", gArray[i]);
            if (i + 1 < numtasks * WORK_PER_TASK)
            {
                printf(", ");
            }
        }
        printf("]\n");

        printf("Global Sum: %d\n", gsum);
    }

    free(gArray);
    free(lArray);

    MPI_Finalize();
}
