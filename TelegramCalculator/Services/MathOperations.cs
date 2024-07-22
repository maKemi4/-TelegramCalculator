using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramCalculator.Services.Abstractions;

namespace TelegramCalculator.Services
{
    public class MathOperations : IMathOperations
    {
        private readonly IProcessingNumbers _processingNumbers;

        public MathOperations()
        {
            _processingNumbers = new ProcessingNumbers();
        }

        public List<object> Operations(List<object> expressionLst)
        {
            while (expressionLst.Count > 1)
            {
                expressionLst = _processingNumbers.ProcessingNegativeNumbers(expressionLst);
                if (expressionLst.Contains("e"))
                {
                    var index = expressionLst.IndexOf("e");
                    expressionLst[index] = (float)Math.E;
                }
                else if (expressionLst.Contains("pi"))
                {
                    var index = expressionLst.IndexOf("pi");
                    expressionLst[index] = (float)Math.PI;
                }
                else if (expressionLst.Contains("+"))
                {
                    var index = expressionLst.IndexOf("+");
                    var temp = (float)expressionLst[index - 1] + (float)expressionLst[index + 1];
                    expressionLst[index] = temp;
                    expressionLst.RemoveAt(index - 1);
                    expressionLst.RemoveAt(index);
                }
                else if (expressionLst.Contains("-"))
                {
                    var index = expressionLst.IndexOf("-");
                    var temp = (float)expressionLst[index - 1] - (float)expressionLst[index + 1];
                    expressionLst[index] = temp;
                    expressionLst.RemoveAt(index - 1);
                    expressionLst.RemoveAt(index);
                }
                else if (expressionLst.Contains("*"))
                {
                    var index = expressionLst.IndexOf("*");
                    var temp = (float)expressionLst[index - 1] * (float)expressionLst[index + 1];
                    expressionLst[index] = temp;
                    expressionLst.RemoveAt(index - 1);
                    expressionLst.RemoveAt(index);
                }
                else if (expressionLst.Contains("/"))
                {
                    var index = expressionLst.IndexOf("/");
                    var temp = (float)expressionLst[index - 1] / (float)expressionLst[index + 1];
                    expressionLst[index] = temp;
                    expressionLst.RemoveAt(index - 1);
                    expressionLst.RemoveAt(index);
                }
                else if (expressionLst.Contains("%"))
                {
                    var index = expressionLst.IndexOf("%");
                    var temp = (float)expressionLst[index - 1] / 100;
                    expressionLst[index] = temp;
                    expressionLst.RemoveAt(index - 1);
                }
                else if (expressionLst.Contains("√"))
                {
                    var index = expressionLst.IndexOf("√");
                    var temp = Math.Sqrt((float)expressionLst[index + 1]);
                    expressionLst[index] = (float)temp;
                    expressionLst.RemoveAt(index + 1);
                }
                else if (expressionLst.Contains("^"))
                {
                    var index = expressionLst.IndexOf("^");
                    var temp = Math.Pow((float)expressionLst[index - 1], (float)expressionLst[index + 1]);
                    expressionLst[index] = (float)temp;
                    expressionLst.RemoveAt(index - 1);
                    expressionLst.RemoveAt(index);
                }
            }
            return expressionLst;
        }
    }
}
