<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="WebFormsCalculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="~/Content/Site.css"/>
    <link rel="stylesheet" href="~/Content/calculator.css"/>
    
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Table ID="TableCalculator" runat="server" GridLines="Both"  HorizontalAlign="Center">
                <asp:TableRow >
                    <asp:TableCell ColumnSpan="4" >
                        <asp:TextBox ID="TextBox_mathExpressionBefore" runat="server" Width="210" Height="50" Rows="3" TextMode="MultiLine"  Enabled="false" BorderStyle="None"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow  >
                    <asp:TableCell ColumnSpan="4" >
                        <asp:TextBox ID="TextBox_mathExpression" runat="server" Width="210" Height="50" Rows="3" OnTextChanged="TextBox_mathExpression_TextChanged" BorderStyle="None" TextMode="MultiLine" ></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell >
                        <asp:Button CssClass="button-calc"  ID="Button_Calc_7" runat="server" Text="7"  OnClick="Button_Calc_Click"/>
                    </asp:TableCell>
                    <asp:TableCell >
                        <asp:Button CssClass="button-calc"  ID="Button_Calc_8" runat="server" Text="8"  OnClick="Button_Calc_Click"/>
                    </asp:TableCell>
                    <asp:TableCell >
                        <asp:Button CssClass="button-calc"  ID="Button_Calc_9" runat="server" Text="9"  OnClick="Button_Calc_Click"/>
                    </asp:TableCell>
                    <asp:TableCell >
                        <asp:Button CssClass="button-calc"  ID="Button_Calc_divide" runat="server" Text=":"  OnClick="Button_Calc_Click"/>
                    </asp:TableCell>
                </asp:TableRow>


                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button CssClass="button-calc"  ID="Button_Calc_4" runat="server" Text="4"  OnClick="Button_Calc_Click"/>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button CssClass="button-calc"  ID="Button_Calc_5" runat="server" Text="5"  OnClick="Button_Calc_Click"/>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button CssClass="button-calc"  ID="Button_Calc_6" runat="server" Text="6"  OnClick="Button_Calc_Click"/>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button CssClass="button-calc"  ID="Button_Calc_multiply" runat="server" Text="×"  OnClick="Button_Calc_Click"/>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button CssClass="button-calc"  ID="Button_Calc_1" runat="server" Text="1"  OnClick="Button_Calc_Click"/>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button CssClass="button-calc"  ID="Button_Calc_2" runat="server" Text="2"  OnClick="Button_Calc_Click"/>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button CssClass="button-calc"  ID="Button_Calc_3" runat="server" Text="3"  OnClick="Button_Calc_Click"/>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button CssClass="button-calc"  ID="Button_Calc_minus" runat="server" Text="-"  OnClick="Button_Calc_Click"/>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button CssClass="button-calc"  ID="Button_Calc_0" runat="server" Text="0"  OnClick="Button_Calc_Click"/>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button CssClass="button-calc" ID="Button_Calc_openBracket" runat="server" Text="("  OnClick="Button_Calc_Click" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button CssClass="button-calc"  ID="Button_Calc_closeBracket" runat="server" Text=")"  OnClick="Button_Calc_Click" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button CssClass="button-calc"  ID="Button_Calc_plus" runat="server" Text="+"  OnClick="Button_Calc_Click" />
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button CssClass="button-calc"  ID="Button_Calc_clear" runat="server" Text="C"  OnClick="Button_Calc_Click"  />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button CssClass="button-calc"  ID="Button_Calc_clearEntry" runat="server" Text="CE"  OnClick="Button_Calc_Click" />
                    </asp:TableCell>
                    <asp:TableCell ColumnSpan="2">
                        <asp:Button CssClass="button-calc"  ID="Button_Calc_enter" runat="server" Text="Enter" Width="104"  OnClick="Button_Calc_Click" />
                    </asp:TableCell>
                </asp:TableRow>

            </asp:Table>

            <br />  
        </div>
    </form>
</body>
</html>
