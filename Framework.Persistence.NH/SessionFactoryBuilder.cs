using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using System.Data;
using System.Reflection;

namespace Framework.Persistence.NH
{
    public static class SessionFactoryBuilder
    {
        public static ISessionFactory Create(string connectionStringName, Assembly assembly)
        {
            var configuration = new Configuration();
            configuration.DataBaseIntegration(cfg =>
            {

               // cfg.Dialect<MsSql2012Dialect>();
                cfg.Dialect<MsSql2008Dialect>();
                cfg.Driver<SqlClientDriver>();
                cfg.ConnectionStringName = connectionStringName;
                cfg.IsolationLevel = IsolationLevel.ReadCommitted;
            });
            var modelMapper = new ModelMapper();
            modelMapper.AddMappings(assembly.GetExportedTypes());

            var hbmMapping = modelMapper.CompileMappingForAllExplicitlyAddedEntities();
            configuration.AddDeserializedMapping(hbmMapping, "test");

            return configuration.BuildSessionFactory();
        }
    }
}
