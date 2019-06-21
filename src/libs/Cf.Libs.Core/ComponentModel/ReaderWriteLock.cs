using System;
using System.Threading;

namespace Cf.Libs.Core.ComponentModel
{
    /// <summary>
    /// Provides a convenience methodology for implementing locked access to resources. 
    /// </summary>
    /// <remarks>
    /// Intended as an infrastructure class.
    /// </remarks>
    public class ReaderWriteLock : IDisposable
    {
        private readonly ReaderWriterLockSlim _rwLock;
        private readonly ReaderWriteLockType _rwType;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReaderWriteLockDisposable"/> class.
        /// </summary>
        /// <param name="rwLock">The readers–writer lock</param>
        /// <param name="readerWriteLockType">Lock type</param>
        public ReaderWriteLock(ReaderWriterLockSlim rwLock, ReaderWriteLockType readerWriteLockType = ReaderWriteLockType.Write)
        {
            _rwLock = rwLock;
            _rwType = readerWriteLockType;

            switch (_rwType)  
            {
                case ReaderWriteLockType.Read:
                    _rwLock.EnterReadLock();
                    break;
                case ReaderWriteLockType.Write:
                    _rwLock.EnterWriteLock();
                    break;
                case ReaderWriteLockType.UpgradeableRead:
                    _rwLock.EnterUpgradeableReadLock();
                    break;
            }
        }

        void IDisposable.Dispose()
        {
            switch (_rwType)
            {
                case ReaderWriteLockType.Read:
                    _rwLock.ExitReadLock();
                    break;
                case ReaderWriteLockType.Write:
                    _rwLock.ExitWriteLock();
                    break;
                case ReaderWriteLockType.UpgradeableRead:
                    _rwLock.ExitUpgradeableReadLock();
                    break;
            }
        }
    }
}
