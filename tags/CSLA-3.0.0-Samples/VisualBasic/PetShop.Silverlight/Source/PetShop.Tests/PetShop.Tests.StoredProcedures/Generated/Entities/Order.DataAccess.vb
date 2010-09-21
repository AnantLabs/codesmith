﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.0, CSLA Framework: v4.0.0.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'Order.vb.
'
'     Template: SwitchableObject.DataAccess.StoredProcedures.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq

Imports Csla
Imports Csla.Data

Namespace PetShop.Tests.StoredProcedures
    Public Partial Class Order
    
#Region "Root Data Access"
    
        <RunLocal()> _
        Protected Overrides Sub DataPortal_Create()
            Dim cancel As Boolean = False
            OnCreating(cancel)
            If (cancel) Then
                Return
            End If
    
            BusinessRules.CheckRules()
    
            OnCreated()
        End Sub
    
        Private Shadows Sub DataPortal_Fetch(ByVal criteria As OrderCriteria )
            Dim cancel As Boolean = False
            OnFetching(criteria, cancel)
            If (cancel) Then
                Return
            End If
    
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("[dbo].[CSLA_Order_Select]", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                    command.Parameters.AddWithValue("@p_ShipAddr2HasValue", criteria.ShipAddr2HasValue)
					command.Parameters.AddWithValue("@p_BillAddr2HasValue", criteria.BillAddr2HasValue)
                    Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                        If reader.Read() Then
                            Map(reader)
                        Else
                            Throw New Exception(String.Format("The record was not found in 'Orders' using the following criteria: {0}.", criteria))
                        End If
                    End Using
                End Using
            End Using
    
            OnFetched()
        End Sub
    
        <Transactional(TransactionalTypes.TransactionScope)> _
        Protected Overrides Sub DataPortal_Insert()
            Dim cancel As Boolean = False
            OnInserting(cancel)
            If (cancel) Then
                Return
            End If
    
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("[dbo].[CSLA_Order_Insert]", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@p_OrderId", Me.OrderId)
				command.Parameters("@p_OrderId").Direction = ParameterDirection.Output
				command.Parameters.AddWithValue("@p_UserId", Me.UserId)
				command.Parameters.AddWithValue("@p_OrderDate", Me.OrderDate)
				command.Parameters.AddWithValue("@p_ShipAddr1", Me.ShipAddr1)
				command.Parameters.AddWithValue("@p_ShipAddr2", ADOHelper.NullCheck(Me.ShipAddr2))
				command.Parameters.AddWithValue("@p_ShipCity", Me.ShipCity)
				command.Parameters.AddWithValue("@p_ShipState", Me.ShipState)
				command.Parameters.AddWithValue("@p_ShipZip", Me.ShipZip)
				command.Parameters.AddWithValue("@p_ShipCountry", Me.ShipCountry)
				command.Parameters.AddWithValue("@p_BillAddr1", Me.BillAddr1)
				command.Parameters.AddWithValue("@p_BillAddr2", ADOHelper.NullCheck(Me.BillAddr2))
				command.Parameters.AddWithValue("@p_BillCity", Me.BillCity)
				command.Parameters.AddWithValue("@p_BillState", Me.BillState)
				command.Parameters.AddWithValue("@p_BillZip", Me.BillZip)
				command.Parameters.AddWithValue("@p_BillCountry", Me.BillCountry)
				command.Parameters.AddWithValue("@p_Courier", Me.Courier)
				command.Parameters.AddWithValue("@p_TotalPrice", Me.TotalPrice)
				command.Parameters.AddWithValue("@p_BillToFirstName", Me.BillToFirstName)
				command.Parameters.AddWithValue("@p_BillToLastName", Me.BillToLastName)
				command.Parameters.AddWithValue("@p_ShipToFirstName", Me.ShipToFirstName)
				command.Parameters.AddWithValue("@p_ShipToLastName", Me.ShipToLastName)
				command.Parameters.AddWithValue("@p_AuthorizationNumber", Me.AuthorizationNumber)
				command.Parameters.AddWithValue("@p_Locale", Me.Locale)
    
                    command.ExecuteNonQuery()
    
                    Using (BypassPropertyChecks)
                        LoadProperty(_orderIdProperty, DirectCast(command.Parameters("@p_OrderId").Value,System.Int32))
                    End Using
                End Using
                
    
                FieldManager.UpdateChildren(Me, connection)
            End Using
    
            OnInserted()
        End Sub
    
        <Transactional(TransactionalTypes.TransactionScope)> _
        Protected Overrides Sub DataPortal_Update()
            Dim cancel As Boolean = False
            OnUpdating(cancel)
            If (cancel) Then
                Return
            End If
    
    
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("[dbo].[CSLA_Order_Update]", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@p_OrderId", Me.OrderId)
				command.Parameters.AddWithValue("@p_UserId", Me.UserId)
				command.Parameters.AddWithValue("@p_OrderDate", Me.OrderDate)
				command.Parameters.AddWithValue("@p_ShipAddr1", Me.ShipAddr1)
				command.Parameters.AddWithValue("@p_ShipAddr2", ADOHelper.NullCheck(Me.ShipAddr2))
				command.Parameters.AddWithValue("@p_ShipCity", Me.ShipCity)
				command.Parameters.AddWithValue("@p_ShipState", Me.ShipState)
				command.Parameters.AddWithValue("@p_ShipZip", Me.ShipZip)
				command.Parameters.AddWithValue("@p_ShipCountry", Me.ShipCountry)
				command.Parameters.AddWithValue("@p_BillAddr1", Me.BillAddr1)
				command.Parameters.AddWithValue("@p_BillAddr2", ADOHelper.NullCheck(Me.BillAddr2))
				command.Parameters.AddWithValue("@p_BillCity", Me.BillCity)
				command.Parameters.AddWithValue("@p_BillState", Me.BillState)
				command.Parameters.AddWithValue("@p_BillZip", Me.BillZip)
				command.Parameters.AddWithValue("@p_BillCountry", Me.BillCountry)
				command.Parameters.AddWithValue("@p_Courier", Me.Courier)
				command.Parameters.AddWithValue("@p_TotalPrice", Me.TotalPrice)
				command.Parameters.AddWithValue("@p_BillToFirstName", Me.BillToFirstName)
				command.Parameters.AddWithValue("@p_BillToLastName", Me.BillToLastName)
				command.Parameters.AddWithValue("@p_ShipToFirstName", Me.ShipToFirstName)
				command.Parameters.AddWithValue("@p_ShipToLastName", Me.ShipToLastName)
				command.Parameters.AddWithValue("@p_AuthorizationNumber", Me.AuthorizationNumber)
				command.Parameters.AddWithValue("@p_Locale", Me.Locale)
    
                    'result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    Dim result As Integer = command.ExecuteNonQuery()
                    If (result = 0) Then
                        throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                    End If
    
                End Using
    
                FieldManager.UpdateChildren(Me, connection)
            End Using
    
            OnUpdated()
        End Sub
    
        Protected Overrides Sub DataPortal_DeleteSelf()
            Dim cancel As Boolean = False
            OnSelfDeleting(cancel)
            If (cancel) Then
                Return
            End If
        
            DataPortal_Delete(New OrderCriteria (OrderId))
        
            OnSelfDeleted()
        End Sub
    
        <Transactional(TransactionalTypes.TransactionScope)> _
        Protected Shadows Sub DataPortal_Delete(ByVal criteria As OrderCriteria )
            Dim cancel As Boolean = False
            OnDeleting(criteria, cancel)
            If (cancel) Then
                Return
            End If
    
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("[dbo].[CSLA_Order_Delete]", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
    
                    'result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    Dim result As Integer = command.ExecuteNonQuery()
                    If (result = 0) Then
                        Throw New DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                    End If
                End Using
            End Using
    
            OnDeleted()
        End Sub
    
        '<Transactional(TransactionalTypes.TransactionScope)> _
        Protected Shadows Sub DataPortal_Delete(ByVal criteria As OrderCriteria, ByVal connection As SqlConnection)
            Dim cancel As Boolean = False
            OnDeleting(criteria, cancel)
            If (cancel) Then
                Return
            End If
    
            Using command As New SqlCommand("[dbo].[CSLA_Order_Delete]", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
    
                'result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                Dim result As Integer = command.ExecuteNonQuery()
                If (result = 0) Then
                    Throw New DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                End If
            End Using
    
            OnDeleted()
        End Sub
    
#End Region
    
#Region "Child Data Access"
    
        <RunLocal()> _
        Protected Overrides Sub Child_Create()
            Dim cancel As Boolean = False
            OnChildCreating(cancel)
            If (cancel) Then
                Return
            End If
    
            BusinessRules.CheckRules()
    
            OnChildCreated()
        End Sub
        
        Private Sub Child_Fetch(ByVal criteria As OrderCriteria)
            Dim cancel As Boolean = False
            OnChildFetching(criteria, cancel)
            If (cancel) Then
                Return
            End If
    
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("[dbo].[CSLA_Order_Select]", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                    command.Parameters.AddWithValue("@p_ShipAddr2HasValue", criteria.ShipAddr2HasValue)
					command.Parameters.AddWithValue("@p_BillAddr2HasValue", criteria.BillAddr2HasValue)
                    Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                        If reader.Read() Then
                            Map(reader)
                        Else
                            Throw New Exception(String.Format("The record was not found in 'Orders' using the following criteria: {0}.", criteria))
                        End If
                    End Using
                End Using
            End Using
    
            OnChildFetched()
            MarkAsChild()
        End Sub
    
#Region "Child_Insert"
    
        Private Sub Child_Insert(ByVal connection as SqlConnection)
            Dim cancel As Boolean = False
            OnChildInserting(connection, cancel)
            If (cancel) Then
                Return
            End If
    
            If Not (connection.State = ConnectionState.Open) Then connection.Open()
            Using command As New SqlCommand("[dbo].[CSLA_Order_Insert]", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@p_OrderId", Me.OrderId)
				command.Parameters("@p_OrderId").Direction = ParameterDirection.Output
				command.Parameters.AddWithValue("@p_UserId", Me.UserId)
				command.Parameters.AddWithValue("@p_OrderDate", Me.OrderDate)
				command.Parameters.AddWithValue("@p_ShipAddr1", Me.ShipAddr1)
				command.Parameters.AddWithValue("@p_ShipAddr2", ADOHelper.NullCheck(Me.ShipAddr2))
				command.Parameters.AddWithValue("@p_ShipCity", Me.ShipCity)
				command.Parameters.AddWithValue("@p_ShipState", Me.ShipState)
				command.Parameters.AddWithValue("@p_ShipZip", Me.ShipZip)
				command.Parameters.AddWithValue("@p_ShipCountry", Me.ShipCountry)
				command.Parameters.AddWithValue("@p_BillAddr1", Me.BillAddr1)
				command.Parameters.AddWithValue("@p_BillAddr2", ADOHelper.NullCheck(Me.BillAddr2))
				command.Parameters.AddWithValue("@p_BillCity", Me.BillCity)
				command.Parameters.AddWithValue("@p_BillState", Me.BillState)
				command.Parameters.AddWithValue("@p_BillZip", Me.BillZip)
				command.Parameters.AddWithValue("@p_BillCountry", Me.BillCountry)
				command.Parameters.AddWithValue("@p_Courier", Me.Courier)
				command.Parameters.AddWithValue("@p_TotalPrice", Me.TotalPrice)
				command.Parameters.AddWithValue("@p_BillToFirstName", Me.BillToFirstName)
				command.Parameters.AddWithValue("@p_BillToLastName", Me.BillToLastName)
				command.Parameters.AddWithValue("@p_ShipToFirstName", Me.ShipToFirstName)
				command.Parameters.AddWithValue("@p_ShipToLastName", Me.ShipToLastName)
				command.Parameters.AddWithValue("@p_AuthorizationNumber", Me.AuthorizationNumber)
				command.Parameters.AddWithValue("@p_Locale", Me.Locale)
    
                command.ExecuteNonQuery()
    
    
                ' Update identity or guid primary key value.
                LoadProperty(_orderIdProperty, DirectCast(command.Parameters("@p_OrderId").Value, System.Int32))
    
            End Using
    
            FieldManager.UpdateChildren(Me, connection)
    
            OnChildInserted()
        End Sub
    
#End Region
    
#Region "Child_Update"
    
        Private Sub Child_Update(ByVal connection as SqlConnection)
            Dim cancel As Boolean = False
            OnChildUpdating(connection, cancel)
            If (cancel) Then
                Return
            End If
    
            If Not connection.State = ConnectionState.Open Then connection.Open()
            Using command As New SqlCommand("[dbo].[CSLA_Order_Update]", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@p_OrderId", Me.OrderId)
				command.Parameters("@p_OrderId").Direction = ParameterDirection.Output
				command.Parameters.AddWithValue("@p_UserId", Me.UserId)
				command.Parameters.AddWithValue("@p_OrderDate", Me.OrderDate)
				command.Parameters.AddWithValue("@p_ShipAddr1", Me.ShipAddr1)
				command.Parameters.AddWithValue("@p_ShipAddr2", ADOHelper.NullCheck(Me.ShipAddr2))
				command.Parameters.AddWithValue("@p_ShipCity", Me.ShipCity)
				command.Parameters.AddWithValue("@p_ShipState", Me.ShipState)
				command.Parameters.AddWithValue("@p_ShipZip", Me.ShipZip)
				command.Parameters.AddWithValue("@p_ShipCountry", Me.ShipCountry)
				command.Parameters.AddWithValue("@p_BillAddr1", Me.BillAddr1)
				command.Parameters.AddWithValue("@p_BillAddr2", ADOHelper.NullCheck(Me.BillAddr2))
				command.Parameters.AddWithValue("@p_BillCity", Me.BillCity)
				command.Parameters.AddWithValue("@p_BillState", Me.BillState)
				command.Parameters.AddWithValue("@p_BillZip", Me.BillZip)
				command.Parameters.AddWithValue("@p_BillCountry", Me.BillCountry)
				command.Parameters.AddWithValue("@p_Courier", Me.Courier)
				command.Parameters.AddWithValue("@p_TotalPrice", Me.TotalPrice)
				command.Parameters.AddWithValue("@p_BillToFirstName", Me.BillToFirstName)
				command.Parameters.AddWithValue("@p_BillToLastName", Me.BillToLastName)
				command.Parameters.AddWithValue("@p_ShipToFirstName", Me.ShipToFirstName)
				command.Parameters.AddWithValue("@p_ShipToLastName", Me.ShipToLastName)
				command.Parameters.AddWithValue("@p_AuthorizationNumber", Me.AuthorizationNumber)
				command.Parameters.AddWithValue("@p_Locale", Me.Locale)
    
                'result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                Dim result As Integer = command.ExecuteNonQuery()
                If (result = 0) Then
                    throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                End If
    
            End Using
            FieldManager.UpdateChildren(Me, connection)
    
            OnChildUpdated()
        End Sub
    
#End Region
    
        Private Sub Child_DeleteSelf()
            Dim cancel As Boolean = False
            OnChildSelfDeleting(cancel)
            If (cancel) Then
                Return
            End If
        
            DataPortal_Delete(New OrderCriteria (OrderId))
        
            OnChildSelfDeleted()
        End Sub
    
        Private Sub Child_DeleteSelf(ParamArray args As Object())
        Dim connection As SqlConnection = args.OfType(Of SqlConnection)().FirstOrDefault()
        If connection Is Nothing Then
            Throw New ArgumentNullException("args", "Must contain a SqlConnection parameter.")
        End If
        
            Dim cancel As Boolean = False
            OnChildSelfDeleting(cancel)
            If (cancel) Then
                Return
            End If
        
            DataPortal_Delete(New OrderCriteria (OrderId), connection)
        
            OnChildSelfDeleted()
        End Sub
    
#End Region
    
        Private Sub Map(ByVal reader As SafeDataReader)
            Dim cancel As Boolean = False
            OnMapping(reader, cancel)
            If (cancel) Then
                Return
            End If
    
            Using(BypassPropertyChecks)
                LoadProperty(_orderIdProperty, reader.Item("OrderId"))
                LoadProperty(_userIdProperty, reader.Item("UserId"))
                LoadProperty(_orderDateProperty, reader.Item("OrderDate"))
                LoadProperty(_shipAddr1Property, reader.Item("ShipAddr1"))
                LoadProperty(_shipAddr2Property, reader.Item("ShipAddr2"))
                LoadProperty(_shipCityProperty, reader.Item("ShipCity"))
                LoadProperty(_shipStateProperty, reader.Item("ShipState"))
                LoadProperty(_shipZipProperty, reader.Item("ShipZip"))
                LoadProperty(_shipCountryProperty, reader.Item("ShipCountry"))
                LoadProperty(_billAddr1Property, reader.Item("BillAddr1"))
                LoadProperty(_billAddr2Property, reader.Item("BillAddr2"))
                LoadProperty(_billCityProperty, reader.Item("BillCity"))
                LoadProperty(_billStateProperty, reader.Item("BillState"))
                LoadProperty(_billZipProperty, reader.Item("BillZip"))
                LoadProperty(_billCountryProperty, reader.Item("BillCountry"))
                LoadProperty(_courierProperty, reader.Item("Courier"))
                LoadProperty(_totalPriceProperty, reader.Item("TotalPrice"))
                LoadProperty(_billToFirstNameProperty, reader.Item("BillToFirstName"))
                LoadProperty(_billToLastNameProperty, reader.Item("BillToLastName"))
                LoadProperty(_shipToFirstNameProperty, reader.Item("ShipToFirstName"))
                LoadProperty(_shipToLastNameProperty, reader.Item("ShipToLastName"))
                LoadProperty(_authorizationNumberProperty, reader.Item("AuthorizationNumber"))
                LoadProperty(_localeProperty, reader.Item("Locale"))
            End Using
    
            OnMapped()
    
            MarkOld()
        End Sub
    End Class
End Namespace
