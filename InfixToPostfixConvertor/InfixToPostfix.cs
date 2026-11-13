using System.Text;

namespace InfixToPostFixConvertor
{
    public static class InfixToPostfix
    {
        public static string InfixToPostfixConverter(string expression)
        {
            Stack<char> stack = new();
            StringBuilder sb = new();

            foreach(char token in expression)
            {
                if (char.IsWhiteSpace(token)) continue;
                else if (char.IsLetterOrDigit(token))
                {
                    sb.Append(token);
                }else if (token == '(')
                {
                    stack.Push(token);
                }else if(token == ')')
                {
                    while(stack.Count > 0 && stack.Peek() != '(')
                    {
                        sb.Append(stack.Pop());
                    }
                    if (stack.Count == 0)
                        throw new ArgumentException("Mismatched parantheses.");
                    stack.Pop();
                }else if (IsOperator(token))
                {
                    while(stack.Count > 0 &&
                        stack.Peek() != '(' &&
                        GetPrecedence(stack.Peek()) >= GetPrecedence(token))
                    {
                        sb.Append(stack.Pop());
                    }
                    stack.Push(token);
                }
                else
                {
                    throw new ArgumentException($"Invalid character: {token}");
               
                }
            }

            while(stack.Count > 0)
            {
                if (stack.Peek() == '(')
                    throw new ArgumentException("Mismatched parentheses.");

                sb.Append(stack.Pop());
            }
            return sb.ToString();
        }

        public static double EvaluatePostfix(string expression)
        {
            var stack = new Stack<double>();
            foreach(char token in expression){
                if (char.IsWhiteSpace(token)) continue;
                else if (char.IsDigit(token))
                {
                    stack.Push(token - '0');
                }else if (IsOperator(token))
                {
                    if (stack.Count < 2)
                        throw new ArgumentException("Invalid postfix expression.");

                    double right = stack.Pop();
                    double left = stack.Pop();

                    double result = token switch
                    {
                        '+' => left + right,
                        '-' => left - right,
                        '*' => left * right,
                        '/' => right == 0
                                    ? throw new DivideByZeroException()
                                    : left / right,
                        '^' => Math.Pow(left,right),
                        _=> throw new ArgumentException("Invalid operator")

                    };
                    stack.Push(result);
                }else
                {
                    throw new ArgumentException($"Invalid token: {token}");
                }
            }
            if(stack.Count != 1)
            {
                throw new ArgumentException("Invalid posfix expression");
            }
            return stack.Pop();
        }
        private static bool IsOperator(char token)
        {
            return token switch
            {
                '+' or '-' or '*' or '/' or '^' => true,
                _ => false
            };
        }
        private static int GetPrecedence(char op)
        {
            return op switch
            {
                '-' or '+' => 1,
                '*' or '/' => 2,
                '^' => 3,
                _ => 0
            };
        }
    }
}