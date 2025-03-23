using System.Text;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private TextBox[,]? matrixInputs;  // Массив текстовых полей для ввода матрицы
        private int[,]? matrix;            // Матрица значений
        private int matrixSize;            // Размер матрицы n×n

        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик нажатия на кнопку "Создать матрицу"
        private void btnCreateMatrix_Click(object sender, EventArgs e)
        {
            // Получаем размер матрицы из числового поля
            matrixSize = (int)nudMatrixSize.Value;
            
            // Очищаем панель перед созданием новой матрицы
            pnlMatrix.Controls.Clear();
            txtOutput.Clear();
            
            // Создаем массив текстовых полей для ввода матрицы
            matrixInputs = new TextBox[matrixSize, matrixSize];
            
            // Вычисляем размер каждого текстового поля
            int cellSize = Math.Min(40, 400 / matrixSize);
            
            // Создаем текстовые поля для каждого элемента матрицы
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    // Создаем новое текстовое поле
                    matrixInputs[i, j] = new TextBox
                    {
                        Location = new Point(j * (cellSize + 5) + 10, i * (cellSize + 5) + 10),
                        Size = new Size(cellSize, cellSize),
                        TextAlign = HorizontalAlignment.Center,
                        Text = "0", // Значение по умолчанию
                        Tag = $"{i},{j}" // Сохраняем индексы в Tag
                    };

                    // Выделяем элементы на главной диагонали (меняем фон)
                    if (i == j)
                    {
                        matrixInputs[i, j].BackColor = Color.LightYellow;
                    }

                    // Обработчик для проверки ввода (только числа)
                    matrixInputs[i, j].KeyPress += MatrixInput_KeyPress;
                    
                    // Добавляем текстовое поле на панель
                    pnlMatrix.Controls.Add(matrixInputs[i, j]);
                }
            }
            
            // Активируем кнопку сортировки
            btnSortByDiagonal.Enabled = true;
        }

        // Обработчик события KeyPress для проверки ввода (только числа)
        private void MatrixInput_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // Разрешаем ввод цифр, BackSpace и минуса (только в начале)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            // Разрешаем ввод минуса только в начале
            if (e.KeyChar == '-' && sender is TextBox textBox && textBox.SelectionStart != 0)
            {
                e.Handled = true;
            }
        }

        // Обработчик нажатия на кнопку "Сортировать"
        private void btnSortByDiagonal_Click(object sender, EventArgs e)
        {
            if (matrixInputs == null) return;

            try
            {
                // Считываем значения из текстовых полей в массив
                matrix = new int[matrixSize, matrixSize];
                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        if (int.TryParse(matrixInputs[i, j].Text, out int value))
                        {
                            matrix[i, j] = value;
                        }
                        else
                        {
                            throw new FormatException($"Некорректное значение в ячейке [{i+1},{j+1}]");
                        }
                    }
                }

                // Выводим исходную матрицу
                DisplayMatrix("Исходная матрица:", matrix);

                // Сортируем строки матрицы по возрастанию элементов главной диагонали
                SortMatrixByDiagonal();

                // Выводим отсортированную матрицу
                DisplayMatrix("Матрица после сортировки:", matrix);

                // Обновляем отображение в текстовых полях
                UpdateMatrixDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод сортировки строк матрицы по возрастанию элементов главной диагонали
        private void SortMatrixByDiagonal()
        {
            if (matrix == null) return;

            // Создаем список пар (значение диагонального элемента, индекс строки)
            var diagElements = new List<(int value, int rowIndex)>();
            for (int i = 0; i < matrixSize; i++)
            {
                diagElements.Add((matrix[i, i], i));
            }

            // Сортируем список по значению диагонального элемента
            diagElements.Sort();

            // Создаем временную матрицу для хранения отсортированных строк
            int[,] sortedMatrix = new int[matrixSize, matrixSize];
            
            // Заполняем временную матрицу
            for (int i = 0; i < matrixSize; i++)
            {
                int originalRowIndex = diagElements[i].rowIndex;
                
                for (int j = 0; j < matrixSize; j++)
                {
                    sortedMatrix[i, j] = matrix[originalRowIndex, j];
                }
            }
            
            // Копируем отсортированные строки обратно в исходную матрицу
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = sortedMatrix[i, j];
                }
            }
        }

        // Метод вывода матрицы в текстовое поле результатов
        private void DisplayMatrix(string title, int[,] matrix)
        {
            var sb = new StringBuilder();
            sb.AppendLine(title);
            
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    sb.Append(matrix[i, j].ToString().PadLeft(5));
                }
                sb.AppendLine();
            }
            sb.AppendLine();
            
            txtOutput.AppendText(sb.ToString());
        }

        // Метод обновления отображения матрицы в текстовых полях
        private void UpdateMatrixDisplay()
        {
            if (matrix == null || matrixInputs == null) return;
            
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrixInputs[i, j].Text = matrix[i, j].ToString();
                }
            }
        }
    }
}
