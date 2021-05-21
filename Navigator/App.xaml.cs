using Autofac;
using Navigator.StartUp;
using Navigator.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Navigator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Bootstrap.Instance.Build();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
      
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => CurrentDomainOnUnhandledException(args);

            TaskScheduler.UnobservedTaskException += (sender, args) => TaskSchedulerOnUnobservedTaskException(args);

            var bootstrap = new StartUp.Bootstrap();

            var container = bootstrap.Bootstraper();

            using (var scope = container.BeginLifetimeScope())
            {
                HomeWindow main = container.Resolve<HomeWindow>();
                try
                {
                    main.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            var vCulture = new CultureInfo("sr-SP-Latin");//odavde do dole za defaultni jezik bez obzira na windows podesavanja

            Thread.CurrentThread.CurrentCulture = vCulture;
            Thread.CurrentThread.CurrentUICulture = vCulture;
            CultureInfo.DefaultThreadCurrentCulture = vCulture;
            CultureInfo.DefaultThreadCurrentUICulture = vCulture;

            FrameworkElement.LanguageProperty.OverrideMetadata(
            typeof(FrameworkElement),
            new FrameworkPropertyMetadata(
         System.Windows.Markup.XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            base.OnStartup(e);
        }
        private static void CurrentDomainOnUnhandledException(UnhandledExceptionEventArgs args)
        {
            Exception ex = args.ExceptionObject as Exception;
            var terminatingMessage = args.IsTerminating ? " Aplikacija će prestati sa radom." : String.Empty;
            var exceptionMessage = ex == null ? "Nastala je neobradjena greska." : ex.Message;
            var message = string.Concat(exceptionMessage, terminatingMessage);
            if (ex != null)
            {
                MessageBox.Show(message, "Exception Caught", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Exception that doesn't come from System.Exception caught.", "Exception Caught", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private static void TaskSchedulerOnUnobservedTaskException(UnobservedTaskExceptionEventArgs args)
        {
            Exception ex = args.Exception as Exception;
            if (ex != null)
            {
                MessageBox.Show(ex.Message, "Exception Caught", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Exception that doesn't come from System.Exception caught.", "Exception Caught", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            args.SetObserved();
        }
    }
}
