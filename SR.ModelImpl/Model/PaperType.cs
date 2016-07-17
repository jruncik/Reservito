using NHibernate;
using System;
using System.Drawing;
using TV.Core.Context;
using TV.Model;
using TV.ModelImpl.DbModel;

namespace TV.ModelImpl.Model
{
    public class PaperType : IPaperType
    {
        public Guid Id
        {
            get {
                return _dbPapertype.Id;
            }
            set {
                _dbPapertype.Id = value;
            }
        }

        public Color Color
        {
            get {
                return Color.FromArgb(_dbPapertype.Color);
            }
            set {
                _dbPapertype.Color = value.ToArgb();
            }
        }

        public string Type
        {
            get {
                return _dbPapertype.Type;
            }
            set {
                _dbPapertype.Type = value;
            }
        }

        public PaperType() :
            this(new DbPaperType())
        {
        }

        public PaperType(DbPaperType dbPaperType)
        {
            _dbPapertype = dbPaperType;
        }

        public void Save()
        {
            using (ISession session = UserContext.SessionFactory.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        using (AppliactionContext.Log.LogTime(this, String.Format("Save paper type '{0} {1}'.", Type, Color.ToString())))
                        {
                            session.SaveOrUpdate(_dbPapertype);
                            tx.Commit();
                        }
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

        public void Reload()
        {
            using (ISession session = UserContext.SessionFactory.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        using (AppliactionContext.Log.LogTime(this, String.Format("Reload paper type '{0} {1}'.", Type, Color.ToString())))
                        {
                            DbPaperType reloadedpaperType = session.Load<DbPaperType>(_dbPapertype.Id);

                            _dbPapertype.Color = reloadedpaperType.Color;
                            _dbPapertype.Type = reloadedpaperType.Type;

                            tx.Commit();
                        }
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
                        using (AppliactionContext.Log.LogTime(this, String.Format("Delete paper type '{0} {1}'.", Type, Color.ToString())))
                        {
                            session.Delete(_dbPapertype);
                            tx.Commit();
                        }
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

        internal DbPaperType DbPaperType
        {
            get {
                return _dbPapertype;
            }
        }

        private readonly DbPaperType _dbPapertype;
    }
}