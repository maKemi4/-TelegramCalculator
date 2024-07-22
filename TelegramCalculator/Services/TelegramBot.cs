using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramCalculator.Services.Abstractions;

namespace TelegramCalculator.Services
{
    public class TelegramBot : ITelegramBot
    {
        private static TelegramBotClient _сlient;
        private readonly IСalculations _сalculations;

        public TelegramBot()
        {
            _сalculations = new Сalculations();
        }

        public void Start(string[] args)
        {
            _сlient = new TelegramBotClient("7472290734:AAHq7_RcWwwQFrR7Pf3oz8A7pCQoUlBfxuw");
            _сlient.StartReceiving(Update, Erorr);
            Console.ReadLine();
        }

        public void Update(ITelegramBotClient client, Update update, CancellationToken token)
        {
            var message = update.Message;

            if (message == null)
            {
                client.SendTextMessageAsync(message.Chat.Id, "Send some expression!");
            }
            else
            {
                try
                {
                    var messageText = message.Text;

                    var regex = new Regex(@"^[0-9+\-*/().\s√^]+$");

                    if (regex.IsMatch(messageText))
                    {
                        var total = _сalculations.EvaluateExpression(messageText);
                        var result = $"Wroted expression:  [{message.Text}]. It's equals =  [{total}]";
                        client.SendTextMessageAsync(message.Chat.Id, result);
                    }
                    else
                    {
                        client.SendTextMessageAsync(message.Chat.Id, "Please send a valid mathematical expression!");
                    }
                }
                catch (Exception ex)
                {
                    client.SendTextMessageAsync(message.Chat.Id, "Something goes wrong!");
                }
            }
        }


        public void Erorr(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}