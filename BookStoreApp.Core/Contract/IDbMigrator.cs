using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Core.Contract
{
    public interface IDbMigrator
    {
        Task RunAsync();
    }
}
