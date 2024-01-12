<!--
	FILE:          GuessNum.aspx
	PROJECT:       Number Guessing Game
	PROGRAMMER:    Salma Rageh 
	FIRST VERSION: 2023-11-12
	DESCRIPTION:   This code gets the maximum guess number, and validates it
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GuessNum.aspx.cs" Inherits="A04.GuessNum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Style.css" />   
</head>
<body>
    <form id="form1" runat="server">
        <h1>Hi-Lo Game</h1>
        <div class="game-container">
            <asp:Label ID="guessPrompt" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="guessNumBox" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="guessNumEmpty" runat="server" ErrorMessage="Your guess number <b>cannot</b> be <b>BLANK</b>"
                ControlToValidate="guessNumBox" Text="*" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="guessNumValid" runat="server" ErrorMessage="Your guess number <b>must</b> be made of <b>numeric</b> characters only"
                ControlToValidate="guessNumBox" Text="*" Display="Dynamic" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
            <asp:Button ID="guessNumButton" runat="server" Text="Make this Guess" OnClick="guessNumButton_Click" />
            <br />
        </div>
         <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ShowSummary="true" CssClass="validation-message"/>
        <asp:Label ID="ErrorMessage" runat="server" Text="" CssClass="validation-message"></asp:Label>
    </form>
</body>
</html>
