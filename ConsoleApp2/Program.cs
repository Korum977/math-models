using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Программа для вычисления произведения cos²(i) от i=1 до n");
        
        try
        {
            Console.Write("Введите значение n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            
            if (n <= 0)
            {
                throw new ArgumentException("Значение n должно быть положительным числом.");
            }
            
            double result = CalculateProduct(n);
            Console.WriteLine($"Результат произведения: {result}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Введено некорректное значение. Пожалуйста, введите целое число.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Ошибка: Введенное значение слишком большое или слишком маленькое.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
        }
        
        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
    
    /// <summary>
    /// Вычисляет произведение cos²(i) от i=1 до n
    /// </summary>
    /// <param name="n">Верхняя граница произведения</param>
    /// <returns>Результат вычисления произведения</returns>
    public static double CalculateProduct(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentException("Значение n должно быть положительным числом.");
        }
        
        double product = 1.0;
        
        for (int i = 1; i <= n; i++)
        {
            double cosSquared = Math.Pow(Math.Cos(i), 2);
            product *= cosSquared;
            
            // Проверка на переполнение или недополнение
            if (double.IsInfinity(product) || double.IsNaN(product))
            {
                throw new OverflowException("Результат вычисления вышел за пределы допустимого диапазона.");
            }
        }
        
        return product;
    }
}
