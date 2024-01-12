<!--
	FILE:          WinPage.aspx
	PROJECT:       Number Guessing Game
	PROGRAMMER:    Salma Rageh 
	FIRST VERSION: 2023-11-12
	DESCRIPTION:   This code displays the win message and allows the user to play again
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WinPage.aspx.cs" Inherits="A04.WinPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Style.css" />   
</head>
<body class="win">
    <form id="form1" runat="server">
        <h1>Hi-Lo Game</h1>
        <div class="win-container">
            <asp:Label ID="Label1" runat="server" Text="You Win!! You guessed the number!!"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Play Again" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
