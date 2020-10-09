#include <stdio.h>
#include <pthread.h>

#define ARRAY_SIZE 1000
#define THREADS 10
#define WSIZE (ARRAY_SIZE / THREADS)

void *slave(void *myid);

int data[ARRAY_SIZE];
int sum = 0;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

void *slave(void *myid) {
    int i, low, high, myresult = 0;
    
    low = (int) myid * WSIZE;
    high = low + WSIZE;

    for (i = low; i < high; i++) {
        myresult += data[i];
    }

    pthread_mutex_lock(&mutex);
    sum += myresult;
    pthread_mutex_unlock(&mutex);

    // return (void*)myresult;
}

int main(int argc, char const *argv[])
{
    int i;
    pthread_t tid[THREADS];

    pthread_mutex_init(&mutex, NULL);

    for(i = 0; i < ARRAY_SIZE; i++) {
        data[i] = i + 1;
    }

    int rc;

    for(i = 0; i < THREADS; i++) {
        rc = pthread_create(&tid[i], NULL, slave, (void*)i);
    }

    for(i = 0; i < THREADS; i++) {
        // void *status;
        // pthread_join(tid[i], &status);
        // sum += (int)status;
        pthread_join(tid[i], NULL);
    }

    printf("sum from 1 to %d = %d\n", ARRAY_SIZE, sum);
    
    return 0;
}