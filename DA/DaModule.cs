using Ninject.Modules;
using Ninject.Extensions.Conventions;

namespace DA
{
    class DaModule: NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind( x => x.FromThisAssembly().SelectAllClasses().BindAllInterfaces() );
        }
    }
}
