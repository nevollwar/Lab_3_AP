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

      
}