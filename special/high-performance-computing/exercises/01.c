#include "mpi.h"
#include <stdio.h>

int main(int argc, char *argv[])
{
  int numtasks, rank, dest, source, rc, count, tag = 1;
  MPI_Status Stat; // required variable for receive routines

  MPI_Init(&argc, &argv);
  MPI_Comm_size(MPI_COMM_WORLD, &numtasks);
  MPI_Comm_rank(MPI_COMM_WORLD, &rank);

  int sum;
  int num = rank + 1;

  MPI_Allreduce(&num, &sum, 1, MPI_INT, MPI_SUM, MPI_COMM_WORLD);

  printf("Task Rank: %d -> SUM: %d\n", rank, sum);


  // task 0 sends to task 1 and waits to receive a return message
  if (rank == 0)
  {
    dest = 1;
    source = 1;

    int testSum = (numtasks * (numtasks + 1)) / 2;
    printf("Total Check: %d | Sum Calculated: %d\n", testSum, sum);


    // MPI_Send(&outmsg, 1, MPI_CHAR, dest, tag, MPI_COMM_WORLD);
    // MPI_Recv(&inmsg, 1, MPI_CHAR, source, tag, MPI_COMM_WORLD, &Stat);
  }

  MPI_Finalize();
}
