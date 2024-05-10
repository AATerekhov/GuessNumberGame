using GuessNumber.Settings;
using System;

namespace GuessNumber.Game
{
    public class GuessNumberGame : Game
    {
        bool _blocked;
        int _riddle;
        int _numberStep;
        /// <summary>
        /// Игра со случайными настройками.
        /// </summary>
        public GuessNumberGame() : base(new SettingsGuessRandom()) { }
        /// <summary>
        /// Игра с начальными настройками
        /// </summary>
        /// <param name="option">Базовые настройки.</param>
        public GuessNumberGame(int[] option) : base(new SettingsGuessManual(option[0], option[1])) { }
        /// <summary>
        /// Сделать ход.
        /// </summary>
        /// <param name="actions"></param>
        /// <returns></returns>
        public override bool Move(int actions,out string message)
        {
            if (!_blocked) 
            {
                message = " Игра не начата, выполните команду Start()";
                return false; 
            }
            if (actions == -1) 
            {
                message = " Игра остановлена.";
                return false;
            }

            _numberStep++;
            int remainingSteps = Settings.GetOptions()[2] - _numberStep;
            //Условия окончания игры.
            if (remainingSteps == 0 || actions == _riddle)
            {
                message = Finish(actions);
                return false;
            }
            else
            {
                message = AnalysisOfProgress(actions, remainingSteps);
                return true;
            }            
        }
        /// <summary>
        /// Начать игру.
        /// </summary>
        /// <returns></returns>
        public override string Start()
        {
            string comment = base.Start();
            _riddle = GetRiddle(Settings.GetOptions()[0], Settings.GetOptions()[1]);
            _blocked = true;
            return comment;
        }
        /// <summary>
        /// Сбросить игру.
        /// </summary>
        public override void Reset()
        {
            Finish();
            base.Reset();
        }
        /// <summary>
        /// Сгенерировать случайное число.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        int GetRiddle(int start, int end)
        {
            return new Random().Next(start, end);
        }
        /// <summary>
        /// Анализ результата игры.
        /// </summary>
        /// <param name="currentNumber"></param>
        /// <returns></returns>
        string GetRezult(int currentNumber)
        {
            int precision = Math.Abs(_riddle - currentNumber);
            if (precision >= 3) return ((Result)3).ToString();
            else return ((Result)precision).ToString();
        }
        /// <summary>
        /// Вывод результата игры и сброс блоккировки настроек.
        /// </summary>
        /// <param name="actions"></param>
        /// <returns></returns>
        string Finish(int actions)
        {
            string comment = string.Empty;
            comment += " Результат: " + GetRezult(actions);
            comment += "\r\n Загаданное число: " + _riddle;
            Finish();
            return comment;
        }
        /// <summary>
        /// Анализ сделанного хода.
        /// </summary>
        /// <param name="actions">Ход</param>
        /// <param name="remainingSteps">Осталось ходов</param>
        /// <returns></returns>
        string AnalysisOfProgress(int actions, int remainingSteps)
        {
            int answer = 0;
            if (actions > _riddle) { answer = 1; }

            return " " + ((Answers)answer).ToString() + "\r\n Осталось попыток: " + remainingSteps; ;
        }
        public void Finish() 
        {
            _blocked = false;
            _numberStep = 0;
            _riddle = 0;
        }
    }
    public enum Result
    {
        Победа = 0,
        Близко_к_победе = 1,
        Близко_к_поражению = 2,
        Поражение = 3
    }

    /// <summary>
    /// Перечислитель результатов игры.
    /// </summary>
    public enum Answers
    {
        Больше = 0,
        Меньше = 1
    }
}
