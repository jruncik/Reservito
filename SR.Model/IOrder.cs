using System;
using System.Collections.Generic;
using System.Drawing;
using TV.Core;

namespace TV.Model
{
    public interface IOrder : IDbStorable
    {
        Guid Id { get; set; }
        IContactPerson Contact { get; set; }
        string OrderType { get; set; }
        DateTime OrderTime { get; set; }
        DateTime FinishTime { get; set; }
        Priority Priority { get; set; }
        IPaperFormat Format { get; set; }
        int PageCount { get; set; }
        int Count { get; set; }
        int QuireCount { get; set; }
        Color PrintColor { get; set; }
        IPaperType PaperType { get; set; }
        IPrintImplementation Implementation { get; set; }
        bool IsSpecimenSupplied { get; set; }
        bool IsPageCompositionSupplied { get; set; }
        IProofsheet Proofsheet { get; set; }
        IFinishingJob Finishing { get; set; }
        string Details { get; set; }
    }
}
