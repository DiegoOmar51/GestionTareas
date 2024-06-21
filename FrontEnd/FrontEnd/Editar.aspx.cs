using FrontEnd.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static FrontEnd.Models.DTO;

namespace FrontEnd
{
    public partial class Editar : Page
    {
        public static string tareaId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                tareaId = Request.QueryString["id"];
                CargarDatos(tareaId); // Llama al método para cargar datos utilizando el ID
            }         

        }


        private void CargarDatos(string tareaId)
        {
            // Lógica para cargar los datos de la tarea utilizando el ID proporcionado
            var options = new RestClientOptions("http://localhost:44388") { };
            var client = new RestClient(options);
            var request = new RestRequest($"/api/Tareas/"+ tareaId, Method.Get); // Utiliza el ID proporcionado en la URL
            request.AddHeader("Authorization", "Bearer " + Variables.token + "");

            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Tarea tarea = JsonConvert.DeserializeObject<Tarea>(response.Content);

                inputID.Text = tarea.ID.ToString();
                inputTitulo.Text = tarea.Titulo;
                inputDescripcion.Text = tarea.Descripcion;
                inputFechaCreacion.Text = tarea.Fecha_Creacion.ToString("yyyy-MM-dd");
                inputFechaVencimiento.Text = tarea.Fecha_Vencimiento.ToString("yyyy-MM-dd");
                inputCompletada.Checked = tarea.Completada;
            }
            else
            {
                // Manejar error
                Console.WriteLine(response.ErrorMessage);
            }
        }

        protected async Task Button2_ClickAsync(object sender, EventArgs e)
        {
            bool finalizado;

            if (inputCompletada.Checked)
            {
                finalizado = true;
            }
            else
            {
                finalizado = false;
            }

            var options = new RestClientOptions("http://localhost:44388") { };
            var client = new RestClient(options);
            var request = new RestRequest("/api/Tareas/"+tareaId, Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + Variables.token + "");

            var body = @"
            {
                ""id"": """ + tareaId + @""",
                ""Titulo"": """ + inputTitulo + @""",
                ""Descripcion"": """ + inputDescripcion + @""",
                ""Fecha_Creacion"": """ + inputFechaCreacion + @""",
                ""Fecha_Vencimiento"": """ + inputFechaVencimiento + @""",
                ""Completada"": """ + finalizado + @"""
            }";
            request.AddStringBody(body, DataFormat.Json);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Response.Redirect("~/About.aspx");
            }
        }
    }
}