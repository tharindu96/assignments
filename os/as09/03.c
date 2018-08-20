#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>

#define MATRIX_A 0
#define MATRIX_B 1
#define MATRIX_R 2

typedef unsigned int uint;

typedef struct {
    uint m;
    uint n;
    int *data;
} Matrix;

typedef struct {
    uint i;
    uint j;
} ThreadData;

static inline uint matrix_get_pos(uint i, uint j, Matrix *matrix) {
    return i * matrix->n + j;
}

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

    uint thread_count = R->m * R->n;
    pthread_t *threads = (pthread_t*) malloc(sizeof(pthread_t) * thread_count);
    ThreadData *thread_data = (ThreadData*) malloc(sizeof(ThreadData) * thread_count);
    int ret;

    for (uint i = 0; i < thread_count; i++) {
        thread_data[i].i = i / R->n;
        thread_data[i].j = i % R->n;

        ret = pthread_create(&threads[i], NULL, slave, (void*)&thread_data[i]);

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

    // clear memory

    free(threads);
    free(thread_data);
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
    ThreadData *tdata = (ThreadData*) data;
    Matrix *R = &matrices[MATRIX_R];
    R->data[matrix_get_pos(tdata->i, tdata->j, R)] = matrix_cell_multiply(tdata->i, tdata->j);
    pthread_exit(0);
}