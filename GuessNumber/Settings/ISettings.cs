using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.Settings
{
    /// <summary>
    /// Настройки условий игры.
    /// </summary>
    public interface ISettings
    {
        //фикчация назначенных опций на игру.
        string Start();
        //Сбросить блоккировку.
        void Reset();
        //передать фиксированные опции.
        int[] GetOptions();
    }
}
