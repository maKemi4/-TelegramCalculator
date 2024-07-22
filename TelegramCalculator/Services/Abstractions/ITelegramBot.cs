using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramCalculator.Services.Abstractions
{
    public interface ITelegramBot
    {
        void Start(string[] args);
        void Update(ITelegramBotClient client, Update update, CancellationToken token);
        void Erorr(ITelegramBotClient client, Exception exception, CancellationToken token);
    }
}