﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v6.5.0, CSLA Templates: v4.0.0.0, CSLA Framework: v4.3.10.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'Supplier.cs'.
//
//     Template: Criteria.Generated.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

using Csla;

namespace PetShop.Tests.StoredProcedures
{
    [Serializable]
    public partial class SupplierCriteria : CriteriaBase<SupplierCriteria>, IGeneratedCriteria
    {
        private readonly Dictionary<string, object> _bag = new Dictionary<string, object>();
        
        #region Constructors

        public SupplierCriteria(){}

        public SupplierCriteria(System.Int32 suppId)
        {
            SuppId = suppId;
        }

        #endregion

        #region Public Properties

        #region Read-Write

        public System.Int32 SuppId
        {
            get { return GetValue<System.Int32>("SuppId"); }
            set { _bag["SuppId"] = value; }
        }

        public System.String Name
        {
            get { return GetValue<System.String>("Name"); }
            set { _bag["Name"] = value; }
        }

        public System.String Status
        {
            get { return GetValue<System.String>("Status"); }
            set { _bag["Status"] = value; }
        }

        public System.String Addr1
        {
            get { return GetValue<System.String>("Addr1"); }
            set { _bag["Addr1"] = value; }
        }

        public System.String Addr2
        {
            get { return GetValue<System.String>("Addr2"); }
            set { _bag["Addr2"] = value; }
        }

        public System.String City
        {
            get { return GetValue<System.String>("City"); }
            set { _bag["City"] = value; }
        }

        public System.String State
        {
            get { return GetValue<System.String>("State"); }
            set { _bag["State"] = value; }
        }

        public System.String Zip
        {
            get { return GetValue<System.String>("Zip"); }
            set { _bag["Zip"] = value; }
        }

        public System.String Phone
        {
            get { return GetValue<System.String>("Phone"); }
            set { _bag["Phone"] = value; }
        }

        #endregion
        
        #region Read-Only

        public bool NameHasValue
        {
            get { return _bag.ContainsKey("Name"); }
        }

        public bool Addr1HasValue
        {
            get { return _bag.ContainsKey("Addr1"); }
        }

        public bool Addr2HasValue
        {
            get { return _bag.ContainsKey("Addr2"); }
        }

        public bool CityHasValue
        {
            get { return _bag.ContainsKey("City"); }
        }

        public bool StateHasValue
        {
            get { return _bag.ContainsKey("State"); }
        }

        public bool ZipHasValue
        {
            get { return _bag.ContainsKey("Zip"); }
        }

        public bool PhoneHasValue
        {
            get { return _bag.ContainsKey("Phone"); }
        }

        /// <summary>
        /// Returns a list of all the modified properties and values.
        /// </summary>
        public Dictionary<string, object> StateBag
        {
            get
            {
                return _bag;
            }
        }

        /// <summary>
        /// Returns a list of all the modified properties and values.
        /// </summary>
        public string TableFullName
        {
            get
            {
                return "Supplier";
            }
        }

        #endregion

        #endregion

        #region Overrides
        
        public override string ToString()
        {
            var result = String.Empty;
            var cancel = false;
            
            OnToString(ref result, ref cancel);
            if(cancel && !String.IsNullOrEmpty(result))
                return result;
            
            if (_bag.Count == 0)
                return "No criterion was specified.";

            foreach (KeyValuePair<string, object> key in _bag)
            {
                result += String.Format("[{0}] = '{1}' AND ", key.Key, key.Value);
            }

            return result.Remove(result.Length - 5, 5);
        }

        #endregion

        #region Private Methods
        private T GetValue<T>(string name)
        {
            object value;
            if (_bag.TryGetValue(name, out value))
                return (T) value;
        
            return default(T);
        }
        
        #endregion
        
        #region Partial Methods
        
        partial void OnToString(ref string result, ref bool cancel);
        
        #endregion
        
    }
}