using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.Settings
{
    public class SettingsGuessRandom : SettingsGuess, IRandom
    {
        /// <summary>
        /// Начало со случайными настройками.
        /// </summary>
        public SettingsGuessRandom() : base() { }
        
        /// <summary>
        /// Фиксация выбранных настроек на время игры.
        /// </summary>
        /// <returns></returns>
        public override string Start()
        {
            if (_blocked) return " Игра уже идет";

            Random();
            _blocked = true;
            return " Настройки применены: " + GetInfo() + "\r\n Приятной игры!";
        }
        /// <summary>
        /// Настройки со случайными значениями.
        /// </summary>
        public string Random()
        {
            _option[1] = new Random().Next(10, 100);
            _option[2] = _option[1] / 10;

            return ToDescription(new int[] { 0, _option[1], _option[2] });
        }
    }
}
