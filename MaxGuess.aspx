<!--
	FILE:          MaxGuess.aspx
	PROJECT:       Number Guessing Game
	PROGRAMMER:    Salma Rageh 
	FIRST VERSION: 2023-11-12
	DESCRIPTION:   This code gets the guess number, and validates it
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaxGuess.aspx.cs" Inherits="A04.MaxGuess" %>

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
            <asp:Label ID="maxGuessPrompt" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="maxGuessBox" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="maxGuessNumValid" runat="server" ErrorMessage="Your maximum guess number <b>must</b> be made of <b>numeric</b> characters only"
                ControlToValidate="maxGuessBox" Text="*" ForeColor="Red" Display="Dynamic" ValidationExpression="^\d+$"></asp:RegularExpressionValidator><asp:RangeValidator ID="maxGuessRange" runat="server" ErrorMessage="The number <b>MUST</b> be greater than 1" 
                ControlToValidate="maxGuessBox" MinimumValue="2" MaximumValue="2147483647" Type="Integer" Text="*" ForeColor="Red" Display="Dynamic"></asp:RangeValidator><asp:RequiredFieldValidator ID="maxGuessEmptyValid" runat="server" ErrorMessage="Your maximum number <b>cannot</b> be <b>BLANK</b>" 
                ControlToValidate="maxGuessBox" Text="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:Button ID="maxGuessButton" runat="server" Text="Submit" OnClick="maxGuessButton_Click" />
            <br />
        </div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ShowSummary="true" CssClass="validation-message"/>
    </form>
</body>
</html>
