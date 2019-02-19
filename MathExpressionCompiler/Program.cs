using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressionCompiler {
    public class Program {
        static void Main(string[] args) {

            string expression;
            expression = "((122 * 3) / ((122 * 1) + 122) - 122)";
            expression = "-122";

            Tokenizer tokenizer = new Tokenizer(expression);
            Console.WriteLine($"tokenizer.IsTokenizationSuccessful = {tokenizer.IsTokenizationSuccessful}");

            if (tokenizer.IsTokenizationSuccessful) {
                Compiler compiler = new Compiler(tokenizer);
                Console.WriteLine($"compiler.IsCompilationSuccessful = {compiler.IsCompilationSuccessful}");
                Console.WriteLine($"compiler.EndResult = {compiler.EndResult}");

            }

            Console.ReadKey();
        }
    }
}
