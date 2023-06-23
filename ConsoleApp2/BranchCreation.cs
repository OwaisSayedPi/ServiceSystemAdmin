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
    public class BranchCreation:Page
    {
        public BranchCreation()
        {
            PageName = "Branch Creation";
        }

        public override void DisplayQuestions()
        {
            Branch branch = new Branch();
            Console.WriteLine("Enter CompanyID");
            branch.CompanyID = GetReader.GetInteger("Enter a valid CompanyID.");
            Console.WriteLine("Enter Branch Name");
            branch.BranchName = GetReader.GetString("Enter a valid branch name.");

            using (HttpClient client = new HttpClient())
            {
                OutResponse<Branch> res = client.PostAsJsonAsync("https://localhost:44391/Api/Branch", branch).Result.Content.ReadFromJsonAsync<OutResponse<Branch>>().Result;

                Console.WriteLine(res.ResMessage);
                Console.WriteLine(res.ResData.BranchID + "-->" + branch.BranchName);
            }
            Console.ReadLine();
        }
    }
}
