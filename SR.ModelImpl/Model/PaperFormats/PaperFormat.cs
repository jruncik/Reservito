using System;
using System.Drawing;
using NHibernate;
using TV.Core.Context;
using TV.Model;
using TV.ModelImpl.DbModel;

namespace TV.ModelImpl.Model.PaperFormats
{
    public class PaperFormat : IPaperFormat
    {
        public virtual string Name
        {
            get { return _dbPaperFormat.Name; }
            set { _dbPaperFormat.Name = value; }
        }

        public virtual Size Size
        {
            get { return new Size(_dbPaperFormat.Width, _dbPaperFormat.Height); }
            set
            {
                _dbPaperFormat.Width = value.Width;
                _dbPaperFormat.Height = value.Height;
            }
        }

        public bool IsBuildIn
        {
            get { return _dbPaperFormat.IsBuildin; }
        }

        internal DbPaperFormat DbPaperFormat
        {
            get { return _dbPaperFormat; }
        }

        public PaperFormat() :
            this(new DbPaperFormat())
        {
        }

        public PaperFormat(DbPaperFormat dbPaperFormat)
        {
            _dbPaperFormat = dbPaperFormat;
        }

        public virtual void Save()
        {
            using (AppliactionContext.Log.LogTime(this, String.Format("Save paper format '{0}'.", Name)))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        try
                        {
                            if (_dbPaperFormat.Id == Guid.Empty)
                            {
                                session.Save(_dbPaperFormat);
                            }
                            else
                            {
                                session.Update(_dbPaperFormat);
                            }
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
        }

        public virtual void Reload()
        {
            using (AppliactionContext.Log.LogTime(this, String.Format("Reload paper format '{0}'.", Name)))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        try
                        {
                            DbPaperFormat reloadedcustPaperFmt = (DbPaperFormat)session.Load<DbPaperFormat>(_dbPaperFormat.Id);

                            _dbPaperFormat.Name = reloadedcustPaperFmt.Name;
                            _dbPaperFormat.Width = reloadedcustPaperFmt.Width;
                            _dbPaperFormat.Height = reloadedcustPaperFmt.Height;
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
        }

        public virtual void Delete()
        {
            using (AppliactionContext.Log.LogTime(this, String.Format("Delete paper format '{0}'.", Name)))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        try
                        {
                            session.Delete(_dbPaperFormat);
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
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}x{2}", Name, _dbPaperFormat.Width, _dbPaperFormat.Height);
        }

        private readonly DbPaperFormat _dbPaperFormat;
    }
}