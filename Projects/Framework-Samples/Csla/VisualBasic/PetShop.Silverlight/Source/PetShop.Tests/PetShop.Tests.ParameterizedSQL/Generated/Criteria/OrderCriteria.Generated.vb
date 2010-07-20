﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.1855, CSLA Framework: v4.0.0.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'Order.vb.
'
'     Template: Criteria.Generated.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

#Region "Using declarations"

Imports System
Imports System.Collections.Generic
Imports System.Runtime.InteropServices

Imports System.Data.SqlClient

Imports Csla

#End Region

Namespace PetShop.Tests.ParameterizedSQL
    <Serializable(), ClassInterface(ClassInterfaceType.None)> _
    Public Partial Class OrderCriteria
        Inherits CriteriaBase(Of OrderCriteria)
        Implements IGeneratedCriteria
    
#Region "Private Read-Only Members"
        
        Private ReadOnly _bag As New Dictionary(Of String, Object)()
        
#End Region
    
#Region "Constructors"
    
        Public Sub New()
        
        End Sub
        
        Public Sub New(ByVal orderId As System.Int32) 
            
            
            Me.OrderId = orderId
        End Sub
    
#End Region
    
#Region "Public Properties"
        
#Region "Read-Write"
    
        
        Public Property OrderId() As System.Int32
            Get
                Return GetValue(Of System.Int32)("OrderId")
            End Get
            Set
                _bag("OrderId") = value
            End Set
        End Property
        
        Public Property UserId() As System.String
            Get
                Return GetValue(Of System.String)("UserId")
            End Get
            Set
                _bag("UserId") = value
            End Set
        End Property
        
        Public Property OrderDate() As System.DateTime
            Get
                Return GetValue(Of System.DateTime)("OrderDate")
            End Get
            Set
                _bag("OrderDate") = value
            End Set
        End Property
        
        Public Property ShipAddr1() As System.String
            Get
                Return GetValue(Of System.String)("ShipAddr1")
            End Get
            Set
                _bag("ShipAddr1") = value
            End Set
        End Property
        
        Public Property ShipAddr2() As System.String
            Get
                Return GetValue(Of System.String)("ShipAddr2")
            End Get
            Set
                _bag("ShipAddr2") = value
            End Set
        End Property
        
        Public Property ShipCity() As System.String
            Get
                Return GetValue(Of System.String)("ShipCity")
            End Get
            Set
                _bag("ShipCity") = value
            End Set
        End Property
        
        Public Property ShipState() As System.String
            Get
                Return GetValue(Of System.String)("ShipState")
            End Get
            Set
                _bag("ShipState") = value
            End Set
        End Property
        
        Public Property ShipZip() As System.String
            Get
                Return GetValue(Of System.String)("ShipZip")
            End Get
            Set
                _bag("ShipZip") = value
            End Set
        End Property
        
        Public Property ShipCountry() As System.String
            Get
                Return GetValue(Of System.String)("ShipCountry")
            End Get
            Set
                _bag("ShipCountry") = value
            End Set
        End Property
        
        Public Property BillAddr1() As System.String
            Get
                Return GetValue(Of System.String)("BillAddr1")
            End Get
            Set
                _bag("BillAddr1") = value
            End Set
        End Property
        
        Public Property BillAddr2() As System.String
            Get
                Return GetValue(Of System.String)("BillAddr2")
            End Get
            Set
                _bag("BillAddr2") = value
            End Set
        End Property
        
        Public Property BillCity() As System.String
            Get
                Return GetValue(Of System.String)("BillCity")
            End Get
            Set
                _bag("BillCity") = value
            End Set
        End Property
        
        Public Property BillState() As System.String
            Get
                Return GetValue(Of System.String)("BillState")
            End Get
            Set
                _bag("BillState") = value
            End Set
        End Property
        
        Public Property BillZip() As System.String
            Get
                Return GetValue(Of System.String)("BillZip")
            End Get
            Set
                _bag("BillZip") = value
            End Set
        End Property
        
        Public Property BillCountry() As System.String
            Get
                Return GetValue(Of System.String)("BillCountry")
            End Get
            Set
                _bag("BillCountry") = value
            End Set
        End Property
        
        Public Property Courier() As System.String
            Get
                Return GetValue(Of System.String)("Courier")
            End Get
            Set
                _bag("Courier") = value
            End Set
        End Property
        
        Public Property TotalPrice() As System.Decimal
            Get
                Return GetValue(Of System.Decimal)("TotalPrice")
            End Get
            Set
                _bag("TotalPrice") = value
            End Set
        End Property
        
        Public Property BillToFirstName() As System.String
            Get
                Return GetValue(Of System.String)("BillToFirstName")
            End Get
            Set
                _bag("BillToFirstName") = value
            End Set
        End Property
        
        Public Property BillToLastName() As System.String
            Get
                Return GetValue(Of System.String)("BillToLastName")
            End Get
            Set
                _bag("BillToLastName") = value
            End Set
        End Property
        
        Public Property ShipToFirstName() As System.String
            Get
                Return GetValue(Of System.String)("ShipToFirstName")
            End Get
            Set
                _bag("ShipToFirstName") = value
            End Set
        End Property
        
        Public Property ShipToLastName() As System.String
            Get
                Return GetValue(Of System.String)("ShipToLastName")
            End Get
            Set
                _bag("ShipToLastName") = value
            End Set
        End Property
        
        Public Property AuthorizationNumber() As System.Int32
            Get
                Return GetValue(Of System.Int32)("AuthorizationNumber")
            End Get
            Set
                _bag("AuthorizationNumber") = value
            End Set
        End Property
        
        Public Property Locale() As System.String
            Get
                Return GetValue(Of System.String)("Locale")
            End Get
            Set
                _bag("Locale") = value
            End Set
        End Property
    
#End Region
        
#Region "Read-Only"
    
        ''' <summary>
        ''' Returns a list of all the modified properties and values.
        ''' </summary>
        Public ReadOnly Property StateBag() As Dictionary(Of String, Object) Implements IGeneratedCriteria.StateBag
            Get
                Return _bag
            End Get
        End Property
    
        ''' <summary>
        ''' Returns a list of all the modified properties and values.
        ''' </summary>
        Public ReadOnly Property TableFullName() As String Implements IGeneratedCriteria.TableFullName
            Get
                Return "[dbo].Orders"
            End Get
        End Property
    
#End Region
    
#End Region
    
#Region "Overrides"
    
        Public Overrides Function ToString() As String
            Dim result As String = String.Empty
            Dim cancel As Boolean = False
            
            OnToString(result, cancel)
            If(cancel AndAlso Not String.IsNullOrEmpty(result)) Then
                Return result
            End If
        
            If _bag.Count = 0 Then
                Return "No criterion was specified."
            End If
    
            For Each key As KeyValuePair(Of String, Object) In _bag
                result += String.Format("[{0}] = '{1}' AND ", key.Key, key.Value)
            Next
    
            Return result.Remove(result.Length - 5, 5)
        End Function
    
#End Region
    
#Region "Private Methods"
        
        Private Function GetValue(Of T)(name As String) As T
            Dim value As New Object
            If _bag.TryGetValue(name, value) Then
                Return DirectCast(value, T)
            End If
        
            Return Nothing
        End Function
        
#End Region
        
#Region "Partial Methods"

        Partial Private Sub OnToString(ByRef result As String, ByRef cancel As Boolean)
        End Sub

#End Region

    End Class
End Namespace