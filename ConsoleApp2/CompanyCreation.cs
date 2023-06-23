using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class CompanyCreation: Page
    {
        public CompanyCreation()
        {
            PageName = "Company Creation";
        }
        public override void DisplayQuestions()
        {
            Company company = new Company();
            Console.WriteLine("Enter Company");
            company.CompanyName = GetReader.GetString("Enter a valid company name.");

            using (HttpClient client = new HttpClient())
            {
                OutResponse<Company> res = client.PostAsJsonAsync("https://localhost:44391/Api/Company", company).Result.Content.ReadFromJsonAsync<OutResponse<Company>>().Result;

                Console.WriteLine(res.ResMessage);
                Console.WriteLine(res.ResData.CompanyID + "-->" + company.CompanyName);
            }
            Console.ReadLine();
        }
    }
}
