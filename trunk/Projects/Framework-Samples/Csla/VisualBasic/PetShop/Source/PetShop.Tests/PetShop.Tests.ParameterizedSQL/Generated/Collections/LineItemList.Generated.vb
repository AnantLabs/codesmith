'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.1357, CSLA Framework: v3.8.0.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'LineItemList.vb.
'
'     Template: EditableRootList.Generated.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System

Imports Csla
Imports Csla.Data

<Serializable()> _
Public Partial Class LineItemList 
    Inherits BusinessListBase(Of LineItemList, LineItem)

    #Region "Contructor(s)"
    
    Private Sub New()
        AllowNew = true
    End Sub
    
    #End Region

    #Region "Factory Methods"

    Public Shared Function NewList() As LineItemList
        Return DataPortal.Create(Of LineItemList)()
    End Function

    Public Shared Function GetByOrderIdLineNum(ByVal orderId As System.Int32, ByVal lineNum As System.Int32) As LineItemList 
        Dim criteria As New LineItemCriteria()
		criteria.OrderId = orderId
		criteria.LineNum = lineNum

        Return DataPortal.Fetch(Of LineItemList)(criteria)
    End Function

    Public Shared Function GetByOrderId(ByVal orderId As System.Int32) As LineItemList 
        Dim criteria As New LineItemCriteria()
		criteria.OrderId = orderId

        Return DataPortal.Fetch(Of LineItemList)(criteria)
    End Function

    Public Shared Function GetAll() As LineItemList
        Return DataPortal.Fetch(Of LineItemList)(New LineItemCriteria())
    End Function

    #End Region

    #Region "Properties"

    Protected Overrides Function AddNewCore() As Object
        Dim item As LineItem = PetShop.Tests.ParameterizedSQL.LineItem.NewLineItem()
        Me.Add(item)
        Return item
    End Function

    #End Region

    #Region "Exists Command"

    Public Shared Function Exists(ByVal criteria As LineItemCriteria) As Boolean
        Return PetShop.Tests.ParameterizedSQL.LineItem.Exists(criteria)
    End Function

    #End Region
End Class