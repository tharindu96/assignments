#include <mpi.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main(int argc, char *argv[])
{
  int numtasks, rank, dest, tag, source, rc, count;
  MPI_Status Stat;

  MPI_Init(&argc, &argv);
  MPI_Comm_size(MPI_COMM_WORLD, &numtasks);
  MPI_Comm_rank(MPI_COMM_WORLD, &rank);
  printf("Task %d starting...\n", rank);

  if (rank == 0)
  {
    char *msg = "Hello World\0";
    MPI_Bcast(msg, strlen(msg), MPI_CHAR, rank, MPI_COMM_WORLD);
    printf("Broadcasted Message!\n");
  } else {
    int l = strlen("Hello World\0");
    char *msg = malloc(sizeof(char) * l);
    MPI_Bcast(msg, l, MPI_CHAR, 0, MPI_COMM_WORLD);
    printf("[%d] Message Received from %d -> %s\n", rank, 0, msg);
    free(msg);
  }

  MPI_Finalize();
}