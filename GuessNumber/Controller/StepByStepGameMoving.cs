
namespace GuessNumber.Controller
{
    internal static class StepByStepGameMoving
    {
        /// <summary>
        /// Проведение пошаговой игры.
        /// </summary>
        /// <param name="game"></param>
        internal static void UndertookGame(this Game.Game game)
        {
            Console.WriteLine(game.Start());
            string message;
            while (game.Move(CheckPositiveIntegeAndExit(8), out message))
            {
                Console.WriteLine(message);
            }
            Console.WriteLine(message);

            var command = CheckValueByEnum(typeof(GemaCommands), 9);

            if (command == ((GemaCommands)0).ToString())
            {
                game.Reset();
                game.UndertookGame();
            }
        }

        internal static int CheckPositiveIntegeAndExit(int numberExpression)
        {
            ProvideescriptionCommands(typeof(StopCommands), 11);
            Console.WriteLine(GetExpressions(numberExpression));
            string value = Console.ReadLine();
            if (value == ((StopCommands)0).ToString()) return -1;
            if (int.TryParse(value, out int numbersMove) && numbersMove > 0)
            {
                return numbersMove;
            }
            else
            {
                Console.WriteLine(GetExpressions(6));
                return CheckPositiveIntegeAndExit(numberExpression);
            }
        }

        /// <summary>
        /// Ввод целого положительного числа по запросу.
        /// </summary>
        /// <param name="numberExpression">Номер запроса.</param>
        /// <returns></returns>
        internal static int CheckPositiveIntege(this int numberExpression)
        {
            Console.WriteLine(numberExpression.GetExpressions());
            if (int.TryParse(Console.ReadLine(), out int numbersMove) && numbersMove > 0)
            {
                return numbersMove;
            }
            else
            {
                Console.WriteLine(6.GetExpressions());
                return numberExpression.CheckPositiveIntege();
            }
        }

        /// <summary>
        /// Ввод команды по запросу.
        /// </summary>
        /// <param name="type">Перечеслитель вариантов команд запроса</param>
        /// <param name="intnumberExpression">Номер запроса.</param>
        /// <returns></returns>
        internal static string CheckValueByEnum(this Type type, int intnumberExpression)
        {
            ProvideescriptionCommands(type, intnumberExpression);
            string value = Console.ReadLine();
            if (Enum.IsDefined(type, value)) { return value; }
            else
            {
                Console.WriteLine(GetExpressions(7));
                return CheckValueByEnum(type, intnumberExpression);
            }
        }
        //Получить выражение по коду.
        internal static string GetExpressions(this int key)
        {
            if (Expressions.TryGetValue(key, out string? value))
            {
                return value;
            }
            return string.Empty;
        }
        /// <summary>
        /// Получить описание команд.
        /// </summary>
        /// <param name="type">Enum с командами.</param>
        /// <param name="offsetkeeping">Порядковый номер хранения в словаре.</param>
        internal static void ProvideescriptionCommands(Type type, int offsetkeeping)
        {
            var values = Enum.GetValues(type);
            for (int i = offsetkeeping; i < offsetkeeping + values.Length; i++)
            {
                Console.WriteLine(GetExpressions(i));
            }
        }
        internal static Dictionary<int, string> Expressions = new Dictionary<int, string>()
        {
            { 0,"Приветстую, играем в угадай число." } ,
            { 1,$"[{(Variants)0}] - Получить случайные параметы игры;" } ,
            { 2,$"[{(Variants)1}] - Задать параметры игры;" } ,
            { 3,$"[{(Variants)2}] - Закончить игру." } ,
            { 4,"Введите число ходов:" } ,
            { 5,"Введите ограничение максимального числа угадывания." } ,
            { 6,"Вы ввели не целое положительное чисило!" } ,
            { 7,"Вы ввели неизвестную команду." } ,
            { 8,"Введите загаданное число." } ,
            { 9,$"[{(GemaCommands)0}] - Начать сначала;" } ,
            { 10,$"[{(GemaCommands)1}] - Вернуться к выбору игры;" } ,
            { 11,$"[{(StopCommands)0}] - Остановить текущий сеанс;" } ,
        };
    }
    internal enum Variants
    {
        R = 0,
        S = 1,
        E = 2,
    }
    internal enum GemaCommands
    {
        R = 0,
        E = 1,
    }
    internal enum StopCommands
    {
        S = 0,
    }
}
