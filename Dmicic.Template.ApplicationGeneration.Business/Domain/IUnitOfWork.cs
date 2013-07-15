using Dmicic.Template.ApplicationGeneration.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Dmicic.Template.ApplicationGeneration.Business.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        TransactionScope StartTransaction();
    }
}
