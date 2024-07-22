using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramCalculator.Services.Abstractions
{
    public interface IProcessingNumbers
    {
        List<object> ProcessingNegativeNumbers(List<object> lst);
        bool IsFloat(string value);
    }
}