using InfixToPostFixConvertor;

string expression = "K+L-M*N+(O^p)*w/u/v*T+Q";

string result = InfixToPostfix.InfixToPostfixConverter(expression);
Console.WriteLine(result);