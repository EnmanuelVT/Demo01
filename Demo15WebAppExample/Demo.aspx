<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="Demo15WebAppExample.Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Image ID="imgFoto" runat="server" Height="350px" Width="320px" />
        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
        <div>
            <asp:FileUpload ID="fuArchivo" runat="server" AllowMultiple="True" />
        </div>
        <p>
            <asp:TextBox ID="txtSalida" runat="server" Height="66px" TextMode="MultiLine" Width="283px"></asp:TextBox>
        </p>
    </form>
</body>
</html>
