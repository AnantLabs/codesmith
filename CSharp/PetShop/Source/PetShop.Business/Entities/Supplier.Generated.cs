﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.0, CSLA Framework: v3.8.4.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'Supplier.cs'.
//
//     Template path: EditableRoot.Generated.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;

using Csla;
using Csla.Validation;
using Csla.Data;

#endregion

namespace PetShop.Business
{
    [Serializable]
    public partial class Supplier : BusinessBase< Supplier >
    {
        #region Contructor(s)

        private Supplier()
        { /* Require use of factory methods */ }

        internal Supplier(System.Int32 suppId)
        {
            using(BypassPropertyChecks)
            {
                LoadProperty(_suppIdProperty, suppId);
            }
        }

        internal Supplier(SafeDataReader reader)
        {
            Map(reader);
        }
        #endregion

        #region Business Rules

        protected override void AddBusinessRules()
        {
            if(AddBusinessValidationRules())
                return;

            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_nameProperty, 80));
            ValidationRules.AddRule(CommonRules.StringRequired, _statusProperty);
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_statusProperty, 2));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_addr1Property, 80));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_addr2Property, 80));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_cityProperty, 80));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_stateProperty, 80));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_zipProperty, 5));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_phoneProperty, 40));
        }

        #endregion

        #region Properties

        private static readonly PropertyInfo< System.Int32 > _suppIdProperty = RegisterProperty< System.Int32 >(p => p.SuppId, string.Empty);
		[System.ComponentModel.DataObjectField(true, false)]
        public System.Int32 SuppId
        {
            get { return GetProperty(_suppIdProperty); }
            set{ SetProperty(_suppIdProperty, value); }
        }

        private static readonly PropertyInfo< System.Int32 > _originalSuppIdProperty = RegisterProperty< System.Int32 >(p => p.OriginalSuppId, string.Empty);
        /// <summary>
        /// Holds the original value for SuppId. This is used for non identity primary keys.
        /// </summary>
        internal System.Int32 OriginalSuppId
        {
            get { return GetProperty(_originalSuppIdProperty); }
            set{ SetProperty(_originalSuppIdProperty, value); }
        }
        private static readonly PropertyInfo< System.String > _nameProperty = RegisterProperty< System.String >(p => p.Name, string.Empty, (System.String)null);
        public System.String Name
        {
            get { return GetProperty(_nameProperty); }
            set{ SetProperty(_nameProperty, value); }
        }
        private static readonly PropertyInfo< System.String > _statusProperty = RegisterProperty< System.String >(p => p.Status, string.Empty);
        public System.String Status
        {
            get { return GetProperty(_statusProperty); }
            set{ SetProperty(_statusProperty, value); }
        }
        private static readonly PropertyInfo< System.String > _addr1Property = RegisterProperty< System.String >(p => p.Addr1, string.Empty, (System.String)null);
        public System.String Addr1
        {
            get { return GetProperty(_addr1Property); }
            set{ SetProperty(_addr1Property, value); }
        }
        private static readonly PropertyInfo< System.String > _addr2Property = RegisterProperty< System.String >(p => p.Addr2, string.Empty, (System.String)null);
        public System.String Addr2
        {
            get { return GetProperty(_addr2Property); }
            set{ SetProperty(_addr2Property, value); }
        }
        private static readonly PropertyInfo< System.String > _cityProperty = RegisterProperty< System.String >(p => p.City, string.Empty, (System.String)null);
        public System.String City
        {
            get { return GetProperty(_cityProperty); }
            set{ SetProperty(_cityProperty, value); }
        }
        private static readonly PropertyInfo< System.String > _stateProperty = RegisterProperty< System.String >(p => p.State, string.Empty, (System.String)null);
        public System.String State
        {
            get { return GetProperty(_stateProperty); }
            set{ SetProperty(_stateProperty, value); }
        }
        private static readonly PropertyInfo< System.String > _zipProperty = RegisterProperty< System.String >(p => p.Zip, string.Empty, (System.String)null);
        public System.String Zip
        {
            get { return GetProperty(_zipProperty); }
            set{ SetProperty(_zipProperty, value); }
        }
        private static readonly PropertyInfo< System.String > _phoneProperty = RegisterProperty< System.String >(p => p.Phone, string.Empty, (System.String)null);
        public System.String Phone
        {
            get { return GetProperty(_phoneProperty); }
            set{ SetProperty(_phoneProperty, value); }
        }

        //AssociatedOneToMany
        private static readonly PropertyInfo< ItemList > _itemsProperty = RegisterProperty<ItemList>(p => p.Items, Csla.RelationshipTypes.Child);
        public ItemList Items
        {
            get
            {
                if(!FieldManager.FieldExists(_itemsProperty))
                {
                    var criteria = new PetShop.Business.ItemCriteria {Supplier = SuppId};
                    

                    if(IsNew || !PetShop.Business.ItemList.Exists(criteria))
                        LoadProperty(_itemsProperty, PetShop.Business.ItemList.NewList());
                    else
                        LoadProperty(_itemsProperty, PetShop.Business.ItemList.GetBySupplier(SuppId));
                }

                return GetProperty(_itemsProperty);
            }
        }
        #endregion

        #region Synchronous Factory Methods 

        public static Supplier NewSupplier()
        {
            return DataPortal.Create< Supplier >();
        }

        public static Supplier GetBySuppId(System.Int32 suppId)
        {
            var criteria = new SupplierCriteria {SuppId = suppId};
            
            
            return DataPortal.Fetch< Supplier >(criteria);
        }

        public static void DeleteSupplier(System.Int32 suppId)
        {
            var criteria = new SupplierCriteria {SuppId = suppId};
            
            
            DataPortal.Delete(criteria);
        }

        #endregion

        #region DataPortal partial methods

        partial void OnCreating(ref bool cancel);
        partial void OnCreated();
        partial void OnFetching(SupplierCriteria criteria, ref bool cancel);
        partial void OnFetched();
        partial void OnMapping(SafeDataReader reader, ref bool cancel);
        partial void OnMapped();
        partial void OnInserting(ref bool cancel);
        partial void OnInserted();
        partial void OnUpdating(ref bool cancel);
        partial void OnUpdated();
        partial void OnSelfDeleting(ref bool cancel);
        partial void OnSelfDeleted();
        partial void OnDeleting(SupplierCriteria criteria, ref bool cancel);
        partial void OnDeleted();

        #endregion

        #region Exists Command

        public static bool Exists(SupplierCriteria criteria)
        {
            return PetShop.Business.ExistsCommand.Execute(criteria);
        }

        #endregion

    }
}