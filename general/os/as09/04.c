#include <pthread.h>
#include <stdio.h>

#define BSIZE 4
#define NUMITEMS 30
#define NUMTHREADS 2

typedef struct {
    char buf[BSIZE];
    int occupied;
    int nextin, nextout;
    pthread_mutex_t mutex;
    pthread_cond_t more;
    pthread_cond_t less;
} buffer_t;

buffer_t buffer;
void* producer(void *);
void* consumer(void *);

pthread_t tid[NUMTHREADS];

int main(int argc, char const *argv[])
{
    int i;

    pthread_cond_init(&(buffer.more), NULL);
    pthread_cond_init(&(buffer.less), NULL);

    pthread_create(&tid[0], NULL, consumer, NULL);
    pthread_create(&tid[1], NULL, producer, NULL);

    for (i = 0; i < NUMTHREADS; i++) {
        pthread_join(tid[i], NULL);
    }

    printf("main: all threads executed!\n");

    return 0;
}


void* producer(void *parm) {
    char items[NUMITEMS] = "IT'S A SMALL WORLD, AFTER ALL.";
    int i;
    printf("producer: started...\n");
    for (i = 0; i < NUMITEMS; i++) {
        if (items[i] == '\0') break;
        pthread_mutex_lock(&(buffer.mutex));
        if (buffer.occupied >= BSIZE) { 
            printf("producer: waiting...\n");
            pthread_cond_wait(&(buffer.less), &(buffer.mutex));
        }
        printf("producer: executing...\n");
        buffer.buf[buffer.nextin++] = items[i];
        buffer.nextin %= BSIZE;
        buffer.occupied++;
        pthread_cond_signal(&(buffer.more));
        pthread_mutex_unlock(&(buffer.mutex));
    }

    printf("producer: exiting...\n");
    pthread_exit(0);
}

void* consumer(void *parm) {
    char item;
    int i;
    printf("consumer: started...\n");
    for (i = 0; i < NUMITEMS; i++) {
        pthread_mutex_lock(&(buffer.mutex));
        if (buffer.occupied <= 0) {
            printf("consumer: waiting...\n");
            pthread_cond_wait(&(buffer.more), &(buffer.mutex));
        }
        printf("consumer: executing...\n");
        item = buffer.buf[buffer.nextout++];
        printf("consumer: %c\n", item);
        buffer.nextout %= BSIZE;
        buffer.occupied--;
        pthread_cond_signal(&(buffer.less));
        pthread_mutex_unlock(&(buffer.mutex));
    }

    printf("consumer: exiting...\n");
    pthread_exit(0);
}