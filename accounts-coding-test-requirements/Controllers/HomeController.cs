using accounts_coding_test_requirements.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace accounts_coding_test_requirements.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();

        /// <summary>
        /// TODO: Add apiUrl to appsettings.json
        /// </summary>
        const string apiUrl = "https://frontiercodingtests.azurewebsites.net/api/accounts/getall"; 

        public async Task<IActionResult> Index()
        {
            var accounts = await GetData();
            var model = new AccountsByStatusScreenModel
            {
                ActiveAccounts = accounts.Where(a => a.AccountStatusId == AccountStatuses.Active).ToList(),
                InactiveAccounts = accounts.Where(a => a.AccountStatusId == AccountStatuses.Inactive).ToList(),
                OverdueAccounts = accounts.Where(a => a.AccountStatusId == AccountStatuses.Overdue).ToList()
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Call the api and deserialize into model.
        /// </summary>
        private async Task<AccountModel[]> GetData()
        {
            var accounts = new AccountModel[0];
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                accounts = await response.Content.ReadAsAsync<AccountModel[]>();
            }
            return accounts;
        }
    }
}
