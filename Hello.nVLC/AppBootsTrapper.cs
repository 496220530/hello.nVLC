using System.Windows;
using Autofac;
using Caliburn.Micro.Autofac;
using Hello.nVLC.Modules;

namespace Hello.nVLC
{
    public class AppBootstrapper : AutofacBootstrapper<MainViewModel>
    {
        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }

        protected override void ConfigureBootstrapper()
        {
            base.ConfigureBootstrapper();
            EnforceNamespaceConvention = false;
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<MainViewModel>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterModule<WindowsModule>();
            builder.RegisterModule<NAudioModule>();
            builder.RegisterModule<VlcModule>();
        }
    }
}
