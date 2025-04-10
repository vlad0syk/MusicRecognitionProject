﻿using MahApps.Metro.Controls.Dialogs;
using MusicRecognitionProject.Dao;
using MusicRecognitionProject.Views;
using System.Windows;
using MusicRecognitionProject.Services;

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

        containerRegistry.Register<IApiService, ApiService>();
        containerRegistry.Register<IGlobalSettingsDao, GlobalSettingsDao>();
        containerRegistry.Register<IMusicResultDao, MusicResultDao>();
    }
}

