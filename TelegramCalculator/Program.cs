using System;
using Telegram.Bot;
using TelegramCalculator.Services;

namespace TelegramCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TelegramBot telegramBot = new TelegramBot();
            telegramBot.Start(args);
        }
    }
}
