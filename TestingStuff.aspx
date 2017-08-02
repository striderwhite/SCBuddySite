<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestingStuff.aspx.cs" Inherits="TestingStuff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 80px">
    
        <asp:ScriptManager ID="ScriptManagerTest" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanelTest" runat="server">
            <ContentTemplate>
            <asp:Label ID="LabelUpdate" runat="server" Text="..."></asp:Label><br>

            <asp:Button runat="server" Text="Button" OnClick="Unnamed1_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    
    </div>
    </form>
</body>
</html>
