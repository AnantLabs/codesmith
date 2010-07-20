﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.1845, CSLA Framework: v4.0.0.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'OrderStatusList.vb.
'
'     Template: EditableChildList.DataAccess.ParameterizedSQL.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On
#If Not SILVERLIGHT Then

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Csla
Imports Csla.Data
Imports Csla.Rules

Namespace PetShop.Business
    Public Partial Class OrderStatusList
    
        Protected Overrides Sub Child_Create()
            Dim cancel As Boolean = False
            OnCreating(cancel)
            If (cancel) Then
                Return
            End If
    
            OnCreated()
        End Sub
    
        Private Shadows Sub Child_Fetch(ByVal criteria As OrderStatusCriteria)
            Dim cancel As Boolean = False
            OnFetching(criteria, cancel)
            If (cancel) Then
                Return
            End If
    
            RaiseListChangedEvents = False
    
            ' Fetch Child objects.
            Dim commandText As String = String.Format("SELECT [OrderId], [LineNum], [Timestamp], [Status] FROM [dbo].[OrderStatus] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag))
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand(commandText, connection)
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                    Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                        If reader.Read() Then
                            Do
                                Me.Add(New OrderStatus(reader))
                            Loop While reader.Read()
                        End If
                    End Using
                End Using
            End Using
    
            RaiseListChangedEvents = True
    
            OnFetched()
        End Sub
        ''' <summary>
        ''' Updates the child object.
        ''' </summary>
        ''' <param name="parameters">The parameters collection may contain more parameters than needed based on the context it was called. We need to filter this list.</param>
        Protected Overrides Sub Child_Update(ParamArray parameters As Object())
        Dim cancel As Boolean = False
        OnUpdating(cancel)
        If cancel Then
            Return
        End If
    
        ' We require that one of the parameters be a connection so we can do the CRUD operations.
        Dim connection As SqlConnection = parameters.OfType(Of SqlConnection)().FirstOrDefault()
        If connection Is Nothing Then
            Throw New ArgumentNullException("parameters", "Must contain a SqlConnection parameter.")
        End If
    
        RaiseListChangedEvents = False
    
        For Each item As OrderStatus In DeletedList
            DataPortal.UpdateChild(item, connection)
        Next
    
        DeletedList.Clear()
    
        ' Trim down the list to what is actually contained in the child class.
        Dim list As New System.Collections.Generic.Dictionary(Of String, Object)
        Dim key As String
        For Each o As Object In parameters
            If Not o Is Nothing Then
                key = o.GetType().ToString()
                If Not list.ContainsKey(key) Then
                    list.Add(key, o)
                End If
            End If
        Next
    
        For Each item As OrderStatus In Items
            DataPortal.UpdateChild(item, list.Values.ToArray())
        Next
    
        RaiseListChangedEvents = True
    
        OnUpdated()
        End Sub
    End Class
End Namespace
#End If
