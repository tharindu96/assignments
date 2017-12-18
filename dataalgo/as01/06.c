#include <stdio.h>

struct course_unit {
    char *code;
    char *name;
    int credits;
};

int main() {

    struct course_unit course_1;

    char *code = "1142";
    char *name = "Software Engineering";

    course_1.code = code;
    course_1.name = name;
    course_1.credits = 100;

    printf("Code: %s\nName: %s\nCredits: %d\n", course_1.code, course_1.name, course_1.credits);
    

    return 0;
}
