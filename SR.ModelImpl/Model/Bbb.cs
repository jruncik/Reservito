using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Core.Context;
using SR.ModelImpl.DbModel;

namespace SR.ModelImpl.Model
{
    public class Bbb
    {
        public Bbb()
        {
            _dbBbb = new DbBbb();
        }

        public Guid Id
        {
            get { return _dbBbb.Id; }
            set { _dbBbb.Id = value; }
        }

        public int Age
        {
            get { return _dbBbb.Age; }
            set { _dbBbb.Age = value; }
        }

        internal DbBbb DbB
        {
            get { return _dbBbb; }
            set { _dbBbb = value; }
        }

        public void Save()
        {
            using (ISession session = UserContext.SessionFactory.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(_dbBbb);
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        AppliactionContext.Log.Critical(this, ex.Message);
                        tx.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public void Delete()
        {
            using (ISession session = UserContext.SessionFactory.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(_dbBbb);
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        AppliactionContext.Log.Critical(this, ex.Message);
                        tx.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private DbBbb _dbBbb;

    }
}
