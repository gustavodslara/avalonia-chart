using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using avaloniachart.DataAccess;
using avaloniachart.ViewModels;
using avaloniachart.Views;
using System.IO;

namespace avaloniachart;

public partial class App : Application
{

    public static DatabaseContext DatabaseContext;
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        DatabaseContext = new DatabaseContext(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "programmers.sqlite"));
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
