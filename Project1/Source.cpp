#include <iostream>
using namespace std;

int countZeros(int arr[], int len) {  // Changed parameter name from size to len
    int count = 0;
    
    __asm {
        mov ecx, len     ; Load len into counter (changed from size)
        mov esi, arr     ; Load array address
        xor eax, eax     ; Clear accumulator for counting
        
    loop_start:
        cmp DWORD PTR [esi], 0  ; Compare array element with 0
        jne skip_count          ; Skip if not equal
        inc eax                 ; Increment counter if zero found
        
    skip_count:
        add esi, 4             ; Move to next array element
        loop loop_start        ; Decrement ecx and loop if not zero
        
        mov count, eax         ; Store final count
    }
    
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