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
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(Variables.token))
            {
                GridView1.Visible = false;
                Button1.Visible = false;
                Button2.Visible = true;

            }
            else
            {
                GridView1.Visible = true;
                Button2.Visible = false;
                Button1.Visible = true;
            }
        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var options = new RestClientOptions("http://localhost:44388"){};
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
                        Variables.token = accessToken;
                        await CargarDatos();
                    }
                    
                }

                Console.WriteLine(response.Content);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

           
        }

        private async Task CargarDatos()
        {
            var options = new RestClientOptions("http://localhost:44388") { };
            var client = new RestClient(options);
            var request = new RestRequest("/api/Tareas", Method.Get);
            request.AddHeader("Authorization", "Bearer " + Variables.token + "");

            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                List<Tarea> tareas = JsonConvert.DeserializeObject<List<Tarea>>(response.Content);

                GridView1.DataSource = tareas;
                GridView1.DataBind();
                Button1.Visible = false;
                Button2.Visible = true;
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<int> selectedIds = new List<int>();

            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox checkBox = (CheckBox)row.FindControl("CheckBox1");
                if (checkBox != null && checkBox.Checked)
                {
                    int id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
                    Response.Redirect("~/Editar.aspx?id=" + id);
                    selectedIds.Add(id);

                }
            }
            // Aquí puedes hacer lo que necesites con los IDs seleccionados
            
        }
        protected void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox headerCheckBox = (CheckBox)sender;
            bool isChecked = headerCheckBox.Checked;

            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox checkBox = (CheckBox)row.FindControl("CheckBox1");
                if (checkBox != null)
                {
                    checkBox.Checked = isChecked;
                }
            }
        }
    }
}