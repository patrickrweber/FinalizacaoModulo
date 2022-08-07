<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="RegisterList.aspx.cs" Inherits="Cadastro.RegisterList" MasterPageFile="MasterPage.Master"%>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPrincipal" runat="server">
    <asp:Panel ID="PanelUserList" runat="server" GroupingText="Lista de Usuarios">
        <asp:Button ID="ButtonInsert" runat="server" Text="Inserir" OnClick="ButtonInsert_Click" />

        <asp:GridView ID="GridViewUserList" runat="server" OnRowCommand="GridViewUserList_RowComannd" 
            CellPadding="4" ForeColor="#333333" GridLines="Vertical">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnView" runat="server" CommandName="View" 
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                            Text="Visualizar" />

                        <asp:Button ID="btnUpd"  runat="server"  CommandName="Update" 
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                            Text="Atualizar"  />

                        <asp:Button ID="btnDel" runat="server" CommandName="Delete"
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                            Text="Excluir" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </asp:Panel>
</asp:Content>
