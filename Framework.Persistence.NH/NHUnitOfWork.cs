using Framework.Core;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Persistence.NH
{
    public class NHUnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        public NHUnitOfWork(ISession session)
        {
            _session = session;
        }

        public void Begin()
        {
            _session.Transaction.Begin();
        }

        public void Commit()
        {
            _session.Transaction.Commit();
        }

        public void Rollback()
        {
            _session.Transaction.Rollback();
        }
    }
}
