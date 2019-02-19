using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressionCompiler {
    public class Compiler {
        private Tokenizer tokenizer;
        private Stack<double?> stackOfNumbers;
        private bool isCompilationSuccessful;

        public double? EndResult { get; set; }
        public bool IsCompilationSuccessful { get => isCompilationSuccessful; set => isCompilationSuccessful = value; }

        public Compiler(string raw_string_data) {
            this.tokenizer = new Tokenizer(raw_string_data);
            this.stackOfNumbers = new Stack<double?>();

            if (tokenizer.IsTokenizationSuccessful) {
                isCompilationSuccessful = CompileExpression();
                if (isCompilationSuccessful) {
                    EndResult = stackOfNumbers.Pop();
                }
            }
            else {
                isCompilationSuccessful = false;
            }
        }

        public Compiler(Tokenizer tokenizer) {
            this.tokenizer = tokenizer;
            this.stackOfNumbers = new Stack<double?>();

            if (tokenizer.IsTokenizationSuccessful) {
                isCompilationSuccessful = CompileExpression();
                if (isCompilationSuccessful) {
                    EndResult = stackOfNumbers.Pop();
                }
            }
            else {
                isCompilationSuccessful = false;
            }
        }

        private bool CompileExpression() {
            object token = tokenizer.NextToken();
            Tokenizer.TokenType? tokenType = tokenizer.NextTokenType();

            if (tokenType == Tokenizer.TokenType.CONSTANT) {
                CompileNumber();

                if (tokenizer.hasMoreTokensToRead() && tokenizer.NextTokenType() == Tokenizer.TokenType.OPERATOR) {
                    bool isCompileOperatorSuccessful = CompileOperator();
                    if (!isCompileOperatorSuccessful) {
                        return false;
                    }
                }
            }
            else if (tokenType == Tokenizer.TokenType.BRACKET) {
                object expectOpenBracket = tokenizer.NextToken();
                tokenizer.AdvanceTokenReader();

                if (!expectOpenBracket.Equals("(")) {
                    return false;
                }

                bool isCompileExpressionSuccessful = CompileExpression();
                if (!isCompileExpressionSuccessful) {
                    return false;
                }

                object expectCloseBracket = tokenizer.NextToken();
                Tokenizer.TokenType? expectCloseBracket_tokenType = tokenizer.NextTokenType();
                tokenizer.AdvanceTokenReader();

                if (!expectCloseBracket.Equals(")")) {
                    return false;
                }

                if (tokenizer.hasMoreTokensToRead() && tokenizer.NextTokenType() == Tokenizer.TokenType.OPERATOR) {
                    bool isCompileOperatorSuccessful = CompileOperator();
                    if (!isCompileOperatorSuccessful) {
                        return false;
                    }
                }
            }
            else if (tokenType == Tokenizer.TokenType.OPERATOR) {
                bool isCompileOperatorSuccessful = CompileOperator();
                if (!isCompileOperatorSuccessful) {
                    return false;
                }
            }
            else {
                return false;
            }


            return true;
        }

        private bool CompileOperator() {
            bool isSuccessful;

            object expectOperator = tokenizer.NextToken();
            Tokenizer.TokenType? expectOperator_tokenType = tokenizer.NextTokenType();

            object tokenBefore = tokenizer.NextToken(-1);
            Tokenizer.TokenType? tokenTypeBefore = tokenizer.NextTokenType(-1);

            if (expectOperator.Equals("-")) {
                if (tokenizer.TokenBeingReadIndx==0 ||
                    tokenizer.NextToken(-1).Equals("(") ||
                     tokenizer.NextTokenType(-1) == Tokenizer.TokenType.OPERATOR) {
                    isSuccessful = CompileUnaryOperation();
                }
                else {
                    isSuccessful = CompileBinaryOperation();
                }
            }
            else if (expectOperator.Equals("+")) {
                if (tokenizer.TokenBeingReadIndx == 0 ||
                    tokenizer.NextToken(-1).Equals("(") ||
                     tokenizer.NextTokenType(-1) == Tokenizer.TokenType.OPERATOR) {
                    isSuccessful = CompileUnaryOperation();
                }
                else {
                    isSuccessful = CompileBinaryOperation();
                }
            }
            else {
                isSuccessful = CompileBinaryOperation();
            }

            return isSuccessful;
        }

        private bool CompileNumber() {
            double token = (double)tokenizer.NextToken();
            Tokenizer.TokenType? tokenType = tokenizer.NextTokenType();
            tokenizer.AdvanceTokenReader();

            stackOfNumbers.Push(token);

            return true;
        }

        private bool CompileBinaryOperation() {
            string op = (string)tokenizer.NextToken();
            Tokenizer.TokenType? tokenType = tokenizer.NextTokenType();
            tokenizer.AdvanceTokenReader();

            bool isCompileExpressionSuccessful = CompileExpression();

            if (!isCompileExpressionSuccessful) {
                return false;
            }

            double? num2 = stackOfNumbers.Pop();
            double? num1 = stackOfNumbers.Pop();
            double? binOpResult;

            if (op.Equals("+")) {
                binOpResult = num1 + num2;
            }
            else if (op.Equals("-")) {
                binOpResult = num1 - num2;
            }
            else if (op.Equals("*")) {
                binOpResult = num1 * num2;
            }
            else if (op.Equals("/")) {
                binOpResult = num1 / num2;
            }
            else {
                binOpResult = null;
            }

            stackOfNumbers.Push(binOpResult);

            return true;
        }

        private bool CompileUnaryOperation() {
            string op = (string)tokenizer.NextToken();
            Tokenizer.TokenType? tokenType = tokenizer.NextTokenType();
            tokenizer.AdvanceTokenReader();

            bool isCompileExpressionSuccessful = CompileExpression();

            if (!isCompileExpressionSuccessful) {
                return false;
            }

            if (op.Equals("-")) {
                double? number = stackOfNumbers.Pop();
                stackOfNumbers.Push(-number);
            }

            return true;
        }
    }
}
