#include <iostream>
using namespace std;

int countZeros(int arr[], int size) {
    int count = 0;
    
    __asm__ __volatile__(
        "movl %1, %%ecx\n"
        "movl %2, %%esi\n"
        "xorl %%eax, %%eax\n"
        "1:\n"
        "cmpl $0, (%%esi)\n"
        "jne 2f\n"
        "incl %%eax\n"
        "2:\n"
        "addl $4, %%esi\n"
        "loop 1b\n"
        "movl %%eax, %0\n"
        : "=r" (count)
        : "r" (size), "r" (arr)
        : "%eax", "%ecx", "%esi"
    );
    
    return count;
}

int main() {
    setlocale(LC_ALL, "Russian");
    
    int arr[] = {0, 5, 0, 7, 2, 0, 9, 0, 1};
    int size = sizeof(arr) / sizeof(arr[0]);
    
    cout << "Массив: ";
    for (int i = 0; i < size; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;
    
    int zeroCount = countZeros(arr, size);
    cout << "Количество нулевых элементов: " << zeroCount << endl;
    
    return 0;
} 