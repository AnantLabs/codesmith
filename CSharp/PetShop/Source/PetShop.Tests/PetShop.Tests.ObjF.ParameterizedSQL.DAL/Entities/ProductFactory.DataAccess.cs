//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.1872, CSLA Framework: v3.8.4.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'Product.cs'.
//
//     Template: ObjectFactory.DataAccess.ParameterizedSQL.cst
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

using PetShop.Tests.ObjF.ParameterizedSQL;

#endregion

namespace PetShop.Tests.ObjF.ParameterizedSQL.DAL
{
    public partial class ProductFactory : ObjectFactory
    {
        #region Create

        /// <summary>
        /// Creates new Product with default values.
        /// </summary>
        /// <returns>new Product.</returns>
        [RunLocal]
        public Product Create()
        {
            var item = (Product)Activator.CreateInstance(typeof(Product), true);

            bool cancel = false;
            OnCreating(ref cancel);
            if (cancel) return item;

            using (BypassPropertyChecks(item))
            {
                // Default values.
                item.CategoryId = "BN";
            }

            CheckRules(item);
            MarkNew(item);
            OnCreated();

            return item;
        }

        /// <summary>
        /// Creates new Product with default values.
        /// </summary>
        /// <returns>new Product.</returns>
        [RunLocal]
        private Product Create(ProductCriteria criteria)
        {
            var item = (Product)Activator.CreateInstance(typeof(Product), true);

            bool cancel = false;
            OnCreating(ref cancel);
            if (cancel) return item;

            var resource = Fetch(criteria);
            using (BypassPropertyChecks(item))
            {
                item.Name = resource.Name;
                item.Description = resource.Description;
                item.Image = resource.Image;
            }

            CheckRules(item);
            MarkNew(item);

            OnCreated();

            return item;
        }

        #endregion

        #region Fetch

        /// <summary>
        /// Fetch Product.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns></returns>
        public Product Fetch(ProductCriteria criteria)
        {
            bool cancel = false;
            OnFetching(criteria, ref cancel);
            if (cancel) return null;

            Product item;
            string commandText = string.Format("SELECT [ProductId], [CategoryId], [Name], [Descn], [Image] FROM [dbo].[Product] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag));
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if (reader.Read())
                            item = Map(reader);
                        else
                            throw new Exception(String.Format("The record was not found in 'Product' using the following criteria: {0}.", criteria));
                    }
                }
            }

            OnFetched();
            return item;
        }

        #endregion

        #region Insert

        private void DoInsert(ref Product item, bool stopProccessingChildren)
        {
            // Don't update if the item isn't dirty.
            if (!item.IsDirty) return;

            bool cancel = false;
            OnInserting(ref cancel);
            if (cancel) return;

            const string commandText = "INSERT INTO [dbo].[Product] ([ProductId], [CategoryId], [Name], [Descn], [Image]) VALUES (@p_ProductId, @p_CategoryId, @p_Name, @p_Descn, @p_Image)";
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@p_ProductId", item.ProductId);
					command.Parameters.AddWithValue("@p_CategoryId", item.CategoryId);
					command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(item.Name));
					command.Parameters.AddWithValue("@p_Descn", ADOHelper.NullCheck(item.Description));
					command.Parameters.AddWithValue("@p_Image", ADOHelper.NullCheck(item.Image));

                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if(reader.Read())
                        {
                        }
                    }
                }
            }

            item.OriginalProductId = item.ProductId;

            MarkOld(item);
            CheckRules(item);
            
            if(!stopProccessingChildren)
            {
            // Update Child Items.
                Update_Category_CategoryMember_CategoryId(ref item);
                Update_Item_Items_ProductId(ref item);
            }

            OnInserted();
        }

        #endregion

        #region Update

        [Transactional(TransactionalTypes.TransactionScope)]
        public Product Update(Product item)
        {
            return Update(item, false);
        }

        public Product Update(Product item, bool stopProccessingChildren)
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

        private void DoUpdate(ref Product item, bool stopProccessingChildren)
        {
            bool cancel = false;
            OnUpdating(ref cancel);
            if (cancel) return;

            // Don't update if the item isn't dirty.
            if (item.IsDirty)
            {
                if(item.OriginalProductId != item.ProductId)
                {
                    // Insert new child.
                    var temp = (Product)Activator.CreateInstance(typeof(Product), true);
                    temp.ProductId = item.ProductId;
                    temp.CategoryId = item.CategoryId;
                    temp.Name = item.Name;
                    temp.Description = item.Description;
                    temp.Image = item.Image;
                    temp = temp.Save();
    
                    // Mark child lists as dirty. This code may need to be updated to one-to-one relationships.
                    foreach(Item itemToUpdate in item.Items)
                    {
				itemToUpdate.ProductId = item.ProductId;
                    }

                    // Update Children
                    Update_Category_CategoryMember_CategoryId(ref item);
                    Update_Item_Items_ProductId(ref item);
    
                    // Delete the old.
                    var criteria = new ProductCriteria {ProductId = item.OriginalProductId};
                    
                    Delete(criteria);
    
                    // Mark the original as the new one.
                    item.OriginalProductId = item.ProductId;

                    MarkOld(item);
                    CheckRules(item);
                    OnUpdated();

                    return;
                }

                const string commandText = "UPDATE [dbo].[Product]  SET [ProductId] = @p_ProductId, [CategoryId] = @p_CategoryId, [Name] = @p_Name, [Descn] = @p_Descn, [Image] = @p_Image WHERE [ProductId] = @p_ProductId";
                using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        command.Parameters.AddWithValue("@p_OriginalProductId", item.OriginalProductId);
					command.Parameters.AddWithValue("@p_ProductId", item.ProductId);
					command.Parameters.AddWithValue("@p_CategoryId", item.CategoryId);
					command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(item.Name));
					command.Parameters.AddWithValue("@p_Descn", ADOHelper.NullCheck(item.Description));
					command.Parameters.AddWithValue("@p_Image", ADOHelper.NullCheck(item.Image));

                        //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                        int result = command.ExecuteNonQuery();
                        if (result == 0)
                            throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");
                    }
                }
            }

            item.OriginalProductId = item.ProductId;

            MarkOld(item);
            CheckRules(item);

            if(!stopProccessingChildren)
            {
                // Update Child Items.
                Update_Category_CategoryMember_CategoryId(ref item);
                Update_Item_Items_ProductId(ref item);
            }

            OnUpdated();
        }
        #endregion

        #region Delete

        [Transactional(TransactionalTypes.TransactionScope)]
        public void Delete(ProductCriteria criteria)
        {
            // Note: this call to delete is for immediate deletion and doesn't keep track of any entity state.
            DoDelete(criteria);
        }

        protected void DoDelete(ref Product item)
        {
            // If we're not dirty then don't update the database.
            if (!item.IsDirty) return;

            // If we're new then don't call delete.
            if (item.IsNew) return;

            var criteria = new ProductCriteria{ProductId = item.ProductId};
            
            DoDelete(criteria);

            MarkNew(item);
        }

        /// <summary>
        /// This call to delete is for immediate deletion and doesn't keep track of any entity state.
        /// </summary>
        /// <param name="criteria">The Criteria.</param>
        private void DoDelete(ProductCriteria criteria)
        {
            bool cancel = false;
            OnDeleting(criteria, ref cancel);
            if (cancel) return;

            string commandText = string.Format("DELETE FROM [dbo].[Product] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag));
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
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

        public Product Map(SafeDataReader reader)
        {
            var item = (Product)Activator.CreateInstance(typeof(Product), true);
            using (BypassPropertyChecks(item))
            {
                item.ProductId = reader.GetString("ProductId");
                item.OriginalProductId = reader.GetString("ProductId");
                item.CategoryId = reader.GetString("CategoryId");
                item.Name = reader.GetString("Name");
                item.Description = reader.GetString("Descn");
                item.Image = reader.GetString("Image");
            }
            
            MarkOld(item);

            return item;
        }

        //AssociatedManyToOne
        private static void Update_Category_CategoryMember_CategoryId(ref Product item)
        {
				item.CategoryMember.CategoryId = item.CategoryId;

            new CategoryFactory().Update(item.CategoryMember, true);
        }
        //AssociatedOneToMany
        private static void Update_Item_Items_ProductId(ref Product item)
        {
            foreach(Item itemToUpdate in item.Items)
            {
				itemToUpdate.ProductId = item.ProductId;

                new ItemFactory().Update(itemToUpdate, true);
            }
        }

        #endregion

        #region DataPortal partial methods

        partial void OnCreating(ref bool cancel);
        partial void OnCreated();
        partial void OnFetching(ProductCriteria criteria, ref bool cancel);
        partial void OnFetched();
        partial void OnMapping(SafeDataReader reader, ref bool cancel);
        partial void OnMapped();
        partial void OnInserting(ref bool cancel);
        partial void OnInserted();
        partial void OnUpdating(ref bool cancel);
        partial void OnUpdated();
        partial void OnSelfDeleting(ref bool cancel);
        partial void OnSelfDeleted();
        partial void OnDeleting(ProductCriteria criteria, ref bool cancel);
        partial void OnDeleted();

        #endregion
    }
}