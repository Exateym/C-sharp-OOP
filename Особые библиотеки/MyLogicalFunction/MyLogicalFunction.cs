using System;
using System.Linq;
using MyGenericCollections.MySet;

namespace MySpecificLibraries
{
    namespace MyLogicalFunction
    {
        public class MyLogicalFunction
        {
            private static string variables = "abcdefghijklmnopqrstuvwxyz";
            private static char NOT = '¬';
            private static string unaryOperator = NOT.ToString();
            private static char NAND = '|';
            private static char NOR = '↓';
            private static char AND = '•';
            private static char OR = '∨';
            private static char XOR = '⨁';
            private static char IMPLICATION = '→';
            private static char EQUIVALENCE = '~';
            private static string binaryOperators = NAND.ToString() + NOR.ToString() + AND.ToString() +
            OR.ToString() + XOR.ToString() + IMPLICATION.ToString() + EQUIVALENCE.ToString();
            private static char openingBracket = '(';
            private static char closingBracket = ')';
            private static string brackets = openingBracket.ToString() + closingBracket.ToString();

            private static string allowedAlphabet = variables + unaryOperator + binaryOperators + brackets;
            public string AllowedAlphabet
            {
                get
                {
                    return allowedAlphabet;
                }
            }

            private static char FALSE = '0';
            private static char TRUE = '1';
            private static string values = FALSE.ToString() + TRUE.ToString();

            private string formula;
            public string Formula
            {
                get
                {
                    return formula;
                }
            }


            private MySet<char> detectedVariables;
            public MySet<char> DetectedVariables
            {
                get
                {
                    return detectedVariables;
                }
            }

            private bool IsThereNoIncorrectlySymbol(string inputString)
            {
                foreach (char symbol in inputString)
                {
                    if (!allowedAlphabet.Contains(symbol))
                    {
                        return false;
                    }
                }
                return true;
            }

            private char? GetLeftSymbol(string inputString, int currentIndex)
            {
                int leftSymbolIndex = currentIndex - 1;
                if (leftSymbolIndex < 0)
                {
                    return null;
                }
                return inputString[leftSymbolIndex];
            }

            private char? GetRightSymbol(string inputString, int currentIndex)
            {
                int rightSymbolIndex = currentIndex + 1;
                if (rightSymbolIndex >= inputString.Length)
                {
                    return null;
                }
                return inputString[rightSymbolIndex];
            }

            private bool AreOpenedBracketsClosed(string inputString)
            {
                int openingBracketCount = 0;
                int closingBracketCount = 0;
                foreach (char character in inputString)
                {
                    if (character == openingBracket)
                    {
                        openingBracketCount++;
                    }
                    if (character == closingBracket)
                    {
                        closingBracketCount++;
                    }
                }
                return openingBracketCount == closingBracketCount;
            }

            private bool IsUnaryOperatorUsedCorrectly(string inputString)
            {
                for (int index = 0; index < inputString.Length; index++)
                {
                    if (inputString[index] == NOT)
                    {
                        char? rightSymbol = GetRightSymbol(inputString, index);
                        if (!rightSymbol.HasValue)
                        {
                            return false;
                        }
                        if (rightSymbol.Value != openingBracket && !variables.Contains(rightSymbol.Value))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            private bool AreUnaryOperatorsUsedCorrectly(string inputString)
            {
                for (int index = 0; index < inputString.Length; index++)
                {
                    if (binaryOperators.Contains(inputString[index]))
                    {
                        char? leftSymbol = GetLeftSymbol(inputString, index);
                        if (!leftSymbol.HasValue)
                        {
                            return false;
                        }
                        char? rightSymbol = GetRightSymbol(inputString, index);
                        if (!rightSymbol.HasValue)
                        {
                            return false;
                        }
                        if (
                            leftSymbol.Value != closingBracket && !variables.Contains(leftSymbol.Value)
                            ||
                            rightSymbol.Value != NOT && rightSymbol.Value != openingBracket && !variables.Contains(rightSymbol.Value)
                           )
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            private bool IsThereNoMissingOperator(string inputString)
            {
                for (int index = 0; index < inputString.Length - 1; index++)
                {
                    char current = inputString[index];
                    char next = inputString[index + 1];
                    if (
                        variables.Contains(current) && variables.Contains(next) ||
                        variables.Contains(current) && next == openingBracket ||
                        current == closingBracket && variables.Contains(next)
                       )
                    {
                        return false;
                    }
                }
                return true;
            }

            private bool IsThereEmptyBrackets(string inputString)
            {
                for (int index = 0; index < inputString.Length - 1; index++)
                {
                    if (inputString[index] == openingBracket && inputString[index + 1] == closingBracket)
                    {
                        return false;
                    }
                }
                return true;
            }

            private bool AreThereBrackets(string inputString)
            {
                foreach (char symbol in inputString)
                {
                    if (brackets.Contains(symbol))
                    {
                        return true;
                    }
                }
                return false;
            }

            public void RewriteData(string inputString)
            {
                if (string.IsNullOrEmpty(inputString))
                {
                    throw new Exception("Была передана нулевая ссылка или пустая строка.");
                }
                if (!IsThereNoIncorrectlySymbol(inputString))
                {
                    throw new Exception("Запись формулы содержит неразрешённый символ.");
                }
                bool thereAreBrackets = AreThereBrackets(inputString);
                if (thereAreBrackets)
                {
                    if (!AreOpenedBracketsClosed(inputString))
                    {
                        throw new Exception("Количество открывшихся скобок не равно количеству закрывшихся.");
                    }
                    if (!IsThereEmptyBrackets(inputString))
                    {
                        throw new Exception("В формуле найдены скобки, внутри которых ничего не содержится.");
                    }
                }
                if (!IsUnaryOperatorUsedCorrectly(inputString))
                {
                    throw new Exception("Неверная запись унарного оператора.");
                }
                if (!AreUnaryOperatorsUsedCorrectly(inputString))
                {
                    throw new Exception("Ошибка в применении бинарного оператора.");
                }
                if (!IsThereNoMissingOperator(inputString))
                {
                    throw new Exception("В записи формулы пропущен оператор.");
                }
                formula = inputString;
                detectedVariables = new MySet<char>();
                foreach (char symbol in formula)
                {
                    if (variables.Contains(symbol))
                    {
                        detectedVariables.AddElementToEnd(symbol);
                    }
                }
                detectedVariables.Sort();
            }

            public MyLogicalFunction(string inputString)
            {
                RewriteData(inputString);
            }

            public MyLogicalFunction(in MyLogicalFunction anotherInstance)
            {
                formula = anotherInstance.formula;
                detectedVariables = anotherInstance.detectedVariables;
            }

            public bool Calculate(params char[] valuesForVariables)
            {
                foreach (char symbol in valuesForVariables)
                {
                    if (!values.Contains(symbol))
                    {
                        throw new Exception("Среди переданных параметров было найдено недопустимое значение для переменной.");
                    }
                }
                if (valuesForVariables.Length != detectedVariables.Length)
                {
                    throw new Exception("Количество переданных значений не совпадает с количеством переменных в формуле.");
                }
                string result = formula;
                for (int index = 0; index < detectedVariables.Length; index++)
                {
                    result = result.Replace(detectedVariables[index], valuesForVariables[index]);
                }
                while (result.Length != 1)
                {
                    result = result.Replace(openingBracket.ToString() + FALSE.ToString() + closingBracket.ToString(), FALSE.ToString());
                    result = result.Replace(openingBracket.ToString() + TRUE.ToString() + closingBracket.ToString(), TRUE.ToString());

                    result = result.Replace(NOT.ToString() + FALSE.ToString(), TRUE.ToString());
                    result = result.Replace(NOT.ToString() + TRUE.ToString(), FALSE.ToString());

                    result = result.Replace(FALSE.ToString() + NAND.ToString() + FALSE.ToString(), TRUE.ToString());
                    result = result.Replace(FALSE.ToString() + NAND.ToString() + TRUE.ToString(), TRUE.ToString());
                    result = result.Replace(TRUE.ToString() + NAND.ToString() + FALSE.ToString(), TRUE.ToString());
                    result = result.Replace(TRUE.ToString() + NAND.ToString() + TRUE.ToString(), FALSE.ToString());

                    result = result.Replace(FALSE.ToString() + NOR.ToString() + FALSE.ToString(), TRUE.ToString());
                    result = result.Replace(FALSE.ToString() + NOR.ToString() + TRUE.ToString(), FALSE.ToString());
                    result = result.Replace(TRUE.ToString() + NOR.ToString() + FALSE.ToString(), FALSE.ToString());
                    result = result.Replace(TRUE.ToString() + NOR.ToString() + TRUE.ToString(), FALSE.ToString());

                    result = result.Replace(FALSE.ToString() + AND.ToString() + FALSE.ToString(), FALSE.ToString());
                    result = result.Replace(FALSE.ToString() + AND.ToString() + TRUE.ToString(), FALSE.ToString());
                    result = result.Replace(TRUE.ToString() + AND.ToString() + FALSE.ToString(), FALSE.ToString());
                    result = result.Replace(TRUE.ToString() + AND.ToString() + TRUE.ToString(), TRUE.ToString());

                    result = result.Replace(FALSE.ToString() + OR.ToString() + FALSE.ToString(), FALSE.ToString());
                    result = result.Replace(FALSE.ToString() + OR.ToString() + TRUE.ToString(), TRUE.ToString());
                    result = result.Replace(TRUE.ToString() + OR.ToString() + FALSE.ToString(), TRUE.ToString());
                    result = result.Replace(TRUE.ToString() + OR.ToString() + TRUE.ToString(), TRUE.ToString());

                    result = result.Replace(FALSE.ToString() + XOR.ToString() + FALSE.ToString(), FALSE.ToString());
                    result = result.Replace(FALSE.ToString() + XOR.ToString() + TRUE.ToString(), TRUE.ToString());
                    result = result.Replace(TRUE.ToString() + XOR.ToString() + FALSE.ToString(), TRUE.ToString());
                    result = result.Replace(TRUE.ToString() + XOR.ToString() + TRUE.ToString(), FALSE.ToString());

                    result = result.Replace(FALSE.ToString() + IMPLICATION.ToString() + FALSE.ToString(), TRUE.ToString());
                    result = result.Replace(FALSE.ToString() + IMPLICATION.ToString() + TRUE.ToString(), TRUE.ToString());
                    result = result.Replace(TRUE.ToString() + IMPLICATION.ToString() + FALSE.ToString(), FALSE.ToString());
                    result = result.Replace(TRUE.ToString() + IMPLICATION.ToString() + TRUE.ToString(), TRUE.ToString());

                    result = result.Replace(FALSE.ToString() + EQUIVALENCE.ToString() + FALSE.ToString(), TRUE.ToString());
                    result = result.Replace(FALSE.ToString() + EQUIVALENCE.ToString() + TRUE.ToString(), FALSE.ToString());
                    result = result.Replace(TRUE.ToString() + EQUIVALENCE.ToString() + FALSE.ToString(), FALSE.ToString());
                    result = result.Replace(TRUE.ToString() + EQUIVALENCE.ToString() + TRUE.ToString(), TRUE.ToString());
                }
                return result == TRUE.ToString();
            }

            public string[] GetTruthRows()
            {
                int quantity = 1 << detectedVariables.Length;
                string[] rows = new string[quantity];
                for (int number = 0; number < quantity; number++)
                {
                    char[] arguments = Convert.ToString(number, 2).PadLeft(detectedVariables.Length, '0').ToCharArray();
                    string parameters = string.Empty;
                    for (int index = 0; index < arguments.Length; index++)
                    {
                        parameters += arguments[index];
                        if (index != arguments.Length - 1)
                        {
                            parameters += ", ";
                        }
                    }
                    string result = $"f({parameters}) = ";
                    if (Calculate(arguments))
                    {
                        result += TRUE;
                    }
                    else
                    {
                        result += FALSE;
                    }
                    rows[number] = result;
                }
                return rows;
            }

            public MySet<string> GetMySetPDNF()
            {
                MySet<string> result = new MySet<string>();
                int quantity = 1 << detectedVariables.Length;
                for (int number = 0; number < quantity; number++)
                {
                    char[] arguments = Convert.ToString(number, 2).PadLeft(detectedVariables.Length, '0').ToCharArray();
                    if (Calculate(arguments))
                    {
                        string statement = string.Empty;
                        for (int index = 0; index < arguments.Length; index++)
                        {
                            if (arguments[index] == TRUE)
                            {
                                statement += detectedVariables[index].ToString();
                            }
                            else
                            {
                                statement += NOT.ToString() + detectedVariables[index].ToString();
                            }
                            if (index != arguments.Length - 1)
                            {
                                statement += AND.ToString();
                            }
                        }
                        result.AddElementToEnd(statement);
                    }
                }
                return result;
            }

            public string GetStringPDNF()
            {
                MySet<string> statements = GetMySetPDNF();
                string result = string.Empty;
                for (int index = 0; index < statements.Length; index++)
                {
                    result += statements[index];
                    if (index != statements.Length - 1)
                    {
                        result += OR.ToString();
                    }
                }
                return result;
            }

            public MySet<string> GetMySetPCNF()
            {
                MySet<string> result = new MySet<string>();
                int quantity = 1 << detectedVariables.Length;
                for (int number = 0; number < quantity; number++)
                {
                    char[] arguments = Convert.ToString(number, 2).PadLeft(detectedVariables.Length, '0').ToCharArray();
                    if (!Calculate(arguments))
                    {
                        string statement = string.Empty;
                        for (int index = 0; index < arguments.Length; index++)
                        {
                            if (arguments[index] == TRUE)
                            {
                                statement += NOT.ToString() + detectedVariables[index].ToString();
                            }
                            else
                            {
                                statement += detectedVariables[index].ToString();
                            }
                            if (index != arguments.Length - 1)
                            {
                                statement += OR.ToString();
                            }
                        }
                        result.AddElementToEnd(statement);
                    }
                }
                return result;
            }

            public string GetStringPCNF()
            {
                MySet<string> statements = GetMySetPCNF();
                string result = string.Empty;
                if (statements.Length == 1)
                {
                    result = statements[0];
                }
                else
                {
                    for (int index = 0; index < statements.Length; index++)
                    {
                        result += openingBracket.ToString() + statements[index] + closingBracket.ToString();
                        if (index != statements.Length - 1)
                        {
                            result += AND.ToString();
                        }
                    }
                }
                return result;
            }

            private MySet<string> GluingImplicants(MySet<string> statements)
            {
                MySet<string> result = new MySet<string>();
                for (int firstStatementIndex = 0; firstStatementIndex < statements.Length - 1; firstStatementIndex++)
                {
                    string[] firstArguments = statements[firstStatementIndex].Split(AND);
                    for (int secondStatementIndex = firstStatementIndex + 1; secondStatementIndex < statements.Length; secondStatementIndex++)
                    {
                        string[] secondArguments = statements[secondStatementIndex].Split(AND);
                        int quantityOfMatches = 0;
                        int quantityOfDifferences = 0;
                        string lastDifferentArgument = string.Empty;
                        for (int firstArgumentIndex = 0; firstArgumentIndex < firstArguments.Length; firstArgumentIndex++)
                        {
                            bool wasFound = false;
                            for (int secondArgumentIndex = 0; secondArgumentIndex < secondArguments.Length && !wasFound; secondArgumentIndex++)
                            {
                                if (firstArguments[firstArgumentIndex] == secondArguments[secondArgumentIndex])
                                {
                                    wasFound = true;
                                }
                            }
                            if (wasFound)
                            {
                                quantityOfMatches++;
                            }
                            else
                            {
                                quantityOfDifferences++;
                                lastDifferentArgument = firstArguments[firstArgumentIndex];
                            }
                        }
                        if (quantityOfMatches > 1 && quantityOfDifferences == 1)
                        {
                            string[] newArguments = new string[firstArguments.Length - 1];
                            for (int firstArgumentIndex = 0, newArgumentIndex = 0; firstArgumentIndex < firstArguments.Length; firstArgumentIndex++)
                            {
                                if (firstArguments[firstArgumentIndex] != lastDifferentArgument)
                                {
                                    newArguments[newArgumentIndex] = firstArguments[firstArgumentIndex];
                                    newArgumentIndex++;
                                }
                            }
                            string gluingResult = string.Empty;
                            for (int newArgumentIndex = 0; newArgumentIndex < newArguments.Length; newArgumentIndex++)
                            {
                                gluingResult += newArguments[newArgumentIndex];
                                if (newArgumentIndex != newArguments.Length - 1)
                                {
                                    gluingResult += AND.ToString();
                                }
                            }
                            result.AddElementToEnd(gluingResult);
                        }
                    }
                }
                if (result.IsEmpty)
                {
                    return statements;
                }
                return result;
            }

            public MySet<string> GetFirstShortestMDNF()
            {
                MySet<string> mySetPDNF = GetMySetPDNF();
                MySet<string> newStatements = new MySet<string>(GluingImplicants(mySetPDNF));
                MySet<string> previousStatements;

                // Итеративное склеивание импликант
                do
                {
                    previousStatements = new MySet<string>(newStatements);
                    newStatements = new MySet<string>(GluingImplicants(newStatements));
                }
                while (newStatements != previousStatements);

                if (newStatements.Length <= 1)
                {
                    return newStatements;
                }

                MySet<string> implicants = new MySet<string>(newStatements);
                MySet<string> bestCover = null;

                // Генерация всех подмножеств импликант
                int subsetCount = 1 << implicants.Length; // 2^n подмножеств
                for (int mask = 1; mask < subsetCount; mask++) // Пропускаем пустое подмножество
                {
                    MySet<string> subset = new MySet<string>();
                    for (int i = 0; i < implicants.Length; i++)
                    {
                        if ((mask & (1 << i)) != 0) // Проверяем, входит ли i-й элемент в подмножество
                        {
                            subset.AddElementToEnd(implicants[i]);
                        }
                    }

                    // Проверка, покрывает ли подмножество все строки СДНФ
                    if (IsFullCoverage(subset, mySetPDNF))
                    {
                        // Сравнение размеров подмножеств
                        if (bestCover == null || subset.Length < bestCover.Length)
                        {
                            bestCover = subset;
                        }
                    }
                }

                return bestCover;
            }

            private bool IsFullCoverage(MySet<string> subset, MySet<string> mySetPDNF)
            {
                bool[] coverage = new bool[mySetPDNF.Length];

                foreach (string implicant in subset)
                {
                    for (int i = 0; i < mySetPDNF.Length; i++)
                    {
                        if (Covers(implicant, mySetPDNF[i]))
                        {
                            coverage[i] = true;
                        }
                    }
                }

                // Проверяем, покрыты ли все строки СДНФ
                return coverage.All(c => c);
            }

            private bool Covers(string implicant, string pcnf)
            {
                string[] implicantLiterals = implicant.Split(AND);
                string[] pcnfLiterals = pcnf.Split(AND);

                return implicantLiterals.All(literal => pcnfLiterals.Contains(literal));
            }

            public string GetStringFirstShortestMDNF()
            {
                MySet<string> statements = GetFirstShortestMDNF();
                string result = string.Empty;
                for (int index = 0; index < statements.Length; index++)
                {
                    result += statements[index];
                    if (index != statements.Length - 1)
                    {
                        result += OR.ToString();
                    }
                }
                return result;
            }
        }
    }
}