using GAguirreS5.Models;

namespace GAguirreS5.Views;

public partial class vHome : ContentPage
{
	public vHome()
	{
		InitializeComponent();
	}

    private void btbInsertar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        App.personrepo.AddNewPerson(txtNombre.Text);
        status.Text = App.personrepo.StatusMessage;

    }

    private void btnlistar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        List<Persona> people = App.personrepo.GetAllPeople();
        ListarPersonas.ItemsSource = people;

    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        if (int.TryParse(txtId.Text, out int id))
        {
            App.personrepo.DeletePerson(id);
            status.Text = App.personrepo.StatusMessage;
        }
        else
        {
            status.Text = "ID inválido";
        }
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        if (int.TryParse(txtId.Text, out int id))
        {
            App.personrepo.UpdatePerson(id, txtNuevoNombre.Text);
            status.Text = App.personrepo.StatusMessage;
        }
        else
        {
            status.Text = "ID inválido";
        }
    }
}