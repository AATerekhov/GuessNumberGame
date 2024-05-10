using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.Settings
{
    public class SettingsGuessManual : SettingsGuess
    {
        
        //Предварительное кол-во ходов.
        public int NumberOfMoves { get; set; }

        //Предварительное максимальное число.
        public int MaximumValue { get; set; }

        /// <summary>
        /// Начать с конкретными настройками.
        /// </summary>
        /// <param name="numberOfMoves">Кол. попыток.</param>
        /// <param name="maximumValue">Максимальное загаданное число.</param>
        public SettingsGuessManual(int numberOfMoves, int maximumValue) : base()
        {
            MaximumValue = maximumValue;
            NumberOfMoves = numberOfMoves;
        }
        /// <summary>
        /// Фиксация выбранных настроек на время игры.
        /// </summary>
        /// <returns></returns>
        public override string Start()
        {
            if (_blocked) return " Игра уже идет";

            _option[1] = MaximumValue;
            _option[2] = NumberOfMoves;
            _blocked = true;

            return " Настройки применены: " + GetInfo() + "\r\n Приятной игры!";
        }

    }
}
