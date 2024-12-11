using Firebase.Database;
using GestionEstudianteEva3.modelos.Modelos;
using System.Collections.ObjectModel;

namespace GestionEstudianteEva3.AppMovil.Vista;

public partial class ListarAlumno : ContentPage
{
    FirebaseClient client = new FirebaseClient("https://apezoa-fad29-default-rtdb.firebaseio.com/");

    public ObservableCollection<Alumno> Lista { get; set; } = new ObservableCollection<Alumno>();

    public ListarAlumno()
    {
        InitializeComponent();
        BindingContext = this;
        CargarLista();
    }

    private void CargarLista()
    {
        client.Child("Alumnos").AsObservable<Alumno>().Subscribe((alumno) =>
        {
            if (alumno != null)
            {
                Lista.Add(alumno.Object);
            }
        });
    }

    private void filtroSerchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        string filtra = filtroSerchBar.Text.ToLower();
        if (filtra.Length > 0)
        {
            ListaCollection.ItemsSource = Lista.Where(x => x.NombreCompleto.ToLower().Contains(filtra));
        }
        else
        {
            ListaCollection.ItemsSource = Lista;
        }
    }

    private void nuevoAlumnoBoton_Clicked(object sender, EventArgs e)
    {

    }
}