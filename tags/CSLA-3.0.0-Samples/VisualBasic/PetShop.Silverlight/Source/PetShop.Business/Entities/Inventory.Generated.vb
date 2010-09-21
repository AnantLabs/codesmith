﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.0, CSLA Framework: v4.0.0.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'Inventory.vb.
'
'     Template path: EditableRoot.Generated.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System

Imports Csla
Imports Csla.Rules
#If SILVERLIGHT Then
Imports Csla.Serialization
#Else
Imports Csla.Data
#End If

Namespace PetShop.Business
    <Serializable()> _
    Public Partial Class Inventory
        Inherits BusinessBase(Of Inventory)
    
#Region "Contructor(s)"
    
#If Not SILVERLIGHT Then
        Private Sub New()
            ' require use of factory method 
        End Sub
#Else
        public Sub New()
            ' require use of factory method 
        End Sub
#End If
    
        Friend Sub New(ByVal itemId As System.String)
            Using(BypassPropertyChecks)
            LoadProperty(_itemIdProperty, itemId)
            End Using
        End Sub
    
#If Not SILVERLIGHT Then
        Friend Sub New(Byval reader As SafeDataReader)
            Map(reader)
        End Sub
#End If

#End Region    
    
#Region "Business Rules"
    
        Protected Overrides Sub AddBusinessRules()
    
            If AddBusinessValidationRules() Then Exit Sub
    
            BusinessRules.AddRule(New Csla.Rules.CommonRules.Required(_itemIdProperty))
            BusinessRules.AddRule(New Csla.Rules.CommonRules.MaxLength(_itemIdProperty, 10))
        End Sub
    
#End Region

#Region "Properties"
    
        Private Shared ReadOnly _itemIdProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Inventory) p.ItemId, String.Empty)
#If Not SILVERLIGHT Then
        
		<System.ComponentModel.DataObjectField(true, false)> _
        Public Property ItemId() As System.String
#Else
        Public Property ItemId() As System.String
#End If
            Get 
                Return GetProperty(_itemIdProperty)
            End Get
            Set (ByVal value As System.String)
                SetProperty(_itemIdProperty, value)
            End Set
        End Property

        Private Shared ReadOnly _originalItemIdProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Inventory) p.OriginalItemId, String.Empty)
        ''' <summary>
        ''' Holds the original value for ItemId. This is used for non identity primary keys.
        ''' </summary>
        Friend Property OriginalItemId() As System.String
            Get 
                Return GetProperty(_originalItemIdProperty) 
            End Get
            Set (value As System.String)
                SetProperty(_originalItemIdProperty, value)
            End Set
        End Property

        Private Shared ReadOnly _qtyProperty As PropertyInfo(Of System.Int32) = RegisterProperty(Of System.Int32)(Function(p As Inventory) p.Qty, String.Empty)
#If Not SILVERLIGHT Then
        
        Public Property Qty() As System.Int32
#Else
        Public Property Qty() As System.Int32
#End If
            Get 
                Return GetProperty(_qtyProperty)
            End Get
            Set (ByVal value As System.Int32)
                SetProperty(_qtyProperty, value)
            End Set
        End Property

#End Region
    
#If Not SILVERLIGHT Then
#Region "Synchronous Factory Methods"
    
        Public Shared Function NewInventory() As Inventory
            Return DataPortal.Create(Of Inventory)()
        End Function
    
        Public Shared Function GetByItemId(ByVal itemId As System.String) As Inventory
            Dim criteria As New InventoryCriteria()
            criteria.ItemId = itemId
            
            Return DataPortal.Fetch(Of Inventory)(criteria)
        End Function
    
        Public Shared Sub DeleteInventory(ByVal itemId As System.String)
            DataPortal.Delete(Of Inventory)(New InventoryCriteria(itemId))
        End Sub
    
#End Region
#End If        
    
#Region "Asynchronous Factory Methods"

#If SILVERLIGHT Then
        Public Shared Sub NewInventoryAsync(ByVal handler As EventHandler(Of DataPortalResult(Of Inventory)))
            Dim dp As New DataPortal(Of Inventory)()
            AddHandler dp.CreateCompleted, handler
            dp.BeginCreate()
        End Sub
    
        Public Shared Sub GetByItemIdAsync(ByVal itemId As System.String, ByVal handler As EventHandler(Of DataPortalResult(Of Inventory)))
            Dim dp As New DataPortal(Of Inventory)()
            AddHandler dp.FetchCompleted, handler
        
            Dim criteria As New InventoryCriteria()
            criteria.ItemId = itemId
    
            dp.BeginFetch(criteria)
        End Sub
    
        Public Shared Sub DeleteInventoryDeleteInventoryAsync(ByVal itemId As System.String, ByVal handler As EventHandler(Of DataPortalResult(Of Inventory)))
            Dim dp As New DataPortal(Of Inventory)()
            AddHandler dp.DeleteCompleted, handler
            dp.BeginDelete(New InventoryCriteria (itemId))
        End Sub
    
#End If

#End Region
    
#Region "DataPortal partial methods"
    
#If Not SILVERLIGHT Then
        Partial Private Sub OnCreating(ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnCreated()
        End Sub
        Partial Private Sub OnFetching(ByVal criteria As InventoryCriteria, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnFetched()
        End Sub
        Partial Private Sub OnMapping(ByVal reader As SafeDataReader, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnMapped()
        End Sub
        Partial Private Sub OnInserting(ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnInserted()
        End Sub
        Partial Private Sub OnUpdating(ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnUpdated()
        End Sub
        Partial Private Sub OnSelfDeleting(ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnSelfDeleted()
        End Sub
        Partial Private Sub OnDeleting(ByVal criteria As InventoryCriteria, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnDeleted()
        End Sub
#End If
    
#End Region

#Region "Exists Command"

        Public Shared Function Exists(ByVal criteria As InventoryCriteria ) As Boolean
            Return PetShop.Business.ExistsCommand.Execute(criteria)
        End Function

#End Region
    End Class
End Namespace
