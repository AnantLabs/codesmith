'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated Imports CSLA 3.7.X CodeSmith Templates.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'Account.vb.
'
'     Template: Criteria.Generated.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
'Option Strict On

#Region "Using declarations"

Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient

Imports Csla

#End Region

<Serializable()> _
Public Partial Class AccountCriteria
    Inherits CriteriaBase

    #Region "Private Read-Only Members"
    
    Private ReadOnly _bag As New Dictionary(Of String, Object)()
    
    #End Region
    
    #Region "Constructors"

    Public Sub New()
        MyBase.New(GetType(Account))
    End Sub
    
    Public Sub New(ByVal accountId As Integer) 
        MyBase.New(GetType(Account))
        
        AccountId = accountId
    End Sub

    
    #End Region
    
	#Region "Public Properties"
    
    #Region "Read-Write"
	
    Public Property UniqueID() As Integer
        Get
            Return GetValue(Of Integer)("UniqueID")
        End Get
        Set
            _bag("UniqueID") = value
        End Set
	End Property
	
    Public Property AccountId() As Integer
        Get
            Return GetValue(Of Integer)("AccountId")
        End Get
        Set
            _bag("AccountId") = value
        End Set
	End Property

    #End Region
    
    #Region "Read-Only"
    
    ''' <summary>
    ''' Returns a list of all the modified properties and values.
    ''' </summary>
    Public ReadOnly Property StateBag() As Dictionary(Of String, Object)
        Get
            Return _bag
        End Get
    End Property

    #End Region

    #End Region
    
    #Region "Private Methods"
    
    Private Function GetValue(Of T)(name As String) As T
        Dim value As T
        If _bag.TryGetValue(name, value) Then
            Return DirectCast(value, T)
        End If
    
        Return Nothing
    End Function
    
    #End Region

End Class