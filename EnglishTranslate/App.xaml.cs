using System.Windows;
using BL;
using DA;
using Ninject;
using Ninject.Modules;

namespace EnglishTranslate
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel container;
        protected override void OnStartup( StartupEventArgs e )
        {
            base.OnStartup( e );
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            this.container = new StandardKernel();
            container.Load(new MainModule());
        }

        private void ComposeObjects()
        {
            Current.MainWindow = this.container.Get<MainWindow>();
            Current.MainWindow.Title = "MainWindow";
        }
    }
}
