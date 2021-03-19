#include <omp.h>

int main(int argc, char const *argv[])
{
    int i, j;



    #pragma omp parallel shared(a,b,n)
    {
        #pragma omp for schedule(dynamic,1) private (i,j)
        for (i = 1; i < n; i++)
            for (j = 0; j < i; j++)
            b[j + n*i] = (a[j + n*i] + a[j + n*(i-1)]) / 2.0;
    }
    return 0;
}
