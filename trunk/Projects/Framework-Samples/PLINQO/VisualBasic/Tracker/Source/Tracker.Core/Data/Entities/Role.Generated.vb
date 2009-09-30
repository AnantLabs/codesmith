﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a CodeSmith Template.
'
'     DO Not MODIfY contents of this file. Changes to this
'     file will be lost if the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------
Imports System
Imports System.Linq

Namespace Tracker.Core.Data
    ''' <summary>
    ''' The class representing the dbo.Role table.
    ''' </summary>
    <System.Data.Linq.Mapping.Table(Name:="dbo.Role")> _
    <System.Runtime.Serialization.DataContract(IsReference:=True)> _
    <System.ComponentModel.DataAnnotations.ScaffoldTable(True)> _
    <System.ComponentModel.DataAnnotations.MetadataType(GetType(Role.Metadata))> _
    <System.Data.Services.Common.DataServiceKey("Id")> _
    <System.Diagnostics.DebuggerDisplay("Id: {Id}")> _
    Partial Public Class Role
        Inherits LinqEntityBase
        Implements ICloneable

#Region "Static Constructor"
        ''' <summary>
        ''' Initializes the <see cref="Role"/> class.
        ''' </summary>
        Shared Sub New()
            CodeSmith.Data.Rules.RuleManager.AddShared(Of Role)()
            AddSharedRules()
        End Sub
#End Region

#Region "Default Constructor"
        ''' <summary>
        ''' Initializes a new instance of the <see cref="Role"/> class.
        ''' </summary>
        <System.Diagnostics.DebuggerNonUserCode()> _
        Public Sub New()
            Initialize()
        End Sub

        Private Sub Initialize()
            _userRoleList = New System.Data.Linq.EntitySet(Of UserRole)( _
                New System.Action(Of UserRole)(AddressOf Me.OnUserRoleListAdd), _
                New System.Action(Of UserRole)(AddressOf Me.OnUserRoleListRemove))
            OnCreated()
        End Sub
#End Region

#Region "Column Mapped Properties"

        Private _id As Integer = Nothing

        ''' <summary>
        ''' Gets the Id column value.
        ''' </summary>
        <System.Data.Linq.Mapping.Column(Name:="Id", Storage:="_id", DbType:="int NOT NULL IDENTITY", IsPrimaryKey:=True, IsDbGenerated:=True, CanBeNull:=False, UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never)> _
        <System.Runtime.Serialization.DataMember(Order:=1)> _
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                If ((Me._id = value) = False) Then
                    OnIdChanging(value)
                    SendPropertyChanging("Id")
                    _id = value
                    SendPropertyChanged("Id")
                    OnIdChanged()
                End If
            End Set
        End Property

        Private _name As String

        ''' <summary>
        ''' Gets or sets the Name column value.
        ''' </summary>
        <System.Data.Linq.Mapping.Column(Name:="Name", Storage:="_name", DbType:="nvarchar(50) NOT NULL", CanBeNull:=False, UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never)> _
        <ComponentModel.DataAnnotations.StringLength(50)> _
        <System.Runtime.Serialization.DataMember(Order:=2)> _
        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._name, value) = False) Then
                    OnNameChanging(value)
                    SendPropertyChanging("Name")
                    _name = value
                    SendPropertyChanged("Name")
                    OnNameChanged()
                End If
            End Set
        End Property

        Private _description As String

        ''' <summary>
        ''' Gets or sets the Description column value.
        ''' </summary>
        <System.Data.Linq.Mapping.Column(Name:="Description", Storage:="_description", DbType:="nvarchar(150)", UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never)> _
        <ComponentModel.DataAnnotations.StringLength(150)> _
        <System.Runtime.Serialization.DataMember(Order:=3)> _
        Public Property Description() As String
            Get
                Return _description
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._description, value) = False) Then
                    OnDescriptionChanging(value)
                    SendPropertyChanging("Description")
                    _description = value
                    SendPropertyChanged("Description")
                    OnDescriptionChanged()
                End If
            End Set
        End Property

        Private _createdDate As Date

        ''' <summary>
        ''' Gets or sets the CreatedDate column value.
        ''' </summary>
        <System.Data.Linq.Mapping.Column(Name:="CreatedDate", Storage:="_createdDate", DbType:="datetime NOT NULL", CanBeNull:=False, UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never)> _
        <System.Runtime.Serialization.DataMember(Order:=4)> _
        Public Property CreatedDate() As Date
            Get
                Return _createdDate
            End Get
            Set(ByVal value As Date)
                If ((Me._createdDate = value) = False) Then
                    OnCreatedDateChanging(value)
                    SendPropertyChanging("CreatedDate")
                    _createdDate = value
                    SendPropertyChanged("CreatedDate")
                    OnCreatedDateChanged()
                End If
            End Set
        End Property

        Private _modifiedDate As Date

        ''' <summary>
        ''' Gets or sets the ModifiedDate column value.
        ''' </summary>
        <System.Data.Linq.Mapping.Column(Name:="ModifiedDate", Storage:="_modifiedDate", DbType:="datetime NOT NULL", CanBeNull:=False, UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never)> _
        <System.Runtime.Serialization.DataMember(Order:=5)> _
        Public Property ModifiedDate() As Date
            Get
                Return _modifiedDate
            End Get
            Set(ByVal value As Date)
                If ((Me._modifiedDate = value) = False) Then
                    OnModifiedDateChanging(value)
                    SendPropertyChanging("ModifiedDate")
                    _modifiedDate = value
                    SendPropertyChanged("ModifiedDate")
                    OnModifiedDateChanged()
                End If
            End Set
        End Property

        Private _rowVersion As System.Data.Linq.Binary = Nothing

        ''' <summary>
        ''' Gets the RowVersion column value.
        ''' </summary>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        <System.Data.Linq.Mapping.Column(Name:="RowVersion", Storage:="_rowVersion", DbType:="timestamp NOT NULL", IsDbGenerated:=True, IsVersion:=True, CanBeNull:=False, UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never)> _
        <System.Runtime.Serialization.DataMember(Order:=6)> _
        Public Property RowVersion() As System.Data.Linq.Binary
            Get
                Return _rowVersion
            End Get
            Set(ByVal value As System.Data.Linq.Binary)
                If (Object.Equals(Me._rowVersion, value) = False) Then
                    OnRowVersionChanging(value)
                    SendPropertyChanging("RowVersion")
                    _rowVersion = value
                    SendPropertyChanged("RowVersion")
                    OnRowVersionChanged()
                End If
            End Set
        End Property
#End Region

#Region "Association Mapped Properties"


        Private _userRoleList As System.Data.Linq.EntitySet(Of UserRole)

        ''' <summary>
        ''' Gets or sets the UserRole association.
        ''' </summary>
        <System.Data.Linq.Mapping.Association(Name:="Role_UserRole", Storage:="_userRoleList", ThisKey:="Id", OtherKey:="RoleId")> _
        <System.Runtime.Serialization.DataMember(Order:=7, EmitDefaultValue:=False)> _
        Public Property UserRoleList() As System.Data.Linq.EntitySet(Of UserRole)
            Get
                If (serializing AndAlso Not _userRoleList.HasLoadedOrAssignedValues) Then
                    Return Nothing
                Else
                    Return _userRoleList
                End If
            End Get
            Set(ByVal value As System.Data.Linq.EntitySet(Of UserRole))
                _userRoleList.Assign(value)
            End Set
        End Property

        <System.Diagnostics.DebuggerNonUserCode()> _
        Private Sub OnUserRoleListAdd(ByVal entity As UserRole)
            SendPropertyChanging(Nothing)
            entity.Role = Me
            SendPropertyChanged(Nothing)
        End Sub

        <System.Diagnostics.DebuggerNonUserCode()> _
        Private Sub OnUserRoleListRemove(ByVal entity As UserRole)
            SendPropertyChanging(Nothing)
            entity.Role = Nothing
            SendPropertyChanged(Nothing)
        End Sub


        Private _userList As System.Data.Linq.EntitySet(Of User)

        ''' <summary>
        ''' Gets or sets the Many To Many UserList list.
        ''' </summary>
        ''' <value>The UserList list.</value>
        Public Property UserList() As System.Data.Linq.EntitySet(Of User)

            Get
                If (serializing) Then
                    Return Nothing
                End If

                If (_userList Is Nothing) Then

                    _userList = New System.Data.Linq.EntitySet(Of User)(AddressOf OnUserListAdd, AddressOf OnUserListRemove)
                    _userList.SetSource(UserRoleList.Select(Function(c) c.User))
                End If
                Return _userList
            End Get
            Set(ByVal value As System.Data.Linq.EntitySet(Of User))

                _userList.Assign(value)
            End Set
        End Property

        <System.Diagnostics.DebuggerNonUserCode()> _
        Private Sub OnUserListAdd(ByVal entity As User)

            SendPropertyChanging(Nothing)
            UserRoleList.Add(New UserRole With {.Role = Me, .User = entity})
            SendPropertyChanged(Nothing)
        End Sub

        <System.Diagnostics.DebuggerNonUserCode()> _
        Private Sub OnUserListRemove(ByVal entity As User)

            SendPropertyChanging(Nothing)
            Dim userRole = UserRoleList.FirstOrDefault(Function(c) c.RoleId = Id AndAlso c.UserId = entity.Id)
            UserRoleList.Remove(userRole)
            SendPropertyChanged(Nothing)
        End Sub

#End Region

#Region "Extensibility Method Definitions"

        ''' <summary>Called by the Shared constructor to add shared rules.</summary>
        Partial Private Shared Sub AddSharedRules()
        End Sub
        ''' <summary>Called when this instance is loaded.</summary>
        Partial Private Sub OnLoaded()
        End Sub
        ''' <summary>Called when this instance is being saved.</summary>
        Partial Private Sub OnValidate(ByVal action As System.Data.Linq.ChangeAction)
        End Sub
        ''' <summary>Called when this instance is created.</summary>
        Partial Private Sub OnCreated()
        End Sub
        ''' <summary>Called when Id is changing.</summary>
        ''' <param name="value">The new value.</param>
        Partial Private Sub OnIdChanging(ByVal value As Integer)
        End Sub
        ''' <summary>Called after Id has Changed.</summary>
        Partial Private Sub OnIdChanged()
        End Sub
        ''' <summary>Called when Name is changing.</summary>
        ''' <param name="value">The new value.</param>
        Partial Private Sub OnNameChanging(ByVal value As String)
        End Sub
        ''' <summary>Called after Name has Changed.</summary>
        Partial Private Sub OnNameChanged()
        End Sub
        ''' <summary>Called when Description is changing.</summary>
        ''' <param name="value">The new value.</param>
        Partial Private Sub OnDescriptionChanging(ByVal value As String)
        End Sub
        ''' <summary>Called after Description has Changed.</summary>
        Partial Private Sub OnDescriptionChanged()
        End Sub
        ''' <summary>Called when CreatedDate is changing.</summary>
        ''' <param name="value">The new value.</param>
        Partial Private Sub OnCreatedDateChanging(ByVal value As Date)
        End Sub
        ''' <summary>Called after CreatedDate has Changed.</summary>
        Partial Private Sub OnCreatedDateChanged()
        End Sub
        ''' <summary>Called when ModifiedDate is changing.</summary>
        ''' <param name="value">The new value.</param>
        Partial Private Sub OnModifiedDateChanging(ByVal value As Date)
        End Sub
        ''' <summary>Called after ModifiedDate has Changed.</summary>
        Partial Private Sub OnModifiedDateChanged()
        End Sub
        ''' <summary>Called when RowVersion is changing.</summary>
        ''' <param name="value">The new value.</param>
        Partial Private Sub OnRowVersionChanging(ByVal value As System.Data.Linq.Binary)
        End Sub
        ''' <summary>Called after RowVersion has Changed.</summary>
        Partial Private Sub OnRowVersionChanged()
        End Sub
#End Region

#Region "Serialization"

        Private serializing As Boolean

        ''' <summary>
        ''' Called when serializing.
        ''' </summary>
        ''' <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"/> for the serialization.</param>
        <System.Runtime.Serialization.OnSerializing(), _
         System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub OnSerializing(ByVal context As System.Runtime.Serialization.StreamingContext)
            serializing = True
        End Sub

        ''' <summary>
        ''' Called when serializing.
        ''' </summary>
        ''' <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"/> for the serialization.</param>
        <System.Runtime.Serialization.OnSerialized(), _
         System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub OnSerialized(ByVal context As System.Runtime.Serialization.StreamingContext)
            serializing = False
        End Sub

        ''' <summary>
        ''' Called when deserializing.
        ''' </summary>
        ''' <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"/> for the serialization.</param>
        <System.Runtime.Serialization.OnDeserializing(), _
         System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub OnDeserializing(ByVal context As System.Runtime.Serialization.StreamingContext)
            Initialize()
        End Sub
        
        ''' <summary>
        ''' Deserializes an instance of <see cref="Role"/> from XML.
        ''' </summary>
        ''' <param name="xml">The XML string representing a <see cref="Role"/> instance.</param>
        ''' <returns>An instance of <see cref="Role"/> that is deserialized from the XML string.</returns>
        Public Shared Function FromXml(ByVal xml As String) As Role
            Dim deserializer = New System.Runtime.Serialization.DataContractSerializer(GetType(Role))
            
            Using sr = New System.IO.StringReader(xml)
                Using reader = System.Xml.XmlReader.Create(sr)
                    Return TryCast(deserializer.ReadObject(reader), Role)
                End Using
            End Using
        End Function

        ''' <summary>
        ''' Deserializes an instance of <see cref="Role"/>.
        ''' </summary>
        ''' <param name="buffer">The byte array representing a <see cref="Role"/> instance.</param>
        ''' <returns>An instance of <see cref="Role"/> that is deserialized from the byte array.</returns>
        Public Shared Function FromBinary(ByVal buffer As Byte()) As Role
            Dim deserializer = New System.Runtime.Serialization.DataContractSerializer(GetType(Role))

            Using ms = New System.IO.MemoryStream(buffer)
                Using reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max)
                    Return TryCast(deserializer.ReadObject(reader), Role)
                End Using
            End Using
        End Function
#End Region

#Region "Clone"
        ''' <summary>
        ''' Creates a new object that is a copy of the current instance.
        ''' </summary>
        ''' <returns>
        ''' A new object that is a copy of this instance.
        ''' </returns>
        Private Function ICloneable_Clone() As Object Implements ICloneable.Clone
            Dim serializer As New System.Runtime.Serialization.DataContractSerializer([GetType]())
            Using ms As New System.IO.MemoryStream()
                serializer.WriteObject(ms, Me)
                ms.Position = 0
                Return serializer.ReadObject(ms)
            End Using
        End Function

        ''' <summary>
        ''' Creates a new object that is a copy of the current instance.
        ''' </summary>
        ''' <returns>
        ''' A new object that is a copy of this instance.
        ''' </returns>
        ''' <remarks>
        ''' This method is equivalent to a Detach from the current <see cref="System.Data.Linq.DataContext"/>.
        ''' Only loaded EntityRef and EntitySet child accessions will be cloned.
        ''' </remarks>
        Public Function Clone() As Role
            Return DirectCast(DirectCast(Me, ICloneable), Role).Clone()
        End Function
#End Region

#Region "Detach Methods"
        ''' <summary>
        ''' Detach this instance from the <see cref="System.Data.Linq.DataContext"/>.
        ''' </summary>
        ''' <remarks>
        ''' Detaching the entity will allow it to be attached to another <see cref="System.Data.Linq.DataContext"/>.
        ''' </remarks>
        Public Overrides Sub Detach()

            If (Not IsAttached()) Then
                Return
            End If

            MyBase.Detach()
            _userRoleList = Detach(_userRoleList, AddressOf OnUserRoleListAdd, AddressOf OnUserRoleListRemove)
        End Sub
#End Region
    End Class
End Namespace

