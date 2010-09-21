﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.0, CSLA Framework: v4.0.0.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'Product.vb.
'
'     Template: DynamicRootList.Generated.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System

Imports Csla
Imports Csla.Data

Namespace PetShop.Tests.OF.ParameterizedSQL
    <Serializable()> _
    <Csla.Server.ObjectFactory(FactoryNames.ProductListFactoryName)> _
    Public Partial Class ProductList
        Inherits DynamicBindingListBase(Of Product)
    
#Region "Constructor(s)"
        
        Private Sub New()
            AllowNew = True
        End Sub
    
#End Region
    
#Region "Method Overrides"
        
        Protected Overrides Function AddNewCore() As Object
            Dim item As Product = PetShop.Tests.OF.ParameterizedSQL.Product.NewProduct()
    
            Dim cancel As Boolean = False
            OnAddNewCore(item, cancel)
            If Not (cancel) Then
                ' Check to see if someone set the item to null in the OnAddNewCore.
                If(item Is Nothing) Then
                    item = PetShop.Tests.OF.ParameterizedSQL.Product.NewProduct()
                End If
                
                Add(item)
            End If

            Return item
        End Function
        
#End Region
    
#Region "Synchronous Factory Methods"
        
        Public Shared Function NewList() As ProductList
            Return DataPortal.Create(Of ProductList)()
        End Function

        Public Shared Function GetAll() As ProductList
            Return DataPortal.Fetch(Of ProductList)(New ProductCriteria())
        End Function

    
        Public Shared Function GetByProductId(ByVal productId As System.String) As ProductList 
            Dim criteria As New ProductCriteria()
            criteria.ProductId = productId

            Return DataPortal.Fetch(Of ProductList)(criteria)
        End Function
    
        Public Shared Function GetByName(ByVal name As System.String) As ProductList 
            Dim criteria As New ProductCriteria()
            criteria.Name = name

            Return DataPortal.Fetch(Of ProductList)(criteria)
        End Function
    
        Public Shared Function GetByCategoryId(ByVal categoryId As System.String) As ProductList 
            Dim criteria As New ProductCriteria()
            criteria.CategoryId = categoryId

            Return DataPortal.Fetch(Of ProductList)(criteria)
        End Function
    
        Public Shared Function GetByCategoryIdName(ByVal categoryId As System.String, ByVal name As System.String) As ProductList 
            Dim criteria As New ProductCriteria()
            criteria.CategoryId = categoryId
			criteria.Name = name

            Return DataPortal.Fetch(Of ProductList)(criteria)
        End Function
    
        Public Shared Function GetByCategoryIdProductIdName(ByVal categoryId As System.String, ByVal productId As System.String, ByVal name As System.String) As ProductList 
            Dim criteria As New ProductCriteria()
            criteria.CategoryId = categoryId
			criteria.ProductId = productId
			criteria.Name = name

            Return DataPortal.Fetch(Of ProductList)(criteria)
        End Function
    
#End Region

#Region "Property overrides"
    
            ''' <summary>
            ''' Returns true if any children are dirty
            ''' </summary>
            Public Shadows ReadOnly Property IsDirty() As Boolean
                Get
                    For Each item As Product In Me.Items
                        If item.IsDirty Then
                            Return True
                        End If
                    Next
            
                    Return False
                End Get
            End Property
    
#End Region
    
#Region "DataPortal partial methods"
    
        Partial Private Sub OnCreating(ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnCreated()
        End Sub
        Partial Private Sub OnFetching(ByVal criteria As ProductCriteria, ByRef cancel As Boolean)
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
        Partial Private Sub OnAddNewCore(ByVal item As Product, ByRef cancel As Boolean)
        End Sub
    
#End Region

#Region "Exists Command"

        Public Shared Function Exists(ByVal criteria As ProductCriteria) As Boolean
            Return PetShop.Tests.OF.ParameterizedSQL.Product.Exists(criteria)
        End Function

#End Region
    End Class
End Namespace