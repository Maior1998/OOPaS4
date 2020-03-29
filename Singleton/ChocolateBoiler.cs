using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    /// <summary>
    /// Представляет собой нагреватель для шоколада.
    /// </summary>
    public class ChocolateBoiler
    {
        /// <summary>
        /// Указывает, согрет ли на данный момент шоколад в нагревателе.
        /// </summary>
        private static bool isboiled;

        /// <summary>
        /// Показывает, закипячен ли нагреватель. Это свойство только для чтения.
        /// </summary>
        public bool isBoiled => isboiled;

        /// <summary>
        /// Указывает, пуст ли сейчас нагреватель.
        /// </summary>
        private static bool isempty;

        /// <summary>
        /// Показывает, пуст ли нагреватель. Это свойство только для чтения.
        /// </summary>
        public bool isEmpty => isempty;

        /// <summary>
        /// Сущность нагревателя, которой все пользуются.
        /// </summary>
        private static readonly ChocolateBoiler instance;
        /// <summary>
        /// Статический конструтор нагревателя. Нужен для заполнения переменной с бойлером (синхронизация потоков) и прочих инициализаций.
        /// </summary>
       
        static ChocolateBoiler()
        {
            instance = new ChocolateBoiler();
        }
        /// <summary>
        /// Инициализирует новый пустой экземпляр бойлера.
        /// </summary>
        
        private ChocolateBoiler()
        {
            isboiled = false;
            isempty = true;
            Console.WriteLine("Boiler Initialized!");
        }

        /// <summary>
        /// Заполняет бойлер шоколадом.
        /// </summary>
        public void Fill()
        {
            if (!isempty) return;
            isempty = false;
            isboiled = false;
            Console.WriteLine("Boiler Filled!!");
        }

        private static readonly object locker = new object();

        /// <summary>
        /// Нагревает шоколад в бойлере, если он там есть.
        /// </summary>
        public void Boil()
        {

            lock (locker)
            {
                if (isempty || isboiled)
                {
                    Console.WriteLine(isempty ? "Boiler is empty!" : "Boiler is already boiled!");
                    return;
                }
                Console.WriteLine($"Start boiling ({Thread.CurrentThread.Name}) . . .");
                Thread.Sleep(5000);
                isboiled = true;
                Console.WriteLine("Boiler Boiled!!");
            }
        }

        /// <summary>
        /// Выливает горячий шоколад из бойлера.
        /// </summary>
        public void Drain()
        {
            if (isempty || !isboiled) return;
            isboiled = false;
            isempty = true;
            Console.WriteLine("Boiler Drained!!");
        }

        /// <summary>
        /// Получает сущность данного бойлера.
        /// </summary>
        /// <returns>Бойлер. Просто бойлер.</returns>
        public static ChocolateBoiler GetBoiler()
        {
            return instance;
        }
    }
}
