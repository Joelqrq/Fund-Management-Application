using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FundManagementApplication.DataAccess;
using FundManagementApplication.Utilities;
using FundManagementApplication.ViewModels;
using FundManagementApplication.Services;
using System.Threading.Tasks;
using FundManagementApplication.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace FundManagementApplication.Controllers {

    [Authorize]
    public class DashboardController : Controller {
        public AzureDbContext AzureDb { get; }
        public IHttpClientFactory ClientFactory { get; }

        public DashboardController(AzureDbContext azureDb, IHttpClientFactory clientFactory) {
            AzureDb = azureDb;
            ClientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard() {

            var model = new DashboardViewModel();

            //Setup fund list
            model.Funds = await AzureDb.Funds.GetFundNames(User.Claims.GetIDFromToken());
            model.SelectedFund = model.Funds.First().Value;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string SelectedFund, string SelectedDate = null) {

            //Get today's date if it's past 5pm
            var time = DateTime.Now.TimeOfDay.Hours;
            SelectedDate = time < 17 ? DateTime.Today.AddDays(-1).ToString() : DateTime.Today.ToString();

            //Retrieve fund factsheet details
            var model = await new DashboardGenerator(AzureDb).GenerateDashboardData(SelectedFund, SelectedDate);
            model.Funds = await AzureDb.Funds.GetFundNames(User.Claims.GetIDFromToken());
            return View("Dashboard", model);
        }

        [HttpGet("[controller]/[action]/{fund}/{date}")]
        public async Task<IActionResult> ExecuteFactSheetAction(int SelectAction, [FromRoute]string fund, [FromRoute]string date = null) {

            //Format date properly
            //if(date != null)
            //    date = HttpUtility.UrlDecode(date);

            //Get today's date if it's past 5pm
            var time = DateTime.Now.TimeOfDay.Hours;
            date = time < 17 ? DateTime.Today.AddDays(-1).ToString() : DateTime.Today.ToString();

            FundFactSheetDto fundFactSheet = await new FundFactSheetGenerator(AzureDb).GenerateFactSheet(User.Claims.GetIDFromToken(), fund, date);

            switch (SelectAction) {
                case 1:
                    //Get access token key
                    using(var client = ClientFactory.CreateClient("SendFactSheet")) {
                        client.DefaultRequestHeaders.Add("X-UIPATH-TenantName", "NilDefaultca3f552939");
                        var httpContent = new StringContent(JsonSerializer.Serialize(new {
                            grant_type = "refresh_token",
                            client_id = "8DEv1AMNXczW3y4U15LL3jYf62jK93n5",
                            refresh_token = "F7gOJTuAzssxBN3ZBdycu1uuGXSyWAxY6OiND_9zUpz3W"
                        }, new JsonSerializerOptions() {
                            WriteIndented = true
                        }));
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        var response = await client.PostAsync("https://account.uipath.com/oauth/token", httpContent);
                        response.EnsureSuccessStatusCode();
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var responseJson = JObject.Parse(responseBody);
                        string accessTokenKey = responseJson["access_token"].ToString();
                        //Add access token key to header
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessTokenKey);
                        //Get folder ID
                        response = await client.GetAsync("https://cloud.uipath.com/nilakspdzp/JoelQ/odata/Folders");
                        response.EnsureSuccessStatusCode();
                        responseBody = await response.Content.ReadAsStringAsync();
                        responseJson = JObject.Parse(responseBody);
                        string folderId = responseJson["value"][0]["Id"].ToString();
                        //Set folder ID
                        client.DefaultRequestHeaders.Add("X-UIPATH-OrganizationUnitId", folderId);
                        //Get Release Key
                        response = await client.GetAsync("https://cloud.uipath.com/nilakspdzp/JoelQ/odata/Releases?$filter=ProcessKey eq 'EmailAutomation'");
                        response.EnsureSuccessStatusCode();
                        responseBody = await response.Content.ReadAsStringAsync();
                        responseJson = JObject.Parse(responseBody);
                        string releaseKey = responseJson["value"][0]["Key"].ToString();
                        //Get Robot ID
                        response = await client.GetAsync("https://cloud.uipath.com/nilakspdzp/JoelQ/odata/Robots?$filter=Name eq 'JoelRobot'");
                        response.EnsureSuccessStatusCode();
                        responseBody = await response.Content.ReadAsStringAsync();
                        responseJson = JObject.Parse(responseBody);
                        string robotId = responseJson["value"][0]["Id"].ToString();
                        //Start Job(Process)
                        httpContent = new StringContent("{ \"startInfo\":{\"ReleaseKey\": \""+releaseKey+"\",\"Strategy\": \"Specific\",\"RobotIds\": ["+robotId+"],\"JobsCount\": 0,\"InputArguments\": \"{ \\\"FundID\\\": \\\""+fund+"\\\" }\"}}");
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        response = await client.PostAsync("https://cloud.uipath.com/nilakspdzp/JoelQ/odata/Jobs/UiPath.Server.Configuration.OData.StartJobs", httpContent);
                        response.EnsureSuccessStatusCode();
                    }
                    return View("Factsheet", fundFactSheet);
                case 2:
                    //Call ctrl + P
                    return View("Factsheet", fundFactSheet);
                case 3:
                    return View("Factsheet", fundFactSheet);
                default:
                    return RedirectToAction("Search", new { SelectedFund = fund, SelectedDate = DateTime.Today.ToString() });
            }
        }
    }
}
