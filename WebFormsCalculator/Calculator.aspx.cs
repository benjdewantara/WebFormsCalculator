using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MathExpressionCompiler;

namespace WebFormsCalculator {
    public partial class Calculator : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void TextBox_mathExpression_TextChanged(object sender, EventArgs e) {
            System.Diagnostics.Debug.WriteLine("TextBox_mathExpression_TextChanged");
        }

        protected void Button_Calc_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            TextBox TextBox_mathExpression = (TextBox)FindControl("TextBox_mathExpression");

            if (!btn.ID.Equals("Button_Calc_enter")) {
                Tokenizer tokenizer = new Tokenizer(TextBox_mathExpression.Text);
                if (tokenizer.IsTokenizationSuccessful) {
                    TextBox_mathExpression.BackColor = System.Drawing.ColorTranslator.FromHtml("#95fc69");
                }
                else {
                    TextBox_mathExpression.BackColor = System.Drawing.ColorTranslator.FromHtml("#fa8383");
                }
            }

            switch (btn.ID) {
                case "Button_Calc_0":
                    System.Diagnostics.Debug.WriteLine("It's zero");
                    TextBox_mathExpression.Text += "0";
                    break;
                case "Button_Calc_1":
                    System.Diagnostics.Debug.WriteLine("One?");
                    TextBox_mathExpression.Text += "1";
                    break;
                case "Button_Calc_2":
                    TextBox_mathExpression.Text += "2";
                    break;
                case "Button_Calc_3":
                    TextBox_mathExpression.Text += "3";
                    break;
                case "Button_Calc_4":
                    TextBox_mathExpression.Text += "4";
                    break;
                case "Button_Calc_5":
                    TextBox_mathExpression.Text += "5";
                    break;
                case "Button_Calc_6":
                    TextBox_mathExpression.Text += "6";
                    break;
                case "Button_Calc_7":
                    TextBox_mathExpression.Text += "7";
                    break;
                case "Button_Calc_8":
                    TextBox_mathExpression.Text += "8";
                    break;
                case "Button_Calc_9":
                    TextBox_mathExpression.Text += "9";
                    break;
                case "Button_Calc_plus":
                    TextBox_mathExpression.Text += "+";
                    break;
                case "Button_Calc_minus":
                    TextBox_mathExpression.Text += "-";
                    break;
                case "Button_Calc_multiply":
                    TextBox_mathExpression.Text += "*";
                    break;
                case "Button_Calc_divide":
                    TextBox_mathExpression.Text += "/";
                    break;
                case "Button_Calc_openBracket":
                    TextBox_mathExpression.Text += "(";
                    break;
                case "Button_Calc_closeBracket":
                    TextBox_mathExpression.Text += ")";
                    break;
                case "Button_Calc_clear":
                    TextBox_mathExpression.Text = "";
                    break;
                case "Button_Calc_clearEntry":
                    if (TextBox_mathExpression.Text.Length > 0) {
                        System.Diagnostics.Debug.WriteLine("TextBox_mathExpression.Text.Length > 0");
                        TextBox_mathExpression.Text = TextBox_mathExpression.Text.Substring(0, TextBox_mathExpression.Text.Length - 1);
                    }
                    break;
                case "Button_Calc_enter":
                    TextBox TextBox_mathExpressionBefore = (TextBox)FindControl("TextBox_mathExpressionBefore");
                    string mathExpressionStr = TextBox_mathExpression.Text;
                    Compiler compiler = new Compiler(mathExpressionStr);

                    if (compiler.IsCompilationSuccessful) {
                        TextBox_mathExpression.BackColor = System.Drawing.ColorTranslator.FromHtml("#95fc69");
                        TextBox_mathExpressionBefore.Text = mathExpressionStr;
                        TextBox_mathExpression.Text = compiler.EndResult.ToString();
                    }
                    else {
                        TextBox_mathExpression.BackColor = System.Drawing.ColorTranslator.FromHtml("#fa8383");
                    }

                    break;
                default:
                    break;
            }

        }
    }
}