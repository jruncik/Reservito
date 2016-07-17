using System.Collections.Generic;

namespace TV.Model
{
    public interface IPaperFormats
    {
        IList<IPaperFormat> Formats { get; }
        IPaperFormat GetFormat(string name);
        IPaperFormat AddFormat(string name, int width, int height);
        void DeleteFormat(IPaperFormat paperformat);
    }
}