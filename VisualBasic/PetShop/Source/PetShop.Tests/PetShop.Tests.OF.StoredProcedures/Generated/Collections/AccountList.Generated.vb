﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v6.5.0, CSLA Templates: v4.0.0.0, CSLA Framework: v4.3.10.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'AccountList.vb.
'
'     Template: EditableChildList.Generated.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.Linq

Imports Csla
Imports Csla.Data

Namespace PetShop.Tests.OF.StoredProcedures
    <Serializable()> _
    <Csla.Server.ObjectFactory(FactoryNames.AccountListFactoryName)> _
    Public Partial Class AccountList 
        Inherits BusinessListBase(Of AccountList, Account)
    
#Region "Contructor(s)"

        public Sub New()
            AllowNew = true
            MarkAsChild()
        End Sub
    
#End Region

#Region "Synchronous Factory Methods" 

        ''' <summary>
        ''' Creates a new object of type <see cref="AccountList"/>. 
        ''' </summary>
        ''' <returns>Returns a newly instantiated collection of type <see cref="AccountList"/>.</returns>
        Friend Shared Function NewList() As AccountList
            Return DataPortal.CreateChild(Of AccountList)()
        End Function

        ''' <summary>
        ''' Returns a <see cref="AccountList"/> object of the specified criteria. 
        ''' </summary>
        ''' <param name="accountId">No additional detail available.</param>
        ''' <returns>A <see cref="AccountList"/> object of the specified criteria.</returns>
        Friend Shared Function GetByAccountId(ByVal accountId As System.Int32) As AccountList 
            Dim criteria As New AccountCriteria()
                        criteria.AccountId = accountId
    
            Return DataPortal.Fetch(Of AccountList)(criteria)
        End Function

        ''' <summary>
        ''' Returns a <see cref="AccountList"/> object of the specified criteria. 
        ''' </summary>
        ''' <param name="uniqueID">No additional detail available.</param>
        ''' <returns>A <see cref="AccountList"/> object of the specified criteria.</returns>
        Friend Shared Function GetByUniqueID(ByVal uniqueID As System.Int32) As AccountList 
            Dim criteria As New AccountCriteria()
                        criteria.UniqueID = uniqueID
    
            Return DataPortal.Fetch(Of AccountList)(criteria)
        End Function

        Friend Shared Function GetByCriteria(ByVal criteria As AccountCriteria) As AccountList
            Return DataPortal.Fetch(Of AccountList)(criteria)
        End Function

        Friend Shared Function GetAll() As AccountList
            Return DataPortal.Fetch(Of AccountList)(New AccountCriteria())
        End Function

#End Region
    
#Region "Asynchronous Factory Methods"

        Friend Shared Sub NewListAsync(ByVal handler As EventHandler(Of DataPortalResult(Of AccountList)))
            Dim dp As New DataPortal(Of AccountList)()
            AddHandler dp.CreateCompleted, handler
            dp.BeginCreate()
        End Sub
    
        Friend Shared Sub GetByAccountIdAsync(ByVal accountId As System.Int32, ByVal handler As EventHandler(Of DataPortalResult(Of AsyncChildLoader(Of AccountList))))
            Dim criteria As New AccountCriteria()
                        criteria.AccountId = accountId

            DataPortal.BeginFetch(Of AsyncChildLoader(Of AccountList))(criteria, handler)
        End Sub
    
        Friend Shared Sub GetByUniqueIDAsync(ByVal uniqueID As System.Int32, ByVal handler As EventHandler(Of DataPortalResult(Of AsyncChildLoader(Of AccountList))))
            Dim criteria As New AccountCriteria()
                        criteria.UniqueID = uniqueID

            DataPortal.BeginFetch(Of AsyncChildLoader(Of AccountList))(criteria, handler)
        End Sub

        Friend Shared Sub GetByCriteriaAsync(ByVal criteria As AccountCriteria, ByVal handler As EventHandler(Of DataPortalResult(Of AccountList)))
            Dim dp As New DataPortal(Of AccountList)()
            AddHandler dp.FetchCompleted, handler

            ' Mark as child?
            dp.BeginFetch(criteria)
        End Sub

        Friend Shared Sub GetAllAsync(ByVal handler As EventHandler(Of DataPortalResult(Of AsyncChildLoader(Of AccountList))))
            DataPortal.BeginFetch(Of AsyncChildLoader(Of AccountList))(New AccountCriteria(), handler)
        End Sub 

#End Region
    
#Region "Method Overrides"
    
        Protected Overrides Function AddNewCore() As Account
            Dim item As Account = PetShop.Tests.OF.StoredProcedures.Account.NewAccount()

            Dim cancel As Boolean = False
            OnAddNewCore(item, cancel)
            If Not (cancel) Then
                ' Check to see if someone set the item to null In the OnAddNewCore.
                If(item Is Nothing) Then
                    item = PetShop.Tests.OF.StoredProcedures.Account.NewAccount()
                End If
            ' Pass the parent value down to the child.
                'Dim profile As Profile = CType(Me.Parent, Profile)
                'If Not(profile Is Nothing)
                '    item.UniqueID = profile.UniqueID
                'End If
                Add(item)
            End If

            Return item
        End Function
#End Region

        Protected Sub AddNewCoreAsync(ByVal handler As EventHandler(Of DataPortalResult(Of Account)))
            PetShop.Tests.OF.StoredProcedures.Account.NewAccountAsync(Sub(o, e)
                    If e.Error Is Nothing Then
                        Add(e.Object)
                        handler.Invoke(Me, New DataPortalResult(Of Account)(e.Object, Nothing, Nothing))
                    End If
                End Sub)
        End Sub

#Region "Property overrides"
    
            ''' <summary>
            ''' Returns true if any children are dirty
            ''' </summary>
            Public Shadows ReadOnly Property IsDirty() As Boolean
                Get
                    For Each item As Account In Me.Items
                        If item.IsDirty Then
                            Return True
                        End If
                    Next
            
                    Return False
                End Get
            End Property
    
#End Region
    
#Region "DataPortal partial methods"
    
        ''' <summary>
        ''' CodeSmith generated stub method that is called when creating the child <see cref="Account"/> object. 
        ''' </summary>
        ''' <param name="cancel">Value returned from the method indicating whether the object creation should proceed.</param>
        Partial Private Sub OnCreating(ByRef cancel As Boolean)
        End Sub

        ''' <summary>
        ''' CodeSmith generated stub method that is called after the child <see cref="Account"/> object has been created. 
        ''' </summary>
        Partial Private Sub OnCreated()
        End Sub

        ''' <summary>
        ''' CodeSmith generated stub method that is called when fetching the child <see cref="Account"/> object. 
        ''' </summary>
        ''' <param name="criteria"><see cref="AccountCriteria"/> object containing the criteria of the object to fetch.</param>
        ''' <param name="cancel">Value returned from the method indicating whether the object fetching should proceed.</param>
        Partial Private Sub OnFetching(ByVal criteria As AccountCriteria, ByRef cancel As Boolean)
        End Sub

        ''' <summary>
        ''' CodeSmith generated stub method that is called after the child <see cref="Account"/> object has been fetched. 
        ''' </summary>
        Partial Private Sub OnFetched()
        End Sub

        ''' <summary>
        ''' CodeSmith generated stub method that is called when mapping the child <see cref="Account"/> object. 
        ''' </summary>
        ''' <param name="cancel">Value returned from the method indicating whether the object mapping should proceed.</param>
        Partial Private Sub OnMapping(ByRef cancel As Boolean)
        End Sub

        ''' <summary>
        ''' CodeSmith generated stub method that is called when mapping the child <see cref="Account"/> object. 
        ''' </summary>
        ''' <param name="reader"></param>
        ''' <param name="cancel">Value returned from the method indicating whether the object mapping should proceed.</param>
        Partial Private Sub OnMapping(ByVal reader As SafeDataReader, ByRef cancel As Boolean)
        End Sub

        ''' <summary>
        ''' CodeSmith generated stub method that is called after the child <see cref="Account"/> object has been mapped. 
        ''' </summary>
        Partial Private Sub OnMapped()
        End Sub

        ''' <summary>
        ''' CodeSmith generated stub method that is called when updating the <see cref="Account"/> object. 
        ''' </summary>
        ''' <param name="cancel">Value returned from the method indicating whether the object creation should proceed.</param>
        Partial Private Sub OnUpdating(ByRef cancel As Boolean)
        End Sub

        ''' <summary>
        ''' CodeSmith generated stub method that is called after the <see cref="Account"/> object has been updated. 
        ''' </summary>
        Partial Private Sub OnUpdated()
        End Sub
        Partial Private Sub OnAddNewCore(ByRef item As Account, ByRef cancel As Boolean)
        End Sub
    
#End Region
#Region "Exists Command"

        ''' <summary>
        ''' Determines if a record exists in the Account in the database for the specified criteria. 
        ''' </summary>
        ''' <param name="criteria">The criteria parameter is a <see cref="AccountList"/> object.</param>
        ''' <returns>A boolean value of true is returned if a record is found.</returns>
        Public Shared Function Exists(ByVal criteria As AccountCriteria) As Boolean
            Return PetShop.Tests.OF.StoredProcedures.Account.Exists(criteria)
        End Function

        ''' <summary>
        ''' Determines if a record exists in the Account in the database for the specified criteria. 
        ''' </summary>
        Public Shared Sub ExistsAsync(ByVal criteria As AccountCriteria, ByVal handler As EventHandler(Of DataPortalResult(Of ExistsCommand)))
            PetShop.Tests.OF.StoredProcedures.Account.ExistsAsync(criteria, handler)
        End Sub

#End Region
 
#region "Enhancements"

        Public Function GetAccount(ByVal accountId As System.Int32) As Account
            Return Me.FirstOrDefault(Function(i As Account) i.AccountId = accountId)
        End Function
        
        Public Overloads Function Contains(ByVal accountId As System.Int32) As Boolean
            Return Me.Where(Function(i As Account) i.AccountId = accountId).Count() > 0
        End Function

        Public Overloads Function ContainsDeleted(ByVal accountId As System.Int32) As Boolean
            Return DeletedList.Where(Function(i As Account) i.AccountId = accountId).Count() > 0
        End Function

        Public Overloads Sub Remove(ByVal accountId As System.Int32)
            Dim item As Account = Me.FirstOrDefault(Function(i As Account) i.AccountId = accountId)
            If item IsNot Nothing Then
                Remove(item)
            End If
        End Sub
        
#End Region
    End Class
End Namespace