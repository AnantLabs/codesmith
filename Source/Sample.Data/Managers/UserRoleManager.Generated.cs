
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
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using CodeSmith.Data;
using CodeSmith.Data.Rules;
using CodeSmith.Data.Rules.Assign;
using CodeSmith.Data.Rules.Validation;

namespace Sample.Data
{
    /// <summary>
    /// The manager class for UserRole.
    /// </summary>
    public partial class UserRoleManager : EntityManagerBase<SampleDataManager, UserRole>
    {
        /// <summary>
        /// Initializes the <see cref="UserRoleManager"/> class.
        /// </summary>
        static UserRoleManager()
        {
            AddRules();
        }

        /// <summary>
        /// Initializes the <see cref="UserRoleManager"/> class.
        /// </summary>
        /// <param name="manager">The current manager.</param>
        public UserRoleManager(SampleDataManager manager) : base(manager)
        {
            OnCreated();
        }

        /// <summary>
        /// Gets the current context.
        /// </summary>
        protected SampleDataContext Context
        {
            get { return Manager.Context; }
        }
        
        /// <summary>
        /// Gets the entity for this manager.
        /// </summary>
        protected Table<UserRole> Entity
        {
            get { return Manager.Context.UserRole; }
        }
        
        
        /// <summary>
        /// Creates the key for this entity.
        /// </summary>
        public static IEntityKey<int, int> CreateKey(int userID, int roleID)
        {
            return new EntityKey<int, int>(userID, roleID);
        }
        
        /// <summary>
        /// Gets an entity by the primary key.
        /// </summary>
        /// <param name="key">The key for the entity.</param>
        /// <returns>
        /// An instance of the entity or null if not found.
        /// </returns>
        /// <remarks>
        /// This method is expecting key to be of type IEntityKey&lt;int, int&gt;.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when key is not of type IEntityKey&lt;int, int&gt;.</exception>
        public override UserRole GetByKey(IEntityKey key)
        {
            if (key is IEntityKey<int, int>)
            {
                IEntityKey<int, int> entityKey = (IEntityKey<int, int>)key;
                return GetByKey(entityKey.Key, entityKey.Key1);
            }
            else
            {
                throw new ArgumentException("Invalid key, expected key to be of type IEntityKey<int, int>");
            }
        }
        
        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <returns>An instance of the entity or null if not found.</returns>
        public UserRole GetByKey(int userID, int roleID)
        {
            if (Context.LoadOptions == null) 
                return Query.GetByKey.Invoke(Context, userID, roleID);
            else
                return Entity.FirstOrDefault(u => u.UserID == userID 
					&& u.RoleID == roleID);
        }
        /// <summary>
        /// Gets a query by an index.
        /// </summary>
        public IQueryable<UserRole> GetByUserID(int userID)
        {
            if (Context.LoadOptions == null) 
                return Query.GetByUserID.Invoke(Context, userID);
            else
                return Entity.Where(u => u.UserID == userID);
        }
        /// <summary>
        /// Gets a query by an index.
        /// </summary>
        public IQueryable<UserRole> GetByRoleID(int roleID)
        {
            if (Context.LoadOptions == null) 
                return Query.GetByRoleID.Invoke(Context, roleID);
            else
                return Entity.Where(u => u.RoleID == roleID);
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

            internal static readonly Func<SampleDataContext, int, int, UserRole> GetByKey = 
                CompiledQuery.Compile(
                    (SampleDataContext db, int userID, int roleID) => 
                        db.UserRole.FirstOrDefault(u => u.UserID == userID 
							&& u.RoleID == roleID));

            internal static readonly Func<SampleDataContext, int, IQueryable<UserRole>> GetByUserID = 
                CompiledQuery.Compile(
                    (SampleDataContext db, int userID) => 
                        db.UserRole.Where(u => u.UserID == userID));

            internal static readonly Func<SampleDataContext, int, IQueryable<UserRole>> GetByRoleID = 
                CompiledQuery.Compile(
                    (SampleDataContext db, int roleID) => 
                        db.UserRole.Where(u => u.RoleID == roleID));

        }
        #endregion
    }
}

