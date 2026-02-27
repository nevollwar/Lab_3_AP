using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lab_3 // Твое название проекта
{
    public partial class Form1 : Form
    {
        // Объявление массива
        private int[] numbersArray;

        public Form1()
        {
            InitializeComponent();
        }

        // 1. Генерация данных
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Берем размер массива из элемента управления (кастуем в int, так как Value это decimal)
            int size = (int)numSize.Value;
            numbersArray = new int[size];

            Random rnd = new Random();

            // Заполняем массив случайными числами. 
            // Беру диапазон с отрицательными числами, чтобы суммы были разнообразнее.
            for (int i = 0; i < size; i++)
            {
                numbersArray[i] = rnd.Next(-5000, 5000);
            }

            // САМОЕ ВАЖНОЕ: Метод двух указателей требует отсортированного массива.
            // Поэтому я сразу сортирую сгенерированный массив встроенным методом.
            Array.Sort(numbersArray);

            // Разблокируем кнопку запуска алгоритмов, так как данные готовы
            btnRun.Enabled = true;

            // Вывожу инфу для пользователя
            lblStatus.Text = $"Массив из {size} элементов успешно сгенерирован и отсортирован!";
            lblStatus.ForeColor = System.Drawing.Color.Green;
        }

        // 2. Алгоритмы поиска

        // Алгоритм 1: Метод полного перебора (Сложность O(N^2))
        private string BruteForceSearch(int[] arr, int target, out long operationsCount)
        {
            operationsCount = 0;

            // Внешний цикл берет первый элемент
            for (int i = 0; i < arr.Length - 1; i++)
            {
                // Внутренний цикл перебирает все ОСТАВШИЕСЯ элементы (начинаем с i + 1)
                for (int j = i + 1; j < arr.Length; j++)
                {
                    operationsCount++; // Считаем каждую проверку (if)

                    if (arr[i] + arr[j] == target)
                    {
                        // Как только нашли первую подходящую пару — выходим
                        return $"[{arr[i]}] + [{arr[j]}] = {target}";
                    }
                }
            }
            return "Пара не найдена";
        }

        // Алгоритм 2: Метод двух указателей (Сложность O(N))
        private string TwoPointersSearch(int[] arr, int target, out long operationsCount)
        {
            operationsCount = 0;

            // Ставим "пальцы" на начало и конец массива
            int left = 0;
            int right = arr.Length - 1;

            // Идем навстречу друг другу, пока указатели не пересекутся
            while (left < right)
            {
                operationsCount++; // Считаем каждую итерацию цикла while

                long currentSum = arr[left] + arr[right];

                if (currentSum == target)
                {
                    // Нашли!
                    return $"[{arr[left]}] + [{arr[right]}] = {target}";
                }
                else if (currentSum < target)
                {
                    // Если сумма меньше цели, значит левое число слишком маленькое. 
                    // Так как массив отсортирован, сдвигаем левый указатель вправо, чтобы увеличить сумму.
                    left++;
                }
                else // currentSum > target
                {
                    // Если сумма больше цели, правое число слишком большое.
                    // Сдвигаем правый указатель влево, чтобы уменьшить сумму.
                    right--;
                }
            }

            return "Пара не найдена";
        }

        // 3. Запуск и замеры
        private void btnRun_Click(object sender, EventArgs e)
        {
            int target = (int)numTarget.Value;

            // Очищаю старые результаты из таблицы перед новым запуском
            gridResults.Rows.Clear();

            // Создаю объект Stopwatch для точного замера времени
            Stopwatch stopwatch = new Stopwatch();

            // --- ТЕСТ 1: ПОЛНЫЙ ПЕРЕБОР ---
            stopwatch.Start();
            string resultBrute = BruteForceSearch(numbersArray, target, out long opsBrute);
            stopwatch.Stop();

            // Я решил использовать ElapsedTicks (типы времени процессора), а не миллисекунды.
            // Причина: алгоритмы могут работать настолько быстро (особенно на O(N)), 
            // что миллисекунды покажут "0 ms", а тики покажут реальную разницу.
            long timeBrute = stopwatch.ElapsedTicks;

            // Добавляем строку в DataGridView
            gridResults.Rows.Add("Полный перебор O(N^2)", $"{timeBrute} тиков", opsBrute, resultBrute);

            // --- ТЕСТ 2: ДВА УКАЗАТЕЛЯ ---
            stopwatch.Reset(); // Обязательно сбрасываем таймер перед вторым тестом!

            stopwatch.Start();
            string resultPointers = TwoPointersSearch(numbersArray, target, out long opsPointers);
            stopwatch.Stop();
            long timePointers = stopwatch.ElapsedTicks;

            gridResults.Rows.Add("Два указателя O(N)", $"{timePointers} тиков", opsPointers, resultPointers);

            lblStatus.Text = "Сравнение завершено. Посмотрите таблицу!";
            lblStatus.ForeColor = System.Drawing.Color.Blue;
        }
    }
}