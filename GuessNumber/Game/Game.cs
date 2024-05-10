using GuessNumber.Settings;
using System;

namespace GuessNumber.Game
{
    /// <summary>
    /// Инециализирует любую консольную игру.
    /// </summary>
    public abstract class Game
    {
        protected ISettings Settings { get; set; }
        public Game(ISettings settings)
        {
            Settings = settings;
        }
        public virtual bool Move(int actions, out string message)
        {
            message = " Ход сделан.";
            return true;
        }
        public virtual string Start()
        {
            return Settings.Start();
        }
        public virtual void Reset()
        {
            Settings.Reset();
        }
    }
}
