﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v6.5.0, CSLA Templates: v4.0.0.0, CSLA Framework: v4.3.10.
'     Changes to this template will not be lost.
'
'     Template: AsyncChildLoader.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Imports Csla
Imports Csla.Serialization

Namespace PetShop.Tests.ParameterizedSQL
    <Serializable> _
    <System.Runtime.InteropServices.ComVisible(False)> _
    Public Class AsyncChildLoader(Of T)
        Inherits ReadOnlyBase(Of AsyncChildLoader(Of T))
        Public Shared ChildProperty As PropertyInfo(Of T) = RegisterProperty(Of T)(Function(c) c.Child)
        Public Property Child() As T
            Get
                Return ReadProperty(ChildProperty)
            End Get
            Private Set
                LoadProperty(ChildProperty, value)
            End Set
        End Property

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Object)
            Child = DataPortal.FetchChild(Of T)(criteria)
        End Sub
    End Class
End Namespace