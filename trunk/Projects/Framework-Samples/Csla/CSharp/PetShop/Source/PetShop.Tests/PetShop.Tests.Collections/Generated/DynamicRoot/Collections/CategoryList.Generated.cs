//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.1357, CSLA Framework: v3.8.0.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'Category.cs'.
//
//     Template: DynamicRootList.Generated.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;

using Csla;

#endregion

namespace PetShop.Tests.Collections.DynamicRoot
{
    [Serializable]
    public partial class CategoryList : EditableRootListBase< Category >
    {
        #region Properties
        
        protected override object AddNewCore()
        {
            Category item = PetShop.Tests.Collections.DynamicRoot.Category.NewCategory();
            Add(item);
            return item;
        }
        
        #endregion

        #region Factory Methods 
        
        public static CategoryList NewList()
        {
            return DataPortal.Create< CategoryList >();
        }

        public static CategoryList GetAll()
        {
            return DataPortal.Fetch< CategoryList >(new CategoryCriteria());
        }

        public static CategoryList GetByCategoryId(System.String categoryId)
        {
            return DataPortal.Fetch< CategoryList >(
                new CategoryCriteria{CategoryId = categoryId});
        }

        private CategoryList()
        { 
            AllowNew = true;
        }
        
        #endregion

        #region Exists Command

        public static bool Exists(CategoryCriteria criteria)
        {
            return PetShop.Tests.Collections.DynamicRoot.Category.Exists(criteria);
        }

        #endregion
    }
}