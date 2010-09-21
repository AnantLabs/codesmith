﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.1872, CSLA Framework: v3.8.4.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'LineItem.cs'.
//
//     Template: SwitchableObject.DataAccess.StoredProcedures.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using Csla;
using Csla.Data;

#endregion

namespace PetShop.Tests.StoredProcedures
{
    public partial class LineItem
    {
        #region Root Data Access

        [RunLocal]
        protected override void DataPortal_Create()
        {
            bool cancel = false;
            OnCreating(ref cancel);
            if (cancel) return;

            ValidationRules.CheckRules();

            OnCreated();
        }

        private void DataPortal_Fetch(LineItemCriteria criteria)
        {
            bool cancel = false;
            OnFetching(criteria, ref cancel);
            if (cancel) return;

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
                            Map(reader);
                        else
                            throw new Exception(string.Format("The record was not found in 'LineItem' using the following criteria: {0}.", criteria));
                    }
                }
            }

            OnFetched();
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            bool cancel = false;
            OnInserting(ref cancel);
            if (cancel) return;

            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("[dbo].[CSLA_LineItem_Insert]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_OrderId", this.OrderId);
					command.Parameters.AddWithValue("@p_LineNum", this.LineNum);
					command.Parameters.AddWithValue("@p_ItemId", this.ItemId);
					command.Parameters.AddWithValue("@p_Quantity", this.Quantity);
					command.Parameters.AddWithValue("@p_UnitPrice", this.UnitPrice);
                    command.ExecuteNonQuery();

                    using (BypassPropertyChecks)
                    {
                    }
                }
                
                LoadProperty(_originalOrderIdProperty, this.OrderId);
                LoadProperty(_originalLineNumProperty, this.LineNum);

                FieldManager.UpdateChildren(this, connection);
            }

            OnInserted();
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            bool cancel = false;
            OnUpdating(ref cancel);
            if (cancel) return;

            if(OriginalOrderId != OrderId || OriginalLineNum != LineNum)
            {
                // Insert new child.
                LineItem item = new LineItem {OrderId = OrderId, LineNum = LineNum, ItemId = ItemId, Quantity = Quantity, UnitPrice = UnitPrice};
                
                item = item.Save();

                // Mark child lists as dirty. This code may need to be updated to one-to-one relationships.

                // Create a new connection.
                using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
                {
                    connection.Open();
                    FieldManager.UpdateChildren(this, connection);
                }

                // Delete the old.
                var criteria = new LineItemCriteria {OrderId = OriginalOrderId, LineNum = OriginalLineNum};
                
                DataPortal_Delete(criteria);

                // Mark the original as the new one.
                OriginalOrderId = OrderId;
                OriginalLineNum = LineNum;
                OnUpdated();

                return;
            }

            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("[dbo].[CSLA_LineItem_Update]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_OriginalOrderId", this.OriginalOrderId);
					command.Parameters.AddWithValue("@p_OrderId", this.OrderId);
					command.Parameters.AddWithValue("@p_OriginalLineNum", this.OriginalLineNum);
					command.Parameters.AddWithValue("@p_LineNum", this.LineNum);
					command.Parameters.AddWithValue("@p_ItemId", this.ItemId);
					command.Parameters.AddWithValue("@p_Quantity", this.Quantity);
					command.Parameters.AddWithValue("@p_UnitPrice", this.UnitPrice);
                    //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    int result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");

                    LoadProperty(_originalOrderIdProperty, this.OrderId);
                    LoadProperty(_originalLineNumProperty, this.LineNum);
                }

                FieldManager.UpdateChildren(this, connection);
            }

            OnUpdated();
        }

        protected override void DataPortal_DeleteSelf()
        {
            bool cancel = false;
            OnSelfDeleting(ref cancel);
            if (cancel) return;
            
            DataPortal_Delete(new LineItemCriteria (OrderId, LineNum));
        
            OnSelfDeleted();
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected void DataPortal_Delete(LineItemCriteria criteria)
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

        //[Transactional(TransactionalTypes.TransactionScope)]
        protected void DataPortal_Delete(LineItemCriteria criteria, SqlConnection connection)
        {
            bool cancel = false;
            OnDeleting(criteria, ref cancel);
            if (cancel) return;

            using (SqlCommand command = new SqlCommand("[dbo].[CSLA_LineItem_Delete]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));

                //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                int result = command.ExecuteNonQuery();
                if (result == 0)
                    throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");
            }

            OnDeleted();
        }

        #endregion

        #region Child Data Access

        protected override void Child_Create()
        {
            bool cancel = false;
            OnChildCreating(ref cancel);
            if (cancel) return;

            ValidationRules.CheckRules();

            OnChildCreated();
        }

        private void Child_Fetch(LineItemCriteria criteria)
        {
            bool cancel = false;
            OnChildFetching(criteria, ref cancel);
            if (cancel) return;

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
                            Map(reader);
                        else
                            throw new Exception(string.Format("The record was not found in 'LineItem' using the following criteria: {0}.", criteria));
                    }
                }
            }

            OnChildFetched();

            MarkAsChild();
        }

        #region Child_Insert

        private void Child_Insert(SqlConnection connection)
        {
            bool cancel = false;
            OnChildInserting(connection, ref cancel);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(SqlCommand command = new SqlCommand("[dbo].[CSLA_LineItem_Insert]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_OrderId", this.OrderId);
					command.Parameters.AddWithValue("@p_LineNum", this.LineNum);
					command.Parameters.AddWithValue("@p_ItemId", this.ItemId);
					command.Parameters.AddWithValue("@p_Quantity", this.Quantity);
					command.Parameters.AddWithValue("@p_UnitPrice", this.UnitPrice);

                command.ExecuteNonQuery();

                // Update the original non-identity primary key value.
                LoadProperty(_originalOrderIdProperty, this.OrderId);

                // Update the original non-identity primary key value.
                LoadProperty(_originalLineNumProperty, this.LineNum);
            }

            FieldManager.UpdateChildren(this, connection);

            OnChildInserted();
        }

        private void Child_Insert(Order order, SqlConnection connection)
        {
            bool cancel = false;
            OnChildInserting(connection, ref cancel);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(SqlCommand command = new SqlCommand("[dbo].[CSLA_LineItem_Insert]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_OrderId", order != null ? order.OrderId : this.OrderId);
					command.Parameters.AddWithValue("@p_LineNum", this.LineNum);
					command.Parameters.AddWithValue("@p_ItemId", this.ItemId);
					command.Parameters.AddWithValue("@p_Quantity", this.Quantity);
					command.Parameters.AddWithValue("@p_UnitPrice", this.UnitPrice);

                command.ExecuteNonQuery();

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(order != null && order.OrderId != this.OrderId)
                LoadProperty(_orderIdProperty, order.OrderId);

                // Update the original non-identity primary key value.
                LoadProperty(_originalOrderIdProperty, this.OrderId);

                // Update the original non-identity primary key value.
                LoadProperty(_originalLineNumProperty, this.LineNum);
            }
            
            // A child relationship exists on this Business Object but its type is not a child type (E.G. EditableChild). 
            // TODO: Please override OnChildInserted() and insert this child manually.
            // FieldManager.UpdateChildren(this, connection);

            OnChildInserted();
        }

        #endregion

        #region Child_Update

        private void Child_Update(SqlConnection connection)
        {
            bool cancel = false;
            OnChildUpdating(connection, ref cancel);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(SqlCommand command = new SqlCommand("[dbo].[CSLA_LineItem_Update]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_OriginalOrderId", this.OriginalOrderId);
					command.Parameters.AddWithValue("@p_OrderId", this.OrderId);
					command.Parameters.AddWithValue("@p_OriginalLineNum", this.OriginalLineNum);
					command.Parameters.AddWithValue("@p_LineNum", this.LineNum);
					command.Parameters.AddWithValue("@p_ItemId", this.ItemId);
					command.Parameters.AddWithValue("@p_Quantity", this.Quantity);
					command.Parameters.AddWithValue("@p_UnitPrice", this.UnitPrice);

                //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                int result = command.ExecuteNonQuery();
                if (result == 0)
                    throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");

                // Update non-identity primary key value.
                LoadProperty(_orderIdProperty,(System.Int32)command.Parameters["@p_OrderId"].Value);

                // Update non-identity primary key value.
                LoadProperty(_lineNumProperty,(System.Int32)command.Parameters["@p_LineNum"].Value);

                // Update non-identity primary key value.
                LoadProperty(_originalOrderIdProperty, this.OrderId);

                // Update non-identity primary key value.
                LoadProperty(_originalLineNumProperty, this.LineNum);
            }

            FieldManager.UpdateChildren(this, connection);

            OnChildUpdated();
        }
 
        private void Child_Update(Order order, SqlConnection connection)
        {
            bool cancel = false;
            OnChildUpdating(connection, ref cancel);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(SqlCommand command = new SqlCommand("[dbo].[CSLA_LineItem_Update]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_OriginalOrderId", order != null ? order.OrderId : this.OriginalOrderId);
					command.Parameters.AddWithValue("@p_OrderId", order != null ? order.OrderId : this.OrderId);
					command.Parameters.AddWithValue("@p_OriginalLineNum", this.OriginalLineNum);
					command.Parameters.AddWithValue("@p_LineNum", this.LineNum);
					command.Parameters.AddWithValue("@p_ItemId", this.ItemId);
					command.Parameters.AddWithValue("@p_Quantity", this.Quantity);
					command.Parameters.AddWithValue("@p_UnitPrice", this.UnitPrice);

                //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                int result = command.ExecuteNonQuery();
                if (result == 0)
                    throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");

                // Update non-identity primary key value.
                LoadProperty(_orderIdProperty,(System.Int32)command.Parameters["@p_OrderId"].Value);

                // Update non-identity primary key value.
                LoadProperty(_lineNumProperty,(System.Int32)command.Parameters["@p_LineNum"].Value);

                // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
                if(order != null && order.OrderId != this.OrderId)
                    LoadProperty(_orderIdProperty, order.OrderId);

                // Update non-identity primary key value.
                LoadProperty(_originalOrderIdProperty, this.OrderId);

                // Update non-identity primary key value.
                LoadProperty(_originalLineNumProperty, this.LineNum);
            }
            
            // A child relationship exists on this Business Object but its type is not a child type (E.G. EditableChild). 
            // TODO: Please override OnChildUpdated() and update this child manually.
            // FieldManager.UpdateChildren(this, connection);

            OnChildUpdated();
        }
        #endregion

        private void Child_DeleteSelf()
        {
            bool cancel = false;
            OnChildSelfDeleting(ref cancel);
            if (cancel) return;
            
            DataPortal_Delete(new LineItemCriteria (OrderId, LineNum));
        
            OnChildSelfDeleted();
        }

        private void Child_DeleteSelf(params object[] args)
        {
            SqlConnection connection = args.OfType<SqlConnection>().FirstOrDefault();
            if(connection == null)
                throw new ArgumentNullException("args", "Must contain a SqlConnection parameter.");

            bool cancel = false;
            OnChildSelfDeleting(ref cancel);
            if (cancel) return;

            DataPortal_Delete(new LineItemCriteria (OrderId, LineNum), connection);

            OnChildSelfDeleted();
        }

        #endregion

        private void Map(SafeDataReader reader)
        {
            bool cancel = false;
            OnMapping(reader, ref cancel);
            if (cancel) return;

            using(BypassPropertyChecks)
            {
                LoadProperty(_orderIdProperty, reader["OrderId"]);
                LoadProperty(_originalOrderIdProperty, reader["OrderId"]);
                LoadProperty(_lineNumProperty, reader["LineNum"]);
                LoadProperty(_originalLineNumProperty, reader["LineNum"]);
                LoadProperty(_itemIdProperty, reader["ItemId"]);
                LoadProperty(_quantityProperty, reader["Quantity"]);
                LoadProperty(_unitPriceProperty, reader["UnitPrice"]);
            }

            OnMapped();

            MarkOld();
        }
    }
}
