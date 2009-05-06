﻿
//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace PLINQO.Tracker.Data
{
    /// <summary>
    /// The manager class for Audit.
    /// </summary>
    public partial class AuditManager 
        : CodeSmith.Data.EntityManagerBase<TrackerDataManager, PLINQO.Tracker.Data.Audit>
    {
        /// <summary>
        /// Initializes the <see cref="AuditManager"/> class.
        /// </summary>
        static AuditManager()
        {
            AddRules();
        }

        /// <summary>
        /// Initializes the <see cref="AuditManager"/> class.
        /// </summary>
        /// <param name="manager">The current manager.</param>
        public AuditManager(TrackerDataManager manager) : base(manager)
        {
            OnCreated();
        }

        /// <summary>
        /// Gets the current context.
        /// </summary>
        protected PLINQO.Tracker.Data.TrackerDataContext Context
        {
            get { return Manager.Context; }
        }
        
        /// <summary>
        /// Gets the entity for this manager.
        /// </summary>
        protected System.Data.Linq.Table<PLINQO.Tracker.Data.Audit> Entity
        {
            get { return Manager.Context.Audit; }
        }
        
        
        /// <summary>
        /// Creates the key for this entity.
        /// </summary>
        public static CodeSmith.Data.IEntityKey<int> CreateKey(int id)
        {
            return new CodeSmith.Data.EntityKey<int>(id);
        }
        
        /// <summary>
        /// Gets an entity by the primary key.
        /// </summary>
        /// <param name="key">The key for the entity.</param>
        /// <returns>
        /// An instance of the entity or null if not found.
        /// </returns>
        /// <remarks>
        /// This method is expecting key to be of type IEntityKey&lt;int&gt;.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when key is not of type IEntityKey&lt;int&gt;.</exception>
        public override PLINQO.Tracker.Data.Audit GetByKey(CodeSmith.Data.IEntityKey key)
        {
            if (key is CodeSmith.Data.IEntityKey<int>)
            {
                var entityKey = (CodeSmith.Data.IEntityKey<int>)key;
                return GetByKey(entityKey.Key);
            }
            else
            {
                throw new ArgumentException("Invalid key, expected key to be of type IEntityKey<int>");
            }
        }
        
        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <returns>An instance of the entity or null if not found.</returns>
        public PLINQO.Tracker.Data.Audit GetByKey(int id)
        {
            if (Context.LoadOptions == null) 
                return Query.GetByKey.Invoke(Context, id);
            else
                return Entity.FirstOrDefault(a => a.Id == id);
        }
        
        /// <summary>
        /// Immediately deletes the entity by the primary key from the underlying data source with a single delete command.
        /// </summary>
        /// <returns>The number of rows deleted from the database.</returns>
        public int Delete(int id)
        {
            return Entity.Delete(a => a.Id == id);
        }
        /// <summary>
        /// Gets a query by an index.
        /// </summary>
        public IQueryable<PLINQO.Tracker.Data.Audit> GetByUserId(int? userId)
        {
            if (Context.LoadOptions == null) 
                return Query.GetByUserId.Invoke(Context, userId);
            else
                return Entity.Where(a => a.UserId == userId);
        }
        /// <summary>
        /// Gets a query by an index.
        /// </summary>
        public IQueryable<PLINQO.Tracker.Data.Audit> GetByTaskId(int? taskId)
        {
            if (Context.LoadOptions == null) 
                return Query.GetByTaskId.Invoke(Context, taskId);
            else
                return Entity.Where(a => a.TaskId == taskId);
        }

        #region Extensibility Method Definitions
        /// <summary>Called by the static constructor to add shared rules.</summary>
        static partial void AddRules();
        /// <summary>Called when the class is created.</summary>
        partial void OnCreated();
        #endregion
        
        #region Query
        /// <summary>
        /// A private class for lazy loading static compiled queries.
        /// </summary>
        private static partial class Query
        {

            internal static readonly Func<PLINQO.Tracker.Data.TrackerDataContext, int, PLINQO.Tracker.Data.Audit> GetByKey = 
                System.Data.Linq.CompiledQuery.Compile(
                    (PLINQO.Tracker.Data.TrackerDataContext db, int id) => 
                        db.Audit.FirstOrDefault(a => a.Id == id));

            internal static readonly Func<PLINQO.Tracker.Data.TrackerDataContext, int?, IQueryable<PLINQO.Tracker.Data.Audit>> GetByUserId = 
                System.Data.Linq.CompiledQuery.Compile(
                    (PLINQO.Tracker.Data.TrackerDataContext db, int? userId) => 
                        db.Audit.Where(a => a.UserId == userId));

            internal static readonly Func<PLINQO.Tracker.Data.TrackerDataContext, int?, IQueryable<PLINQO.Tracker.Data.Audit>> GetByTaskId = 
                System.Data.Linq.CompiledQuery.Compile(
                    (PLINQO.Tracker.Data.TrackerDataContext db, int? taskId) => 
                        db.Audit.Where(a => a.TaskId == taskId));

        }
        #endregion
    }
}

