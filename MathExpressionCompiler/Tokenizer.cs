using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressionCompiler {
    public class Tokenizer {
        private List<object> tokens;
        private List<TokenType> tokenTypes;
        private string string_data = "";
        private string captured = string.Empty;
        private bool isTokenizationSuccessful;

        private int tokenBeingReadIndx = 0;

        public List<object> Tokens { get => tokens; }
        public bool IsTokenizationSuccessful { get => isTokenizationSuccessful; set => isTokenizationSuccessful = value; }
        public int TokenBeingReadIndx { get => tokenBeingReadIndx; set => tokenBeingReadIndx = value; }

        public Tokenizer(string raw_string_data) {
            // get rid of trailing or in-between whitespaces
            foreach (char chr in raw_string_data) {
                if (!char.IsWhiteSpace(chr)) {
                    this.string_data += chr;
                }
            }

            isTokenizationSuccessful = Tokenize();
        }

        private bool Tokenize() {
            tokens = new List<object>();
            tokenTypes = new List<TokenType>();

            for (int i = 0; i < string_data.Length; i++) {
                // check if it's a symbol
                if (IsOperator(string_data[i]) || IsBracket(string_data[i])) {
                    if (captured.Length > 0) {
                        // This means it's a real number
                        if (char.IsNumber(captured[0])) {
                            double.TryParse(captured, out double number);
                            tokens.Add(number);
                            tokenTypes.Add(TokenType.CONSTANT);
                        }
                        else {
                            return false;
                        }

                        captured = string.Empty;
                    }

                    captured = string_data[i].ToString();
                    tokens.Add(captured);
                    if (IsOperator(captured[0])) {
                        tokenTypes.Add(TokenType.OPERATOR);
                    }
                    else if (IsBracket(captured[0])) {
                        tokenTypes.Add(TokenType.BRACKET);
                    }
                    else {
                        return false;
                    }
                    captured = string.Empty;
                }
                else if (char.IsNumber(string_data[i])) {
                    captured += string_data[i].ToString();
                }
                else if (string_data[i].Equals('.') && char.IsNumber(string_data[i + 1])) {
                    captured += string_data[i].ToString();
                }
                else {
                    return false;
                }

                if (i == string_data.Length - 1 && captured.Length > 0) {
                    if (char.IsNumber(captured[0])) {
                        double.TryParse(captured, out double number);
                        tokens.Add(number);
                        tokenTypes.Add(TokenType.CONSTANT);
                    }
                    else {
                        return false;
                    }

                    captured = string.Empty;
                }
            }

            return true;
        }

        private bool IsOperator(char symbol) {
            char[] operators = new char[] { '+', '-', '*', '/' };

            foreach (var op in operators) {
                if (symbol == op) {
                    return true;
                }
            }

            return false;
        }

        private bool IsBracket(char symbol) {
            if (symbol == '(' || symbol == ')') {
                return true;
            }

            return false;
        }


        public enum TokenType {
            OPERATOR, CONSTANT, BRACKET
        }

        public object NextToken() {
            return NextToken(1);
        }

        public object NextToken(int nextIndx) {
            if (nextIndx < 0) {
                nextIndx += 1;
            }

            int getNextIndx = tokenBeingReadIndx + nextIndx - 1;

            if (getNextIndx < 0 || getNextIndx >= tokens.Count) {
                return null;
            }

            return tokens[tokenBeingReadIndx + nextIndx - 1];
        }

        public TokenType? NextTokenType() {
            return NextTokenType(1);
        }

        public TokenType? NextTokenType(int nextIndx) {
            if (nextIndx < 0) {
                nextIndx += 1;
            }

            int getNextIndx = tokenBeingReadIndx + nextIndx - 1;

            if (getNextIndx < 0 || getNextIndx >= tokens.Count) {
                return null;
            }

            return tokenTypes[tokenBeingReadIndx + nextIndx - 1];
        }

        public void AdvanceTokenReader() {
            tokenBeingReadIndx++;
        }

        public bool hasMoreTokensToRead() {
            if (tokenBeingReadIndx < tokens.Count) {
                return true;
            }

            return false;
        }

    }
}
