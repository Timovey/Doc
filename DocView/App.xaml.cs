using BusinessLogic.Logic;
using System;
using System.Configuration;
using System.Windows;
using Unity;
using Unity.Lifetime;


namespace DocView
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer currentContainer = BuildUnityContainer(); 
            var mainWindow = currentContainer.Resolve<MainWindow>();
            mainWindow.Show();
        }


        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer(); 
           // currentContainer.RegisterType<SaveLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
