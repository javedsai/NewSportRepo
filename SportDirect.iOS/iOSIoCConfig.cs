using System;
using SportDirect.Bootstrap;

namespace SportDirect.iOS
{
    public class iOSIoCConfig : IoCConfig
    {
        public override void RegisterServices()
        {
            base.RegisterServices();
            //SimpleIoc.Default.Register<ISqlite, Sqlite>();
            // TODO: register other native based services here!
        }
    }
}
