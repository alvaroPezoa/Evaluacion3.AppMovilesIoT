namespace GestionEstudianteEva3.AppMovil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Vista.ListarAlumno();
        }
    }
}
