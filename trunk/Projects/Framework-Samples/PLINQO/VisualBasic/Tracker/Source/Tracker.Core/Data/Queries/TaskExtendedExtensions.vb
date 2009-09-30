﻿
'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a CodeSmith Template.
'
'     DO NOT MODIFY contents of this file. Changes to this
'     file will be lost if the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Linq
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Linq.Dynamic

Namespace Tracker.Core.Data
    ''' <summary>
    ''' The query extension class for TaskExtended.
    ''' </summary>
    Public Module TaskExtendedExtensions
        ''' <summary>
        ''' Gets an instance by the primary key.
        ''' </summary>
        <System.Runtime.CompilerServices.Extension> _
        Public Function GetByKey(ByVal queryable As IQueryable(Of Tracker.Core.Data.TaskExtended), ByVal taskId As Integer) As Tracker.Core.Data.TaskExtended

            Dim entity As System.Data.Linq.Table(Of Tracker.Core.Data.TaskExtended) = CType(queryable, Table(Of Tracker.Core.Data.TaskExtended))
            If (entity IsNot Nothing AndAlso entity.Context.LoadOptions Is Nothing) Then
                Return Query.GetByKey.Invoke(DirectCast(entity.Context, Tracker.Core.Data.TrackerDataContext), taskId)
            End If

            Return queryable.FirstOrDefault(Function(t)t.TaskId = taskId)
        End Function
        
        ''' <summary>
        ''' Immediately deletes the entity by the primary key from the underlying data source with a single delete command.
        ''' </summary>
        ''' <param name="table">Represents a table for a particular type in the underlying database containing rows are to be deleted.</param>
        ''' <returns>The number of rows deleted from the database.</returns>
        <System.Runtime.CompilerServices.Extension> _
        Public Function Delete(ByVal table As System.Data.Linq.Table(Of Tracker.Core.Data.TaskExtended), ByVal taskId As Integer) As Integer
            Return table.Delete(Function(t)t.TaskId = taskId)
        End Function

        ''' <summary>
        ''' Gets a query for <see cref="Tracker.Core.Data.TaskExtended"/>.
        ''' </summary>
        ''' <param name="queryable">Query to append where clause.</param>
        ''' <param name="taskId">TaskId to search for.</param>
        ''' <returns>IQueryable with additional where clause.</returns>
        <System.Runtime.CompilerServices.Extension> _
        Public Function ByTaskId(queryable As IQueryable(Of Tracker.Core.Data.TaskExtended), taskId As Integer) As IQueryable(Of Tracker.Core.Data.TaskExtended)
            Return queryable.Where(Function(t)t.TaskId = taskId)
        End Function
        
        ''' <summary>
        ''' Gets a query for <see cref="Tracker.Core.Data.TaskExtended"/>.
        ''' </summary>
        ''' <param name="queryable">Query to append where clause.</param>
        ''' <param name="taskId">TaskId to search for.</param>
        ''' <param name="additionalValues">Additional values to search for.</param>
        ''' <returns>IQueryable with additional where clause.</returns>
        <System.Runtime.CompilerServices.Extension> _
        Public Function ByTaskId(queryable As IQueryable(Of Tracker.Core.Data.TaskExtended), taskId As Integer, ParamArray additionalValues As Integer()) As IQueryable(Of Tracker.Core.Data.TaskExtended)
            Dim TaskIdList = New List(Of Integer)()
            TaskIdList.Add(taskId)
        
            If additionalValues IsNot Nothing Then
                TaskIdList.AddRange(additionalValues)
            End If
        
            If TaskIdList.Count = 1 Then
                Return queryable.ByTaskId(TaskIdList(0))
            End If
        
            Dim expression = DynamicExpression.BuildExpression(Of Tracker.Core.Data.TaskExtended, Boolean)("TaskId", TaskIdList)
            Return queryable.Where(expression)
        End Function

        ''' <summary>
        ''' Gets a query for <see cref="Tracker.Core.Data.TaskExtended"/>.
        ''' </summary>
        ''' <param name="queryable">Query to append where clause.</param>
        ''' <param name="browser">Browser to search for.</param>
        ''' <returns>IQueryable with additional where clause.</returns>
        <System.Runtime.CompilerServices.Extension> _
        Public Function ByBrowser(queryable As IQueryable(Of Tracker.Core.Data.TaskExtended), browser As String) As IQueryable(Of Tracker.Core.Data.TaskExtended)
            Return queryable.Where(Function(t) Object.Equals(t.Browser, browser))
        End Function
        
        ''' <summary>
        ''' Gets a query for <see cref="Tracker.Core.Data.TaskExtended"/>.
        ''' </summary>
        ''' <param name="queryable">Query to append where clause.</param>
        ''' <param name="browser">Browser to search for.</param>
        ''' <param name="additionalValues">Additional values to search for.</param>
        ''' <returns>IQueryable with additional where clause.</returns>
        <System.Runtime.CompilerServices.Extension> _
        Public Function ByBrowser(queryable As IQueryable(Of Tracker.Core.Data.TaskExtended), browser As String, ParamArray additionalValues As String()) As IQueryable(Of Tracker.Core.Data.TaskExtended)
            Dim BrowserList = New List(Of String)()
            BrowserList.Add(browser)
        
            If additionalValues IsNot Nothing Then
                BrowserList.AddRange(additionalValues)
            Else
                BrowserList.Add(Nothing)
            End If
        
            If BrowserList.Count = 1 Then
                Return queryable.ByBrowser(BrowserList(0))
            End If
        
            Dim expression = DynamicExpression.BuildExpression(Of Tracker.Core.Data.TaskExtended, Boolean)("Browser", BrowserList)
            Return queryable.Where(expression)
        End Function

        ''' <summary>
        ''' Gets a query for <see cref="Tracker.Core.Data.TaskExtended"/>.
        ''' </summary>
        ''' <param name="queryable">Query to append where clause.</param>
        ''' <param name="os">Os to search for.</param>
        ''' <returns>IQueryable with additional where clause.</returns>
        <System.Runtime.CompilerServices.Extension> _
        Public Function ByOs(queryable As IQueryable(Of Tracker.Core.Data.TaskExtended), os As String) As IQueryable(Of Tracker.Core.Data.TaskExtended)
            Return queryable.Where(Function(t) Object.Equals(t.Os, os))
        End Function
        
        ''' <summary>
        ''' Gets a query for <see cref="Tracker.Core.Data.TaskExtended"/>.
        ''' </summary>
        ''' <param name="queryable">Query to append where clause.</param>
        ''' <param name="os">Os to search for.</param>
        ''' <param name="additionalValues">Additional values to search for.</param>
        ''' <returns>IQueryable with additional where clause.</returns>
        <System.Runtime.CompilerServices.Extension> _
        Public Function ByOs(queryable As IQueryable(Of Tracker.Core.Data.TaskExtended), os As String, ParamArray additionalValues As String()) As IQueryable(Of Tracker.Core.Data.TaskExtended)
            Dim OsList = New List(Of String)()
            OsList.Add(os)
        
            If additionalValues IsNot Nothing Then
                OsList.AddRange(additionalValues)
            Else
                OsList.Add(Nothing)
            End If
        
            If OsList.Count = 1 Then
                Return queryable.ByOs(OsList(0))
            End If
        
            Dim expression = DynamicExpression.BuildExpression(Of Tracker.Core.Data.TaskExtended, Boolean)("Os", OsList)
            Return queryable.Where(expression)
        End Function

        ''' <summary>
        ''' Gets a query for <see cref="Tracker.Core.Data.TaskExtended"/>.
        ''' </summary>
        ''' <param name="queryable">Query to append where clause.</param>
        ''' <param name="createdDate">CreatedDate to search for.</param>
        ''' <returns>IQueryable with additional where clause.</returns>
        <System.Runtime.CompilerServices.Extension> _
        Public Function ByCreatedDate(queryable As IQueryable(Of Tracker.Core.Data.TaskExtended), createdDate As Date) As IQueryable(Of Tracker.Core.Data.TaskExtended)
            Return queryable.Where(Function(t)t.CreatedDate = createdDate)
        End Function
        
        ''' <summary>
        ''' Gets a query for <see cref="Tracker.Core.Data.TaskExtended"/>.
        ''' </summary>
        ''' <param name="queryable">Query to append where clause.</param>
        ''' <param name="createdDate">CreatedDate to search for.</param>
        ''' <param name="additionalValues">Additional values to search for.</param>
        ''' <returns>IQueryable with additional where clause.</returns>
        <System.Runtime.CompilerServices.Extension> _
        Public Function ByCreatedDate(queryable As IQueryable(Of Tracker.Core.Data.TaskExtended), createdDate As Date, ParamArray additionalValues As Date()) As IQueryable(Of Tracker.Core.Data.TaskExtended)
            Dim CreatedDateList = New List(Of Date)()
            CreatedDateList.Add(createdDate)
        
            If additionalValues IsNot Nothing Then
                CreatedDateList.AddRange(additionalValues)
            End If
        
            If CreatedDateList.Count = 1 Then
                Return queryable.ByCreatedDate(CreatedDateList(0))
            End If
        
            Dim expression = DynamicExpression.BuildExpression(Of Tracker.Core.Data.TaskExtended, Boolean)("CreatedDate", CreatedDateList)
            Return queryable.Where(expression)
        End Function

        ''' <summary>
        ''' Gets a query for <see cref="Tracker.Core.Data.TaskExtended"/>.
        ''' </summary>
        ''' <param name="queryable">Query to append where clause.</param>
        ''' <param name="modifiedDate">ModifiedDate to search for.</param>
        ''' <returns>IQueryable with additional where clause.</returns>
        <System.Runtime.CompilerServices.Extension> _
        Public Function ByModifiedDate(queryable As IQueryable(Of Tracker.Core.Data.TaskExtended), modifiedDate As Date) As IQueryable(Of Tracker.Core.Data.TaskExtended)
            Return queryable.Where(Function(t)t.ModifiedDate = modifiedDate)
        End Function
        
        ''' <summary>
        ''' Gets a query for <see cref="Tracker.Core.Data.TaskExtended"/>.
        ''' </summary>
        ''' <param name="queryable">Query to append where clause.</param>
        ''' <param name="modifiedDate">ModifiedDate to search for.</param>
        ''' <param name="additionalValues">Additional values to search for.</param>
        ''' <returns>IQueryable with additional where clause.</returns>
        <System.Runtime.CompilerServices.Extension> _
        Public Function ByModifiedDate(queryable As IQueryable(Of Tracker.Core.Data.TaskExtended), modifiedDate As Date, ParamArray additionalValues As Date()) As IQueryable(Of Tracker.Core.Data.TaskExtended)
            Dim ModifiedDateList = New List(Of Date)()
            ModifiedDateList.Add(modifiedDate)
        
            If additionalValues IsNot Nothing Then
                ModifiedDateList.AddRange(additionalValues)
            End If
        
            If ModifiedDateList.Count = 1 Then
                Return queryable.ByModifiedDate(ModifiedDateList(0))
            End If
        
            Dim expression = DynamicExpression.BuildExpression(Of Tracker.Core.Data.TaskExtended, Boolean)("ModifiedDate", ModifiedDateList)
            Return queryable.Where(expression)
        End Function

        'Insert User Defined Extensions here.
        'Anything outside of this Region will be lost at regeneration
        #Region "User Extensions"


        #End Region

        #Region "Query"
        ''' <summary>
        ''' A private class for lazy loading static compiled queries.
        ''' </summary>
        Private Partial Class Query


            Friend Shared ReadOnly GetByKey As Func(Of TrackerDataContext, Integer, Tracker.Core.Data.TaskExtended) = _
                CompiledQuery.Compile( _
                    Function(db As TrackerDataContext , ByVal taskId As Integer) _
                        db.TaskExtended.FirstOrDefault(Function(t)t.TaskId = taskId))

            ' Add your compiled queries here.
            'Anything outside of this Region will be lost at regeneration
            #Region "User Queries"

            #End Region

        End Class
        #End Region
    End Module
End Namespace

