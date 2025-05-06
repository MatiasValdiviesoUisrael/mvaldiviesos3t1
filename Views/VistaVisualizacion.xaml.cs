using mvaldiviesos3t1.Models;

namespace mvaldiviesos3t1.Views;

public partial class VistaVisualizacion : ContentPage
{
	public VistaVisualizacion()
	{
		InitializeComponent();
		MostrarDatos();
    }

    private void MostrarDatos()
	{
        lblDatos.Text =
            $"Tipo: {contacto.Tipo}\n" +
            $"Identificación: {contacto.ID}\n" +
            $"Nombres: {contacto.Nombres}\n" +
            $"Apellidos: {contacto.Apellidos}\n" +
            $"Fecha: {contacto.Fecha}\n" +
            $"Correo: {contacto.Correo}\n" +
            $"Salario: {contacto.Salario:C}";

        double aporte = contacto.Salario * 0.0945;
        lblAporte.Text = $"Aporte al IESS: {aporte:C}";
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        string contenido = lblDatos.Text + "\n" + lblAporte.Text;
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "contacto.txt");

        File.WriteAllText(path, contenido);
        DisplayAlert("Exportado", $"Archivo guardado en:\n{path}", "OK");
    }
}