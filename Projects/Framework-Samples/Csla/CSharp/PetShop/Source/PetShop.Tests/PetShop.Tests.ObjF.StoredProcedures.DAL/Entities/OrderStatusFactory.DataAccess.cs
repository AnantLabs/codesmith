﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.1413, CSLA Framework: v3.8.2.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'OrderStatus.cs'.
//
//     Template: ObjectFactory.DataAccess.StoredProcedures.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;
using System.Data;
using System.Data.SqlClient;

using Csla;
using Csla.Server;
using Csla.Data;

using PetShop.Tests.ObjF.StoredProcedures;

#endregion

namespace PetShop.Tests.ObjF.StoredProcedures.DAL
{
    public partial class OrderStatusFactory : ObjectFactory
    {
        #region Create

        /// <summary>
        /// Creates new OrderStatus with default values.
        /// </summary>
        /// <returns>new OrderStatus.</returns>
        [RunLocal]
        public OrderStatus Create()
        {
            var item = (OrderStatus)Activator.CreateInstance(typeof(OrderStatus), true);

            bool cancel = false;
            OnCreating(ref cancel);
            if (cancel) return item;

            using (BypassPropertyChecks(item))
            {
                // Default values.
            }

            CheckRules(item);
            MarkNew(item);
            OnCreated();

            return item;
        }

        /// <summary>
        /// Creates new OrderStatus with default values.
        /// </summary>
        /// <returns>new OrderStatus.</returns>
        [RunLocal]
        private OrderStatus Create(OrderStatusCriteria criteria)
        {
            var item = (OrderStatus)Activator.CreateInstance(typeof(OrderStatus), true);

            bool cancel = false;
            OnCreating(ref cancel);
            if (cancel) return item;

            var resource = Fetch(criteria);
            using (BypassPropertyChecks(item))
            {
                item.Timestamp = resource.Timestamp;
                item.Status = resource.Status;
            }

            CheckRules(item);
            MarkNew(resource);

            OnCreated();

            return item;
        }

        #endregion

        #region Fetch

        /// <summary>
        /// Fetch OrderStatus.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns></returns>
        public OrderStatus Fetch(OrderStatusCriteria criteria)
        {
            bool cancel = false;
            OnFetching(criteria, ref cancel);
            if (cancel) return null;

            OrderStatus item;
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("[dbo].[CSLA_OrderStatus_Select]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    
                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if(reader.Read())
                           item = Map(reader);
                        else
                            throw new Exception(string.Format("The record was not found in 'OrderStatus' using the following criteria: {0}.", criteria));
                    }
                }
            }

            MarkOld(item);
            OnFetched();
            return item;
        }

        #endregion

        #region Insert

        private void DoInsert(ref OrderStatus item, bool stopProccessingChildren)
        {
            // Don't update if the item isn't dirty.
            if (!item.IsDirty) return;

            bool cancel = false;
            OnInserting(ref cancel);
            if (cancel) return;

            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("[dbo].[CSLA_OrderStatus_Insert]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_OrderId", item.OrderId);
					command.Parameters.AddWithValue("@p_LineNum", item.LineNum);
					command.Parameters.AddWithValue("@p_Timestamp", item.Timestamp);
					command.Parameters.AddWithValue("@p_Status", item.Status);

                    command.ExecuteNonQuery();

                }
            }

            item.OriginalOrderId = item.OrderId;
            item.OriginalLineNum = item.LineNum;

            MarkOld(item);
            CheckRules(item);
            
            if(!stopProccessingChildren)
            {
            // Update Child Items.
                Update_Order_OrderMember_OrderId(ref item);
            }

            OnInserted();
        }

        #endregion

        #region Update

        [Transactional(TransactionalTypes.TransactionScope)]
        public OrderStatus Update(OrderStatus item)
        {
            return Update(item, false);
        }

        public OrderStatus Update(OrderStatus item, bool stopProccessingChildren)
        {
            if(item.IsDeleted)
            {
                DoDelete(ref item);
                MarkNew(item);
            }
            else if(item.IsNew)
            {
                DoInsert(ref item, stopProccessingChildren);
            }
            else
            {
                DoUpdate(ref item, stopProccessingChildren);
            }

            return item;
        }

        private void DoUpdate(ref OrderStatus item, bool stopProccessingChildren)
        {
            bool cancel = false;
            OnUpdating(ref cancel);
            if (cancel) return;

            // Don't update if the item isn't dirty.
            if (item.IsDirty)
            {
                if(item.OriginalOrderId != item.OrderId || item.OriginalLineNum != item.LineNum)
                {
                    // Insert new child.
                    var temp = (OrderStatus)Activator.CreateInstance(typeof(OrderStatus), true);
                    temp.OrderId = item.OrderId;
                    temp.LineNum = item.LineNum;
                    temp.Timestamp = item.Timestamp;
                    temp.Status = item.Status;
                    temp = temp.Save();
    
                    // Mark child lists as dirty. This code may need to be updated to one-to-one relationships.

                    // Update Children
                    Update_Order_OrderMember_OrderId(ref item);
    
                    // Delete the old.
                    Delete(new OrderStatusCriteria {OrderId = item.OriginalOrderId, LineNum = item.OriginalLineNum});
    
                    // Mark the original as the new one.
                    item.OriginalOrderId = item.OrderId;
                    item.OriginalLineNum = item.LineNum;

                    MarkOld(item);
                    CheckRules(item);
                    OnUpdated();

                    return;
                }

                using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("[dbo].[CSLA_OrderStatus_Update]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_OriginalOrderId", item.OriginalOrderId);
					command.Parameters.AddWithValue("@p_OrderId", item.OrderId);
					command.Parameters.AddWithValue("@p_OriginalLineNum", item.OriginalLineNum);
					command.Parameters.AddWithValue("@p_LineNum", item.LineNum);
					command.Parameters.AddWithValue("@p_Timestamp", item.Timestamp);
					command.Parameters.AddWithValue("@p_Status", item.Status);

                        //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                        int result = command.ExecuteNonQuery();
                        if (result == 0)
                            throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");

                    }
                }
            }

            item.OriginalOrderId = item.OrderId;
            item.OriginalLineNum = item.LineNum;

            MarkOld(item);
            CheckRules(item);

            if(!stopProccessingChildren)
            {
            // Update Child Items.
                Update_Order_OrderMember_OrderId(ref item);
            }

            OnUpdated();
        }

        #endregion

        #region Delete

        [Transactional(TransactionalTypes.TransactionScope)]
        public void Delete(OrderStatusCriteria criteria)
        {
            //Note: this call to delete is for immediate deletion and doesn't keep track of any entity state.
            DoDelete(criteria);
        }

        protected void DoDelete(ref OrderStatus item)
        {
            // If we're not dirty then don't update the database.
            if (!item.IsDirty) return;

            // If we're new then don't call delete.
            if (item.IsNew) return;

            DoDelete(new OrderStatusCriteria{OrderId = item.OrderId, LineNum = item.LineNum});

            MarkNew(item);
        }

        /// <summary>
        /// This call to delete is for immediate deletion and doesn't keep track of any entity state.
        /// </summary>
        /// <param name="criteria">The Criteria.</param>
        private void DoDelete(OrderStatusCriteria criteria)
        {
            bool cancel = false;
            OnDeleting(criteria, ref cancel);
            if (cancel) return;

            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("[dbo].[CSLA_OrderStatus_Delete]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));

                    //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    int result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");
                }
            }

            OnDeleted();
        }

        #endregion

        #region Helper Methods

        public OrderStatus Map(SafeDataReader reader)
        {
            var item = (OrderStatus)Activator.CreateInstance(typeof(OrderStatus), true);
            using (BypassPropertyChecks(item))
            {
                item.OrderId = reader.GetInt32("OrderId");
                item.OriginalOrderId = reader.GetInt32("OrderId");
                item.LineNum = reader.GetInt32("LineNum");
                item.OriginalLineNum = reader.GetInt32("LineNum");
                item.Timestamp = reader.GetDateTime("Timestamp");
                item.Status = reader.GetString("Status");
            }
            
            return item;
        }

        //AssociatedManyToOne
        private static void Update_Order_OrderMember_OrderId(ref OrderStatus item)
        {
				item.OrderMember.OrderId = item.OrderId;

            new OrderFactory().Update(item.OrderMember, true);
        }

        #endregion

        #region Data access partial methods

        partial void OnCreating(ref bool cancel);
        partial void OnCreated();
        partial void OnFetching(OrderStatusCriteria criteria, ref bool cancel);
        partial void OnFetched();
        partial void OnMapping(ref bool cancel);
        partial void OnMapped();
        partial void OnInserting(ref bool cancel);
        partial void OnInserted();
        partial void OnUpdating(ref bool cancel);
        partial void OnUpdated();
        partial void OnSelfDeleting(ref bool cancel);
        partial void OnSelfDeleted();
        partial void OnDeleting(OrderStatusCriteria criteria, ref bool cancel);
        partial void OnDeleted();

        #endregion
    }
}