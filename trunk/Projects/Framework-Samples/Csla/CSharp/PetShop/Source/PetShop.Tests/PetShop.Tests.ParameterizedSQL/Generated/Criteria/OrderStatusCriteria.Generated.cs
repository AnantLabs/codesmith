//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.0, CSLA Framework: v3.8.0.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'OrderStatus.cs'.
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

namespace PetShop.Tests.ParameterizedSQL
{
    [Serializable]
    public partial class OrderStatusCriteria : CriteriaBase, IGeneratedCriteria
    {
        #region Private Read-Only Members
        
        private readonly Dictionary<string, object> _bag = new Dictionary<string, object>();
        
        #endregion
        
        #region Constructors

        public OrderStatusCriteria() : base(typeof(OrderStatus)){}

        public OrderStatusCriteria(System.Int32 orderId, System.Int32 lineNum) : base(typeof(OrderStatus))
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

        public System.DateTime Timestamp
        {
            get { return GetValue< System.DateTime >("Timestamp"); }
            set { _bag["Timestamp"] = value; }
        }

        public System.String Status
        {
            get { return GetValue< System.String >("Status"); }
            set { _bag["Status"] = value; }
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
                return "[dbo].OrderStatus";
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