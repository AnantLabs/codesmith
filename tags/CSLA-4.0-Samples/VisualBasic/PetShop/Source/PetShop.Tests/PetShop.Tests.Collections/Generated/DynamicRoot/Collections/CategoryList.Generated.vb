﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v6.5.0, CSLA Templates: v4.0.0.0, CSLA Framework: v4.3.10.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'Category.vb.
'
'     Template: DynamicRootList.Generated.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System
Imports System.Linq

Imports Csla
Imports Csla.Data

Namespace PetShop.Tests.Collections.DynamicRoot
    <Serializable()> _
    Public Partial Class CategoryList
        Inherits DynamicBindingListBase(Of Category)
    
#Region "Constructor(s)"

        public Sub New()
            AllowNew = True
        End Sub

#End Region

#Region "Synchronous Factory Methods"

        ''' <summary>
        ''' Creates a new list collection of type <see cref="CategoryList"/>. 
        ''' </summary>
        ''' <returns>Returns a newly instantiated collection of type <see cref="CategoryList"/>.</returns>
        Public Shared Function NewList() As CategoryList
            Return DataPortal.Create(Of CategoryList)()
        End Function

        ''' <summary>
        ''' Returns a <see cref="CategoryList"/> collection of <see cref="Category"/> items with the specified criteria. 
        ''' </summary>
        ''' <param name="categoryId">No additional detail available.</param>
        ''' <returns>Collection of all <see cref="Category"/> items.</returns>    
        Public Shared Function GetByCategoryId(ByVal categoryId As System.String) As CategoryList 
            Dim criteria As New CategoryCriteria()
                        criteria.CategoryId = categoryId

            Return DataPortal.Fetch(Of CategoryList)(criteria)
        End Function

        Public Shared Function GetByCriteria(ByVal criteria As CategoryCriteria) As CategoryList
            Return DataPortal.Fetch(Of CategoryList)(criteria)
        End Function

        ''' <summary>
        ''' Returns a <see cref="CategoryList"/> collection of all <see cref="Category"/> items. 
        ''' </summary>
        ''' <returns>Collection of all Category items.</returns>    
        Public Shared Function GetAll() As CategoryList
            Return DataPortal.Fetch(Of CategoryList)(New CategoryCriteria())
        End Function

#End Region

#Region "Asynchronous Factory Methods"

        Public Shared Sub NewListAsync(ByVal handler As EventHandler(Of DataPortalResult(Of CategoryList)))
            Dim dp As New DataPortal(Of CategoryList)()
            AddHandler dp.CreateCompleted, handler
            dp.BeginCreate()
        End Sub
    
        Public Shared Sub GetByCategoryIdAsync(ByVal categoryId As System.String, ByVal handler As EventHandler(Of DataPortalResult(Of CategoryList)))
            Dim dp As New DataPortal(Of CategoryList)()
            AddHandler dp.FetchCompleted, handler
        
            Dim criteria As New CategoryCriteria()
            criteria.CategoryId = categoryId
    
            dp.BeginFetch(criteria)
        End Sub

        Public Shared Sub GetByCriteriaAsync(ByVal criteria As CategoryCriteria, ByVal handler As EventHandler(Of DataPortalResult(Of CategoryList)))
            Dim dp As New DataPortal(Of CategoryList)()
            AddHandler dp.FetchCompleted, handler

            ' Mark as child?
            dp.BeginFetch(criteria)
        End Sub

        Public Shared Sub GetAllAsync(ByVal handler As EventHandler(Of DataPortalResult(Of CategoryList)))
            Dim dp As New DataPortal(Of CategoryList)()
            AddHandler dp.FetchCompleted, handler
            dp.BeginFetch(New CategoryCriteria())
        End Sub 

#end Region

#Region "Method Overrides"

        Protected Overrides Function AddNewCore() As Object
            Dim item As Category = PetShop.Tests.Collections.DynamicRoot.Category.NewCategory()
    
            Dim cancel As Boolean = False
            OnAddNewCore(item, cancel)
            If Not (cancel) Then
                ' Check to see if someone set the item to null In the OnAddNewCore.
                If(item Is Nothing) Then
                    item = PetShop.Tests.Collections.DynamicRoot.Category.NewCategory()
                End If
                
                Add(item)
            End If

            Return item
        End Function

#End Region

#Region "DataPortal partial methods"
    
        ''' <summary>
        ''' CodeSmith generated stub method that is called when creating the child <see cref="Category"/> object. 
        ''' </summary>
        ''' <param name="cancel">Value returned from the method indicating whether the object creation should proceed.</param>
        Partial Private Sub OnCreating(ByRef cancel As Boolean)
        End Sub

        ''' <summary>
        ''' CodeSmith generated stub method that is called after the child <see cref="Category"/> object has been created. 
        ''' </summary>
        Partial Private Sub OnCreated()
        End Sub

        ''' <summary>
        ''' CodeSmith generated stub method that is called when fetching the child <see cref="Category"/> object. 
        ''' </summary>
        ''' <param name="criteria"><see cref="CategoryCriteria"/> object containing the criteria of the object to fetch.</param>
        ''' <param name="cancel">Value returned from the method indicating whether the object fetching should proceed.</param>
        Partial Private Sub OnFetching(ByVal criteria As CategoryCriteria, ByRef cancel As Boolean)
        End Sub

        ''' <summary>
        ''' CodeSmith generated stub method that is called after the child <see cref="Category"/> object has been fetched. 
        ''' </summary>
        Partial Private Sub OnFetched()
        End Sub

        ''' <summary>
        ''' CodeSmith generated stub method that is called when mapping the child <see cref="Category"/> object. 
        ''' </summary>
        ''' <param name="cancel">Value returned from the method indicating whether the object mapping should proceed.</param>
        Partial Private Sub OnMapping(ByRef cancel As Boolean)
        End Sub

        ''' <summary>
        ''' CodeSmith generated stub method that is called when mapping the child <see cref="Category"/> object. 
        ''' </summary>
        ''' <param name="reader"></param>
        ''' <param name="cancel">Value returned from the method indicating whether the object mapping should proceed.</param>
        Partial Private Sub OnMapping(ByVal reader As SafeDataReader, ByRef cancel As Boolean)
        End Sub

        ''' <summary>
        ''' CodeSmith generated stub method that is called after the child <see cref="Category"/> object has been mapped. 
        ''' </summary>
        Partial Private Sub OnMapped()
        End Sub

        ''' <summary>
        ''' CodeSmith generated stub method that is called when updating the <see cref="Category"/> object. 
        ''' </summary>
        ''' <param name="cancel">Value returned from the method indicating whether the object creation should proceed.</param>
        Partial Private Sub OnUpdating(ByRef cancel As Boolean)
        End Sub

        ''' <summary>
        ''' CodeSmith generated stub method that is called after the <see cref="Category"/> object has been updated. 
        ''' </summary>
        Partial Private Sub OnUpdated()
        End Sub
        Partial Private Sub OnAddNewCore(ByRef item As Category, ByRef cancel As Boolean)
        End Sub
    
#End Region
#Region "Exists Command"

        ''' <summary>
        ''' Determines if a record exists in the Category in the database for the specified criteria. 
        ''' </summary>
        ''' <param name="criteria">The criteria parameter is a <see cref="CategoryList"/> object.</param>
        ''' <returns>A boolean value of true is returned if a record is found.</returns>
        Public Shared Function Exists(ByVal criteria As CategoryCriteria) As Boolean
            Return PetShop.Tests.Collections.DynamicRoot.Category.Exists(criteria)
        End Function

        ''' <summary>
        ''' Determines if a record exists in the Category in the database for the specified criteria. 
        ''' </summary>
        Public Shared Sub ExistsAsync(ByVal criteria As CategoryCriteria, ByVal handler As EventHandler(Of DataPortalResult(Of ExistsCommand)))
            PetShop.Tests.Collections.DynamicRoot.Category.ExistsAsync(criteria, handler)
        End Sub

#End Region
 
#region "Enhancements"

        Public Function GetCategory(ByVal categoryId As System.String) As Category
            Return Me.FirstOrDefault(Function(i As Category) i.CategoryId = categoryId)
        End Function
        
        Public Overloads Function Contains(ByVal categoryId As System.String) As Boolean
            Return Me.Where(Function(i As Category) i.CategoryId = categoryId).Count() > 0
        End Function
        
#End Region
    End Class
End Namespace