﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using CodeSmith.Data.Linq;
using CodeSmith.Data.Linq.Dynamic;

namespace Tracker.Core.Data
{
    /// <summary>
    /// The query extension class for Role.
    /// </summary>
    public static partial class RoleExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static Tracker.Core.Data.Role GetByKey(this IQueryable<Tracker.Core.Data.Role> queryable, int id)
        {
            var entity = queryable as System.Data.Linq.Table<Tracker.Core.Data.Role>;
            if (entity != null && entity.Context.LoadOptions == null)
                return Query.GetByKey.Invoke((Tracker.Core.Data.TrackerDataContext)entity.Context, id);
            
            return queryable.FirstOrDefault(r => r.Id == id);
        }

        /// <summary>
        /// Immediately deletes the entity by the primary key from the underlying data source with a single delete command.
        /// </summary>
        /// <param name="table">Represents a table for a particular type in the underlying database containing rows are to be deleted.</param>
        /// <returns>The number of rows deleted from the database.</returns>
        public static int Delete(this System.Data.Linq.Table<Tracker.Core.Data.Role> table, int id)
        {
            return table.Delete(r => r.Id == id);
        }
        
        /// <summary>
        /// Gets a query for <see cref="Tracker.Core.Data.Role.Id"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="id">Id to search for.</param>
        /// <returns>IQueryable with additional where clause.</returns>
        public static IQueryable<Tracker.Core.Data.Role> ById(this IQueryable<Tracker.Core.Data.Role> queryable, int id)
        {
            return queryable.Where(r => r.Id == id);
        }
        
        /// <summary>
        /// Gets a query for <see cref="Tracker.Core.Data.Role.Id"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="id">Id to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns>IQueryable with additional where clause.</returns>
        public static IQueryable<Tracker.Core.Data.Role> ById(this IQueryable<Tracker.Core.Data.Role> queryable, int id, params int[] additionalValues)
        {
            var idList = new List<int> {id};

            if (additionalValues != null)
                idList.AddRange(additionalValues);

            if (idList.Count == 1)
                return queryable.ById(idList[0]);

            var expression = DynamicExpression.BuildExpression<Tracker.Core.Data.Role, bool>("Id", idList);
            return queryable.Where(expression);
        }
        
        /// <summary>
        /// Gets a query for <see cref="Tracker.Core.Data.Role.Name"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="name">Name to search for.</param>
        /// <returns>IQueryable with additional where clause.</returns>
        public static IQueryable<Tracker.Core.Data.Role> ByName(this IQueryable<Tracker.Core.Data.Role> queryable, string name)
        {
            return queryable.Where(r => r.Name == name);
        }
        
        /// <summary>
        /// Gets a query for <see cref="Tracker.Core.Data.Role.Name"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="name">Name to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns>IQueryable with additional where clause.</returns>
        public static IQueryable<Tracker.Core.Data.Role> ByName(this IQueryable<Tracker.Core.Data.Role> queryable, string name, params string[] additionalValues)
        {
            var nameList = new List<string> {name};

            if (additionalValues != null)
                nameList.AddRange(additionalValues);

            if (nameList.Count == 1)
                return queryable.ByName(nameList[0]);

            var expression = DynamicExpression.BuildExpression<Tracker.Core.Data.Role, bool>("Name", nameList);
            return queryable.Where(expression);
        }
        
        /// <summary>
        /// Gets a query for <see cref="Tracker.Core.Data.Role.Description"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="description">Description to search for.</param>
        /// <returns>IQueryable with additional where clause.</returns>
        public static IQueryable<Tracker.Core.Data.Role> ByDescription(this IQueryable<Tracker.Core.Data.Role> queryable, string description)
        {
            return queryable.Where(r => object.Equals(r.Description, description));
        }
        
        /// <summary>
        /// Gets a query for <see cref="Tracker.Core.Data.Role.Description"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="description">Description to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns>IQueryable with additional where clause.</returns>
        public static IQueryable<Tracker.Core.Data.Role> ByDescription(this IQueryable<Tracker.Core.Data.Role> queryable, string description, params string[] additionalValues)
        {
            var descriptionList = new List<string> {description};

            if (additionalValues != null)
                descriptionList.AddRange(additionalValues);
            else
                descriptionList.Add(null);

            if (descriptionList.Count == 1)
                return queryable.ByDescription(descriptionList[0]);

            var expression = DynamicExpression.BuildExpression<Tracker.Core.Data.Role, bool>("Description", descriptionList);
            return queryable.Where(expression);
        }
        
        /// <summary>
        /// Gets a query for <see cref="Tracker.Core.Data.Role.CreatedDate"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="createdDate">CreatedDate to search for.</param>
        /// <returns>IQueryable with additional where clause.</returns>
        public static IQueryable<Tracker.Core.Data.Role> ByCreatedDate(this IQueryable<Tracker.Core.Data.Role> queryable, System.DateTime createdDate)
        {
            return queryable.Where(r => r.CreatedDate == createdDate);
        }
        
        /// <summary>
        /// Gets a query for <see cref="Tracker.Core.Data.Role.CreatedDate"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="createdDate">CreatedDate to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns>IQueryable with additional where clause.</returns>
        public static IQueryable<Tracker.Core.Data.Role> ByCreatedDate(this IQueryable<Tracker.Core.Data.Role> queryable, System.DateTime createdDate, params System.DateTime[] additionalValues)
        {
            var createdDateList = new List<System.DateTime> {createdDate};

            if (additionalValues != null)
                createdDateList.AddRange(additionalValues);

            if (createdDateList.Count == 1)
                return queryable.ByCreatedDate(createdDateList[0]);

            var expression = DynamicExpression.BuildExpression<Tracker.Core.Data.Role, bool>("CreatedDate", createdDateList);
            return queryable.Where(expression);
        }
        
        /// <summary>
        /// Gets a query for <see cref="Tracker.Core.Data.Role.ModifiedDate"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="modifiedDate">ModifiedDate to search for.</param>
        /// <returns>IQueryable with additional where clause.</returns>
        public static IQueryable<Tracker.Core.Data.Role> ByModifiedDate(this IQueryable<Tracker.Core.Data.Role> queryable, System.DateTime modifiedDate)
        {
            return queryable.Where(r => r.ModifiedDate == modifiedDate);
        }
        
        /// <summary>
        /// Gets a query for <see cref="Tracker.Core.Data.Role.ModifiedDate"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="modifiedDate">ModifiedDate to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns>IQueryable with additional where clause.</returns>
        public static IQueryable<Tracker.Core.Data.Role> ByModifiedDate(this IQueryable<Tracker.Core.Data.Role> queryable, System.DateTime modifiedDate, params System.DateTime[] additionalValues)
        {
            var modifiedDateList = new List<System.DateTime> {modifiedDate};

            if (additionalValues != null)
                modifiedDateList.AddRange(additionalValues);

            if (modifiedDateList.Count == 1)
                return queryable.ByModifiedDate(modifiedDateList[0]);

            var expression = DynamicExpression.BuildExpression<Tracker.Core.Data.Role, bool>("ModifiedDate", modifiedDateList);
            return queryable.Where(expression);
        }

        #region Query
        /// <summary>
        /// A private class for lazy loading static compiled queries.
        /// </summary>
        private static partial class Query
        {

            internal static readonly Func<Tracker.Core.Data.TrackerDataContext, int, Tracker.Core.Data.Role> GetByKey = 
                System.Data.Linq.CompiledQuery.Compile(
                    (Tracker.Core.Data.TrackerDataContext db, int id) => 
                        db.Role.FirstOrDefault(r => r.Id == id));

        }
        #endregion
    }
}

