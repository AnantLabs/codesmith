﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.1845, CSLA Framework: v4.0.0.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'ItemList.vb.
'
'     Template: EditableChildList.Generated.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System
Imports System.Collections.Generic

Imports Csla
#If SILVERLIGHT Then
Imports Csla.Serialization
#Else
Imports Csla.Data
#End If

Namespace PetShop.Business
    <Serializable()> _
    Public Partial Class ItemList 
        Inherits BusinessListBase(Of ItemList, Item)
    
#Region "Contructor(s)"
    #If Not SILVERLIGHT Then
        Private Sub New()
            AllowNew = true
            MarkAsChild()
        End Sub
    #Else
        public Sub New()
            AllowNew = true
            MarkAsChild()
        End Sub
    #End If
    
#End Region
    
    #If Not SILVERLIGHT Then
#Region "Synchronous Factory Methods" 
    
        Friend Shared Function NewList() As ItemList
            Return DataPortal.CreateChild(Of ItemList)()
        End Function
    
        Friend Shared Function GetByItemId(ByVal itemId As System.String) As ItemList 
            Dim criteria As New ItemCriteria()
            criteria.ItemId = itemId
    
            Return DataPortal.FetchChild(Of ItemList)(criteria)
        End Function
    
        Friend Shared Function GetByProductIdItemIdListPriceName(ByVal productId As System.String, ByVal itemId As System.String, ByVal listPrice As System.Nullable(Of System.Decimal), ByVal name As System.String) As ItemList 
            Dim criteria As New ItemCriteria()
            criteria.ProductId = productId
			criteria.ItemId = itemId
			criteria.ListPrice = listPrice.Value
			criteria.Name = name
    
            Return DataPortal.FetchChild(Of ItemList)(criteria)
        End Function
    
        Friend Shared Function GetByProductId(ByVal productId As System.String) As ItemList 
            Dim criteria As New ItemCriteria()
            criteria.ProductId = productId
    
            Return DataPortal.FetchChild(Of ItemList)(criteria)
        End Function
    
        Friend Shared Function GetBySupplier(ByVal supplier As System.Nullable(Of System.Int32)) As ItemList 
            Dim criteria As New ItemCriteria()
            criteria.Supplier = supplier.Value
    
            Return DataPortal.FetchChild(Of ItemList)(criteria)
        End Function
    
        Friend Shared Function GetAll() As ItemList
            Return DataPortal.FetchChild(Of ItemList)(New ItemCriteria())
        End Function
    
#End Region
    #End If        
    
#Region "Asynchronous Factory Methods"
    
        Friend Shared Sub NewListAsync(ByVal handler As EventHandler(Of DataPortalResult(Of Item)))
            Dim dp As New DataPortal(Of Item)()
            AddHandler dp.CreateCompleted, handler
            dp.BeginCreate()
        End Sub
    
        Friend Shared Sub GetByItemIdAsync(ByVal itemId As System.String, ByVal handler As EventHandler(Of DataPortalResult(Of Item)))
            Dim criteria As New ItemCriteria()
            criteria.ItemId = itemId

            'How should this be called? In the sync method we call FetchChild.
            Dim dp As New DataPortal(Of Item)()
            AddHandler dp.FetchCompleted, handler
            dp.BeginFetch(criteria)
        End Sub
    
        Friend Shared Sub GetByProductIdItemIdListPriceNameAsync(ByVal productId As System.String, ByVal itemId As System.String, ByVal listPrice As System.Nullable(Of System.Decimal), ByVal name As System.String, ByVal handler As EventHandler(Of DataPortalResult(Of Item)))
            Dim criteria As New ItemCriteria()
            criteria.ProductId = productId
			criteria.ItemId = itemId
			criteria.ListPrice = listPrice.Value
			criteria.Name = name

            'How should this be called? In the sync method we call FetchChild.
            Dim dp As New DataPortal(Of Item)()
            AddHandler dp.FetchCompleted, handler
            dp.BeginFetch(criteria)
        End Sub
    
        Friend Shared Sub GetByProductIdAsync(ByVal productId As System.String, ByVal handler As EventHandler(Of DataPortalResult(Of Item)))
            Dim criteria As New ItemCriteria()
            criteria.ProductId = productId

            'How should this be called? In the sync method we call FetchChild.
            Dim dp As New DataPortal(Of Item)()
            AddHandler dp.FetchCompleted, handler
            dp.BeginFetch(criteria)
        End Sub
    
        Friend Shared Sub GetBySupplierAsync(ByVal supplier As System.Nullable(Of System.Int32), ByVal handler As EventHandler(Of DataPortalResult(Of Item)))
            Dim criteria As New ItemCriteria()
            criteria.Supplier = supplier.Value

            'How should this be called? In the sync method we call FetchChild.
            Dim dp As New DataPortal(Of Item)()
            AddHandler dp.FetchCompleted, handler
            dp.BeginFetch(criteria)
        End Sub
    
        Friend Shared Sub GetAllAsync(ByVal handler As EventHandler(Of DataPortalResult(Of Item)))
            'How should this be called? In the sync method we call FetchChild.
            Dim dp As New DataPortal(Of Item)()
            AddHandler dp.FetchCompleted, handler
            dp.BeginFetch(New ItemCriteria())
        End Sub
    
    #End Region
    
#Region "Method Overrides"
    
    #If Not SILVERLIGHT Then
        Protected Overrides Function AddNewCore() As Item
            Dim item As Item = PetShop.Business.Item.NewItem()

            Dim cancel As Boolean = False
            OnAddNewCore(item, cancel)
            If Not (cancel) Then
                ' Check to see if someone set the item to null in the OnAddNewCore.
                If(item Is Nothing) Then
                    item = PetShop.Business.Item.NewItem()
                End If
            ' Pass the parent value down to the child.
                Dim product As Product = CType(Me.Parent, Product)
                If Not(product Is Nothing)
                    item.ProductId = product.ProductId
                End If
            ' Pass the parent value down to the child.
                Dim supplier As Supplier = CType(Me.Parent, Supplier)
                If Not(supplier Is Nothing)
                    item.Supplier = supplier.SuppId
                End If
                Add(item)
            End If

            Return item
        End Function
    #Else
        Protected Overrides Sub AddNewCore() 
            PetShop.Business.Item.NewItemAsync(Sub(o, e)
                    Dim item As Item = e.Object
        
                    Dim cancel As Boolean = False
                    OnAddNewCore(item, cancel)
                    If Not (cancel) Then
                        ' Check to see if someone set the item to null in the OnAddNewCore.
                        If(item Is Nothing) Then
                            Return
                        End If
                        ' Pass the parent value down to the child.
                        Dim product As Product = CType(Me.Parent, Product)
                        If Not(product Is Nothing)
                            item.ProductId = product.ProductId
                        End If
                        ' Pass the parent value down to the child.
                        Dim supplier As Supplier = CType(Me.Parent, Supplier)
                        If Not(supplier Is Nothing)
                            item.Supplier = supplier.SuppId
                        End If
                        Add(item)
                    End If
                End Sub)
        End Sub
    #End If
    
        Protected Sub AddNewCoreAsync(ByVal handler As EventHandler(Of DataPortalResult(Of Item)))
            PetShop.Business.Item.NewItemAsync(Sub(o, e)
                    If e.Error Is Nothing Then
                        Add(e.Object)
                        handler.Invoke(Me, New DataPortalResult(Of Item)(e.Object, Nothing, Nothing))
                    End If
                End Sub)
        End Sub
    
    
#End Region
#Region "DataPortal partial methods"
    
    #If Not SILVERLIGHT Then
        Partial Private Sub OnCreating(ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnCreated()
        End Sub
        Partial Private Sub OnFetching(ByVal criteria As ItemCriteria, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnFetched()
        End Sub
        Partial Private Sub OnMapping(ByVal reader As SafeDataReader, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnMapped()
        End Sub
        Partial Private Sub OnUpdating(ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnUpdated()
        End Sub
    #End If
        Partial Private Sub OnAddNewCore(ByVal item As Item, ByRef cancel As Boolean)
        End Sub
    
#End Region

#Region "Exists Command"

        Public Shared Function Exists(ByVal criteria As ItemCriteria) As Boolean
            Return PetShop.Business.Item.Exists(criteria)
        End Function

#End Region
    End Class
End Namespace