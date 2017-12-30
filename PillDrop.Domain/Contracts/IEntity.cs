using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillDrop.Domain.Contracts
{
    public interface IEntity
    {
        long Id { get; }
        bool IsTransient();
    }
}

