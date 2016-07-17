using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using NHibernate;
using SR.Core;
using SR.Core.Context;
using SR.Core.Rights;
using SR.Model;
using SR.ModelImpl.DbModel;

namespace SR.ModelImpl.Model.PaperFormats
{
    public class PaperFormats : IPaperFormats
    {
        public PaperFormats()
        {
            ReadFormats();
        }

        public IList<IPaperFormat> Formats
        {
            get { return _paperFormats; }
        }

        public IPaperFormat GetFormat(string name)
        {
            IPaperFormat paperFormat = TryFindPaperFormat(name);
            if (paperFormat != null)
            {
                return paperFormat;
            }

            AppliactionContext.Log.Error(this, String.Format(Resources.PaperFormatAlreadyExist, paperFormat.Name));
            throw new TvException(String.Format(Resources.PaperFormatNotFound, paperFormat.Name));
        }

        public IPaperFormat AddFormat(string name, int width, int height)
        {
            CheckRights();
            IPaperFormat paperFormat = TryFindPaperFormat(name);
            if (paperFormat != null)
            {
                AppliactionContext.Log.Error(this, String.Format(Resources.PaperFormatAlreadyExist, paperFormat.Name));
                throw new TvException(String.Format(Resources.PaperFormatAlreadyExist, paperFormat.Name));
            }

            PaperFormat newPaperFormat = new PaperFormat();
            newPaperFormat.Name = name;
            newPaperFormat.Size = new Size(width, height);

            newPaperFormat.Save();
            _paperFormats.Add(newPaperFormat);

            return newPaperFormat;
        }

        public void DeleteFormat(IPaperFormat paperformat)
        {
            CheckRights();
            if (paperformat.IsBuildIn)
            {
                AppliactionContext.Log.Error(this, "Format can't be deleted.");
                AppliactionContext.Log.Error(this, String.Format(Resources.PapeFormatIsBuildinFormat, paperformat.Name));
                throw new TvException(String.Format(Resources.PapeFormatIsBuildinFormat, paperformat.Name));
            }

            PaperFormat deletedPaperFormat = paperformat as PaperFormat;
            _paperFormats.Remove(deletedPaperFormat);
            deletedPaperFormat.Delete();
        }

        private void ReadFormats()
        {
            using (AppliactionContext.Log.LogTime(this, "Reading all custom aper formats"))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    IList<DbPaperFormat> dbPaperFormats = session.CreateCriteria<DbPaperFormat>().List<DbPaperFormat>();
                    foreach (DbPaperFormat dbPaperFormat in dbPaperFormats)
                    {
                        IPaperFormat newCustomPaperFormat = new PaperFormat(dbPaperFormat);
                        _paperFormats.Add(newCustomPaperFormat);
                        AppliactionContext.Log.Debug(this, String.Format("Custom paper format '{0}' loaded from DB.", newCustomPaperFormat));
                    }
                }
            }
        }

        private void CheckRights()
        {
            if (!UserContext.Context.IsInRole(Roles.ManageUsers))
            {
                AppliactionContext.Log.Error(this, String.Format(Resources.NotEnoughtRights, UserContext.User.Username));
                throw new RightsException(String.Format(Resources.NotEnoughtRights, UserContext.User.Username));
            }
        }

        private IPaperFormat TryFindPaperFormat(string formatName)
        {
            return _paperFormats.FirstOrDefault(format => String.Compare(formatName, format.Name, StringComparison.OrdinalIgnoreCase) == 0);
        }

        private readonly IList<IPaperFormat> _paperFormats = new List<IPaperFormat>(64);
    }
}