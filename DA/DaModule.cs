using Ninject.Modules;
using Ninject.Extensions.Conventions;

namespace DA
{
    public class DaModule: NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind( x => x.FromThisAssembly().SelectAllClasses().BindAllInterfaces() );
        }
    }
}
