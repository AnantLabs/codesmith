﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v6.5.0, CSLA Templates: v4.0.0.0, CSLA Framework: v4.3.10.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'Product.cs'.
//
//     Template: ObjectFactoryList.DataAccess.StoredProcedures.cst
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
    public partial class ProductListFactory : ObjectFactory
    {
        #region Create

        /// <summary>
        /// Creates new ProductList with default values.
        /// </summary>
        /// <returns>new ProductList.</returns>
        [RunLocal]
        public ProductList Create()
        {
            var item = (ProductList)Activator.CreateInstance(typeof(ProductList), true);

            bool cancel = false;
            OnCreating(ref cancel);
            if (cancel) return item;

            CheckRules(item);
            MarkNew(item);

            OnCreated();

            return item;
        }

        #endregion

        #region Fetch

        /// <summary>
        /// Fetch ProductList.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns></returns>
        public ProductList Fetch(ProductCriteria criteria)
        {
            ProductList item = (ProductList)Activator.CreateInstance(typeof(ProductList), true);

            bool cancel = false;
            OnFetching(criteria, ref cancel);
            if (cancel) return item;

            // Fetch Child objects.
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
                        {
                            do
                            {
                                item.Add(new ProductFactory().Map(reader));
                            } while(reader.Read());
                        }
                    }
                }
            }

            MarkOld(item);
            OnFetched();
            return item;
        }

        #endregion

        #region DataPortal partial methods

        /// <summary>
        /// CodeSmith generated stub method that is called when creating the child <see cref="Product"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object creation should proceed.</param>
        partial void OnCreating(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the child <see cref="Product"/> object has been created. 
        /// </summary>
        partial void OnCreated();

        /// <summary>
        /// CodeSmith generated stub method that is called when fetching the child <see cref="Product"/> object. 
        /// </summary>
        /// <param name="criteria"><see cref="ProductCriteria"/> object containing the criteria of the object to fetch.</param>
        /// <param name="cancel">Value returned from the method indicating whether the object fetching should proceed.</param>
        partial void OnFetching(ProductCriteria criteria, ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the child <see cref="Product"/> object has been fetched. 
        /// </summary>
        partial void OnFetched();

        /// <summary>
        /// CodeSmith generated stub method that is called when mapping the child <see cref="Product"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object mapping should proceed.</param>
        partial void OnMapping(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called when mapping the child <see cref="Product"/> object. 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="cancel">Value returned from the method indicating whether the object mapping should proceed.</param>
        partial void OnMapping(SafeDataReader reader, ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the child <see cref="Product"/> object has been mapped. 
        /// </summary>
        partial void OnMapped();

        /// <summary>
        /// CodeSmith generated stub method that is called when updating the <see cref="Product"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object creation should proceed.</param>
        partial void OnUpdating(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the <see cref="Product"/> object has been updated. 
        /// </summary>
        partial void OnUpdated();
        partial void OnAddNewCore(ref Product item, ref bool cancel);

        #endregion
    }
}