﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.0, CSLA Framework: v3.8.4.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'Category.vb.
'
'     Template: ReadOnlyChild.Generated.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System

Imports Csla
Imports Csla.Data
Imports System.Data.SqlClient

Namespace PetShop.Tests.Collections.ReadOnlyChild
    <Serializable()> _
    Public Partial Class CategoryInfo 
        Inherits ReadOnlyBase(Of CategoryInfo)
    
#Region "Contructor(s)"
 
        Private Sub New()
            ' require use of factory method 
        End Sub
    
        Friend Sub New(ByVal categoryId As System.String)
            LoadProperty(_categoryIdProperty, categoryId)
        End Sub
    
        Friend Sub New(Byval reader As SafeDataReader)
            Map(reader)
        End Sub

#End Region    

#Region "Properties"
    
        Private Shared ReadOnly _categoryIdProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As CategoryInfo) p.CategoryId, String.Empty)
        
		<System.ComponentModel.DataObjectField(true, false)> _
        Public Readonly Property CategoryId() As System.String
            Get 
                Return GetProperty(_categoryIdProperty)
            End Get
        End Property
        
        Private Shared ReadOnly _nameProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As CategoryInfo) p.Name, String.Empty, vbNullString)
        
        Public Readonly Property Name() As System.String
            Get 
                Return GetProperty(_nameProperty)
            End Get
        End Property
        
        Private Shared ReadOnly _descriptionProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As CategoryInfo) p.Description, String.Empty, vbNullString)
        
        Public Readonly Property Description() As System.String
            Get 
                Return GetProperty(_descriptionProperty)
            End Get
        End Property
        
#End Region
    
#Region "Synchronous Factory Methods" 
    
        Friend Shared Function GetByCategoryId(ByVal categoryId As System.String) As CategoryInfo
            Dim criteria As New CategoryCriteria()
            criteria.CategoryId = categoryId
    
            Return DataPortal.FetchChild(Of CategoryInfo)(criteria)
        End Function
        
#End Region

#Region "ChildPortal partial methods"
    
        Partial Private Sub OnChildCreating(ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnChildCreated()
        End Sub
        Partial Private Sub OnChildFetching(ByVal criteria As CategoryCriteria, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnChildFetched()
        End Sub
        Partial Private Sub OnMapping(ByVal reader As SafeDataReader, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnMapped()
        End Sub
        Partial Private Sub OnChildInserting(ByVal connection As SqlConnection, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnChildInserted()
        End Sub
        Partial Private Sub OnChildUpdating(ByVal connection As SqlConnection, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnChildUpdated()
        End Sub
        Partial Private Sub OnChildSelfDeleting(ByVal connection As SqlConnection, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnChildSelfDeleted()
        End Sub
        Partial Private Sub OnDeleting(ByVal criteria As CategoryCriteria, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnDeleting(ByVal criteria As CategoryCriteria, ByVal connection As SqlConnection, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnDeleted()
        End Sub
    
#End Region

#Region "Exists Command"

        Public Shared Function Exists(ByVal criteria As CategoryCriteria ) As Boolean
            Return PetShop.Tests.Collections.ReadOnlyChild.ExistsCommand.Execute(criteria)
        End Function

#End Region
    End Class
End Namespace