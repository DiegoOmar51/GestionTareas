<%@ Page  Async="true"Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="FrontEnd.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 
    <h3>Gestion de Tareas</h3>
    <p>Clic en el boton, para acceder al sistema de gestion de tareas</p>
    <asp:Button ID="Button1" runat="server" Text="Ingresar" OnClick="Button1_Click" class="btn btn-primary"/>
    <hr/>
    <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" CssClass="table table-striped"></asp:GridView>--%>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" DataKeyNames="ID" CssClass="table table-striped">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server" />
            </ItemTemplate>
            <HeaderTemplate>
                <asp:CheckBox ID="HeaderCheckBox" runat="server" OnCheckedChanged="HeaderCheckBox_CheckedChanged" AutoPostBack="true" />
            </HeaderTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<hr/>
<asp:Button ID="Button2" runat="server" Text="Ver Seleccionado" OnClick="Button2_Click"  />

</asp:Content>
