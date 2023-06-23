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
    public class CounterCreation : Page
    {
        public CounterCreation()
        {
            PageName = "Counter Creation";
        }

        public override void DisplayQuestions()
        {
            Counter counter = new Counter();
            Console.WriteLine("Enter BranchID");
            counter.BranchID = GetReader.GetInteger("Enter a valid BranchID.");
            Console.WriteLine("Enter Counter Name");
            counter.CounterName = GetReader.GetString("Enter a valid counter name.");

            using (HttpClient client = new HttpClient())
            {
                OutResponse<Branch> res = client.PostAsJsonAsync("https://localhost:44391/Api/Counter", counter).Result.Content.ReadFromJsonAsync<OutResponse<Branch>>().Result;

                Console.WriteLine(res.ResMessage);
                Console.WriteLine(res.ResData.BranchID + "-->" + counter.CounterName);
            }
            Console.ReadLine();
        }
    }
}
