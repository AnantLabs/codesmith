﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.1413, CSLA Framework: v3.8.2.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'LineItem.cs'.
//
//     Template: Criteria.Generated.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using Csla;

#endregion

namespace PetShop.Tests.StoredProcedures
{
    [Serializable]
    public partial class LineItemCriteria : CriteriaBase, IGeneratedCriteria
    {
        #region Private Read-Only Members
        
        private readonly Dictionary<string, object> _bag = new Dictionary<string, object>();
        
        #endregion
        
        #region Constructors

        public LineItemCriteria() : base(typeof(LineItem)){}

        public LineItemCriteria(System.Int32 orderId, System.Int32 lineNum) : base(typeof(LineItem))
        {
            OrderId = orderId;
            LineNum = lineNum;
        }
        
        #endregion
        
        #region Public Properties
        
        #region Read-Write

        public System.Int32 OrderId
        {
            get { return GetValue< System.Int32 >("OrderId"); }
            set { _bag["OrderId"] = value; }
        }

        public System.Int32 LineNum
        {
            get { return GetValue< System.Int32 >("LineNum"); }
            set { _bag["LineNum"] = value; }
        }

        public System.String ItemId
        {
            get { return GetValue< System.String >("ItemId"); }
            set { _bag["ItemId"] = value; }
        }

        public System.Int32 Quantity
        {
            get { return GetValue< System.Int32 >("Quantity"); }
            set { _bag["Quantity"] = value; }
        }

        public System.Decimal UnitPrice
        {
            get { return GetValue< System.Decimal >("UnitPrice"); }
            set { _bag["UnitPrice"] = value; }
        }

        #endregion
        
        #region Read-Only

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
                return "[dbo].LineItem";
            }
        }

        #endregion

        #endregion

        #region Overrides
        
        public override string ToString()
        {
            if (_bag.Count == 0)
                return "No criterion was specified";

            var result = string.Empty;
            foreach (KeyValuePair<string, object> key in _bag)
            {
                result += string.Format("[{0}] = '{1}' AND ", key.Key, key.Value);
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
    }
}