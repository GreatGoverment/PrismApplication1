using Microsoft.Practices.Unity;
using Prism.Mvvm;
using PrismApplication.Views;
using System.Linq;
using System.Windows;
using Prism.Unity;
//using Microsoft.Practices.Prism.UnityExtensions;

namespace PrismApplication
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            ViewModelLocator.SetAutoWireViewModel(this.Shell, true); // ここでViewModelを差し込む
            ((Shell)this.Shell).Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // Viewを全てobject型としてコンテナに登録しておく（RegionManagerで使うため）
            this.Container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(t => t.Namespace.EndsWith(".Views")),
                getFromTypes: _ => new[] { typeof(object) },
                getName: WithName.TypeName);

            // ViewModelLocatorでViewModelを生成する方法をUnityで行うようにする
            ViewModelLocationProvider.SetDefaultViewModelFactory(t => this.Container.Resolve(t));
        }
    }
}
