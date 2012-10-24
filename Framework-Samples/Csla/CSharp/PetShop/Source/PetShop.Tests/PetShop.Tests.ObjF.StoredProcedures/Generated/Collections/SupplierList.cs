﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v6.5.3, CSLA Templates: v4.0.0.0, CSLA Framework: v4.3.x.
//       Changes to this template will not be lost.
//
//     Template: EditableChildList.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Csla;

namespace PetShop.Tests.ObjF.StoredProcedures
{    
    /// <summary>
    /// The SupplierList class is a CSLA editable child list class collection of <see cref="Supplier"/> objects.  See CSLA documentation for a more detailed description.
    /// </summary>
    /// <returns></returns>
    public partial class SupplierList
    {
        #region Authorization Rules

        /// <summary>
        /// Allows the specification of CSLA based authorization rules for a collection list.  Specifies what roles can 
        /// perform which operations for a given business object
        /// </summary>
        protected void AddAuthorizationRules()
        {
            //Csla.Rules.BusinessRules.AddRule(typeof(SupplierList), new Csla.Rules.CommonRules.IsInRole(Csla.Rules.AuthorizationActions.CreateObject, "SomeRole"));
            //Csla.Rules.BusinessRules.AddRule(typeof(SupplierList), new Csla.Rules.CommonRules.IsInRole(Csla.Rules.AuthorizationActions.EditObject, "SomeRole"));
            //Csla.Rules.BusinessRules.AddRule(typeof(SupplierList), new Csla.Rules.CommonRules.IsInRole(Csla.Rules.AuthorizationActions.DeleteObject, "SomeRole", "SomeAdminRole"));
        }
        #endregion
    }
}