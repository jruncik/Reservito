using SR.Core;

namespace SR.Model
{
    public interface IWorkoutInfo : IDbStorable
    {
        int Price { get; set; }

        int Capacity { get; set; }
    }
}
