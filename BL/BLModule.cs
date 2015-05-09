using Ninject.Modules;
using Ninject.Extensions.Conventions;

namespace BL
{
    public class BLModule: NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind( x => x.FromThisAssembly().SelectAllClasses().BindAllInterfaces() );
            Kernel.Rebind<IRecordRepository>().To<RecordRepository>().InSingletonScope();
        }
    }
}