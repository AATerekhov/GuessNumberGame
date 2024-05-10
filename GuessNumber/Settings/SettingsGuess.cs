using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.Settings
{
    public abstract class SettingsGuess : ISettings, IDescription
    {
        protected  bool _blocked;
        /// <summary>
        /// 0 - StartValume,
        /// 1 - MaximumValue,
        /// 2 - NumberOfMoves,
        /// </summary>
        protected int[] _option;

        /// <summary>
        /// Начало со случайными настройками.
        /// </summary>
        public SettingsGuess()
        {
            _option = new int[3];
            _option[0] = 0;
        }

        /// <summary>
        /// Фиксация выбранных настроек на время игры.
        /// </summary>
        /// <returns></returns>
        public virtual string Start()
        {
            if (_blocked) return " Игра уже идет";
            _blocked = true;
            return " Настройки применены: " + GetInfo() + "\r\n Приятной игры!";
        }
        public int[] GetOptions()
        {
            return _option;
        }
        public string GetInfo()
        {
            return ToDescription(_option);
        }
        public void Reset()
        {
            _blocked = false;
        }
        protected string ToDescription(int[] option)
        {
            return " Число от " + option[0] + " до " + option[1] + ", колличество попыток - " + option[2];
        }

    }
}
