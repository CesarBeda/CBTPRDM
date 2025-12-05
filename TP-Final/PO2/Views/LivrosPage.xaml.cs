using P02.Models;

namespace P02.Views;

public partial class LivrosPage : ContentPage
{
    public LivrosPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        ListaLivros.ItemsSource = await App.Database.GetLivrosAsync();
    }

    private async void NovoLivro_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LivroFormPage());
    }

    private async void Editar_Clicked(object sender, EventArgs e)
    {
        var livro = (sender as Button).BindingContext as Livro;
        await Navigation.PushAsync(new LivroFormPage(livro));
    }

    private async void Excluir_Clicked(object sender, EventArgs e)
    {
        var livro = (sender as Button).BindingContext as Livro;
        await App.Database.DeleteLivroAsync(livro);
        ListaLivros.ItemsSource = await App.Database.GetLivrosAsync();
    }
}
