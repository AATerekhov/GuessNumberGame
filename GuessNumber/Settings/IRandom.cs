using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.Settings
{
    /// <summary>
    /// Получить случайные настройки опций.
    /// </summary>
    public interface IRandom
    {
        string Random();
    }
}
