<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersRegister.aspx.cs" Inherits="Cadastro.WebForm1" MasterPageFile="MasterPage.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPrincipal" runat="server">

    <asp:Panel ID="PanelRegisterUser" runat="server">

        <table style="height: 220px; width: 352px;">
            <tr>
                <td>
                    <asp:Label ID="LabelId" runat="server" Text="ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxId" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelName" runat="server" Text="Nome"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelEmail" runat="server" Text="E-mail"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelLogin" runat="server" Text="Login"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxLogin" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelPassword" runat="server" Text="Senha"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>

        <asp:Button ID="ButtonInsert" runat="server" Text="Inserir" OnClick="ButtonInsert_Click" />
        <asp:Button ID="ButtonUpdate" runat="server" Text="Atualizar" OnClick="ButtonUpdate_Click" />
        <asp:Button ID="ButtonDelete" runat="server" Text="Excluir" OnClick="ButtonDelete_Click" />
        <asp:Button ID="ButtonClose" runat="server" Text="Fechar" OnClick="ButtonClose_Click" />

    </asp:Panel>
</asp:Content>

