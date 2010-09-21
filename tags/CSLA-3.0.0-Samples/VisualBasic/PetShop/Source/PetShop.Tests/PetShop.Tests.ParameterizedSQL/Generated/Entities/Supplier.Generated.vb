﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.0, CSLA Framework: v3.8.4.
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
Imports Csla.Validation
Imports Csla.Data

Namespace PetShop.Tests.ParameterizedSQL
    <Serializable()> _
    Public Partial Class Supplier
        Inherits BusinessBase(Of Supplier)
    
#Region "Contructor(s)"
    
        Private Sub New()
            ' require use of factory method 
        End Sub
    
        Friend Sub New(ByVal suppId As System.Int32)
            Using(BypassPropertyChecks)
                _suppId = suppId
            End Using
        End Sub
    
        Friend Sub New(Byval reader As SafeDataReader)
            Map(reader)
        End Sub

#End Region    
    
#Region "Business Rules"
    
        Protected Overrides Sub AddBusinessRules()
    
            If AddBusinessValidationRules() Then Exit Sub
    
            ValidationRules.AddRule(AddressOf CommonRules.StringMaxLength, New CommonRules.MaxLengthRuleArgs(_nameProperty, 80))
            ValidationRules.AddRule(AddressOf CommonRules.StringRequired, _statusProperty)
            ValidationRules.AddRule(AddressOf CommonRules.StringMaxLength, New CommonRules.MaxLengthRuleArgs(_statusProperty, 2))
            ValidationRules.AddRule(AddressOf CommonRules.StringMaxLength, New CommonRules.MaxLengthRuleArgs(_addr1Property, 80))
            ValidationRules.AddRule(AddressOf CommonRules.StringMaxLength, New CommonRules.MaxLengthRuleArgs(_addr2Property, 80))
            ValidationRules.AddRule(AddressOf CommonRules.StringMaxLength, New CommonRules.MaxLengthRuleArgs(_cityProperty, 80))
            ValidationRules.AddRule(AddressOf CommonRules.StringMaxLength, New CommonRules.MaxLengthRuleArgs(_stateProperty, 80))
            ValidationRules.AddRule(AddressOf CommonRules.StringMaxLength, New CommonRules.MaxLengthRuleArgs(_zipProperty, 5))
            ValidationRules.AddRule(AddressOf CommonRules.StringMaxLength, New CommonRules.MaxLengthRuleArgs(_phoneProperty, 40))
        End Sub
    
#End Region

#Region "Properties"
    
        Private Shared ReadOnly _suppIdProperty As PropertyInfo(Of System.Int32) = RegisterProperty(Of System.Int32)(Function(p As Supplier) p.SuppId, String.Empty)
        Private _suppId As System.Int32 = _suppIdProperty.DefaultValue
        
		<System.ComponentModel.DataObjectField(true, false)> _
        Public Property SuppId() As System.Int32
            Get 
                Return GetProperty(_suppIdProperty, _suppId) 
            End Get
            Set (value As System.Int32)
                SetProperty(_suppIdProperty, _suppId, value)
            End Set
        End Property

        Private Shared ReadOnly _originalSuppIdProperty As PropertyInfo(Of System.Int32) = RegisterProperty(Of System.Int32)(Function(p As Supplier) p.OriginalSuppId, String.Empty)
        Private _originalSuppId As System.Int32 = _originalSuppIdProperty.DefaultValue
        ''' <summary>
        ''' Holds the original value for SuppId. This is used for non identity primary keys.
        ''' </summary>
        Friend Property OriginalSuppId() As System.Int32
            Get 
                Return GetProperty(_originalSuppIdProperty, _originalSuppId) 
            End Get
            Set (value As System.Int32)
                SetProperty(_originalSuppIdProperty, _originalSuppId, value)
            End Set
        End Property

        Private Shared ReadOnly _nameProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Supplier) p.Name, String.Empty, vbNullString)
        Private _name As System.String = _nameProperty.DefaultValue
        
        Public Property Name() As System.String
            Get 
                Return GetProperty(_nameProperty, _name) 
            End Get
            Set (value As System.String)
                SetProperty(_nameProperty, _name, value)
            End Set
        End Property

        Private Shared ReadOnly _statusProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Supplier) p.Status, String.Empty)
        Private _status As System.String = _statusProperty.DefaultValue
        
        Public Property Status() As System.String
            Get 
                Return GetProperty(_statusProperty, _status) 
            End Get
            Set (value As System.String)
                SetProperty(_statusProperty, _status, value)
            End Set
        End Property

        Private Shared ReadOnly _addr1Property As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Supplier) p.Addr1, String.Empty, vbNullString)
        Private _addr1 As System.String = _addr1Property.DefaultValue
        
        Public Property Addr1() As System.String
            Get 
                Return GetProperty(_addr1Property, _addr1) 
            End Get
            Set (value As System.String)
                SetProperty(_addr1Property, _addr1, value)
            End Set
        End Property

        Private Shared ReadOnly _addr2Property As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Supplier) p.Addr2, String.Empty, vbNullString)
        Private _addr2 As System.String = _addr2Property.DefaultValue
        
        Public Property Addr2() As System.String
            Get 
                Return GetProperty(_addr2Property, _addr2) 
            End Get
            Set (value As System.String)
                SetProperty(_addr2Property, _addr2, value)
            End Set
        End Property

        Private Shared ReadOnly _cityProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Supplier) p.City, String.Empty, vbNullString)
        Private _city As System.String = _cityProperty.DefaultValue
        
        Public Property City() As System.String
            Get 
                Return GetProperty(_cityProperty, _city) 
            End Get
            Set (value As System.String)
                SetProperty(_cityProperty, _city, value)
            End Set
        End Property

        Private Shared ReadOnly _stateProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Supplier) p.State, String.Empty, vbNullString)
        Private _state As System.String = _stateProperty.DefaultValue
        
        Public Property State() As System.String
            Get 
                Return GetProperty(_stateProperty, _state) 
            End Get
            Set (value As System.String)
                SetProperty(_stateProperty, _state, value)
            End Set
        End Property

        Private Shared ReadOnly _zipProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Supplier) p.Zip, String.Empty, vbNullString)
        Private _zip As System.String = _zipProperty.DefaultValue
        
        Public Property Zip() As System.String
            Get 
                Return GetProperty(_zipProperty, _zip) 
            End Get
            Set (value As System.String)
                SetProperty(_zipProperty, _zip, value)
            End Set
        End Property

        Private Shared ReadOnly _phoneProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Supplier) p.Phone, String.Empty, vbNullString)
        Private _phone As System.String = _phoneProperty.DefaultValue
        
        Public Property Phone() As System.String
            Get 
                Return GetProperty(_phoneProperty, _phone) 
            End Get
            Set (value As System.String)
                SetProperty(_phoneProperty, _phone, value)
            End Set
        End Property

        'AssociatedOneToMany
        Private Shared ReadOnly _itemsProperty As PropertyInfo(Of ItemList) = RegisterProperty(Of ItemList)(Function(p As Supplier) p.Items, Csla.RelationshipTypes.Child)
    Public ReadOnly Property Items() As ItemList
            Get
                If Not (FieldManager.FieldExists(_itemsProperty)) Then
                    Dim criteria As New PetShop.Tests.ParameterizedSQL.ItemCriteria()
                    criteria.Supplier = SuppId
    
                    If (Me.IsNew OrElse Not PetShop.Tests.ParameterizedSQL.ItemList.Exists(criteria)) Then
                        LoadProperty(_itemsProperty, PetShop.Tests.ParameterizedSQL.ItemList.NewList())
                    Else
                        LoadProperty(_itemsProperty, PetShop.Tests.ParameterizedSQL.ItemList.GetBySupplier(SuppId))
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
            DataPortal.Delete(New SupplierCriteria(suppId))
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
            Return PetShop.Tests.ParameterizedSQL.ExistsCommand.Execute(criteria)
        End Function

#End Region
    End Class
End Namespace
