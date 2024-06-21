<%@ Page Async="true" Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="FrontEnd.Editar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Gestion de Tareas</h3>
    <p>Clic en el boton, para acceder al sistema de gestion de tareas</p>
    <hr />
    <div class="card text-center">
    <div class="card-body">
        <div class="container mt-5">
            <form>
                <div class="form-group row">
                    <label for="inputID" class="col-sm-2 col-form-label">ID</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="inputID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="inputTitulo" class="col-sm-2 col-form-label">Título</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="inputTitulo" runat="server" CssClass="form-control" placeholder="Título del objeto"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="inputDescripcion" class="col-sm-2 col-form-label">Descripción</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="inputDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" placeholder="Descripción detallada del objeto"></asp:TextBox>
  </div>
                </div>
                <div class="form-group row">
                    <label for="inputFechaCreacion" class="col-sm-2 col-form-label">Fecha de Creación</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="inputFechaCreacion" runat="server" CssClass="form-control" Type="date"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="inputFechaVencimiento" class="col-sm-2 col-form-label">Fecha de Vencimiento</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="inputFechaVencimiento" runat="server" CssClass="form-control" Type="date"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-2">Completada</div>
                    <div class="col-sm-2">
                        <div class="form-check">
                            <asp:CheckBox ID="inputCompletada" runat="server" CssClass="form-check-input" />
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-5 offset-sm-2">
                        <asp:Button ID="Button2" runat="server" Text="Guardar Informacion" OnClick="Button2_Click"  />
                    </div>
                </div>
            </form>
        </div>
        
    </div>
</div>

    <hr />

</asp:Content>
