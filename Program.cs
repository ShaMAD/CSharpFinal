//Написать программу, которая из имеющегося массива строк формирует новый массив из строк,
//длина которых меньше, либо равна 3 символам. Первоначальный массив можно ввести с клавиатуры,
//либо задать на старте выполнения алгоритма.
//При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

//Примеры:
//[“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
//[“1234”, “1567”, “-2”, “computer science”] → [“-2”]
//[“Russia”, “Denmark”, “Kazan”] → []

using System.Reflection.Metadata;

namespace CSharpFinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] myArray = GetInputStringToArray();
            Console.WriteLine("Hello, World!");


        }
        /// <summary>
        /// Запрос на ввод строки с клавиатуры и разделение её на слова через разделитель
        /// </summary>
        /// <returns></returns>
        private static string[] GetInputStringToArray()
        {
            Console.Write("Введите слова через пробел: ");
            string userInput = Console.ReadLine()!.Trim();
            string[] parsedArray = userInput.Split(' ');
            return parsedArray;
    }
    }
}