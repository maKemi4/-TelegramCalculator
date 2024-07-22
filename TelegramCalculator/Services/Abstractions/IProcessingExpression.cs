using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramCalculator.Services.Abstractions
{
    public interface IProcessingExpression
    {
        List<object> ParseExpression(string expression);
        string RemoveBrackets(string expression);
    }
}