<%@ Page Title="About" Async="True" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="GestionTareas.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    
    <div class="jumbotron">
        <h1>Gestion de Tarea </h1>
        <p class="lead">Plataforma de Gestion de Tareas</p>   
         <p>
             <asp:Button ID="Button1" runat="server" Text="Ingresar"  />
         </p> 
         <p>
             <input id="Button1" type="button" value="button" />
         </p> 
    </div>
</asp:Content>
