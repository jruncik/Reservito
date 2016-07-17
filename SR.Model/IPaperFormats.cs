using System.Collections.Generic;

namespace SR.Model
{
    public interface IPaperFormats
    {
        IList<IPaperFormat> Formats { get; }
        IPaperFormat GetFormat(string name);
        IPaperFormat AddFormat(string name, int width, int height);
        void DeleteFormat(IPaperFormat paperformat);
    }
}