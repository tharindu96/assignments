#include <mpi.h>
#include <stdio.h>
#include <stdlib.h>

typedef struct {
    int *partnerRanks;
    int partnerCount;
    int sendFirst;
} ProcessActionInfo;

void getProcessActionInfo(ProcessActionInfo **info, int numtasks, int rank);
void printProcessActionInfo(ProcessActionInfo *info);

void createProcessActionInfo(ProcessActionInfo **info, int partnerCount);
void destroyProcessActionInfo(ProcessActionInfo **info);

void sendToPartner(int rank, int partnerRank, int tag);
void recvFromPartner(int rank, int partnerRank, int tag, MPI_Status *stat);

int main(int argc, char *argv[])
{
    int numtasks, rank, dest, tag, source, count;
    int inmsg;
    int outmsg;
    MPI_Status stat;

    MPI_Init(&argc, &argv);
    MPI_Comm_size(MPI_COMM_WORLD, &numtasks);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    printf("Task %d starting...\n", rank);

    if (numtasks == 1) {
        printf("Number of Tasks must be greater than 1");
        MPI_Finalize();
        return 0;
    }

    // get the partner id
    ProcessActionInfo *info = 0;
    getProcessActionInfo(&info, numtasks, rank);

    for (int i = 0; i < info->partnerCount; i++) {
        if (info->sendFirst) {
            sendToPartner(rank, info->partnerRanks[i], rank);
            recvFromPartner(rank, info->partnerRanks[i], info->partnerRanks[i], &stat);   
        } else {
            recvFromPartner(rank, info->partnerRanks[i], info->partnerRanks[i], &stat);
            sendToPartner(rank, info->partnerRanks[i], rank);
        }   
    }


    // clean process info
    destroyProcessActionInfo(&info);

    MPI_Finalize();
}

void sendToPartner(int rank, int partnerRank, int tag) {
    MPI_Send(&rank, 1, MPI_INT, partnerRank, tag, MPI_COMM_WORLD);
    printf("Task [%d] partner with Task [%d] -- Message Sent\n", rank, partnerRank);
}

void recvFromPartner(int rank, int partnerRank, int tag, MPI_Status *stat) {
    int retBuf;
    MPI_Recv(&retBuf, 1, MPI_INT, partnerRank, tag, MPI_COMM_WORLD, stat);
    printf("Task [%d] partner with Task [%d] -- Message Received %d\n", rank, partnerRank, retBuf);
}

void createProcessActionInfo(ProcessActionInfo **info, int partnerCount) {
    *info = malloc(sizeof(ProcessActionInfo));
    (*info)->partnerCount = partnerCount;
    (*info)->partnerRanks = malloc(sizeof(int) * partnerCount);
}


void destroyProcessActionInfo(ProcessActionInfo **info) {
    if (*info == 0) return;
    free((*info)->partnerRanks);
    free((*info));
    *info = 0;
}

void printProcessActionInfo(ProcessActionInfo *info) {
    printf("partners: %d, sendFirst: %d\n", info->partnerCount, info->sendFirst);
    for(int i = 0; i < info->partnerCount; i++) {
        printf("\tpartner[%d] = %d\n", i, info->partnerRanks[i]);
    }
    printf("------------------\n");
}

void getProcessActionInfo(ProcessActionInfo **info, int numtasks, int rank) {

    // partner rank
    if (numtasks % 2 == 1) {
        if (rank == numtasks - 1) {
            createProcessActionInfo(info, 1);
            (*info)->sendFirst = 0;
            (*info)->partnerRanks[0] = 0;
            return;
        }
        if (rank == 0) {
            createProcessActionInfo(info, 2);
            (*info)->sendFirst = 1;
            (*info)->partnerRanks[0] = 1;
            (*info)->partnerRanks[1] = numtasks - 1;
            return;
        }
    }

    createProcessActionInfo(info, 1);

    if (rank % 2 == 0) {
        (*info)->sendFirst = 1;
        (*info)->partnerRanks[0] = rank + 1;
    } else {
        (*info)->sendFirst = 0;
        (*info)->partnerRanks[0] = rank - 1;
    }

}
