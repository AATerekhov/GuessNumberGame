using GuessNumber.Game;
using GuessNumber.Controller;

namespace GuessNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(0.GetExpressions());
            StartGame();
        }
        // Запуск меню выбора игры.
        static void StartGame() 
        {
            var command = typeof(Variants).CheckValueByEnum(1);

            if (command == ((Variants)0).ToString())
            {
                new GuessNumberGame().UndertookGame();
                StartGame();
            }
            else if (command == ((Variants)1).ToString())
            {
                new GuessNumberGame(GetProperty()).UndertookGame();
                StartGame();
            }
            else return;
        }
        //Запрос ввода параметров игры.
        static int[] GetProperty()
        {
            int[] options = [4.CheckPositiveIntege(), 5.CheckPositiveIntege()];
            return options;
        }
    }
}
