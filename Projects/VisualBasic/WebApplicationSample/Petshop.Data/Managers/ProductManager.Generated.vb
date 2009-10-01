﻿
'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a CodeSmith Template.
'
'     DO NOT MODIFY contents of this file. Changes to this
'     file will be lost if the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic
Imports System.Data.Linq
Imports System.Linq
Imports System.Text

Namespace Petshop.Data
    ''' <summary>
    ''' The manager class for Product.
    ''' </summary>
    Partial Public Class ProductManager 
        Inherits CodeSmith.Data.EntityManagerBase(Of PetshopDataManager, Petshop.Data.Product)

        ''' <summary>
        ''' Initializes the <see cref="ProductManager"/> class.
        ''' </summary>
        ''' <param name="manager">The current manager.</param>
        Public Sub New(ByVal manager As PetshopDataManager) 
            MyBase.New(manager)
            OnCreated()
        End Sub

        ''' <summary>
        ''' Gets the current context.
        ''' </summary>
        Protected ReadOnly Property Context() As Petshop.Data.PetshopDataContext
            Get
                return Manager.Context
            End Get
        End Property
        
        ''' <summary>
        ''' Gets the entity for this manager.
        ''' </summary>
        Protected ReadOnly Property Entity() As System.Data.Linq.Table(Of Petshop.Data.Product)
            Get 
                return Manager.Context.Product
            End Get
        End Property
        
        
        ''' <summary>
        ''' Creates the key for this entity.
        ''' </summary>
        Public Shared Function CreateKey(ByVal productId As String) As CodeSmith.Data.IEntityKey(Of String)
            Return New CodeSmith.Data.EntityKey(Of String)(productId)
        End Function
        
        ''' <summary>
        ''' Gets an entity by the primary key.
        ''' </summary>
        ''' <param name="key">The key for the entity.</param>
        ''' <returns>
        ''' An instance of the entity or null if not found.
        ''' </returns>
        ''' <remarks>
        ''' This method is expecting key to be of type IEntityKey(Of String).
        ''' </remarks>
        ''' <exception cref="ArgumentException">Thrown when key is not of type IEntityKey(Of String).</exception>
        Public Overrides Function GetByKey(ByVal key As CodeSmith.Data.IEntityKey) As Petshop.Data.Product
            If (key Is GetType(CodeSmith.Data.IEntityKey(Of String))) Then
                Dim entityKey As CodeSmith.Data.IEntityKey(Of String) = DirectCast(key, CodeSmith.Data.IEntityKey(Of String))
                return GetByKey(entityKey.Key)
            Else
                Throw New ArgumentException("Invalid key, expected key to be of type IEntityKey(Of String)")
            End If
        End Function
        
        ''' <summary>
        ''' Gets an instance by the primary key.
        ''' </summary>
        ''' <returns>An instance of the entity or null if not found.</returns>
        Public Overloads Function GetByKey(ByVal productId As String) As Petshop.Data.Product
            If (Context.LoadOptions Is Nothing) Then 
                return Query.GetByKey.Invoke(Context, productId)
            Else
                return Entity.FirstOrDefault(Function(p)p.ProductId = productId)
            End If
        End Function
        
        ''' <summary>
        ''' Immediately deletes the entity by the primary key from the underlying data source with a single delete command.
        ''' </summary>
        ''' <returns>The number of rows deleted from the database.</returns>
        Public Function Delete(ByVal productId As String) As Integer
            return Entity.Delete(Function(p)p.ProductId = productId)
        End Function
        
        ''' <summary>
        ''' Gets a query by an index.
        ''' </summary>
        Public Overloads Function GetByName(ByVal name As String) As IQueryable(Of Petshop.Data.Product)
            If Context.LoadOptions Is Nothing Then 
                return Query.GetByName.Invoke(Context, name)
            Else
                return Entity.Where(Function(p)Object.Equals(p.Name, name))
            End If
        End Function
        
        ''' <summary>
        ''' Gets a query by an index.
        ''' </summary>
        Public Overloads Function GetByCategoryId(ByVal categoryId As String) As IQueryable(Of Petshop.Data.Product)
            If Context.LoadOptions Is Nothing Then 
                return Query.GetByCategoryId.Invoke(Context, categoryId)
            Else
                return Entity.Where(Function(p)p.CategoryId = categoryId)
            End If
        End Function
        
        ''' <summary>
        ''' Gets a query by an index.
        ''' </summary>
        Public Overloads Function GetByCategoryIdName(ByVal categoryId As String, ByVal name As String) As IQueryable(Of Petshop.Data.Product)
            If Context.LoadOptions Is Nothing Then 
                return Query.GetByCategoryIdName.Invoke(Context, categoryId, name)
            Else
                return Entity.Where(Function(p)p.CategoryId = categoryId _
					AndAlso Object.Equals(p.Name, name))
            End If
        End Function
        
        ''' <summary>
        ''' Gets a query by an index.
        ''' </summary>
        Public Overloads Function GetByCategoryIdProductIdName(ByVal categoryId As String, ByVal productId As String, ByVal name As String) As IQueryable(Of Petshop.Data.Product)
            If Context.LoadOptions Is Nothing Then 
                return Query.GetByCategoryIdProductIdName.Invoke(Context, categoryId, productId, name)
            Else
                return Entity.Where(Function(p)p.CategoryId = categoryId _
					AndAlso p.ProductId = productId _
					AndAlso Object.Equals(p.Name, name))
            End If
        End Function

        #Region "Extensibility Method Definitions"
        ''' <summary>Called when the class is created.</summary>
        Partial Private Sub OnCreated()
        End Sub
        #End Region
        
        #Region "Query"
        ''' <summary>
        ''' A private class for lazy loading static compiled queries.
        ''' </summary>
        Private Partial Class Query

            Friend Shared Readonly GetByKey As Func(Of Petshop.Data.PetshopDataContext, String, Petshop.Data.Product) = _
                CompiledQuery.Compile( _
                     Function(db As Petshop.Data.PetshopDataContext, ByVal productId As String) _
                        db.Product.FirstOrDefault(Function(p)p.ProductId = productId))

            Friend Shared Readonly  GetByName As Func(Of Petshop.Data.PetshopDataContext, String, IQueryable(Of Petshop.Data.Product)) = _
                CompiledQuery.Compile( _
                    Function( db As Petshop.Data.PetshopDataContext , ByVal name As String) _
                        db.Product.Where(Function(p)Object.Equals(p.Name, name)))

            Friend Shared Readonly  GetByCategoryId As Func(Of Petshop.Data.PetshopDataContext, String, IQueryable(Of Petshop.Data.Product)) = _
                CompiledQuery.Compile( _
                    Function( db As Petshop.Data.PetshopDataContext , ByVal categoryId As String) _
                        db.Product.Where(Function(p)p.CategoryId = categoryId))

            Friend Shared Readonly  GetByCategoryIdName As Func(Of Petshop.Data.PetshopDataContext, String, String, IQueryable(Of Petshop.Data.Product)) = _
                CompiledQuery.Compile( _
                    Function( db As Petshop.Data.PetshopDataContext , ByVal categoryId As String, ByVal name As String) _
                        db.Product.Where(Function(p)p.CategoryId = categoryId _
							AndAlso Object.Equals(p.Name, name)))

            Friend Shared Readonly  GetByCategoryIdProductIdName As Func(Of Petshop.Data.PetshopDataContext, String, String, String, IQueryable(Of Petshop.Data.Product)) = _
                CompiledQuery.Compile( _
                    Function( db As Petshop.Data.PetshopDataContext , ByVal categoryId As String, ByVal productId As String, ByVal name As String) _
                        db.Product.Where(Function(p)p.CategoryId = categoryId _
							AndAlso p.ProductId = productId _
							AndAlso Object.Equals(p.Name, name)))

        End Class
        #End Region
    End Class
End Namespace

