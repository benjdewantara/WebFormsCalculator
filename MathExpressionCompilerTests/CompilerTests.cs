using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathExpressionCompiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressionCompiler.Tests {
    [TestClass()]
    public class CompilerTests {
        [TestMethod]
        public void EmptyString() {
            string mathExpressionString = "";
            Tokenizer tokenizer = new Tokenizer(mathExpressionString);
            Assert.AreEqual(tokenizer.IsTokenizationSuccessful, true);

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Assert.AreEqual(compiler.IsCompilationSuccessful, false);
            }
        }


        [TestMethod]
        public void OnlyOneOperator() {
            string mathExpressionString = "+";
            Tokenizer tokenizer = new Tokenizer(mathExpressionString);
            Assert.AreEqual(tokenizer.IsTokenizationSuccessful, true);

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Assert.AreEqual(compiler.IsCompilationSuccessful, false);
            }
        }


        [TestMethod]
        public void OnlyOneSymbol() {
            string mathExpressionString = "(";
            Tokenizer tokenizer = new Tokenizer(mathExpressionString);
            Assert.AreEqual(tokenizer.IsTokenizationSuccessful, true);

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Assert.AreEqual(compiler.IsCompilationSuccessful, false);
            }
        }

        [TestMethod]
        public void OneNumberFollowedByOneOperator() {
            string mathExpressionString = "3/";
            Tokenizer tokenizer = new Tokenizer(mathExpressionString);
            Assert.AreEqual(tokenizer.IsTokenizationSuccessful, true);

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Assert.AreEqual(compiler.IsCompilationSuccessful, false);
            }
        }

        [TestMethod]
        public void InvalidSymbolCharacter() {
            string mathExpressionString = "@";
            Tokenizer tokenizer = new Tokenizer(mathExpressionString);
            Assert.AreEqual(tokenizer.IsTokenizationSuccessful, false);

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Assert.AreEqual(compiler.IsCompilationSuccessful, false);
            }
        }

        [TestMethod]
        public void OnlyOneNumber() {
            string mathExpressionString = "122";
            Tokenizer tokenizer = new Tokenizer(mathExpressionString);
            Assert.AreEqual(tokenizer.IsTokenizationSuccessful, true);

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Assert.AreEqual(compiler.IsCompilationSuccessful, true);
                Assert.AreEqual(compiler.EndResult, 122);
            }
        }

        [TestMethod]
        public void OnlyOneNumberMinus() {
            string mathExpressionString = "-122";
            Tokenizer tokenizer = new Tokenizer(mathExpressionString);
            Assert.AreEqual(tokenizer.IsTokenizationSuccessful, true);

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Assert.AreEqual(compiler.IsCompilationSuccessful, true);
                Assert.AreEqual(compiler.EndResult, -122);
            }
        }

        [TestMethod]
        public void OnlyOneNumberPlus() {
            string mathExpressionString = "+122";
            Tokenizer tokenizer = new Tokenizer(mathExpressionString);
            Assert.AreEqual(tokenizer.IsTokenizationSuccessful, true);

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Assert.AreEqual(compiler.IsCompilationSuccessful, true);
                Assert.AreEqual(compiler.EndResult, 122);
            }
        }

        [TestMethod]
        public void Addition() {
            string mathExpressionString = "122+1";
            Tokenizer tokenizer = new Tokenizer(mathExpressionString);
            Assert.AreEqual(tokenizer.IsTokenizationSuccessful, true);

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Assert.AreEqual(compiler.IsCompilationSuccessful, true);
                Assert.AreEqual(compiler.EndResult, 123);
            }
        }

        [TestMethod]
        public void Subtraction() {
            string mathExpressionString = "122-1";
            Tokenizer tokenizer = new Tokenizer(mathExpressionString);
            Assert.AreEqual(tokenizer.IsTokenizationSuccessful, true);

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Assert.AreEqual(compiler.IsCompilationSuccessful, true);
                Assert.AreEqual(compiler.EndResult, 121);
            }
        }


        [TestMethod]
        public void Multiplication() {
            string mathExpressionString = "122*2";
            Tokenizer tokenizer = new Tokenizer(mathExpressionString);
            Assert.AreEqual(tokenizer.IsTokenizationSuccessful, true);

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Assert.AreEqual(compiler.IsCompilationSuccessful, true);
                Assert.AreEqual(compiler.EndResult, 244);
            }
        }

        [TestMethod]
        public void Division() {
            string mathExpressionString = "122/2";
            Tokenizer tokenizer = new Tokenizer(mathExpressionString);
            Assert.AreEqual(tokenizer.IsTokenizationSuccessful, true);

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Assert.AreEqual(compiler.IsCompilationSuccessful, true);
                Assert.AreEqual(compiler.EndResult, 61);
            }
        }

        [TestMethod]
        public void InBracketExpression() {
            string mathExpressionString = "(122*2)";
            Tokenizer tokenizer = new Tokenizer(mathExpressionString);
            Assert.AreEqual(tokenizer.IsTokenizationSuccessful, true);

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Assert.AreEqual(compiler.IsCompilationSuccessful, true);
                Assert.AreEqual(compiler.EndResult, 244);
            }
        }

        [TestMethod]
        public void InBracketExpressionInvalid1() {
            string mathExpressionString = "(122*2)/)";
            Tokenizer tokenizer = new Tokenizer(mathExpressionString);
            Assert.AreEqual(tokenizer.IsTokenizationSuccessful, true);

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Assert.AreEqual(compiler.IsCompilationSuccessful, false);
            }
        }

        [TestMethod]
        public void InBracketExpressionInvalid2() {
            string mathExpressionString = "(122*2)/()";
            Tokenizer tokenizer = new Tokenizer(mathExpressionString);
            Assert.AreEqual(tokenizer.IsTokenizationSuccessful, true);

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Assert.AreEqual(compiler.IsCompilationSuccessful, false);
            }
        }


        [TestMethod]
        public void InBracketExpressionComplex1() {
            string mathExpressionString = "(122*2)+(1)";
            Tokenizer tokenizer = new Tokenizer(mathExpressionString);
            Assert.AreEqual(tokenizer.IsTokenizationSuccessful, true);

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Assert.AreEqual(compiler.IsCompilationSuccessful, true);
                Assert.AreEqual(compiler.EndResult, 245);
            }
        }


        [TestMethod]
        public void InBracketExpressionComplex2() {
            string mathExpressionString = "((122 * 2) / (1))";
            Tokenizer tokenizer = new Tokenizer(mathExpressionString);
            Assert.AreEqual(tokenizer.IsTokenizationSuccessful, true);

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Assert.AreEqual(compiler.IsCompilationSuccessful, true);
                Assert.AreEqual(compiler.EndResult, 244);
            }
        }

        [TestMethod]
        public void InBracketExpressionComplex3() {
            string mathExpressionString = "((122 * 3) / ((122 * 1) + 122) - 122)";
            Tokenizer tokenizer = new Tokenizer(mathExpressionString);
            Assert.AreEqual(tokenizer.IsTokenizationSuccessful, true);

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Assert.AreEqual(compiler.IsCompilationSuccessful, true);
                Assert.AreEqual(compiler.EndResult, 3);
            }
        }

        [TestMethod]
        public void InBracketExpressionComplex3TimesMinusOneInTheEnd() {
            string mathExpressionString = "((122 * 3) / ((122 * 1) + 122) - 122) * -1";
            Tokenizer tokenizer = new Tokenizer(mathExpressionString);
            Assert.AreEqual(tokenizer.IsTokenizationSuccessful, true);

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Assert.AreEqual(compiler.IsCompilationSuccessful, true);
                Assert.AreEqual(compiler.EndResult, -3);
            }
        }
    }
}