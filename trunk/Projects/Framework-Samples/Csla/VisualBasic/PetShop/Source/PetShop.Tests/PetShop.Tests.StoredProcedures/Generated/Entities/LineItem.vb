'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.1357, CSLA Framework: v3.8.0.
'       Changes to this template will not be lost.
'
'     Template: SwitchableObject.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System

Imports Csla
Imports Csla.Security
Imports Csla.Validation

Public Partial Class LineItem
    #Region "Validation Rules"

    ''' <summary>
    ''' All custom rules need to be placed in this method.
    ''' </summary>
    ''' <Returns>Return true to override the generated rules If false generated rules will be run.</Returns>
    Protected Function AddBusinessValidationRules() As Boolean
        ' TODO: add validation rules
        'ValidationRules.AddRule(RuleMethod, "")

        Return False
    End Function

    #End Region

    #Region "Authorization Rules"

    Protected Overrides Sub AddAuthorizationRules()
        ''More information on these rules can be found here (http://www.devx.com/codemag/Article/40663/1763/page/2).

        'Dim canWrite As String() = { "AdminUser", "RegularUser" }
        'Dim canRead As String() = { "AdminUser", "RegularUser", "ReadOnlyUser" }
        'Dim admin As String() = { "AdminUser" }

        'AuthorizationRules.AllowCreate(GetType(LineItem), admin)
        'AuthorizationRules.AllowDelete(GetType(LineItem), admin)
        'AuthorizationRules.AllowEdit(GetType(LineItem), canWrite)
        'AuthorizationRules.AllowGet(GetType(LineItem), canRead)

        ''OrderId
        'AuthorizationRules.AllowWrite(_orderIdProperty, canWrite)
        'AuthorizationRules.AllowRead(_orderIdProperty, canRead)

        ''LineNum
        'AuthorizationRules.AllowWrite(_lineNumProperty, canWrite)
        'AuthorizationRules.AllowRead(_lineNumProperty, canRead)

        ''ItemId
        'AuthorizationRules.AllowWrite(_itemIdProperty, canWrite)
        'AuthorizationRules.AllowRead(_itemIdProperty, canRead)

        ''Quantity
        'AuthorizationRules.AllowWrite(_quantityProperty, canWrite)
        'AuthorizationRules.AllowRead(_quantityProperty, canRead)

        ''UnitPrice
        'AuthorizationRules.AllowWrite(_unitPriceProperty, canWrite)
        'AuthorizationRules.AllowRead(_unitPriceProperty, canRead)

        ''OrderMember
        'AuthorizationRules.AllowRead(_orderMemberProperty, canRead)

    End Sub

    #End Region
End Class