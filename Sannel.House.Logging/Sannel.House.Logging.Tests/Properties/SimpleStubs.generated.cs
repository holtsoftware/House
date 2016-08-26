using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sannel.House.Logging.Models;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sannel.House.Logging.Interface
{
    [CompilerGenerated]
    public class StubIDbContext : IDbContext
    {
        private readonly Dictionary<string, object> _stubs = new Dictionary<string, object>();

        global::Microsoft.EntityFrameworkCore.DbSet<global::Sannel.House.Logging.Models.ApplicationLogEntry> global::Sannel.House.Logging.Interface.IDbContext.ApplicationLogEntries
        {
            get
            {
                return ((ApplicationLogEntries_Get_Delegate)_stubs[nameof(ApplicationLogEntries_Get_Delegate)]).Invoke();
            }

            set
            {
                ((ApplicationLogEntries_Set_Delegate)_stubs[nameof(ApplicationLogEntries_Set_Delegate)]).Invoke(value);
            }
        }

        public delegate global::Microsoft.EntityFrameworkCore.DbSet<global::Sannel.House.Logging.Models.ApplicationLogEntry> ApplicationLogEntries_Get_Delegate();

        public StubIDbContext ApplicationLogEntries_Get(ApplicationLogEntries_Get_Delegate del)
        {
            _stubs[nameof(ApplicationLogEntries_Get_Delegate)] = del;
            return this;
        }

        public delegate void ApplicationLogEntries_Set_Delegate(global::Microsoft.EntityFrameworkCore.DbSet<global::Sannel.House.Logging.Models.ApplicationLogEntry> value);

        public StubIDbContext ApplicationLogEntries_Set(ApplicationLogEntries_Set_Delegate del)
        {
            _stubs[nameof(ApplicationLogEntries_Set_Delegate)] = del;
            return this;
        }

        int global::Sannel.House.Logging.Interface.IDbContext.SaveChanges()
        {
            return ((SaveChanges_Delegate)_stubs[nameof(SaveChanges_Delegate)]).Invoke();
        }

        public delegate int SaveChanges_Delegate();

        public StubIDbContext SaveChanges(SaveChanges_Delegate del)
        {
            _stubs[nameof(SaveChanges_Delegate)] = del;
            return this;
        }

        global::System.Threading.Tasks.Task<int> global::Sannel.House.Logging.Interface.IDbContext.SaveChangesAsync(global::System.Threading.CancellationToken cancellationToken)
        {
            return ((SaveChangesAsync_CancellationTokenCancellationToken_Delegate)_stubs[nameof(SaveChangesAsync_CancellationTokenCancellationToken_Delegate)]).Invoke(cancellationToken);
        }

        public delegate global::System.Threading.Tasks.Task<int> SaveChangesAsync_CancellationTokenCancellationToken_Delegate(global::System.Threading.CancellationToken cancellationToken);

        public StubIDbContext SaveChangesAsync(SaveChangesAsync_CancellationTokenCancellationToken_Delegate del)
        {
            _stubs[nameof(SaveChangesAsync_CancellationTokenCancellationToken_Delegate)] = del;
            return this;
        }

        void global::System.IDisposable.Dispose()
        {
            ((IDisposable_Dispose_Delegate)_stubs[nameof(IDisposable_Dispose_Delegate)]).Invoke();
        }

        public delegate void IDisposable_Dispose_Delegate();

        public StubIDbContext Dispose(IDisposable_Dispose_Delegate del)
        {
            _stubs[nameof(IDisposable_Dispose_Delegate)] = del;
            return this;
        }
    }
}