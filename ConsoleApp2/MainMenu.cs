namespace ConsoleApp2
{
    public class MainMenu : Page
    {
        public MainMenu()
        {
            pages.Add(new CompanyCreation());
            pages.Add(new BranchCreation());
            pages.Add(new CounterCreation());
            pages.Add(new ServiceCreation());
        }
    }
}