﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.1855, CSLA Framework: v4.0.0.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'OrderStatusList.vb.
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

Namespace PetShop.Tests.OF.ParameterizedSQL
    <Serializable()> _
    <Csla.Server.ObjectFactory(FactoryNames.OrderStatusListFactoryName)> _
    Public Partial Class OrderStatusList 
        Inherits BusinessListBase(Of OrderStatusList, OrderStatus)
    
#Region "Contructor(s)"
        
        Private Sub New()
            AllowNew = true
        End Sub
    
#End Region
    
#Region "Method Overrides"
    
        Protected Overrides Function AddNewCore() As OrderStatus
            Dim item As OrderStatus = PetShop.Tests.OF.ParameterizedSQL.OrderStatus.NewOrderStatus()

            Dim cancel As Boolean = False
            OnAddNewCore(item, cancel)
            If Not (cancel) Then
                ' Check to see if someone set the item to null in the OnAddNewCore.
                If(item Is Nothing) Then
                    item = PetShop.Tests.OF.ParameterizedSQL.OrderStatus.NewOrderStatus()
                End If
            ' Pass the parent value down to the child.
                'Dim order As Order = CType(Me.Parent, Order)
                'If Not(order Is Nothing)
                '    item.OrderId = order.OrderId
                'End If
                Add(item)
            End If

            Return item
        End Function
    
#End Region
    
#Region "Synchronous Factory Methods"
    
        Public Shared Function NewList() As OrderStatusList
            Return DataPortal.Create(Of OrderStatusList)()
        End Function
    
        Public Shared Function GetByOrderIdLineNum(ByVal orderId As System.Int32, ByVal lineNum As System.Int32) As OrderStatusList 
            Dim criteria As New OrderStatusCriteria()
            criteria.OrderId = orderId
			criteria.LineNum = lineNum
    
            Return DataPortal.Fetch(Of OrderStatusList)(criteria)
        End Function
    
        Public Shared Function GetByOrderId(ByVal orderId As System.Int32) As OrderStatusList 
            Dim criteria As New OrderStatusCriteria()
            criteria.OrderId = orderId
    
            Return DataPortal.Fetch(Of OrderStatusList)(criteria)
        End Function
    
        Public Shared Function GetAll() As OrderStatusList
            Return DataPortal.Fetch(Of OrderStatusList)(New OrderStatusCriteria())
        End Function
    
#End Region
    #Region "Property overrides"
    
            ''' <summary>
            ''' Returns true if any children are dirty
            ''' </summary>
            Public Shadows ReadOnly Property IsDirty() As Boolean
                Get
                    For Each item As OrderStatus In Me.Items
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
        Partial Private Sub OnFetching(ByVal criteria As OrderStatusCriteria, ByRef cancel As Boolean)
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
        Partial Private Sub OnAddNewCore(ByVal item As OrderStatus, ByRef cancel As Boolean)
        End Sub
    
#End Region

#Region "Exists Command"

        Public Shared Function Exists(ByVal criteria As OrderStatusCriteria) As Boolean
            Return PetShop.Tests.OF.ParameterizedSQL.OrderStatus.Exists(criteria)
        End Function

#End Region
    End Class
End Namespace