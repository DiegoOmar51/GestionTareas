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
    public partial class Tareas : System.Web.UI.Page
    {
        protected async Task Page_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                var options = new RestClientOptions("http://localhost:44388") { };
                var client = new RestClient(options);
                var request = new RestRequest("/token", Method.Post);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("username", "test");
                request.AddParameter("password", "test");
                request.AddParameter("grant_type", "password");

                var response = await client.ExecuteAsync(request);

                Console.WriteLine(response.Content);
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    var jsonResponse = response.Content;
                    var tokenResponse = JsonConvert.DeserializeObject<dynamic>(jsonResponse);

                    string accessToken = tokenResponse.access_token;

                    if (!string.IsNullOrEmpty(accessToken))
                    {
                        //Response.Redirect("~/Tareas.aspx");
                        accessToken = Variables.token;

                        await CargarDatos();
                    }

                }

                Console.WriteLine(response.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            
            //await CargarDatos();
            
        }

        private async Task CargarDatos()
        {
            var options = new RestClientOptions("http://localhost:44388"){};
            var client = new RestClient(options);
            var request = new RestRequest("/api/Tareas", Method.Get);
            request.AddHeader("Authorization", "Bearer "+ Variables.token + "");

            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                List<Tarea> tareas = JsonConvert.DeserializeObject<List<Tarea>>(response.Content);

                GridView1.DataSource = tareas;
                GridView1.DataBind();
            }
            else
            {
                // Manejar error
                Console.WriteLine(response.ErrorMessage);
            }
        }
    }
}