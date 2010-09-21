﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.1872, CSLA Framework: v3.8.4.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'LineItem.cs'.
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
using Csla.Data;
using Csla.Server;

using PetShop.Tests.ObjF.StoredProcedures;

#endregion

namespace PetShop.Tests.ObjF.StoredProcedures.DAL
{
    public partial class LineItemFactory : ObjectFactory
    {
        #region Create

        /// <summary>
        /// Creates new LineItem with default values.
        /// </summary>
        /// <returns>new LineItem.</returns>
        [RunLocal]
        public LineItem Create()
        {
            var item = (LineItem)Activator.CreateInstance(typeof(LineItem), true);

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
        /// Creates new LineItem with default values.
        /// </summary>
        /// <returns>new LineItem.</returns>
        [RunLocal]
        private LineItem Create(LineItemCriteria criteria)
        {
            var item = (LineItem)Activator.CreateInstance(typeof(LineItem), true);

            bool cancel = false;
            OnCreating(ref cancel);
            if (cancel) return item;

            var resource = Fetch(criteria);
            using (BypassPropertyChecks(item))
            {
                item.ItemId = resource.ItemId;
                item.Quantity = resource.Quantity;
                item.UnitPrice = resource.UnitPrice;
            }

            CheckRules(item);
            MarkNew(item);

            OnCreated();

            return item;
        }

        #endregion

        #region Fetch

        /// <summary>
        /// Fetch LineItem.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns></returns>
        public LineItem Fetch(LineItemCriteria criteria)
        {
            bool cancel = false;
            OnFetching(criteria, ref cancel);
            if (cancel) return null;

            LineItem item;
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("[dbo].[CSLA_LineItem_Select]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    
                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if(reader.Read())
                           item = Map(reader);
                        else
                            throw new Exception(string.Format("The record was not found in 'LineItem' using the following criteria: {0}.", criteria));
                    }
                }
            }

            MarkOld(item);
            OnFetched();
            return item;
        }

        #endregion

        #region Insert

        private void DoInsert(ref LineItem item, bool stopProccessingChildren)
        {
            // Don't update if the item isn't dirty.
            if (!item.IsDirty) return;

            bool cancel = false;
            OnInserting(ref cancel);
            if (cancel) return;

            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("[dbo].[CSLA_LineItem_Insert]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_OrderId", item.OrderId);
					command.Parameters.AddWithValue("@p_LineNum", item.LineNum);
					command.Parameters.AddWithValue("@p_ItemId", item.ItemId);
					command.Parameters.AddWithValue("@p_Quantity", item.Quantity);
					command.Parameters.AddWithValue("@p_UnitPrice", item.UnitPrice);

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
        public LineItem Update(LineItem item)
        {
            return Update(item, false);
        }

        public LineItem Update(LineItem item, bool stopProccessingChildren)
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

        private void DoUpdate(ref LineItem item, bool stopProccessingChildren)
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
                    var temp = (LineItem)Activator.CreateInstance(typeof(LineItem), true);
                    temp.OrderId = item.OrderId;
                    temp.LineNum = item.LineNum;
                    temp.ItemId = item.ItemId;
                    temp.Quantity = item.Quantity;
                    temp.UnitPrice = item.UnitPrice;
                    temp = temp.Save();
    
                    // Mark child lists as dirty. This code may need to be updated to one-to-one relationships.

                    // Update Children
                    Update_Order_OrderMember_OrderId(ref item);
    
                    // Delete the old.
                    var criteria = new LineItemCriteria {OrderId = item.OriginalOrderId, LineNum = item.OriginalLineNum};
                    
                    Delete(criteria);
    
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
                    using(SqlCommand command = new SqlCommand("[dbo].[CSLA_LineItem_Update]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_OriginalOrderId", item.OriginalOrderId);
					command.Parameters.AddWithValue("@p_OrderId", item.OrderId);
					command.Parameters.AddWithValue("@p_OriginalLineNum", item.OriginalLineNum);
					command.Parameters.AddWithValue("@p_LineNum", item.LineNum);
					command.Parameters.AddWithValue("@p_ItemId", item.ItemId);
					command.Parameters.AddWithValue("@p_Quantity", item.Quantity);
					command.Parameters.AddWithValue("@p_UnitPrice", item.UnitPrice);

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
        public void Delete(LineItemCriteria criteria)
        {
            //Note: this call to delete is for immediate deletion and doesn't keep track of any entity state.
            DoDelete(criteria);
        }

        protected void DoDelete(ref LineItem item)
        {
            // If we're not dirty then don't update the database.
            if (!item.IsDirty) return;

            // If we're new then don't call delete.
            if (item.IsNew) return;

            var criteria = new LineItemCriteria{OrderId = item.OrderId, LineNum = item.LineNum};
            
            DoDelete(criteria);

            MarkNew(item);
        }

        /// <summary>
        /// This call to delete is for immediate deletion and doesn't keep track of any entity state.
        /// </summary>
        /// <param name="criteria">The Criteria.</param>
        private void DoDelete(LineItemCriteria criteria)
        {
            bool cancel = false;
            OnDeleting(criteria, ref cancel);
            if (cancel) return;

            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("[dbo].[CSLA_LineItem_Delete]", connection))
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

        public LineItem Map(SafeDataReader reader)
        {
            var item = (LineItem)Activator.CreateInstance(typeof(LineItem), true);
            using (BypassPropertyChecks(item))
            {
                item.OrderId = reader.GetInt32("OrderId");
                item.OriginalOrderId = reader.GetInt32("OrderId");
                item.LineNum = reader.GetInt32("LineNum");
                item.OriginalLineNum = reader.GetInt32("LineNum");
                item.ItemId = reader.GetString("ItemId");
                item.Quantity = reader.GetInt32("Quantity");
                item.UnitPrice = reader.GetDecimal("UnitPrice");
            }
            
            MarkOld(item);
            
            return item;
        }

        //AssociatedManyToOne
        private static void Update_Order_OrderMember_OrderId(ref LineItem item)
        {
				item.OrderMember.OrderId = item.OrderId;

            new OrderFactory().Update(item.OrderMember, true);
        }

        #endregion

        #region DataPortal partial methods

        partial void OnCreating(ref bool cancel);
        partial void OnCreated();
        partial void OnFetching(LineItemCriteria criteria, ref bool cancel);
        partial void OnFetched();
        partial void OnMapping(SafeDataReader reader, ref bool cancel);
        partial void OnMapped();
        partial void OnInserting(ref bool cancel);
        partial void OnInserted();
        partial void OnUpdating(ref bool cancel);
        partial void OnUpdated();
        partial void OnSelfDeleting(ref bool cancel);
        partial void OnSelfDeleted();
        partial void OnDeleting(LineItemCriteria criteria, ref bool cancel);
        partial void OnDeleted();

        #endregion
    }
}