using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlowBuddie.Abstractions
{
    public interface IEntity
    {
        string Id { get; }

        DateTimeOffset CreatedAt { get; }

        DateTimeOffset UpdatedAt { get; }

        string CreatedBy { get; }

        string UpdatedBy { get; }
    }
}
