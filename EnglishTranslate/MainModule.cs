using BL;
using DA;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace EnglishTranslate
{
    public class MainModule:NinjectModule
    {
                 
        public override void Load()
        {
            Kernel.Load(new INinjectModule[]{new BLModule(), new DaModule()});
            Kernel.Bind( x => x.FromThisAssembly().SelectAllClasses().BindAllInterfaces() );
        }
    }
}