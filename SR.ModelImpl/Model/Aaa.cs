using NHibernate;
using System;
using TV.Core.Context;
using TV.ModelImpl.DbModel;

namespace TV.ModelImpl.Model
{
    public class Aaa
    {
        public Aaa()
        {
            _bbb = new Bbb();
            _dbAaa = new DbAaa();
            _dbAaa.B = _bbb.DbB;
        }

        public Guid Id
        {
            get { return _dbAaa.Id; }
            set { _dbAaa.Id = value; }
        }

        public string Name
        {
            get { return _dbAaa.Name; }
            set { _dbAaa.Name = value; }
        }

        public Bbb B
        {
            get { return _bbb; }
            set
            {
                _bbb = value;
                _dbAaa.B = _bbb.DbB;
            }
        }

        public void Save()
        {
            using (ISession session = UserContext.SessionFactory.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(_dbAaa);
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
                        session.Delete(_dbAaa);
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

        private DbAaa _dbAaa;
        private Bbb _bbb;
    }
}
