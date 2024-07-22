using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TelegramCalculator.Services.Abstractions;

namespace TelegramCalculator.Services
{
    public class ProcessingExpression : IProcessingExpression
    {
        private readonly IProcessingNumbers _processingNumbers;

        public ProcessingExpression()
        {
            _processingNumbers = new ProcessingNumbers();
        }

        public List<object> ParseExpression(string expression)
        {
            var pattern = @"pi|e|[0-9\.]+|[+-^√!°%/*//]";
            var matches = Regex.Matches(expression, pattern);
            var newLst = new List<object>();
            

            foreach (Match match in matches)
            {
                string part = match.Value;
                bool isFloat = _processingNumbers.IsFloat(part);
                if (isFloat)
                {
                    newLst.Add(float.Parse(part));
                }
                else
                {
                    newLst.Add(part);
                }
            }

            return newLst;
        }

        public string RemoveBrackets(string expression)
        {
            var startBracketIndex = -1;

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    startBracketIndex = i;
                }
            }
            var endBracketIndex = -1;

            for (int j = startBracketIndex; j < expression.Length; j++)
            {
                if (expression[j] == ')')
                {
                    endBracketIndex = j;
                    break;
                }
            }

            var partOfExpression = expression.Substring(startBracketIndex, endBracketIndex - startBracketIndex + 1);

            return partOfExpression;
        }
    }
}