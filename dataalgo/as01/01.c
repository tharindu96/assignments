#include <stdio.h>

int main() {
  int mark[4];

  mark[0] = 23;
  mark[1] = 34;  
  mark[2] = 65;  
  mark[3] = 74;

  int sum = 0;
  
  for(int i = 0; i < 4; i++) {
      printf("%d\n", mark[i]);
      sum += mark[i];
  }

  printf("sum: %d\n", sum);
  
  return 0;
}
