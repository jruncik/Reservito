using System.Drawing;
using TV.Core;

namespace TV.Model
{
    public interface IPaperFormat: IDbStorable
    {
        string Name { get; set; }
        Size Size { get; set; }
        bool IsBuildIn { get; }
    }
}