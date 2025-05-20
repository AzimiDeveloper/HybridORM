using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hama.Infrastructure.Repositories.Interfaces
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString();
    }
}
