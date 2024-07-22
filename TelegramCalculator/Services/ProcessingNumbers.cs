using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramCalculator.Services.Abstractions;

namespace TelegramCalculator.Services
{
    public class ProcessingNumbers : IProcessingNumbers
    {
        public bool IsFloat(string value) => float.TryParse(value, out var _);

        public List<object> ProcessingNegativeNumbers(List<object> lst)
        {
            List<object> newLst = new List<object>();
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i] is string && (string)lst[i] == "-" &&
                    (i == 0 || !(lst[i - 1] is double)) &&
                    (i + 1 < lst.Count && lst[i + 1] is double))
                {
                    lst[i + 1] = (double)lst[i + 1] * -1;
                }
                else
                {
                    newLst.Add(lst[i]);
                }
            }
            return newLst;
        }
    }
}
