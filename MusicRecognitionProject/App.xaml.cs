using MahApps.Metro.Controls.Dialogs;
using MusicRecognitionProject.Dao;
using MusicRecognitionProject.Views;
using System.Windows;

namespace MusicRecognitionProject;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{
    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IDialogCoordinator, DialogCoordinator>();
        containerRegistry.RegisterSingleton<ITranslationsDao, TranslationsDao>();
        containerRegistry.RegisterSingleton<IInputDevicesDao, InputDevicesDao>();
        containerRegistry.RegisterSingleton<IGlobalSettingsDao, GlobalSettingsDao>();
    }
}

