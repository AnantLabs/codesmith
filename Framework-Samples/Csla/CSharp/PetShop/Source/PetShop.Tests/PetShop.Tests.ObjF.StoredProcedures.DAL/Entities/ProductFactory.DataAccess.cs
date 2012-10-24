﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v6.5.3, CSLA Templates: v4.0.0.0, CSLA Framework: v4.5.x.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'Product.cs'.
//
//     Template: ObjectFactory.DataAccess.StoredProcedures.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;

using Csla;
using Csla.Data;
using Csla.Server;

using PetShop.Tests.ObjF.StoredProcedures;

namespace PetShop.Tests.ObjF.StoredProcedures.DAL
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
            using (var connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[CSLA_Product_Select]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    command.Parameters.AddWithValue("@p_NameHasValue", criteria.NameHasValue);
                command.Parameters.AddWithValue("@p_DescnHasValue", criteria.DescriptionHasValue);
                command.Parameters.AddWithValue("@p_ImageHasValue", criteria.ImageHasValue);
                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if(reader.Read())
                           item = Map(reader);
                        else
                            throw new Exception(String.Format("The record was not found in 'dbo.Product' using the following criteria: {0}.", criteria));
                    }
                }
            }

            MarkOld(item);
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

            using (var connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using(var command = new SqlCommand("[dbo].[CSLA_Product_Insert]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_ProductId", item.ProductId);
                command.Parameters.AddWithValue("@p_CategoryId", item.CategoryId);
                command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(item.Name));
                command.Parameters.AddWithValue("@p_Descn", ADOHelper.NullCheck(item.Description));
                command.Parameters.AddWithValue("@p_Image", ADOHelper.NullCheck(item.Image));

                    command.ExecuteNonQuery();

                }
            }

            item.OriginalProductId = item.ProductId;

            MarkOld(item);
            CheckRules(item);

            if(!stopProccessingChildren)
            {
            // Update Child Items.
                Update_Category_Category_FK__Product__Categor__0CBAE877(ref item);
                Update_Items_Items_FK__Item__ProductId__117F9D94(ref item);
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
                    Update_Category_Category_FK__Product__Categor__0CBAE877(ref item);
                    Update_Items_Items_FK__Item__ProductId__117F9D94(ref item);
    
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

                using (var connection = new SqlConnection(ADOHelper.ConnectionString))
                {
                    connection.Open();
                    using(var command = new SqlCommand("[dbo].[CSLA_Product_Update]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
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
                Update_Category_Category_FK__Product__Categor__0CBAE877(ref item);
                Update_Items_Items_FK__Item__ProductId__117F9D94(ref item);
            }

            OnUpdated();
        }

        #endregion

        #region Delete

        [Transactional(TransactionalTypes.TransactionScope)]
        public void Delete(ProductCriteria criteria)
        {
            //Note: this call to delete is for immediate deletion and doesn't keep track of any entity state.
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

            using (var connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[CSLA_Product_Delete]", connection))
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

        //Associations.Where(a => a.AssociationType == AssociationType.ManyToOne || a.AssociationType == AssociationType.ManyToZeroOrOne)
        private static void Update_Category_Category_FK__Product__Categor__0CBAE877(ref Product item)
        {
                item.Category.CategoryId = item.CategoryId;

            new CategoryFactory().Update(item.Category, true);
        }
        //Where(a => a.AssociationType == AssociationType.OneToMany  || a.AssociationType == AssociationType.ZeroOrOneToMany  || a.AssociationType == AssociationType.ManyToMany)
        private static void Update_Items_Items_FK__Item__ProductId__117F9D94(ref Product item)
        {
            foreach(Item itemToUpdate in item.Items)
            {
                itemToUpdate.ProductId = item.ProductId;

                new ItemFactory().Update(itemToUpdate, true);
            }
        }

        #endregion

        #region DataPortal partial methods

        /// <summary>
        /// CodeSmith generated stub method that is called when creating the <see cref="Product"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object creation should proceed.</param>
        partial void OnCreating(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the <see cref="Product"/> object has been created. 
        /// </summary>
        partial void OnCreated();

        /// <summary>
        /// CodeSmith generated stub method that is called when fetching the <see cref="Product"/> object. 
        /// </summary>
        /// <param name="criteria"><see cref="ProductCriteria"/> object containing the criteria of the object to fetch.</param>
        /// <param name="cancel">Value returned from the method indicating whether the object fetching should proceed.</param>
        partial void OnFetching(ProductCriteria criteria, ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the <see cref="Product"/> object has been fetched. 
        /// </summary>    
        partial void OnFetched();

        /// <summary>
        /// CodeSmith generated stub method that is called when mapping the <see cref="Product"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object mapping should proceed.</param>
        partial void OnMapping(ref bool cancel);
 
        /// <summary>
        /// CodeSmith generated stub method that is called when mapping the <see cref="Product"/> object. 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="cancel">Value returned from the method indicating whether the object mapping should proceed.</param>
        partial void OnMapping(SafeDataReader reader, ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the <see cref="Product"/> object has been mapped. 
        /// </summary>
        partial void OnMapped();

        /// <summary>
        /// CodeSmith generated stub method that is called when inserting the <see cref="Product"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object insertion should proceed.</param>
        partial void OnInserting(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the <see cref="Product"/> object has been inserted. 
        /// </summary>
        partial void OnInserted();

        /// <summary>
        /// CodeSmith generated stub method that is called when updating the <see cref="Product"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object creation should proceed.</param>
        partial void OnUpdating(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the <see cref="Product"/> object has been updated. 
        /// </summary>
        partial void OnUpdated();

        /// <summary>
        /// CodeSmith generated stub method that is called when self deleting the <see cref="Product"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object self deletion should proceed.</param>
        partial void OnSelfDeleting(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the <see cref="Product"/> object has been deleted. 
        /// </summary>
        partial void OnSelfDeleted();

        /// <summary>
        /// CodeSmith generated stub method that is called when deleting the <see cref="Product"/> object. 
        /// </summary>
        /// <param name="criteria"><see cref="ProductCriteria"/> object containing the criteria of the object to delete.</param>
        /// <param name="cancel">Value returned from the method indicating whether the object deletion should proceed.</param>
        partial void OnDeleting(ProductCriteria criteria, ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the <see cref="Product"/> object with the specified criteria has been deleted. 
        /// </summary>
        partial void OnDeleted();
        partial void OnChildLoading(Csla.Core.IPropertyInfo childProperty, ref bool cancel);

        #endregion
    }
}