﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v6.5.0, CSLA Templates: v4.0.0.0, CSLA Framework: v4.3.10.
'     Changes to Me file will be lost after each regeneration.
'
'     Template: ExistsCommand.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System
Imports Csla
Imports Csla.Core
Imports Csla.Serialization.Mobile

#If SILVERLIGHT Then
Imports Csla.Serialization
#Else
Imports System.Data.SqlClient
Imports Csla.Data
#End If

Namespace PetShop.Business
    <Serializable()> _
    Public Class ExistsCommand
        Inherits CommandBase(Of ExistsCommand)
    
#Region "Constructor(s)"

        Public Sub New()
        End Sub

#End Region
    
#Region "Authorization Methods"
    
        Public Shared Function CanExecuteCommand() As Boolean
            Return True
        End Function
    
#End Region

#Region "Client-side Code"
    
        Private _criteria As IGeneratedCriteria
        Private Property Criteria() As IGeneratedCriteria
           
        Get
                Return _criteria
            End Get
            Set(ByVal value As IGeneratedCriteria)
                _criteria = value
            End Set
        End Property
    
        Private _result As Boolean
        Public Property Result() As Boolean
            Get
                Return _result
            End Get
            Private Set(ByVal value As Boolean)
                _result = value
            End Set
        End Property
    
        Private Sub BeforeServer(ByVal criteria As IGeneratedCriteria)
            Me.Criteria = criteria
            Me.Result = False
        End Sub
    
        Private Sub AfterServer()
        End Sub
    
#End Region

#Region "Factory Methods"
#If Not SILVERLIGHT Then

        Public Shared Function Execute(Of T As IGeneratedCriteria)(ByVal criteria As T) As Boolean
            If Not CanExecuteCommand() Then
                Throw New System.Security.SecurityException("Not authorized to execute command")
            End If
    
            Dim cmd As New ExistsCommand()
            cmd.BeforeServer(criteria)
            cmd = DataPortal.Execute(cmd)
            cmd.AfterServer()
    
            Return cmd.Result
        End Function
#End If

        Public Shared Sub ExecuteAsync(Of T As IGeneratedCriteria)(ByVal criteria As T, ByVal handler As EventHandler(Of DataPortalResult(Of ExistsCommand)))
            If Not CanExecuteCommand() Then
                Throw New System.Security.SecurityException("Not authorized to execute command")
            End If

            Dim cmd As New ExistsCommand()
            cmd.BeforeServer(criteria)

            Dim dp As New DataPortal(Of ExistsCommand)() 
            AddHandler dp.ExecuteCompleted, handler
            dp.BeginExecute(cmd)
        End Sub

#End Region

#If Not SILVERLIGHT Then
	
#Region "Data Access"

        Protected Overloads Overrides Sub DataPortal_Execute()
            Dim commandText As String = String.Format("SELECT COUNT(1) FROM {0} {1}", Criteria.TableFullName, ADOHelper.BuildWhereStatement(Criteria.StateBag))
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand(commandText, connection)
                    command.Parameters.AddRange(ADOHelper.SqlParameters(Criteria.StateBag))
                    Result = (CInt(command.ExecuteScalar()) > 0)
                End Using
            End Using
        End Sub

#End Region

#Region "Serialization"

        Protected Overrides Sub OnGetState(info As SerializationInfo, mode As StateMode)
            MyBase.OnGetState(info, mode)
            info.AddValue("Result", Result)
        End Sub

        Protected Overrides Sub OnSetState(info As SerializationInfo, mode As StateMode)
            MyBase.OnSetState(info, mode)
            Result = info.GetValue(Of Boolean)("Result")
        End Sub

        Protected Overrides Sub OnGetChildren(info As SerializationInfo, formatter As MobileFormatter)
            Dim serializedCriteria As SerializationInfo = formatter.SerializeObject(Criteria)
            info.AddChild("Criteria", 2)
        End Sub

        Protected Overrides Sub OnSetChildren(info As SerializationInfo, formatter As MobileFormatter)
            Dim criteriaData As SerializationInfo.ChildData = info.Children("Criteria")
            Criteria = DirectCast(formatter.GetObject(criteriaData.ReferenceId), IGeneratedCriteria)
        End Sub
#End Region

#End If
    End Class
End Namespace