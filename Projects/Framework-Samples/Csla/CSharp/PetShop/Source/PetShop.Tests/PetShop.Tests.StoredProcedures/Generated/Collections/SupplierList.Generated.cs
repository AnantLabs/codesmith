﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.1413, CSLA Framework: v3.8.2.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'SupplierList.cs'.
//
//     Template: EditableChildList.Generated.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;
using System.Collections.Generic;
using Csla;

#endregion

namespace PetShop.Tests.StoredProcedures
{
    [Serializable]
    public partial class SupplierList : BusinessListBase< SupplierList, Supplier >
    {
        #region Factory Methods 
        
        internal static SupplierList NewList()
        {
            return DataPortal.CreateChild< SupplierList >();
        }

        internal static SupplierList GetBySuppId(System.Int32 suppId)
        {
            return DataPortal.FetchChild< SupplierList >(
                new SupplierCriteria{SuppId = suppId});
        }

        internal static SupplierList GetAll()
        {
            return DataPortal.FetchChild< SupplierList >(new SupplierCriteria());
        }

        private SupplierList()
        {
            AllowNew = true;
            MarkAsChild();
        }
        
        #endregion

        #region Properties
        
        protected override object AddNewCore()
        {
            Supplier item = PetShop.Tests.StoredProcedures.Supplier.NewSupplier();
            Add(item);
            return item;
        }
        
        #endregion


        #region Exists Command

        public static bool Exists(SupplierCriteria criteria)
        {
            return PetShop.Tests.StoredProcedures.Supplier.Exists(criteria);
        }

        #endregion
    }
}