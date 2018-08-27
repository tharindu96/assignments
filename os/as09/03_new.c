#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>

#define MATRIX_A 0
#define MATRIX_B 1
#define MATRIX_R 2

#define MAX_THREADS 20000

typedef unsigned int uint;

typedef struct {
    uint m;
    uint n;
    int *data;
} Matrix;

typedef struct _ThreadJob {
    uint i;
    uint j;
    struct _ThreadJob *next;
} ThreadJob;

typedef struct {
    uint count;
    pthread_mutex_t mtx;
    ThreadJob *head;
    ThreadJob *tail;
} JobQueue;

static inline uint min(uint m, uint n) {
    if (m > n) return n; else return m;
}

static inline uint matrix_get_pos(uint i, uint j, Matrix *matrix) {
    return i * matrix->n + j;
}

JobQueue* jobqueue_init();
void jobqueue_free(JobQueue *queue);
void jobqueue_enqueue(JobQueue *queue, ThreadJob *job);
void jobqueue_dequeue(JobQueue *queue, ThreadJob **job);

ThreadJob* threadjob_init(uint i, uint j);
void threadjob_free(ThreadJob *job);

void matrix_init(Matrix *matrix, uint m, uint n);
void matrix_free(Matrix *matrix);

void matrix_generate(Matrix *matrix);

void matrix_enter_dimensions(Matrix *matrix);
void matrix_enter_data(Matrix *matrix);

void matrix_print(Matrix *matrix);

uint matrix_cell_multiply(uint i, uint j);

void *slave(void *data);

Matrix matrices[3];

int main(int argc, char const *argv[])
{
    Matrix *A = &matrices[MATRIX_A];
    Matrix *B = &matrices[MATRIX_B];
    Matrix *R = &matrices[MATRIX_R];
    
    printf("Enter Dimensions for Matrix A\n");
    matrix_enter_dimensions(A);

    printf("Enter Dimensions for Matrix B\n");
    matrix_enter_dimensions(B);

    if (A->n != B->m) {
        printf("Error: Matrix Dimensions does not satify for multiplication!\n");
        matrix_free(A);
        matrix_free(B);
        return 0;
    }

    matrix_generate(A);
    matrix_generate(B);

    // printf("Enter Data for Matrix A\n");
    // matrix_enter_data(A);

    // printf("Enter Data for Matrix B\n");
    // matrix_enter_data(B);

    matrix_init(R, A->n, B->m);

    uint job_count = R->m * R->n;
    uint thread_count = min(job_count, MAX_THREADS);

    JobQueue *queue = jobqueue_init();

    pthread_t *threads = (pthread_t*) malloc(sizeof(pthread_t) * thread_count);
    ThreadJob *job;
    int ret;

    // ThreadJob *thread_job = (ThreadJob*) malloc(sizeof(ThreadJob) * thread_count);

    for (uint i = 0; i < job_count; i++) {
        job = threadjob_init(i / R->n, i % R->n);
        jobqueue_enqueue(queue, job);
    }

    for (uint i = 0; i < thread_count; i++) {
        ret = pthread_create(&threads[i], NULL, slave, (void*)queue);
        if (ret) {
            printf("Error: pthread_create\n");
            exit(-1);
        }
    }

    for (uint i = 0; i < thread_count; i++) {
        pthread_join(threads[i], NULL);
    }

    printf("Matrix A:\n");
    matrix_print(A);

    printf("Matrix B:\n");
    matrix_print(B);

    printf("R = A * B Matrix:\n");
    matrix_print(R);

    // // clear memory

    jobqueue_free(queue);
    free(threads);
    matrix_free(A);
    matrix_free(B);
    matrix_free(R);
    
    return 0;
}

void matrix_init(Matrix *matrix, uint m, uint n) {
    matrix->m = m;
    matrix->n = n;
    matrix->data = (int*) malloc(sizeof(int) * (matrix->m * matrix->n));
}

void matrix_generate(Matrix *matrix) {
    for (uint i = 0; i < matrix->m; i++) {
        for (uint j = 0; j < matrix->n; j++) {
            matrix->data[matrix_get_pos(i, j, matrix)] = (int)(((float)rand() / RAND_MAX) * 200);
        }
    }
}

void matrix_enter_dimensions(Matrix *matrix) {

    uint m, n;

    printf("# of Rows: ");
    scanf("%d", &m);

    printf("# of Columns: ");
    scanf("%d", &n);

    matrix_init(matrix, m, n);
}

void matrix_enter_data(Matrix *matrix) {
    for (uint i = 0; i < matrix->m; i++) {
        for (uint j = 0; j < matrix->n; j++) {
            printf("Enter value at (%d, %d): ", i+1, j+1);
            scanf("%d", &matrix->data[matrix_get_pos(i, j, matrix)]);
        }
    }
}

void matrix_free(Matrix* matrix) {
    free(matrix->data);
    matrix->m = 0;
    matrix->n = 0;
}

void matrix_print(Matrix *matrix) {
    for (uint i = 0; i < matrix->m; i++) {
        for (uint j = 0; j < matrix->n; j++) {
            printf("%d ", matrix->data[matrix_get_pos(i, j, matrix)]);
        }
        printf("\n");
    }
}

uint matrix_cell_multiply(uint i, uint j) {
    Matrix *A = &matrices[MATRIX_A];
    Matrix *B = &matrices[MATRIX_B];
    uint res = 0;
    for (uint k = 0; k < A->n; k++) {
        res += A->data[matrix_get_pos(i, k, A)] * B->data[matrix_get_pos(k, j, B)];
    }
    return res;
}

void *slave(void *data) {
    JobQueue *queue = (JobQueue*) data;

    ThreadJob *tjob = NULL;
    jobqueue_dequeue(queue, &tjob);

    while (tjob != NULL) {
        Matrix *R = &matrices[MATRIX_R];
        R->data[matrix_get_pos(tjob->i, tjob->j, R)] = matrix_cell_multiply(tjob->i, tjob->j);
        threadjob_free(tjob);
        jobqueue_dequeue(queue, &tjob);
    }

    pthread_exit(0);
}

JobQueue* jobqueue_init() {
    JobQueue *q = malloc(sizeof(JobQueue));
    q->head = NULL;
    q->tail = NULL;
    pthread_mutex_init(&q->mtx, NULL);
    q->count = 0;
    return q;
}

void jobqueue_free(JobQueue *queue) {
    ThreadJob *job;
    if (queue->count > 0) {
        while (queue->head != NULL) {
            job = queue->head;
            queue->head = queue->head->next;
            threadjob_free(job);
        }
    }
    pthread_mutex_destroy(&queue->mtx);
    free(queue);
}

void jobqueue_enqueue(JobQueue *queue, ThreadJob *job) {
    pthread_mutex_lock(&queue->mtx);

    if (queue->count == 0) {
        queue->head = job;
        queue->tail = job;
    } else {
        queue->tail->next = job;
        queue->tail = queue->tail->next;
    }

    queue->count++;

    pthread_mutex_unlock(&queue->mtx);
}

void jobqueue_dequeue(JobQueue *queue, ThreadJob **job) {
    pthread_mutex_lock(&queue->mtx);

    if(queue->count > 0) {
        *job = queue->head;
        queue->head = (*job)->next;
        queue->count--;
    } else {
        *job = NULL;
    }

    pthread_mutex_unlock(&queue->mtx);
}

ThreadJob* threadjob_init(uint i, uint j) {
    ThreadJob *job = malloc(sizeof(ThreadJob));
    job->i = i;
    job->j = j;
    job->next = NULL;
    return job;
}

void threadjob_free(ThreadJob *job) {
    job->next = NULL;
    free(job);
}