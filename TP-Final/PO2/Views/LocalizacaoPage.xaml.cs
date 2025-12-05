using Microsoft.Maui.Devices.Sensors;

namespace P02.Views;

public partial class LocalizacaoPage : ContentPage
{
    public LocalizacaoPage()
    {
        InitializeComponent();
    }

    private async void OnGetLocationClicked(object sender, EventArgs e)
    {
        var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

        if (status != PermissionStatus.Granted)
        {
            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        }

        if (status != PermissionStatus.Granted)
        {
            Resultado.Text = "Permissão de localização negada.";
            return;
        }

        try
        {
            var location = await Geolocation.GetLocationAsync();

            if (location != null)
            {
                Resultado.Text = $"Latitude: {location.Latitude}\nLongitude: {location.Longitude}";
            }
            else
            {
                Resultado.Text = "Não foi possível obter a localização.";
            }
        }
        catch (Exception ex)
        {
            Resultado.Text = $"Erro: {ex.Message}";
        }
    }
}