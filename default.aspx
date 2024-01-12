<!--
	FILE:          default.aspx
	PROJECT:       Number Guessing Game
	PROGRAMMER:    Salma Rageh 
	FIRST VERSION: 2023-11-12
	DESCRIPTION:   This code gets the name, and validates it
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="A04._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hi-Lo Game</title>
    <link rel="stylesheet" type="text/css" href="Style.css" />   
</head>
<body>
    <form id="form1" runat="server">
        <h1>Hi-Lo Game</h1>
        <div class="game-container">
            <asp:Label ID="userNamePrompt" runat="server" Text="What is your name?"></asp:Label>
            <asp:TextBox ID="userNameBox" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="nameEmptyValid" runat="server" ErrorMessage="Your name <b>cannot</b> be <b>BLANK</b>" 
                ControlToValidate="userNameBox" Text="*" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="nameCharValid" runat="server" ErrorMessage="Your name <b>must</b> be made of <b>ALPHA</b> characters only"
                ControlToValidate="userNameBox" ValidationExpression="^[A-Za-z]+$" Text="*" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
            <asp:Button ID="userNameButton" runat="server" Text="Submit" OnClick="userNameButton_Click" />
            <br />
        </div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ShowSummary="true" CssClass="validation-message"/>
    </form>
</body>
</html>
