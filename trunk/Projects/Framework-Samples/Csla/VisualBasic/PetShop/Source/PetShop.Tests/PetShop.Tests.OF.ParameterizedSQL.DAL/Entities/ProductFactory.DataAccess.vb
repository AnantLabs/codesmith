'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v2.0.1.1739, CSLA Framework: v3.8.2.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'Product.cs'.
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
    Public Partial Class ProductFactory
        Inherits ObjectFactory
    
        #Region "Create"
    
        ''' <summary>
        ''' Creates New Product with default values.
        ''' </summary>
        ''' <Returns>New Product.</Returns>
        <RunLocal()> _
        Public Function Create() As Product
            Dim item As Product = CType(Activator.CreateInstance(GetType(Product), True), Product)
    
            Dim cancel As Boolean = False
            OnCreating(cancel)
            If (cancel) Then
                Return item
            End If
    
            Using BypassPropertyChecks(item)
                ' Default values.
    
                item.CategoryId = "BN"
    
                CheckRules(item)
                MarkNew(item)
            End Using
    
            OnCreated()
    
            Return item
        End Function
    
        ''' <summary>
        ''' Creates New Product with default values.
        ''' </summary>
        ''' <Returns>New Product.</Returns>
        <RunLocal()> _
        Private Function Create(ByVal criteria As ProductCriteria) As  Product
            Dim item As Product = CType(Activator.CreateInstance(GetType(Product), True), Product)
    
            Dim cancel As Boolean = False
            OnCreating(cancel)
            If (cancel) Then
                Return item
            End If
    
            Dim resource As Product = Fetch(criteria)
    
            Using BypassPropertyChecks(item)
                item.Name = resource.Name
                item.Description = resource.Description
                item.Image = resource.Image
            End Using
    
            CheckRules(item)
            MarkNew(item)
    
            OnCreated()
    
            Return item
        End Function
    
        #End Region
    
        #Region "Fetch
    
        ''' <summary>
        ''' Fetch Product.
        ''' </summary>
        ''' <param name="criteria">The criteria.</param>
        ''' <Returns></Returns>
        Public Function Fetch(ByVal criteria As ProductCriteria) As Product
            Dim item As Product = Nothing
            
            Dim cancel As Boolean = False
            OnFetching(criteria, cancel)
            If (cancel) Then
                Return item
            End If
    
            Dim commandText As String = String.Format("SELECT [ProductId], [CategoryId], [Name], [Descn], [Image] FROM [dbo].[Product] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag))
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand(commandText, connection)
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                    Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                        If reader.Read() Then
                            item = Map(reader)
                        Else
                            Throw New Exception(String.Format("The record was not found in 'Product' using the following criteria: {0}.", criteria))
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
    
        Private Sub DoInsert(ByRef item As Product, ByVal stopProccessingChildren As Boolean)
            ' Don't update If the item isn't dirty.
            If Not (item.IsDirty) Then
                Return
            End If
    
            Dim cancel As Boolean = False
            OnInserting(cancel)
            If (cancel) Then
                Return
            End If
    
            Const commandText As String = "INSERT INTO [dbo].[Product] ([ProductId], [CategoryId], [Name], [Descn], [Image]) VALUES (@p_ProductId, @p_CategoryId, @p_Name, @p_Descn, @p_Image)"
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand(commandText, connection)
                    command.Parameters.AddWithValue("@p_ProductId", item.ProductId)
			command.Parameters.AddWithValue("@p_CategoryId", item.CategoryId)
			command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(item.Name))
			command.Parameters.AddWithValue("@p_Descn", ADOHelper.NullCheck(item.Description))
			command.Parameters.AddWithValue("@p_Image", ADOHelper.NullCheck(item.Image))
    
                    Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                        If reader.Read() Then
    
                        End If
                    End Using
                End Using
            End Using
    
            item.OriginalProductId = item.ProductId
    
            MarkOld(item)
            CheckRules(item)
            
            If Not (stopProccessingChildren) Then
                ' Update Child Items.
                Update_Category_CategoryMember_CategoryId(item)
                Update_Item_Items_ProductId(item)
            End If
    
            OnInserted()
        End Sub
    
        #End Region
    
        #Region "Update"
    
        <Transactional(TransactionalTypes.TransactionScope)> _
        Public Function Update(ByVal item As Product) As Product
            Return Update(item, false)
        End Function
    
        Public Function Update(ByVal item As Product, ByVal stopProccessingChildren as Boolean) As Product
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
    
        Private Sub DoUpdate(ByRef item As Product, ByVal stopProccessingChildren As Boolean)
            Dim cancel As Boolean = False
            OnUpdating(cancel)
            If (cancel) Then
                Return
            End If
            
            ' Don't update If the item isn't dirty.
            If (item.IsDirty) Then
    
                If Not item.OriginalProductId = item.ProductId Then
                    ' Insert new child.
                    Dim temp As Product = CType(Activator.CreateInstance(GetType(Product), True), Product)
                    temp.ProductId = item.ProductId
			temp.CategoryId = item.CategoryId
			temp.Name = item.Name
			temp.Description = item.Description
			temp.Image = item.Image
                    temp = temp.Save()
    
                    ' Mark child lists as dirty. This code may need to be updated to one-to-one relationships.
                    For Each itemToUpdate As Item In item.Items
    		itemToUpdate.ProductId = item.ProductId
                    Next
                    ' Update Child Items.
                    Update_Category_CategoryMember_CategoryId(item)
                    Update_Item_Items_ProductId(item)
        
                    ' Delete the old.
                    Dim criteria As New ProductCriteria()
                    criteria.ProductId = item.OriginalProductId
                    Delete(criteria)
        
                    ' Mark the original as the new one.
                    item.OriginalProductId = item.ProductId
                    MarkOld(item)
                    CheckRules(item)
    
                    OnUpdated()
            
                    Return
                End If
    
                Const commandText As String = "UPDATE [dbo].[Product]  SET [ProductId] = @p_ProductId, [CategoryId] = @p_CategoryId, [Name] = @p_Name, [Descn] = @p_Descn, [Image] = @p_Image WHERE [ProductId] = @p_ProductId"
                Using connection As New SqlConnection(ADOHelper.ConnectionString)
                    connection.Open()
                    Using command As New SqlCommand(commandText, connection)
                        command.Parameters.AddWithValue("@p_OriginalProductId", item.OriginalProductId)
			command.Parameters.AddWithValue("@p_ProductId", item.ProductId)
			command.Parameters.AddWithValue("@p_CategoryId", item.CategoryId)
			command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(item.Name))
			command.Parameters.AddWithValue("@p_Descn", ADOHelper.NullCheck(item.Description))
			command.Parameters.AddWithValue("@p_Image", ADOHelper.NullCheck(item.Image))
    
                        'result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                        Dim result As Integer = command.ExecuteNonQuery()
                        If (result = 0) Then
                            throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                        End If
                    End Using
                End Using
            End If
    
            item.OriginalProductId = item.ProductId
    
            MarkOld(item)
            CheckRules(item)
    
            If Not (stopProccessingChildren) Then
                ' Update Child Items.
                Update_Category_CategoryMember_CategoryId(item)
                Update_Item_Items_ProductId(item)
            End If
    
            OnUpdated()
        End Sub
    
        #End Region
    
        #Region "Delete"
    
        <Transactional(TransactionalTypes.TransactionScope)> _
        Public Sub Delete(ByVal criteria As ProductCriteria)
            ' Note: this call to delete is for immediate deletion and doesn't keep track of any entity state.
            DoDelete(criteria)
        End Sub
    
        Protected Sub DoDelete(ByRef item As Product)
            ' If we're not dirty then don't update the database.
            If Not (item.IsDirty) Then
                Return
            End If
    
            ' If we're New then don't call delete.
            If (item.IsNew) Then
                Return
            End If
    
            Dim criteria As New ProductCriteria()
    criteria.ProductId = item.ProductId
            DoDelete(criteria)
    
            MarkNew(item)
        End Sub
    
        ''' <summary>
        ''' This call to delete is for immediate deletion and doesn't keep track of any entity state.
        ''' </summary>
        ''' <param name="criteria">The Criteria.</param>
        Private Sub DoDelete(ByVal criteria As ProductCriteria)
            Dim cancel As Boolean = False
            OnDeleting(criteria, cancel)
            If (cancel) Then
                Return
            End If
    
            Dim commandText As String = String.Format("DELETE FROM [dbo].[Product] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag))
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
    
        Public Function Map(ByVal reader As SafeDataReader) As Product
            Dim item As Product = CType(Activator.CreateInstance(GetType(Product), True), Product)
            Using BypassPropertyChecks(item)
                item.ProductId = reader.GetString("ProductId")
                item.OriginalProductId = reader.GetString("ProductId")
                item.CategoryId = reader.GetString("CategoryId")
                item.Name = reader.GetString("Name")
                item.Description = reader.GetString("Descn")
                item.Image = reader.GetString("Image")
            End Using
                MarkOld(item)
    
            Return item
        End Function
    
        'AssociatedManyToOne
        Private Shared Sub  Update_Category_CategoryMember_CategoryId(ByRef item As Product)
    		item.CategoryMember.CategoryId = item.CategoryId
    
            Dim factory As New CategoryFactory
            factory.Update(item.CategoryMember, True)
        End Sub
        'AssociatedOneToMany
        Private Shared Sub  Update_Item_Items_ProductId(ByRef item As Product)
            For Each itemToUpdate As Item In item.Items
    		itemToUpdate.ProductId = item.ProductId
    
                Dim factory As New ItemFactory
                factory.Update(itemToUpdate, True)
            Next
        End Sub
    
        #End Region
    
        #Region "DataPortal partial methods"
    
        Partial Private Sub OnCreating(ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnCreated()
        End Sub
        Partial Private Sub OnFetching(ByVal criteria As ProductCriteria, ByRef cancel As Boolean)
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
        Partial Private Sub OnDeleting(ByVal criteria As ProductCriteria, ByRef cancel As Boolean)
        End Sub
        Partial Private Sub OnDeleted()
        End Sub
    
        #End Region
    End Class
End Namespace