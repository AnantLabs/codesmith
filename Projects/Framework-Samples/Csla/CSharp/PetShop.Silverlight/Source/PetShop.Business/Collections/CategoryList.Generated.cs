﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.1817, CSLA Framework: v4.0.0.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'CategoryList.cs'.
//
//     Template: EditableRootList.Generated.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;

using Csla;
using Csla.Data;

#endregion

namespace PetShop.Business
{
    [Serializable]
    public partial class CategoryList : BusinessListBase< CategoryList, Category >
    {    
        #region Contructor(s)

        private CategoryList()
        { 
            AllowNew = true;
        }
        
        #endregion

        #region Method Overrides
        
        protected override Category AddNewCore()
        {
            Category item = PetShop.Business.Category.NewCategory();

            bool cancel = false;
            OnAddNewCore(ref item, ref cancel);
            if (!cancel)
            {
                // Check to see if someone set the item to null in the OnAddNewCore.
                if(item == null)
                    item = PetShop.Business.Category.NewCategory();


                Add(item);
            }

            return item;
        }
        
        #endregion

        #region Synchronous Factory Methods 
        
        public static CategoryList NewList()
        {
            return DataPortal.Create< CategoryList >();
        }      

        public static CategoryList GetByCategoryId(System.String categoryId)
        {
			var criteria = new CategoryCriteria{CategoryId = categoryId};
			
			
            return DataPortal.Fetch< CategoryList >(criteria);
        }
        

        public static CategoryList GetAll()
        {
            return DataPortal.Fetch< CategoryList >(new CategoryCriteria());
        }

        #endregion



        #region DataPortal partial methods

        partial void OnCreating(ref bool cancel);
        partial void OnCreated();
        partial void OnFetching(CategoryCriteria criteria, ref bool cancel);
        partial void OnFetched();
        partial void OnMapping(SafeDataReader reader, ref bool cancel);
        partial void OnMapped();
        partial void OnUpdating(ref bool cancel);
        partial void OnUpdated();
        partial void OnAddNewCore(ref Category item, ref bool cancel);

        #endregion

        #region Exists Command

        public static bool Exists(CategoryCriteria criteria)
        {
            return PetShop.Business.Category.Exists(criteria);
        }

        #endregion

    }
}