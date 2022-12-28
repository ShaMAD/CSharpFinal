//Написать программу, которая из имеющегося массива строк формирует новый массив из строк,
//длина которых меньше, либо равна 3 символам. Первоначальный массив можно ввести с клавиатуры,
//либо задать на старте выполнения алгоритма.
//При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

//Примеры:
//[“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
//[“1234”, “1567”, “-2”, “computer science”] → [“-2”]
//[“Russia”, “Denmark”, “Kazan”] → []

namespace CSharpFinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] myArray = GetInputStringToArray("Введите слова через пробел (символ ' '): ", ' ');
            Console.WriteLine();

            //готовое решение Linq
            var smallArray = myArray
                .Where(e => e.Length <= 3)
                .ToArray();
            PrintStringArray(smallArray, "Самый простой способ Linq:    ");

            //ручной способ с методами
            string[] manualSmallArray = ResizeTrimToLength(myArray, 3);
            PrintStringArray(manualSmallArray, "Ручной спопоб с Array.Resize: ");

            //ручной способ
            string[] fullManualSmallArray = FullManualTrimToLength(myArray, 3);
            PrintStringArray(fullManualSmallArray, "Полностью ручной перебор:     ");

            //рекурсивный способ
            string[] recurseArray = RecurseTrimToLength(myArray, 3, myArray.Length).Split(' ');
            PrintStringArray(recurseArray, "Поиск через рекурсию:         ");

            Console.WriteLine("Не YAGNI конечно, скучно для итоговой...");
        }

        /// <summary>
        /// Сокращение массива с использованиес Array.Resize
        /// </summary>
        /// <param name="array">Массив</param>
        /// <param name="maxstringlength">Количество символов на выходе</param>
        /// <returns>Сокращенный массив</returns>
        static string[] ResizeTrimToLength(string[] array, int maxstringlength)
        {
            string[] smallArray = new string[0];

            for (int i = 0, j = 0; i < array.Length; i++)
                if (array[i].Length <= maxstringlength)
                {
                    Array.Resize(ref smallArray, ++j);
                    smallArray[j - 1] = array[i];
                }
            return smallArray;
        }

        /// <summary>
        /// Ручное сокращение массива
        /// </summary>
        /// <param name="array">Массив строк</param>
        /// <param name="maxstringlength">Количество символов на выходе</param>
        /// <returns>Сокращенный массив</returns>
        static string[] FullManualTrimToLength(string[] array, uint maxstringlength)
        {
            uint[] indexesArray = new uint[array.Length];
            uint indexCounter = 0;

            for (uint i = 0; i < array.Length; i++)
                if (array[i].Length <= maxstringlength)
                    indexesArray[indexCounter++] = i;

            string[] returnArrray = new string[indexCounter];

            for (int i = 0; i < indexCounter; i++)
                returnArrray[i] = array[indexesArray[i]];

            return returnArrray;
        }

        /// <summary>
        /// Рекурсивный поиск элементов массива
        /// </summary>
        /// <param name="array">Массив строк</param>
        /// <param name="maxstringlength">Количество символов на выходе</param>
        /// <param name="len">Длинна массива</param>
        /// <param name="text">Строка для сборки текста</param>
        /// <param name="pos">Позиция в массиве</param>
        /// <returns>Строка с подходящими элементами через пробел</returns>
        static string RecurseTrimToLength(string[] array, uint maxstringlength, int len, string text = "", uint pos = 0)
        {
            if (pos == len)
                return text;
            return (array[pos].Length <= maxstringlength) ?
                RecurseTrimToLength(array, maxstringlength, len, text + array[pos] + " ", ++pos) :
                RecurseTrimToLength(array, maxstringlength, len, text, ++pos);
        }

        /// <summary>
        /// Печать массива
        /// </summary>
        /// <param name="array">Одномерный массив</param>
        /// <param name="text">Текст для вывода перед массивом</param>
        static void PrintStringArray(string[] array, string text)
        {
            Console.Write(text);
            for (uint i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
            Console.WriteLine();
        }

        /// <summary>
        /// Запрос на ввод строки с клавиатуры и разделение её на слова через разделитель
        /// </summary>
        /// <param name="text">Текст для отображения пользователю</param>
        /// <param name="sep">Символ разделителя</param>
        /// <returns>Массив слов</returns>
        static string[] GetInputStringToArray(string text, char sep)
        {
            Console.Write(text);
            string[] parsedArray = Console.ReadLine()!.Trim().Split(' ');
            return parsedArray;
        }
    }
}