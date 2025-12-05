using P02.Models;

namespace P02.Views;

public partial class LivroFormPage : ContentPage
{
    private Livro _livro;

    public LivroFormPage(Livro livro = null)
    {
        InitializeComponent();
        _livro = livro;

        if (_livro != null)
        {
            NomeEntry.Text = _livro.Nome;
            AutorEntry.Text = _livro.Autor;
            EmailEntry.Text = _livro.EmailAutor;
            IsbnEntry.Text = _livro.ISBN;
        }
    }

    private async void Salvar_Clicked(object sender, EventArgs e)
    {
        if (_livro == null)
            _livro = new Livro();

        _livro.Nome = NomeEntry.Text;
        _livro.Autor = AutorEntry.Text;
        _livro.EmailAutor = EmailEntry.Text;
        _livro.ISBN = IsbnEntry.Text;

        await App.Database.SaveLivroAsync(_livro);
        await Navigation.PopAsync();
    }
}
