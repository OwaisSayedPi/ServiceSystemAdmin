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
    public class ServiceCreation:Page
    {
        public ServiceCreation()
        {
            PageName = "Service Creation";
        }
        OutResponse<string> outResponse = new OutResponse<string>();
        Company company = new Company();

        public override void DisplayQuestions()
        {
            Services service = new Services();
            Console.WriteLine("Enter CounterID");
            service.CounterID = GetReader.GetInteger("Enter a valid CounterID.");
            Console.WriteLine("Enter Service Name");
            service.ServiceName = GetReader.GetString("Enter a valid service name.");
            List<Question> questionList = QuestionToAdd();
            service.Question = questionList;

            using (HttpClient client = new HttpClient())
            {
                OutResponse<string> res = client.PostAsJsonAsync("https://localhost:44391/Api/Service", service).Result.Content.ReadFromJsonAsync<OutResponse<string>>().Result;

                Console.WriteLine(res.ResMessage);
                Console.WriteLine(res.ResData);
            }
            Console.ReadLine();
        }

        private List<Question> QuestionToAdd()
        {
            List<Question> questionList = new List<Question>();
            bool check = true;
            int counter = 1;
            while (check)
            {
                Question question = new Question();
                Console.WriteLine($"Enter Question {counter}");
                question.QuestionID = counter;
                question.QuestionString = GetReader.GetString("Enter a valid Question.");
                counter++;
                Console.WriteLine("Do you want to add more: y/n");
                char.TryParse(Console.ReadLine(), out char choice);
                if (choice == 'n' || choice == 'N')
                {
                    check = false;
                }
                questionList.Add(question); 
            }

            return questionList;
        }
    }
}
