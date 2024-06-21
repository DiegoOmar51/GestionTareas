<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Auth.aspx.cs" Inherits="GestionTareas.Auth" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="jumbotron">
        <h1>Gestion de Tarea </h1>
        <p class="lead">Plataforma de Gestion de Tareas</p>   
         <p>
             <asp:Button ID="Button1" runat="server" Text="Ingresar" OnClick="Button1_Click"  />
         </p> 
         <p>
             <input id="Button1" type="button" value="button" />
         </p> 
    </div>
</asp:Content>
