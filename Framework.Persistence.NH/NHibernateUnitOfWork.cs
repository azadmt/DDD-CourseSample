using Framework.Core;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Persistence.NH
{
    public class NHibernateUnitOfWork : IUnitOfWork
    {
        private readonly ISession session;

        public NHibernateUnitOfWork(ISession session)
        {
            this.session = session;

        }
        public void Begin()
        {
            session.BeginTransaction();
        }

        public void Commit()
        {
            session.Transaction.Commit();         
        }

        public void Rollback()
        {
            session.Transaction.Rollback();
        }
    }
}
