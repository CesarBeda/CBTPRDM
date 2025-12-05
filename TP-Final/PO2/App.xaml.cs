using P02.Services;

namespace P02;

public partial class App : Application
{
    static LivroDatabase database;

    public static LivroDatabase Database
    {
        get
        {
            if (database == null)
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "livros.db3");
                database = new LivroDatabase(path);
            }
            return database;
        }
    }

    public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new AppShell());
	}
}