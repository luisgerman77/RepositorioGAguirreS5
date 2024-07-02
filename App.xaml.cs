using GAguirreS5.Utils;

namespace GAguirreS5
{
    public partial class App : Application
    {
        public static PersonRepository personrepo { get; set; }
        public App(PersonRepository person)
        {
            InitializeComponent();

            MainPage = new Views.vHome();
            personrepo=person;
        }
    }
}
