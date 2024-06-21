using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionTareas
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        //protected async Task Button1_ClickAsync(object sender, EventArgs e)
        //{
        //    var options = new RestClientOptions("http://localhost:44388")
        //    {
        //        Timeout = TimeSpan.FromSeconds(20),
        //    };
        //    var client = new RestClient(options);
        //    var request = new RestRequest("/token", Method.Get);
        //    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        //    request.AddParameter("username", "test");
        //    request.AddParameter("password", "test");
        //    request.AddParameter("grant_type", "password");
        //    RestResponse response = await client.ExecuteAsync(request);
        //    Console.WriteLine(response.Content);

        //    var jsonResponse = response.Content;
        //    var tokenResponse = JsonConvert.DeserializeObject<dynamic>(jsonResponse);

        //    // Obtener el valor del access_token
        //    string accessToken = tokenResponse.access_token;

        //    // Mostrar el token en la consola
        //    Console.WriteLine("Access Token: " + accessToken);

        //    if (string.IsNullOrEmpty(accessToken))
        //    {
        //        // Si el accessToken es vacío o nulo, redirigir a una página
        //        Response.Redirect("~/PaginaError.aspx");
        //    }
        //    else
        //    {
        //        // Si se obtuvo un accessToken válido, redirigir a otra página
        //        Response.Redirect("~/PaginaExito.aspx");
        //    }

        //}
    }
}