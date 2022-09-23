using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Domain.Interfaces
{
    public interface IPersonActions
    {
        Task DepositMoney(Guid personId);
    }
}
