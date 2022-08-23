using MCC.Domain.Interfaces.Repositories.General;
using MCC.Domain.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal class TempNotes
    {
        private readonly IPersonToProfileRepo<PersonToProfile, Guid, string> repository;

        public TempNotes(IPersonToProfileRepo<PersonToProfile, Guid, string> assignationRepo)
        {
            repository = assignationRepo;
        }

        protected void BeginTransaction()
        {
            repository.BeginTransaction();
        }

        protected bool TransactionIsInProgress()
        {
            return repository.TransactionIsInProgress();
        }

        protected void SendToSaveAllChanges()
        {
            repository.SendToSaveAllChanges();
        }

        protected void CommitTransaction()
        {
            repository.CommitTransaction();
        }

        protected void RollbackTransaction()
        {
            repository.RollbackTransaction();
        }

        protected void CloseTransaction()
        {
            repository.CloseTransaction();
        }
    }
}
