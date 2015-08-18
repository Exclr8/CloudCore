using System;
using System.Data.Common;
using System.Data.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Frameworkone.UnitTestUtilities.Database
{
    /// <summary>
    /// Allows LINQ to SQL integration testing with automatic rollbacks after each test.
    /// 
    /// Credit: Adapted from Matt Hidinger http://bit.ly/1fssqsB
    /// </summary>
    /// <typeparam name="TContext">The type of data context to use</typeparam>
    public abstract class RolledBackDataContextTests<TContext> where TContext : DataContext
    {
        private TContext _context;
        private DbTransaction _transaction;

        protected RolledBackDataContextTests()
        {
            InitDataContext();
        }

        protected RolledBackDataContextTests(TContext dataContext)
        {
            _context = dataContext;
            InitDataContext();
        }

        private void InitDataContext()
        {
            EnsureContextInstance();
            WrapInTransaction();
        }        

        private void EnsureContextInstance()
        {
            if (_context == null)

            if (string.IsNullOrEmpty(ConnectionString))
            {
                _context = (TContext)Activator.CreateInstance(typeof(TContext));
            }
            else
            {
                _context = (TContext)Activator.CreateInstance(typeof(TContext), ConnectionString);
            }
        }
        
        [TestInitialize]
        public void WrapInTransaction()
        {
            _context.Connection.Open();
            _transaction = _context.Connection.BeginTransaction();
            _context.Transaction = _transaction;
        }
        /// <summary>
        /// Provides access to the internal data context. Any changes made will be automatically rolled back
        /// </summary>
        protected TContext Context
        {
            get
            {
                if (_context == null)
                    InitDataContext();

                return _context;
            }
        }

        /// <summary>
        /// Optionally specify the connection string to use
        /// </summary>
        protected virtual string ConnectionString
        {
            get
            {
                return null;
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _transaction.Rollback();
            _context.Dispose();
            _context = null;
        }
    }
}
