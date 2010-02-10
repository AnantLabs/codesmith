'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.0, CSLA Framework: v3.8.0.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'LineItem.vb.
'
'     Template: SwitchableObject.DataAccess.ParameterizedSQL.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Csla
Imports Csla.Data

Public Partial Class LineItem

    #Region "Root Data Access"

    <RunLocal()> _
    Protected Overrides Sub DataPortal_Create()
        ValidationRules.CheckRules()
    End Sub

    <Transactional(TransactionalTypes.TransactionScope)> _
    Private Shadows Sub DataPortal_Fetch(ByVal criteria As LineItemCriteria)
        Dim cancel As Boolean = False
        OnFetching(criteria, cancel)
        If (cancel) Then
            Return
        End If

        Dim commandText As String = String.Format("SELECT [OrderId], [LineNum], [ItemId], [Quantity], [UnitPrice] FROM [dbo].[LineItem] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag))
        Using connection As New SqlConnection(ADOHelper.ConnectionString)
            connection.Open()
            Using command As New SqlCommand(commandText, connection)
                command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                    If reader.Read() Then
                        Map(reader)
                    Else
                        Throw New Exception(String.Format("The record was not found in 'LineItem' using the following criteria: {0}.", criteria))
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

        Const commandText As String = "INSERT INTO [dbo].[LineItem] ([OrderId], [LineNum], [ItemId], [Quantity], [UnitPrice]) VALUES (@p_OrderId, @p_LineNum, @p_ItemId, @p_Quantity, @p_UnitPrice)"
        Using connection As New SqlConnection(ADOHelper.ConnectionString)
            connection.Open()
            Using command As New SqlCommand(commandText, connection)
                command.Parameters.AddWithValue("@p_OrderId", OrderId)
				command.Parameters.AddWithValue("@p_LineNum", LineNum)
				command.Parameters.AddWithValue("@p_ItemId", ItemId)
				command.Parameters.AddWithValue("@p_Quantity", Quantity)
				command.Parameters.AddWithValue("@p_UnitPrice", UnitPrice)

                Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                    If reader.Read() Then

                    End If
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

        Const commandText As String = "UPDATE [dbo].[LineItem]  SET [OrderId] = @p_OrderId, [LineNum] = @p_LineNum, [ItemId] = @p_ItemId, [Quantity] = @p_Quantity, [UnitPrice] = @p_UnitPrice WHERE [OrderId] = @p_OrderId AND [LineNum] = @p_LineNum"
        Using connection As New SqlConnection(ADOHelper.ConnectionString)
            connection.Open()
            Using command As New SqlCommand(commandText, connection)
                command.Parameters.AddWithValue("@p_OrderId", OrderId)
				command.Parameters.AddWithValue("@p_LineNum", LineNum)
				command.Parameters.AddWithValue("@p_ItemId", ItemId)
				command.Parameters.AddWithValue("@p_Quantity", Quantity)
				command.Parameters.AddWithValue("@p_UnitPrice", UnitPrice)

                Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                    'RecordsAffected: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    If reader.RecordsAffected = 0 Then
                        Throw New DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                    End If
                End Using
            End Using

			FieldManager.UpdateChildren(Me, connection)
        End Using

        OnUpdated()
    End Sub

    <Transactional(TransactionalTypes.TransactionScope)> _
    Protected Overrides Sub DataPortal_DeleteSelf()
        Dim cancel As Boolean = False
        OnSelfDeleting(cancel)
        If (cancel) Then
            Return
        End If
    
        DataPortal_Delete(New LineItemCriteria(OrderId, LineNum))
    
		OnSelfDeleted()
    End Sub

    <Transactional(TransactionalTypes.TransactionScope)> _
    Protected Shadows Sub DataPortal_Delete(ByVal criteria As LineItemCriteria)
        Dim cancel As Boolean = False
        OnDeleting(criteria, cancel)
        If (cancel) Then
            Return
        End If

        Dim commandText As String = String.Format("DELETE FROM [dbo].[LineItem] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag))
        Using connection As New SqlConnection(ADOHelper.ConnectionString)
            connection.Open()
            Using command As New SqlCommand(commandText, connection)
                command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))

                'result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                Dim result As Integer = command.ExecuteNonQuery()
                If (result = 0) Then
                    throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                End If
            End Using
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

        ValidationRules.CheckRules()

        OnChildCreated()
    End Sub

    Private Sub Child_Fetch(ByVal criteria As LineItemCriteria)
        Dim cancel As Boolean = False
        OnChildFetching(criteria, cancel)
        If (cancel) Then
            Return
        End If

        Dim commandText As String = String.Format("SELECT [OrderId], [LineNum], [ItemId], [Quantity], [UnitPrice] FROM [dbo].[LineItem] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag))
        Using connection As New SqlConnection(ADOHelper.ConnectionString)
            connection.Open()
            Using command As New SqlCommand(commandText, connection)
                command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                    If reader.Read() Then
                        Map(reader)
                    Else
                        Throw New Exception(String.Format("The record was not found in 'LineItem' using the following criteria: {0}.", criteria))
                    End If
                End Using
            End Using
        End Using

        OnChildFetched()

        MarkAsChild()
    End Sub

    Private Sub Child_Insert(ByVal order As Order, ByRef connection As SqlConnection)
        Dim cancel As Boolean = False
        OnChildInserting(cancel)
        If (cancel) Then
            Return
        End If

        If connection.State <> ConnectionState.Open Then connection.Open()
        Const commandText As String = "INSERT INTO [dbo].[LineItem] ([OrderId], [LineNum], [ItemId], [Quantity], [UnitPrice]) VALUES (@p_OrderId, @p_LineNum, @p_ItemId, @p_Quantity, @p_UnitPrice)"
        Using command As New SqlCommand(commandText, connection)
            command.Parameters.AddWithValue("@p_OrderId", order.OrderId)
				command.Parameters.AddWithValue("@p_LineNum", LineNum)
				command.Parameters.AddWithValue("@p_ItemId", ItemId)
				command.Parameters.AddWithValue("@p_Quantity", Quantity)
				command.Parameters.AddWithValue("@p_UnitPrice", UnitPrice)

            Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                If reader.Read() Then
                End If
            End Using
        End Using

        OnChildInserted()
    End Sub

    Private Sub Child_Update(ByVal order As Order, ByRef connection As SqlConnection)
        Dim cancel As Boolean = False
        OnChildUpdating(cancel)
        If (cancel) Then
            Return
        End If

        If connection.State <> ConnectionState.Open Then connection.Open()
        Const commandText As String = "UPDATE [dbo].[LineItem]  SET [OrderId] = @p_OrderId, [LineNum] = @p_LineNum, [ItemId] = @p_ItemId, [Quantity] = @p_Quantity, [UnitPrice] = @p_UnitPrice WHERE [OrderId] = @p_OrderId AND [LineNum] = @p_LineNum"
        Using command As New SqlCommand(commandText, connection)
			command.Parameters.AddWithValue("@p_OrderId", order.OrderId)
				command.Parameters.AddWithValue("@p_LineNum", LineNum)
				command.Parameters.AddWithValue("@p_ItemId", ItemId)
				command.Parameters.AddWithValue("@p_Quantity", Quantity)
				command.Parameters.AddWithValue("@p_UnitPrice", UnitPrice)

            Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                'RecordsAffected: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                If reader.RecordsAffected = 0 Then
                    Throw New DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                End If
            End Using
        End Using

        OnChildUpdated()
    End Sub

    Private Sub Child_DeleteSelf()
        Dim cancel As Boolean = False
        OnChildSelfDeleting(cancel)
        If (cancel) Then
            Return
        End If
    
        DataPortal_Delete(New LineItemCriteria(OrderId, LineNum))
    
		OnChildSelfDeleted()
    End Sub

    #End Region

    Private Sub Map(ByVal reader As SafeDataReader)
        Using(BypassPropertyChecks)
            LoadProperty(_orderIdProperty, reader.GetInt32("OrderId"))
            LoadProperty(_lineNumProperty, reader.GetInt32("LineNum"))
            LoadProperty(_itemIdProperty, reader.GetString("ItemId"))
            LoadProperty(_quantityProperty, reader.GetInt32("Quantity"))
            LoadProperty(_unitPriceProperty, reader.GetDecimal("UnitPrice"))
        End Using

        MarkOld()
    End Sub
    
    #Region "Data access partial methods"

    Partial Private Sub OnCreating(ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnFetching(ByVal criteria As LineItemCriteria, ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnFetched()
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
    Partial Private Sub OnDeleting(ByVal criteria As LineItemCriteria, ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnDeleted()
    End Sub

    #End Region

    #Region "Child data access partial methods"

    Partial Private Sub OnChildCreating(ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnChildCreated()
    End Sub
    Partial Private Sub OnChildFetching(ByVal criteria As LineItemCriteria, ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnChildFetched()
    End Sub
    Partial Private Sub OnChildInserting(ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnChildInserted()
    End Sub
    Partial Private Sub OnChildUpdating(ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnChildUpdated()
    End Sub
    Partial Private Sub OnChildSelfDeleting(ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnChildSelfDeleted()
    End Sub

    #End Region
End Class