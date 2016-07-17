using System.Drawing;
using SR.Core;

namespace SR.Model
{
    public interface IPaperFormat: IDbStorable
    {
        string Name { get; set; }
        Size Size { get; set; }
        bool IsBuildIn { get; }
    }
}