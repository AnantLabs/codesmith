﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.0, CSLA Framework: v4.0.0.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'Category.vb.
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
Imports Csla.Data

Namespace PetShop.Tests.Collections.EditableRoot
    <Serializable()> _
    Public Partial Class Category
        Inherits BusinessBase(Of Category)
    
#Region "Contructor(s)"
    
        Private Sub New()
            ' require use of factory method 
        End Sub
    
        Friend Sub New(ByVal categoryId As System.String)
            Using(BypassPropertyChecks)
            LoadProperty(_categoryIdProperty, categoryId)
            End Using
        End Sub
    
        Friend Sub New(Byval reader As SafeDataReader)
            Map(reader)
        End Sub

#End Region    
    
#Region "Business Rules"
    
        Protected Overrides Sub AddBusinessRules()
    
            If AddBusinessValidationRules() Then Exit Sub
    
            BusinessRules.AddRule(New Csla.Rules.CommonRules.Required(_categoryIdProperty))
            BusinessRules.AddRule(New Csla.Rules.CommonRules.MaxLength(_categoryIdProperty, 10))
            BusinessRules.AddRule(New Csla.Rules.CommonRules.MaxLength(_nameProperty, 80))
            BusinessRules.AddRule(New Csla.Rules.CommonRules.MaxLength(_descriptionProperty, 255))
        End Sub
    
#End Region

#Region "Properties"
    
        Private Shared ReadOnly _categoryIdProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Category) p.CategoryId, String.Empty)
        
		<System.ComponentModel.DataObjectField(true, false)> _
        Public Property CategoryId() As System.String
            Get 
                Return GetProperty(_categoryIdProperty)
            End Get
            Set (ByVal value As System.String)
                SetProperty(_categoryIdProperty, value)
            End Set
        End Property

        Private Shared ReadOnly _originalCategoryIdProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Category) p.OriginalCategoryId, String.Empty)
        ''' <summary>
        ''' Holds the original value for CategoryId. This is used for non identity primary keys.
        ''' </summary>
        Friend Property OriginalCategoryId() As System.String
            Get 
                Return GetProperty(_originalCategoryIdProperty) 
            End Get
            Set (value As System.String)
                SetProperty(_originalCategoryIdProperty, value)
            End Set
        End Property

        Private Shared ReadOnly _nameProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Category) p.Name, String.Empty, vbNullString)
        
        Public Property Name() As System.String
            Get 
                Return GetProperty(_nameProperty)
            End Get
            Set (ByVal value As System.String)
                SetProperty(_nameProperty, value)
            End Set
        End Property

        Private Shared ReadOnly _descriptionProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Category) p.Description, String.Empty, vbNullString)
        
        Public Property Description() As System.String
            Get 
                Return GetProperty(_descriptionProperty)
            End Get
            Set (ByVal value As System.String)
                SetProperty(_descriptionProperty, value)
            End Set
        End Property

#End Region
    
#Region "Synchronous Factory Methods"
    
        Public Shared Function NewCategory() As Category
            Return DataPortal.Create(Of Category)()
        End Function
    
        Public Shared Function GetByCategoryId(ByVal categoryId As System.String) As Category
            Dim criteria As New CategoryCriteria()
            criteria.CategoryId = categoryId
            
            Return DataPortal.Fetch(Of Category)(criteria)
        End Function
    
        Public Shared Sub DeleteCategory(ByVal categoryId As System.String)
            DataPortal.Delete(Of Category)(New CategoryCriteria(categoryId))
        End Sub
    
#End Region
    
#Region "DataPortal partial methods"
    
        Partial Private Sub OnCreating(ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnCreated()
        End Sub
        Partial Private Sub OnFetching(ByVal criteria As CategoryCriteria, ByRef cancel As Boolean)
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
        Partial Private Sub OnDeleting(ByVal criteria As CategoryCriteria, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnDeleted()
        End Sub
    
#End Region

#Region "Exists Command"

        Public Shared Function Exists(ByVal criteria As CategoryCriteria ) As Boolean
            Return PetShop.Tests.Collections.EditableRoot.ExistsCommand.Execute(criteria)
        End Function

#End Region
    End Class
End Namespace
