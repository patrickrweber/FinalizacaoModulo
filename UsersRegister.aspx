<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersRegister.aspx.cs" Inherits="Register.WebForm1" MasterPageFile="MasterPage.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPrincipal" runat="server">

    <asp:Panel ID="PanelRegisterUser" runat="server">

        <table>
            <tr>
                <td>
                    <asp:Label ID="LabelId" runat="server" Text="ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxId" runat="server"></asp:TextBox>
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


    </asp:Panel>

</asp:Content>

