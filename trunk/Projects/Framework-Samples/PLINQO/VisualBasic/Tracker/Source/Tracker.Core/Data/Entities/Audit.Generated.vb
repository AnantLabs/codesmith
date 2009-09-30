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
    ''' The class representing the dbo.Audit table.
    ''' </summary>
    <System.Data.Linq.Mapping.Table(Name:="dbo.Audit")> _
    <System.Runtime.Serialization.DataContract(IsReference:=True)> _
    <System.ComponentModel.DataAnnotations.ScaffoldTable(True)> _
    <System.ComponentModel.DataAnnotations.MetadataType(GetType(Audit.Metadata))> _
    <System.Data.Services.Common.DataServiceKey("Id")> _
    <System.Diagnostics.DebuggerDisplay("Id: {Id}")> _
    Partial Public Class Audit
        Inherits LinqEntityBase
        Implements ICloneable

#Region "Static Constructor"
        ''' <summary>
        ''' Initializes the <see cref="Audit"/> class.
        ''' </summary>
        Shared Sub New()
            CodeSmith.Data.Rules.RuleManager.AddShared(Of Audit)()
            AddSharedRules()
        End Sub
#End Region

#Region "Default Constructor"
        ''' <summary>
        ''' Initializes a new instance of the <see cref="Audit"/> class.
        ''' </summary>
        <System.Diagnostics.DebuggerNonUserCode()> _
        Public Sub New()
            Initialize()
        End Sub

        Private Sub Initialize()
            _task = Nothing
            _user = Nothing
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

        Private _date As Date

        ''' <summary>
        ''' Gets or sets the Date column value.
        ''' </summary>
        <System.Data.Linq.Mapping.Column(Name:="Date", Storage:="_date", DbType:="datetime NOT NULL", CanBeNull:=False, UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never)> _
        <System.Runtime.Serialization.DataMember(Order:=2)> _
        Public Property [Date]() As Date
            Get
                Return _date
            End Get
            Set(ByVal value As Date)
                If ((Me._date = value) = False) Then
                    OnDateChanging(value)
                    SendPropertyChanging("Date")
                    _date = value
                    SendPropertyChanged("Date")
                    OnDateChanged()
                End If
            End Set
        End Property

        Private _userId As Nullable(Of Integer)

        ''' <summary>
        ''' Gets or sets the UserId column value.
        ''' </summary>
        <System.Data.Linq.Mapping.Column(Name:="UserId", Storage:="_userId", DbType:="int", UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never)> _
        <System.Runtime.Serialization.DataMember(Order:=3)> _
        Public Property UserId() As Nullable(Of Integer)
            Get
                Return _userId
            End Get
            Set(ByVal value As Nullable(Of Integer))
                If (Me._userId.Equals(value) = False) Then
                    If (_user.HasLoadedOrAssignedValue) Then
                        Throw New System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException()
                    End If
                    OnUserIdChanging(value)
                    SendPropertyChanging("UserId")
                    _userId = value
                    SendPropertyChanged("UserId")
                    OnUserIdChanged()
                End If
            End Set
        End Property

        Private _taskId As Nullable(Of Integer)

        ''' <summary>
        ''' Gets or sets the TaskId column value.
        ''' </summary>
        <System.Data.Linq.Mapping.Column(Name:="TaskId", Storage:="_taskId", DbType:="int", UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never)> _
        <System.Runtime.Serialization.DataMember(Order:=4)> _
        Public Property TaskId() As Nullable(Of Integer)
            Get
                Return _taskId
            End Get
            Set(ByVal value As Nullable(Of Integer))
                If (Me._taskId.Equals(value) = False) Then
                    If (_task.HasLoadedOrAssignedValue) Then
                        Throw New System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException()
                    End If
                    OnTaskIdChanging(value)
                    SendPropertyChanging("TaskId")
                    _taskId = value
                    SendPropertyChanged("TaskId")
                    OnTaskIdChanged()
                End If
            End Set
        End Property

        Private _content As String

        ''' <summary>
        ''' Gets or sets the Content column value.
        ''' </summary>
        <System.Data.Linq.Mapping.Column(Name:="Content", Storage:="_content", DbType:="varchar(MAX) NOT NULL", CanBeNull:=False, UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never)> _
        <System.Runtime.Serialization.DataMember(Order:=5)> _
        Public Property Content() As String
            Get
                Return _content
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._content, value) = False) Then
                    OnContentChanging(value)
                    SendPropertyChanging("Content")
                    _content = value
                    SendPropertyChanged("Content")
                    OnContentChanged()
                End If
            End Set
        End Property

        Private _username As String

        ''' <summary>
        ''' Gets or sets the Username column value.
        ''' </summary>
        <System.Data.Linq.Mapping.Column(Name:="Username", Storage:="_username", DbType:="nvarchar(50) NOT NULL", CanBeNull:=False, UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never)> _
        <ComponentModel.DataAnnotations.StringLength(50)> _
        <System.Runtime.Serialization.DataMember(Order:=6)> _
        Public Property Username() As String
            Get
                Return _username
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._username, value) = False) Then
                    OnUsernameChanging(value)
                    SendPropertyChanging("Username")
                    _username = value
                    SendPropertyChanged("Username")
                    OnUsernameChanged()
                End If
            End Set
        End Property

        Private _createdDate As Date

        ''' <summary>
        ''' Gets or sets the CreatedDate column value.
        ''' </summary>
        <System.Data.Linq.Mapping.Column(Name:="CreatedDate", Storage:="_createdDate", DbType:="datetime NOT NULL", CanBeNull:=False, UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never)> _
        <System.Runtime.Serialization.DataMember(Order:=7)> _
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

        Private _rowVersion As System.Data.Linq.Binary = Nothing

        ''' <summary>
        ''' Gets the RowVersion column value.
        ''' </summary>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        <System.Data.Linq.Mapping.Column(Name:="RowVersion", Storage:="_rowVersion", DbType:="timestamp NOT NULL", IsDbGenerated:=True, IsVersion:=True, CanBeNull:=False, UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never)> _
        <System.Runtime.Serialization.DataMember(Order:=8)> _
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

        Private _myxml As String

        ''' <summary>
        ''' Gets or sets the myxml column value.
        ''' </summary>
        <System.Data.Linq.Mapping.Column(Name:="myxml", Storage:="_myxml", DbType:="xml", UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never)> _
        <System.Runtime.Serialization.DataMember(Order:=9)> _
        Public Property Myxml() As String
            Get
                Return _myxml
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._myxml, value) = False) Then
                    OnMyxmlChanging(value)
                    SendPropertyChanging("Myxml")
                    _myxml = value
                    SendPropertyChanged("Myxml")
                    OnMyxmlChanged()
                End If
            End Set
        End Property
#End Region

#Region "Association Mapped Properties"

        Private  _task As System.Data.Linq.EntityRef(Of Task)

        ''' <summary>
        ''' Gets or sets the Task association.
        ''' </summary>
        <System.Data.Linq.Mapping.Association(Name:="Task_Audit", Storage:="_task", ThisKey:="TaskId", OtherKey:="Id", IsUnique:=true, IsForeignKey:=true)> _
        <System.Runtime.Serialization.DataMember(Order:=10, EmitDefaultValue:=False)> _
        Public Property Task() As Task
            Get
                If (serializing AndAlso Not _task.HasLoadedOrAssignedValue) Then
                    Return Nothing
                Else
                    Return _task.Entity
                End If
            End Get
            Set(ByVal value As Task)
                Dim previousValue As Task = _task.Entity
                If ((Object.Equals(previousValue, value) = False) OrElse (Me._task.HasLoadedOrAssignedValue = False)) Then
                    SendPropertyChanging("Task")
                    If ((previousValue Is Nothing) = False) Then
                        _task.Entity = Nothing
                        previousValue.AuditList.Remove(Me)
                    End If
                    _task.Entity = value
                    If ((value Is Nothing) = False) Then
                        value.AuditList.Add(Me)
                        _taskId = value.Id
                    Else
                        _taskId = Nothing
                    End If
                    SendPropertyChanged("Task")
                End If
            End Set
        End Property
        Private  _user As System.Data.Linq.EntityRef(Of User)

        ''' <summary>
        ''' Gets or sets the User association.
        ''' </summary>
        <System.Data.Linq.Mapping.Association(Name:="User_Audit", Storage:="_user", ThisKey:="UserId", OtherKey:="Id", IsUnique:=true, IsForeignKey:=true)> _
        <System.Runtime.Serialization.DataMember(Order:=11, EmitDefaultValue:=False)> _
        Public Property User() As User
            Get
                If (serializing AndAlso Not _user.HasLoadedOrAssignedValue) Then
                    Return Nothing
                Else
                    Return _user.Entity
                End If
            End Get
            Set(ByVal value As User)
                Dim previousValue As User = _user.Entity
                If ((Object.Equals(previousValue, value) = False) OrElse (Me._user.HasLoadedOrAssignedValue = False)) Then
                    SendPropertyChanging("User")
                    If ((previousValue Is Nothing) = False) Then
                        _user.Entity = Nothing
                        previousValue.AuditList.Remove(Me)
                    End If
                    _user.Entity = value
                    If ((value Is Nothing) = False) Then
                        value.AuditList.Add(Me)
                        _userId = value.Id
                    Else
                        _userId = Nothing
                    End If
                    SendPropertyChanged("User")
                End If
            End Set
        End Property
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
        ''' <summary>Called when Date is changing.</summary>
        ''' <param name="value">The new value.</param>
        Partial Private Sub OnDateChanging(ByVal value As Date)
        End Sub
        ''' <summary>Called after Date has Changed.</summary>
        Partial Private Sub OnDateChanged()
        End Sub
        ''' <summary>Called when UserId is changing.</summary>
        ''' <param name="value">The new value.</param>
        Partial Private Sub OnUserIdChanging(ByVal value As Nullable(Of Integer))
        End Sub
        ''' <summary>Called after UserId has Changed.</summary>
        Partial Private Sub OnUserIdChanged()
        End Sub
        ''' <summary>Called when TaskId is changing.</summary>
        ''' <param name="value">The new value.</param>
        Partial Private Sub OnTaskIdChanging(ByVal value As Nullable(Of Integer))
        End Sub
        ''' <summary>Called after TaskId has Changed.</summary>
        Partial Private Sub OnTaskIdChanged()
        End Sub
        ''' <summary>Called when Content is changing.</summary>
        ''' <param name="value">The new value.</param>
        Partial Private Sub OnContentChanging(ByVal value As String)
        End Sub
        ''' <summary>Called after Content has Changed.</summary>
        Partial Private Sub OnContentChanged()
        End Sub
        ''' <summary>Called when Username is changing.</summary>
        ''' <param name="value">The new value.</param>
        Partial Private Sub OnUsernameChanging(ByVal value As String)
        End Sub
        ''' <summary>Called after Username has Changed.</summary>
        Partial Private Sub OnUsernameChanged()
        End Sub
        ''' <summary>Called when CreatedDate is changing.</summary>
        ''' <param name="value">The new value.</param>
        Partial Private Sub OnCreatedDateChanging(ByVal value As Date)
        End Sub
        ''' <summary>Called after CreatedDate has Changed.</summary>
        Partial Private Sub OnCreatedDateChanged()
        End Sub
        ''' <summary>Called when RowVersion is changing.</summary>
        ''' <param name="value">The new value.</param>
        Partial Private Sub OnRowVersionChanging(ByVal value As System.Data.Linq.Binary)
        End Sub
        ''' <summary>Called after RowVersion has Changed.</summary>
        Partial Private Sub OnRowVersionChanged()
        End Sub
        ''' <summary>Called when Myxml is changing.</summary>
        ''' <param name="value">The new value.</param>
        Partial Private Sub OnMyxmlChanging(ByVal value As String)
        End Sub
        ''' <summary>Called after Myxml has Changed.</summary>
        Partial Private Sub OnMyxmlChanged()
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
        ''' Deserializes an instance of <see cref="Audit"/> from XML.
        ''' </summary>
        ''' <param name="xml">The XML string representing a <see cref="Audit"/> instance.</param>
        ''' <returns>An instance of <see cref="Audit"/> that is deserialized from the XML string.</returns>
        Public Shared Function FromXml(ByVal xml As String) As Audit
            Dim deserializer = New System.Runtime.Serialization.DataContractSerializer(GetType(Audit))
            
            Using sr = New System.IO.StringReader(xml)
                Using reader = System.Xml.XmlReader.Create(sr)
                    Return TryCast(deserializer.ReadObject(reader), Audit)
                End Using
            End Using
        End Function

        ''' <summary>
        ''' Deserializes an instance of <see cref="Audit"/>.
        ''' </summary>
        ''' <param name="buffer">The byte array representing a <see cref="Audit"/> instance.</param>
        ''' <returns>An instance of <see cref="Audit"/> that is deserialized from the byte array.</returns>
        Public Shared Function FromBinary(ByVal buffer As Byte()) As Audit
            Dim deserializer = New System.Runtime.Serialization.DataContractSerializer(GetType(Audit))

            Using ms = New System.IO.MemoryStream(buffer)
                Using reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max)
                    Return TryCast(deserializer.ReadObject(reader), Audit)
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
        Public Function Clone() As Audit
            Return DirectCast(DirectCast(Me, ICloneable), Audit).Clone()
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
            _task = Detach(_task)
            _user = Detach(_user)
        End Sub
#End Region
    End Class
End Namespace

