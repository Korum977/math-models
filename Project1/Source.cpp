#include <iostream>
using namespace std;

int countZeros(int arr[], int size) {
    int count = 0;
    
    __asm  volatile(
        "mov %1, %%ecx\n\t"    
        "mov %2, %%esi\n\t"     
        "xor %%eax, %%eax\n\t"     
        
        "loop_start:\n\t"
        "cmpl $0, (%%esi)\n\t"  
        "jne skip_count\n\t"         
        "inc %%eax\n\t"               
        
        "skip_count:\n\t"
        "add $4, %%esi\n\t"           
        "loop loop_start\n\t"      
        "mov %%eax, %0\n\t"       
        : "=r" (count)
        : "r" (size), "r" (arr)
        : "%eax", "%ecx", "%esi"
    );
    
    return count;
}

int main() {
    int arr[] = { 1, 0, 3, 0, 0, 6, 7, 0, 9 };
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