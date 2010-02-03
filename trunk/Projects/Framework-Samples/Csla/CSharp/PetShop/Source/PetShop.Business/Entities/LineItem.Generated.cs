//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.1357, CSLA Framework: v3.8.0.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'LineItem.cs'.
//
//     Template: SwitchableObject.Generated.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;

using Csla;
using Csla.Data;
using Csla.Validation;

#endregion

namespace PetShop.Business
{
    [Serializable]
    public partial class LineItem : BusinessBase< LineItem >
    {
        #region Contructor(s)

        private LineItem()
        { /* Require use of factory methods */ }

        private LineItem(System.Int32 orderId, System.Int32 lineNum)
        {
            using(BypassPropertyChecks)
            {
                LoadProperty(_orderIdProperty, orderId);
                LoadProperty(_lineNumProperty, lineNum);
            }
        }

        internal LineItem(SafeDataReader reader)
        {
            Map(reader);
        }
        #endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            if(AddBusinessValidationRules())
                return;

            ValidationRules.AddRule(CommonRules.StringRequired, _itemIdProperty);
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_itemIdProperty, 10));
        }

        #endregion

        #region Properties

        private static readonly PropertyInfo< System.Int32 > _orderIdProperty = RegisterProperty< System.Int32 >(p => p.OrderId);
		[System.ComponentModel.DataObjectField(true, false)]
        public System.Int32 OrderId
        {
            get { return GetProperty(_orderIdProperty); }
            set{ SetProperty(_orderIdProperty, value); }
        }

        private static readonly PropertyInfo< System.Int32 > _lineNumProperty = RegisterProperty< System.Int32 >(p => p.LineNum);
		[System.ComponentModel.DataObjectField(true, false)]
        public System.Int32 LineNum
        {
            get { return GetProperty(_lineNumProperty); }
            set{ SetProperty(_lineNumProperty, value); }
        }

        private static readonly PropertyInfo< System.String > _itemIdProperty = RegisterProperty< System.String >(p => p.ItemId);
        public System.String ItemId
        {
            get { return GetProperty(_itemIdProperty); }
            set{ SetProperty(_itemIdProperty, value); }
        }

        private static readonly PropertyInfo< System.Int32 > _quantityProperty = RegisterProperty< System.Int32 >(p => p.Quantity);
        public System.Int32 Quantity
        {
            get { return GetProperty(_quantityProperty); }
            set{ SetProperty(_quantityProperty, value); }
        }

        private static readonly PropertyInfo< System.Decimal > _unitPriceProperty = RegisterProperty< System.Decimal >(p => p.UnitPrice);
        public System.Decimal UnitPrice
        {
            get { return GetProperty(_unitPriceProperty); }
            set{ SetProperty(_unitPriceProperty, value); }
        }

        //AssociatedManyToOne
        private static readonly PropertyInfo< Order > _orderMemberProperty = RegisterProperty< Order >(p => p.OrderMember, Csla.RelationshipTypes.Child);
        public Order OrderMember
        {
            get
            {
                if(!FieldManager.FieldExists(_orderMemberProperty))
                {
                    if(IsNew || !PetShop.Business.Order.Exists(new PetShop.Business.OrderCriteria {OrderId = OrderId}))
                        LoadProperty(_orderMemberProperty, PetShop.Business.Order.NewOrder());
                    else
                        LoadProperty(_orderMemberProperty, PetShop.Business.Order.GetByOrderId(OrderId));
                }

                return GetProperty(_orderMemberProperty); 
            }
        }


        #endregion

        #region Root Factory Methods 
        
        public static LineItem NewLineItem()
        {
            return DataPortal.Create< LineItem >();
        }

        public static LineItem GetByOrderIdLineNum(System.Int32 orderId, System.Int32 lineNum)
        {
            return DataPortal.Fetch< LineItem >(
                new LineItemCriteria{OrderId = orderId, LineNum = lineNum});
        }

        public static LineItem GetByOrderId(System.Int32 orderId)
        {
            return DataPortal.Fetch< LineItem >(
                new LineItemCriteria{OrderId = orderId});
        }

        public static void DeleteLineItem(System.Int32 orderId, System.Int32 lineNum)
        {
                DataPortal.Delete(new LineItemCriteria(orderId, lineNum));
        }
        
        #endregion

        #region Child Factory Methods 
        
        internal static LineItem NewLineItemChild()
        {
            return DataPortal.CreateChild< LineItem >();
        }
        internal static LineItem GetByOrderIdLineNumChild(System.Int32 orderId, System.Int32 lineNum)
        {
            return DataPortal.FetchChild< LineItem >(
                new LineItemCriteria{OrderId = orderId, LineNum = lineNum});
        }
        internal static LineItem GetByOrderIdChild(System.Int32 orderId)
        {
            return DataPortal.FetchChild< LineItem >(
                new LineItemCriteria{OrderId = orderId});
        }

        #endregion

        #region Exists Command

        public static bool Exists(LineItemCriteria criteria)
        {
            return ExistsCommand.Execute(criteria);
        }

        #endregion

        #region Protected Overriden Method(s)

        // NOTE: This is needed for Composite Keys. 
        private readonly Guid _guidID = Guid.NewGuid();
        protected override object GetIdValue()
        {
            return _guidID;
        }

        #endregion
    }
}