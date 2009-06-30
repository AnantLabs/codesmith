//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CSLA 3.6.x CodeSmith Templates.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'Cart.cs'.
//
//     Template: EditableChild.Generated.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region using declarations

using System;

using Csla;
using Csla.Data;
using Csla.Validation;

#endregion

namespace PetShop.Business
{
	[Serializable]
	public partial class Cart : BusinessBase< Cart >
	{
        #region Contructor(s)

		private Cart()
		{ /* Require use of factory methods */ }
        
        internal Cart(SafeDataReader reader)
        {
            Fetch(reader);
        }
        
		#endregion
        
		#region Validation Rules
		
		protected override void AddBusinessRules()
		{
            if(AddBusinessValidationRules())
                return;
            
			ValidationRules.AddRule(CommonRules.StringRequired, "ItemId");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ItemId", 10));
			ValidationRules.AddRule(CommonRules.StringRequired, "Name");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Name", 80));
			ValidationRules.AddRule(CommonRules.StringRequired, "Type");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Type", 80));
			ValidationRules.AddRule(CommonRules.StringRequired, "CategoryId");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("CategoryId", 10));
			ValidationRules.AddRule(CommonRules.StringRequired, "ProductId");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ProductId", 10));
		}
		
		#endregion
        
		#region Business Methods


		private static readonly PropertyInfo< int > _cartIdProperty = RegisterProperty< int >(p => p.CartId);
		[System.ComponentModel.DataObjectField(true, true)]
		public int CartId
		{
			get { return GetProperty(_cartIdProperty); }				
		}
        
		private static readonly PropertyInfo< string > _itemIdProperty = RegisterProperty< string >(p => p.ItemId);
		public string ItemId
		{
			get { return GetProperty(_itemIdProperty); }				
            set
            { 
                OnPropertyChanging("ItemId");
                SetProperty(_itemIdProperty, value); 
                OnPropertyChanged("ItemId");
            }
		}
        
		private static readonly PropertyInfo< string > _nameProperty = RegisterProperty< string >(p => p.Name);
		public string Name
		{
			get { return GetProperty(_nameProperty); }				
            set
            { 
                OnPropertyChanging("Name");
                SetProperty(_nameProperty, value); 
                OnPropertyChanged("Name");
            }
		}
        
		private static readonly PropertyInfo< string > _typeProperty = RegisterProperty< string >(p => p.Type);
		public string Type
		{
			get { return GetProperty(_typeProperty); }				
            set
            { 
                OnPropertyChanging("Type");
                SetProperty(_typeProperty, value); 
                OnPropertyChanged("Type");
            }
		}
        
		private static readonly PropertyInfo< decimal > _priceProperty = RegisterProperty< decimal >(p => p.Price);
		public decimal Price
		{
			get { return GetProperty(_priceProperty); }				
            set
            { 
                OnPropertyChanging("Price");
                SetProperty(_priceProperty, value); 
                OnPropertyChanged("Price");
            }
		}
        
		private static readonly PropertyInfo< string > _categoryIdProperty = RegisterProperty< string >(p => p.CategoryId);
		public string CategoryId
		{
			get { return GetProperty(_categoryIdProperty); }				
            set
            { 
                OnPropertyChanging("CategoryId");
                SetProperty(_categoryIdProperty, value); 
                OnPropertyChanged("CategoryId");
            }
		}
        
		private static readonly PropertyInfo< string > _productIdProperty = RegisterProperty< string >(p => p.ProductId);
		public string ProductId
		{
			get { return GetProperty(_productIdProperty); }				
            set
            { 
                OnPropertyChanging("ProductId");
                SetProperty(_productIdProperty, value); 
                OnPropertyChanged("ProductId");
            }
		}
        
		private static readonly PropertyInfo< bool > _isShoppingCartProperty = RegisterProperty< bool >(p => p.IsShoppingCart);
		public bool IsShoppingCart
		{
			get { return GetProperty(_isShoppingCartProperty); }				
            set
            { 
                OnPropertyChanging("IsShoppingCart");
                SetProperty(_isShoppingCartProperty, value); 
                OnPropertyChanged("IsShoppingCart");
            }
		}
        
		private static readonly PropertyInfo< int > _quantityProperty = RegisterProperty< int >(p => p.Quantity);
		public int Quantity
		{
			get { return GetProperty(_quantityProperty); }				
            set
            { 
                OnPropertyChanging("Quantity");
                SetProperty(_quantityProperty, value); 
                OnPropertyChanged("Quantity");
            }
		}
        
		private static readonly PropertyInfo< int > _uniqueIDProperty = RegisterProperty< int >(p => p.UniqueID);
		public int UniqueID
		{
			get { return GetProperty(_uniqueIDProperty); }				
            set
            { 
                OnPropertyChanging("UniqueID");
                SetProperty(_uniqueIDProperty, value); 
                OnPropertyChanged("UniqueID");
            }
		}
		
		private static readonly PropertyInfo< Profile > _profileProperty = RegisterProperty< Profile >(p => p.Profile, Csla.RelationshipTypes.LazyLoad);
		public Profile Profile
		{
			get
            {
                if(!FieldManager.FieldExists(_profileProperty))
                    SetProperty(_profileProperty, Profile.GetProfile(UniqueID));

                   return GetProperty(_profileProperty); 
            }
		}

		#endregion
				
		#region Factory Methods 
		
		internal static Cart NewCart()
		{
			return DataPortal.CreateChild< Cart >();
		}
		
		internal static Cart GetCart(int cartId)
		{
			return DataPortal.FetchChild< Cart >(
				new CartCriteria(cartId));
		}
		
		#endregion
		
	}
}