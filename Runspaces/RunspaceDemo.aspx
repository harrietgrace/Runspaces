<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RunspaceDemo.aspx.cs" Inherits="Runspaces.RunspaceDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Runspace Demo</title>
	<link href="styles/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="wrapper">
        <form id="containerForm" runat="server">
            <h1>Runspace Demo</h1>
            <div class="input-area">
			    <label>Script you want to run:</label>
                <asp:FileUpload ID="fileUpload" runat="server" />
			    <div class="clearfix"></div>
                <label>Test Value 1:</label>
                <asp:TextBox ID="firstValue" runat="server"></asp:TextBox>
                <div class="clearfix"></div>
                <label>Test Value 2:</label>
                <asp:TextBox ID="secondValue" runat="server"></asp:TextBox>
                <div class="clearfix"></div>
                <asp:Button ID="BtnExecuteScript" runat="server" Text="Run Scripts" OnClick="BtnExecuteScript_Click" />
		    </div>
            <div class="output-area">
			    Script output:
			    <asp:TextBox ID="TxtOutput" runat="server" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
			    <asp:Button ID="BtnClear" runat="server" Text="Clear All Values and Output" OnClick="BtnClear_Click" CausesValidation="False"/>
		    </div>
    
        </form>
    </div>
</body>
</html>
