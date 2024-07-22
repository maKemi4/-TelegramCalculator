using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramCalculator.Services.Abstractions;

namespace TelegramCalculator.Services
{
    public class Сalculations : IСalculations
    {
        private readonly IProcessingExpression _processingExpression;
        private readonly IMathOperations _mathOperations;

        public Сalculations()
        {
            _processingExpression = new ProcessingExpression();
            _mathOperations = new MathOperations();
        }

        public float EvaluatePart(string partExpression)
        {
            var lst = _processingExpression.ParseExpression(partExpression);
            var result = _mathOperations.Operations(lst);
            return (float)result[0];
        }

        public float EvaluateExpression(string expression)
        {
            if (expression.Contains("("))
            {
                while (true)
                {
                    if (!expression.Contains("("))
                    {
                        break;
                    }
                    var partExpression = _processingExpression.RemoveBrackets(expression);
                    var value = EvaluatePart(partExpression.Substring(1, partExpression.Length - 2));
                    expression = expression.Replace(partExpression, value.ToString());
                    
                }
                return EvaluatePart(expression);
            }
            else
            {
                return EvaluatePart(expression);
            }
        }
    }
}
