'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.0, CSLA Framework: v3.8.0.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'CategoryList.vb.
'
'     Template: EditableRootList.DataAccess.ParameterizedSQL.cst
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

Public Partial Class CategoryList

    Private Shadows Sub DataPortal_Fetch(ByVal criteria As CategoryCriteria)
        RaiseListChangedEvents = False

        Dim cancel As Boolean = False
        OnFetching(criteria, cancel)
        If (cancel) Then
            Return
        End If

        ' Fetch Child objects.
        Dim commandText As String = String.Format("SELECT [CategoryId], [Name], [Descn] FROM [dbo].[Category] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag))
        Using connection As New SqlConnection(ADOHelper.ConnectionString)
            connection.Open()
            Using command As New SqlCommand(commandText, connection)
                command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                    If reader.Read() Then
                        Do
                            Me.Add(New Category(reader))
                        Loop While reader.Read()
                    Else
                        Throw New Exception(String.Format("The record was not found in 'Category' using the following criteria: {0}.", criteria))
                    End If
                End Using
            End Using
        End Using

        OnFetched()

        RaiseListChangedEvents = True
    End Sub
    
    #Region "Data access partial methods"

    Partial Private Sub OnCreating(ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnFetching(ByVal criteria As CategoryCriteria, ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnFetched()
    End Sub
    
    #End Region
End Class