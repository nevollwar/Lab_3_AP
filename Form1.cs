using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class Form1 : Form
    {
        // Глобальный массив для хранения данных между нажатиями кнопок
        private int[] numbersArray;

        /// <summary>
        /// Инициализирует главную форму приложения.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        // 1. Генерация данных

        /// <summary>
        /// Обработчик кнопки генерации массива.
        /// Создает массив выбранного размера, заполняет его случайными числами и выполняет сортировку.
        /// Сортировка является обязательным условием для корректной работы алгоритма двух указателей.
        /// </summary>
        /// <param name="sender">Источник события (объект, вызвавший метод - кнопка).</param>
        /// <param name="e">Аргументы события (дополнительная информация о клике).</param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Получаем требуемый размер массива из компонента ввода
            int size = (int)numSize.Value;
            numbersArray = new int[size];

            Random rnd = new Random();

            // Заполнение массива псевдослучайными числами.
            // Используется диапазон с отрицательными значениями для вариативности суммы.
            for (int i = 0; i < size; i++)
            {
                numbersArray[i] = rnd.Next(-5000, 5000);
            }

            // Сортировка массива по возрастанию.
            // Это обязательное условие для корректной работы алгоритма двух указателей.
            Array.Sort(numbersArray);

            // Активация кнопки запуска алгоритмов после успешной подготовки данных
            btnRun.Enabled = true;

            // Обновление статуса в интерфейсе
            lblStatus.Text = $"Массив из {size} элементов успешно сгенерирован и отсортирован.";
            lblStatus.ForeColor = System.Drawing.Color.Green;
        }

        // 2. Алгоритмы поиска

        // Алгоритм 1: Метод полного перебора (Временная сложность O(N^2))

        /// <summary>
        /// Реализует поиск пары чисел с заданной суммой методом полного перебора.
        /// Сравнивает каждый элемент со всеми последующими.
        /// </summary>
        /// <param name="arr">Исходный массив чисел для поиска.</param>
        /// <param name="target">Целевая сумма, которую необходимо найти.</param>
        /// <param name="operationsCount">Возвращаемый параметр (out): счетчик выполненных базовых операций сравнения.</param>
        /// <returns>Строка с результатом: найденная пара чисел или сообщение об их отсутствии.</returns>
        private string BruteForceSearch(int[] arr, int target, out long operationsCount)
        {
            operationsCount = 0;

            // Внешний цикл фиксирует первый элемент пары
            for (int i = 0; i < arr.Length - 1; i++)
            {
                // Внутренний цикл проверяет все последующие элементы
                for (int j = i + 1; j < arr.Length; j++)
                {
                    operationsCount++; // Учет базовой операции сравнения

                    if (arr[i] + arr[j] == target)
                    {
                        // Досрочный выход при нахождении первой подходящей пары
                        return $"[{arr[i]}] + [{arr[j]}] = {target}";
                    }
                }
            }
            return "Пара не найдена";
        }

        // Алгоритм 2: Метод двух указателей (Временная сложность O(N))

        /// <summary>
        /// Реализует поиск пары чисел с заданной суммой оптимизированным методом двух указателей.
        /// Сдвигает левую или правую границу поиска в зависимости от текущей суммы.
        /// Требует предварительно отсортированного массива.
        /// </summary>
        /// <param name="arr">Отсортированный массив чисел.</param>
        /// <param name="target">Целевая сумма, которую необходимо найти.</param>
        /// <param name="operationsCount">Возвращаемый параметр (out): счетчик выполненных итераций цикла.</param>
        /// <returns>Строка с результатом: найденная пара чисел или сообщение об их отсутствии.</returns>
        private string TwoPointersSearch(int[] arr, int target, out long operationsCount)
        {
            operationsCount = 0;

            // Инициализация указателей на границах отсортированного массива
            int left = 0;
            int right = arr.Length - 1;

            // Сдвиг указателей навстречу друг другу
            while (left < right)
            {
                operationsCount++; // Учет итерации цикла

                long currentSum = arr[left] + arr[right];

                if (currentSum == target)
                {
                    // Целевая сумма найдена
                    return $"[{arr[left]}] + [{arr[right]}] = {target}";
                }
                else if (currentSum < target)
                {
                    // Если текущая сумма меньше целевой, сдвигаем левый указатель вправо 
                    // для получения большего значения (т.к. массив отсортирован)
                    left++;
                }
                else
                {
                    // Если сумма больше целевой, сдвигаем правый указатель влево
                    // для получения меньшего значения
                    right--;
                }
            }

            return "Пара не найдена";
        }

        // 3. Запуск исследования

        /// <summary>
        /// Обработчик кнопки запуска тестирования алгоритмов.
        /// Поочередно запускает оба алгоритма поиска, замеряет время их выполнения с помощью Stopwatch 
        /// и выводит результаты в DataGridView.
        /// </summary>
        /// <param name="sender">Источник события (кнопка).</param>
        /// <param name="e">Аргументы события.</param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            int target = (int)numTarget.Value;

            // Очистка предыдущих результатов из таблицы
            gridResults.Rows.Clear();

            // Инициализация таймера для профилирования производительности алгоритмов
            Stopwatch stopwatch = new Stopwatch();

            // Тест 1: Полный перебор
            stopwatch.Start();
            string resultBrute = BruteForceSearch(numbersArray, target, out long opsBrute);
            stopwatch.Stop();

            // Использование ElapsedTicks (тиков процессора) вместо миллисекунд 
            // позволяет корректно отображать время выполнения быстрых алгоритмов.
            long timeBrute = stopwatch.ElapsedTicks;
            gridResults.Rows.Add("Полный перебор O(N^2)", $"{timeBrute} тиков", opsBrute, resultBrute);

            // Тест 2: Два указателя
            stopwatch.Reset(); // Обязательный сброс таймера перед следующим замером

            stopwatch.Start();
            string resultPointers = TwoPointersSearch(numbersArray, target, out long opsPointers);
            stopwatch.Stop();

            long timePointers = stopwatch.ElapsedTicks;
            gridResults.Rows.Add("Два указателя O(N)", $"{timePointers} тиков", opsPointers, resultPointers);

            // Вывод сообщения о завершении работы
            lblStatus.Text = "Анализ завершен. Результаты выведены в таблицу.";
            lblStatus.ForeColor = System.Drawing.Color.Blue;
        }

        // 4. Справочная информация

        /// <summary>
        /// Обработчик вызова справки.
        /// Выводит пользователю всплывающее окно (MessageBox) с инструкцией 
        /// и краткими теоретическими сведениями по алгоритмам.
        /// </summary>
        /// <param name="sender">Источник события (элемент меню).</param>
        /// <param name="e">Аргументы события.</param>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            // Форматирование текста смещено к левому краю, чтобы избежать лишних пробелов в окне MessageBox
            string helpText = @"Лабораторная работа №3. Вариант 30.
Тема: Поиск пары элементов с заданной суммой.

ИНСТРУКЦИЯ ПОЛЬЗОВАТЕЛЯ:
1. В верхнем поле введите желаемый размер массива (от 100 до 10 000 элементов).
2. Во втором поле задайте 'Целевую сумму', которую в сумме должны дать два искомых числа.
3. Нажмите кнопку 'Сгенерировать массив'. Программа создаст случайный массив и отсортирует его (необходимое условие для оптимизированного поиска).
4. Нажмите кнопку 'Запустить алгоритмы'.
5. В таблице ниже появятся результаты сравнения методов по времени выполнения и количеству базовых операций.

Вывод: Оптимизированный метод двух указателей O(N) выполняется быстрее полного перебора O(N^2), так как проходит по массиву всего один раз.

Разработал: Ясенков Никита";

            // Вывод модального окна с информацией
            MessageBox.Show(helpText, "Справка о программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}