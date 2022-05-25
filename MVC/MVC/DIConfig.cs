using Data.Dictionary;
using Data.Models;
using JSONRepository;
using Ninject.Modules;
using Ninject.Web.Common;
using SQLRepository;

namespace MVC
{
    public class DIConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IPhoneDictionary<User>>().To<JSONDictionary>();
            //Bind<IPhoneDictionary<User>>().To<SQLDictionary>();

            //Bind<IPhoneDictionary<User>>().To<SQLDictionary>().InTransientScope();
            //Bind<IPhoneDictionary<User>>().To<SQLDictionary>().InSingletonScope();
            //Bind<IPhoneDictionary<User>>().To<SQLDictionary>().InThreadScope();
            //Bind<IPhoneDictionary<User>>().To<SQLDictionary>().InRequestScope();
        }
    }
}