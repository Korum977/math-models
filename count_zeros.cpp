#include <iostream>
using namespace std;

int countZeros(int arr[], int size) {
    int count = 0;
    
    __asm__ volatile(
        "mov %1, %%ecx\n\t"    // размер в ecx
        "mov %2, %%esi\n\t"    // адрес массива в esi
        "xor %%eax, %%eax\n\t" // обнуляем счетчик
        "1:\n\t"
        "cmpl $0, (%%esi)\n\t" // сравниваем с нулем
        "jne 2f\n\t"
        "inc %%eax\n\t"        // увеличиваем счетчик
        "2:\n\t"
        "add $4, %%esi\n\t"    // следующий элемент
        "loop 1b\n\t"
        "mov %%eax, %0"        // сохраняем результат
        : "=r" (count)
        : "r" (size), "r" (arr)
        : "%ecx", "%esi", "%eax"
    );
    
    return count;
}

int main() {
    int arr[] = {0, 5, 0, 7, 0, 9, 1, 0, 3};
    int size = sizeof(arr) / sizeof(arr[0]);
    
    cout << "Массив: ";
    for (int i = 0; i < size; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;
    
    int zeros = countZeros(arr, size);
    cout << "Количество нулевых элементов: " << zeros << endl;
    
    return 0;
} 