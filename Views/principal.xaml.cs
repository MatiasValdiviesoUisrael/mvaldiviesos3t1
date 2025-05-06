using mvaldiviesos3t1.Models;
using System.Text.RegularExpressions;

namespace mvaldiviesos3t1.Views;

public partial class principal : ContentPage
{
	public principal()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        string tipo = pickerIdentificacion.SelectedItem?.ToString() ?? "";
        string id = entryIdentificacion.Text?.Trim() ?? "";
        string nombres = entryNombres.Text?.Trim() ?? "";
        string apellidos = entryApellidos.Text?.Trim() ?? "";
        string correo = entryCorreo.Text?.Trim() ?? "";
        string salarioTexto = entrySalario.Text?.Trim() ?? "";
        double salario;

        if (string.IsNullOrWhiteSpace(tipo) || string.IsNullOrWhiteSpace(id) ||
            string.IsNullOrWhiteSpace(nombres) || string.IsNullOrWhiteSpace(apellidos) ||
            !double.TryParse(salarioTexto, out salario) || salario <= 0 ||
            !Regex.IsMatch(correo, @"^[\w\-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
        {
            DisplayAlert("Error", "Por favor, completa todos los campos correctamente.", "OK");
            return;
        }

        if (tipo == "CI" && !Regex.IsMatch(id, @"^\d{10}$") ||
            tipo == "RUC" && !Regex.IsMatch(id, @"^\d{13}$"))
        {
            DisplayAlert("Error", "Formato de identificación inválido.", "OK");
            return;
        }

        contacto.Tipo = tipo;
        contacto.ID = id;
        contacto.Nombres = nombres;
        contacto.Apellidos = apellidos;
        contacto.Fecha = dateFecha.Date.ToShortDateString();
        contacto.Correo = correo;
        contacto.Salario = salario;

        Navigation.PushAsync(new VistaVisualizacion());
    }
}