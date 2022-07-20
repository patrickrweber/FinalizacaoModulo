<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" MasterPageFile="MasterPage.Master" Inherits="Cadastro.Login" %>

<asp:Content ID="Content" ContentPlaceHolderId="ContentPrincipal" runat="server">
    <asp:Login ID="LoginUser" runat="server" OnAuthenticate="LoginUser_Authenticate"></asp:Login>
</asp:Content>
