'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.0, CSLA Framework: v3.8.4.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'Category.cs'.
'
'     Template: ObjectFactory.DataAccess.ParameterizedSQL.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

#Region "Imports declarations"

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Csla
Imports Csla.Data
Imports Csla.Server

Imports PetShop.Tests.OF.ParameterizedSQL

#End Region

Namespace PetShop.Tests.OF.ParameterizedSQL.DAL
    Public Partial Class CategoryFactory
        Inherits ObjectFactory
    
#Region "Create"
    
        ''' <summary>
        ''' Creates New Category with default values.
        ''' </summary>
        ''' <Returns>New Category.</Returns>
        <RunLocal()> _
        Public Function Create() As Category
            Dim item As Category = CType(Activator.CreateInstance(GetType(Category), True), Category)
    
            Dim cancel As Boolean = False
            OnCreating(cancel)
            If (cancel) Then
                Return item
            End If
    
            Using BypassPropertyChecks(item)
                ' Default values.
    
    
                CheckRules(item)
                MarkNew(item)
            End Using
    
            OnCreated()
    
            Return item
        End Function
    
        ''' <summary>
        ''' Creates New Category with default values.
        ''' </summary>
        ''' <Returns>New Category.</Returns>
        <RunLocal()> _
        Private Function Create(ByVal criteria As CategoryCriteria) As  Category
            Dim item As Category = CType(Activator.CreateInstance(GetType(Category), True), Category)
    
            Dim cancel As Boolean = False
            OnCreating(cancel)
            If (cancel) Then
                Return item
            End If
    
            Dim resource As Category = Fetch(criteria)
    
            Using BypassPropertyChecks(item)
                item.Name = resource.Name
                item.Description = resource.Description
            End Using
    
            CheckRules(item)
            MarkNew(item)
    
            OnCreated()
    
            Return item
        End Function
    
#End Region
    
#Region "Fetch
    
        ''' <summary>
        ''' Fetch Category.
        ''' </summary>
        ''' <param name="criteria">The criteria.</param>
        ''' <Returns></Returns>
        Public Function Fetch(ByVal criteria As CategoryCriteria) As Category
            Dim item As Category = Nothing
            
            Dim cancel As Boolean = False
            OnFetching(criteria, cancel)
            If (cancel) Then
                Return item
            End If
    
            Dim commandText As String = String.Format("SELECT [CategoryId], [Name], [Descn] FROM [dbo].[Category] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag))
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand(commandText, connection)
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                    Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                        If reader.Read() Then
                            item = Map(reader)
                        Else
                            Throw New Exception(String.Format("The record was not found in 'Category' using the following criteria: {0}.", criteria))
                        End If
                    End Using
                End Using
            End Using
    
            MarkOld(item)
    
            OnFetched()
    
            Return item
        End Function
    
#End Region
    
#Region "Insert"
    
        Private Sub DoInsert(ByRef item As Category, ByVal stopProccessingChildren As Boolean)
            ' Don't update If the item isn't dirty.
            If Not (item.IsDirty) Then
                Return
            End If
    
            Dim cancel As Boolean = False
            OnInserting(cancel)
            If (cancel) Then
                Return
            End If
    
            Const commandText As String = "INSERT INTO [dbo].[Category] ([CategoryId], [Name], [Descn]) VALUES (@p_CategoryId, @p_Name, @p_Descn)"
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand(commandText, connection)
                    command.Parameters.AddWithValue("@p_CategoryId", item.CategoryId)
				command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(item.Name))
				command.Parameters.AddWithValue("@p_Descn", ADOHelper.NullCheck(item.Description))
    
                    Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                        If reader.Read() Then
    
                        End If
                    End Using
                End Using
            End Using
    
            item.OriginalCategoryId = item.CategoryId
    
            MarkOld(item)
            CheckRules(item)
            
            If Not (stopProccessingChildren) Then
                ' Update Child Items.
                Update_Product_Products_CategoryId(item)
            End If
    
            OnInserted()
        End Sub
    
#End Region
    
#Region "Update"
    
        <Transactional(TransactionalTypes.TransactionScope)> _
        Public Function Update(ByVal item As Category) As Category
            Return Update(item, false)
        End Function
    
        Public Function Update(ByVal item As Category, ByVal stopProccessingChildren as Boolean) As Category
            If(item.IsDeleted) Then
                DoDelete(item)
                MarkNew(item)
            Else If(item.IsNew) Then
                DoInsert(item, stopProccessingChildren)
            Else
            DoUpdate(item, stopProccessingChildren)
            End If
    
            Return item
        End Function
    
        Private Sub DoUpdate(ByRef item As Category, ByVal stopProccessingChildren As Boolean)
            Dim cancel As Boolean = False
            OnUpdating(cancel)
            If (cancel) Then
                Return
            End If
            
            ' Don't update If the item isn't dirty.
            If (item.IsDirty) Then
    
                If Not item.OriginalCategoryId = item.CategoryId Then
                    ' Insert new child.
                    Dim temp As Category = CType(Activator.CreateInstance(GetType(Category), True), Category)
                    temp.CategoryId = item.CategoryId
			temp.Name = item.Name
			temp.Description = item.Description
                    temp = temp.Save()
    
                    ' Mark child lists as dirty. This code may need to be updated to one-to-one relationships.
                    For Each itemToUpdate As Product In item.Products
    		itemToUpdate.CategoryId = item.CategoryId
                    Next
                    ' Update Child Items.
                    Update_Product_Products_CategoryId(item)
        
                    ' Delete the old.
                    Dim criteria As New CategoryCriteria()
                    criteria.CategoryId = item.OriginalCategoryId
                    Delete(criteria)
        
                    ' Mark the original as the new one.
                    item.OriginalCategoryId = item.CategoryId
                    MarkOld(item)
                    CheckRules(item)
    
                    OnUpdated()
            
                    Return
                End If
    
                Const commandText As String = "UPDATE [dbo].[Category]  SET [CategoryId] = @p_CategoryId, [Name] = @p_Name, [Descn] = @p_Descn WHERE [CategoryId] = @p_CategoryId"
                Using connection As New SqlConnection(ADOHelper.ConnectionString)
                    connection.Open()
                    Using command As New SqlCommand(commandText, connection)
                        command.Parameters.AddWithValue("@p_OriginalCategoryId", item.OriginalCategoryId)
				command.Parameters.AddWithValue("@p_CategoryId", item.CategoryId)
				command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(item.Name))
				command.Parameters.AddWithValue("@p_Descn", ADOHelper.NullCheck(item.Description))
    
                        'result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                        Dim result As Integer = command.ExecuteNonQuery()
                        If (result = 0) Then
                            throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                        End If
                    End Using
                End Using
            End If
    
            item.OriginalCategoryId = item.CategoryId
    
            MarkOld(item)
            CheckRules(item)
    
            If Not (stopProccessingChildren) Then
                ' Update Child Items.
                Update_Product_Products_CategoryId(item)
            End If
    
            OnUpdated()
        End Sub
    
#End Region
    
#Region "Delete"
    
        <Transactional(TransactionalTypes.TransactionScope)> _
        Public Sub Delete(ByVal criteria As CategoryCriteria)
            ' Note: this call to delete is for immediate deletion and doesn't keep track of any entity state.
            DoDelete(criteria)
        End Sub
    
        Protected Sub DoDelete(ByRef item As Category)
            ' If we're not dirty then don't update the database.
            If Not (item.IsDirty) Then
                Return
            End If
    
            ' If we're New then don't call delete.
            If (item.IsNew) Then
                Return
            End If
    
            Dim criteria As New CategoryCriteria()
    criteria.CategoryId = item.CategoryId
            DoDelete(criteria)
    
            MarkNew(item)
        End Sub
    
        ''' <summary>
        ''' This call to delete is for immediate deletion and doesn't keep track of any entity state.
        ''' </summary>
        ''' <param name="criteria">The Criteria.</param>
        Private Sub DoDelete(ByVal criteria As CategoryCriteria)
            Dim cancel As Boolean = False
            OnDeleting(criteria, cancel)
            If (cancel) Then
                Return
            End If
    
            Dim commandText As String = String.Format("DELETE FROM [dbo].[Category] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag))
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
    
#Region "Helper Methods"
    
        Public Function Map(ByVal reader As SafeDataReader) As Category
            Dim item As Category = CType(Activator.CreateInstance(GetType(Category), True), Category)
            Using BypassPropertyChecks(item)
                item.CategoryId = reader.GetString("CategoryId")
                item.OriginalCategoryId = reader.GetString("CategoryId")
                item.Name = reader.GetString("Name")
                item.Description = reader.GetString("Descn")
            End Using
                MarkOld(item)
    
            Return item
        End Function
    
        'AssociatedOneToMany
        Private Shared Sub  Update_Product_Products_CategoryId(ByRef item As Category)
            For Each itemToUpdate As Product In item.Products
    		itemToUpdate.CategoryId = item.CategoryId
    
                Dim factory As New ProductFactory
                factory.Update(itemToUpdate, True)
            Next
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
    End Class
End Namespace