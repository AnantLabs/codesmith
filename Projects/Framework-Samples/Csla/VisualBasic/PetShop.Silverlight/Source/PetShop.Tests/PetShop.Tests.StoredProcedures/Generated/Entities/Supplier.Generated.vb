﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.0, CSLA Framework: v4.0.0.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'Supplier.vb.
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

Namespace PetShop.Tests.StoredProcedures
    <Serializable()> _
    Public Partial Class Supplier
        Inherits BusinessBase(Of Supplier)
    
#Region "Contructor(s)"
    
        Private Sub New()
            ' require use of factory method 
        End Sub
    
        Friend Sub New(ByVal suppId As System.Int32)
            Using(BypassPropertyChecks)
            LoadProperty(_suppIdProperty, suppId)
            End Using
        End Sub
    
        Friend Sub New(Byval reader As SafeDataReader)
            Map(reader)
        End Sub

#End Region    
    
#Region "Business Rules"
    
        Protected Overrides Sub AddBusinessRules()
    
            If AddBusinessValidationRules() Then Exit Sub
    
            BusinessRules.AddRule(New Csla.Rules.CommonRules.MaxLength(_nameProperty, 80))
            BusinessRules.AddRule(New Csla.Rules.CommonRules.Required(_statusProperty))
            BusinessRules.AddRule(New Csla.Rules.CommonRules.MaxLength(_statusProperty, 2))
            BusinessRules.AddRule(New Csla.Rules.CommonRules.MaxLength(_addr1Property, 80))
            BusinessRules.AddRule(New Csla.Rules.CommonRules.MaxLength(_addr2Property, 80))
            BusinessRules.AddRule(New Csla.Rules.CommonRules.MaxLength(_cityProperty, 80))
            BusinessRules.AddRule(New Csla.Rules.CommonRules.MaxLength(_stateProperty, 80))
            BusinessRules.AddRule(New Csla.Rules.CommonRules.MaxLength(_zipProperty, 5))
            BusinessRules.AddRule(New Csla.Rules.CommonRules.MaxLength(_phoneProperty, 40))
        End Sub
    
#End Region

#Region "Properties"
    
        Private Shared ReadOnly _suppIdProperty As PropertyInfo(Of System.Int32) = RegisterProperty(Of System.Int32)(Function(p As Supplier) p.SuppId, String.Empty)
        
		<System.ComponentModel.DataObjectField(true, false)> _
        Public Property SuppId() As System.Int32
            Get 
                Return GetProperty(_suppIdProperty)
            End Get
            Set (ByVal value As System.Int32)
                SetProperty(_suppIdProperty, value)
            End Set
        End Property

        Private Shared ReadOnly _originalSuppIdProperty As PropertyInfo(Of System.Int32) = RegisterProperty(Of System.Int32)(Function(p As Supplier) p.OriginalSuppId, String.Empty)
        ''' <summary>
        ''' Holds the original value for SuppId. This is used for non identity primary keys.
        ''' </summary>
        Friend Property OriginalSuppId() As System.Int32
            Get 
                Return GetProperty(_originalSuppIdProperty) 
            End Get
            Set (value As System.Int32)
                SetProperty(_originalSuppIdProperty, value)
            End Set
        End Property

        Private Shared ReadOnly _nameProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Supplier) p.Name, String.Empty, vbNullString)
        
        Public Property Name() As System.String
            Get 
                Return GetProperty(_nameProperty)
            End Get
            Set (ByVal value As System.String)
                SetProperty(_nameProperty, value)
            End Set
        End Property

        Private Shared ReadOnly _statusProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Supplier) p.Status, String.Empty)
        
        Public Property Status() As System.String
            Get 
                Return GetProperty(_statusProperty)
            End Get
            Set (ByVal value As System.String)
                SetProperty(_statusProperty, value)
            End Set
        End Property

        Private Shared ReadOnly _addr1Property As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Supplier) p.Addr1, String.Empty, vbNullString)
        
        Public Property Addr1() As System.String
            Get 
                Return GetProperty(_addr1Property)
            End Get
            Set (ByVal value As System.String)
                SetProperty(_addr1Property, value)
            End Set
        End Property

        Private Shared ReadOnly _addr2Property As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Supplier) p.Addr2, String.Empty, vbNullString)
        
        Public Property Addr2() As System.String
            Get 
                Return GetProperty(_addr2Property)
            End Get
            Set (ByVal value As System.String)
                SetProperty(_addr2Property, value)
            End Set
        End Property

        Private Shared ReadOnly _cityProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Supplier) p.City, String.Empty, vbNullString)
        
        Public Property City() As System.String
            Get 
                Return GetProperty(_cityProperty)
            End Get
            Set (ByVal value As System.String)
                SetProperty(_cityProperty, value)
            End Set
        End Property

        Private Shared ReadOnly _stateProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Supplier) p.State, String.Empty, vbNullString)
        
        Public Property State() As System.String
            Get 
                Return GetProperty(_stateProperty)
            End Get
            Set (ByVal value As System.String)
                SetProperty(_stateProperty, value)
            End Set
        End Property

        Private Shared ReadOnly _zipProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Supplier) p.Zip, String.Empty, vbNullString)
        
        Public Property Zip() As System.String
            Get 
                Return GetProperty(_zipProperty)
            End Get
            Set (ByVal value As System.String)
                SetProperty(_zipProperty, value)
            End Set
        End Property

        Private Shared ReadOnly _phoneProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Supplier) p.Phone, String.Empty, vbNullString)
        
        Public Property Phone() As System.String
            Get 
                Return GetProperty(_phoneProperty)
            End Get
            Set (ByVal value As System.String)
                SetProperty(_phoneProperty, value)
            End Set
        End Property

        'AssociatedOneToMany
        Private Shared ReadOnly _itemsProperty As PropertyInfo(Of ItemList) = RegisterProperty(Of ItemList)(Function(p As Supplier) p.Items, Csla.RelationshipTypes.Child)
    Public ReadOnly Property Items() As ItemList
            Get
                If Not (FieldManager.FieldExists(_itemsProperty)) Then
                    Dim criteria As New PetShop.Tests.StoredProcedures.ItemCriteria()
                    criteria.Supplier = SuppId
    
                    If (Me.IsNew OrElse Not PetShop.Tests.StoredProcedures.ItemList.Exists(criteria)) Then
                        LoadProperty(_itemsProperty, PetShop.Tests.StoredProcedures.ItemList.NewList())
                    Else
                        LoadProperty(_itemsProperty, PetShop.Tests.StoredProcedures.ItemList.GetBySupplier(SuppId))
                    End If
                End If
                
                Return GetProperty(_itemsProperty) 
            End Get
        End Property

#End Region
    
#Region "Synchronous Factory Methods"
    
        Public Shared Function NewSupplier() As Supplier
            Return DataPortal.Create(Of Supplier)()
        End Function
    
        Public Shared Function GetBySuppId(ByVal suppId As System.Int32) As Supplier
            Dim criteria As New SupplierCriteria()
            criteria.SuppId = suppId
            
            Return DataPortal.Fetch(Of Supplier)(criteria)
        End Function
    
        Public Shared Sub DeleteSupplier(ByVal suppId As System.Int32)
            DataPortal.Delete(Of Supplier)(New SupplierCriteria(suppId))
        End Sub
    
#End Region
    
#Region "DataPortal partial methods"
    
        Partial Private Sub OnCreating(ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnCreated()
        End Sub
        Partial Private Sub OnFetching(ByVal criteria As SupplierCriteria, ByRef cancel As Boolean)
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
        Partial Private Sub OnDeleting(ByVal criteria As SupplierCriteria, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnDeleted()
        End Sub
    
#End Region

#Region "Exists Command"

        Public Shared Function Exists(ByVal criteria As SupplierCriteria ) As Boolean
            Return PetShop.Tests.StoredProcedures.ExistsCommand.Execute(criteria)
        End Function

#End Region
    End Class
End Namespace
