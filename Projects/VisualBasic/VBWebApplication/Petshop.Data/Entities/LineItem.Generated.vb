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

Namespace Petshop.Data
    ''' <summary>
    ''' The class representing the dbo.LineItem table.
    ''' </summary>
    <System.Data.Linq.Mapping.Table(Name:="dbo.LineItem")> _
    <System.Runtime.Serialization.DataContract(IsReference:=True)> _
    <System.ComponentModel.DataAnnotations.ScaffoldTable(True)> _
    <System.ComponentModel.DataAnnotations.MetadataType(GetType(LineItem.Metadata))> _
    <System.Data.Services.Common.DataServiceKey("OrderId", "LineNum")> _
    <System.Diagnostics.DebuggerDisplay("OrderId: {OrderId}, LineNum: {LineNum}")> _
    Partial Public Class LineItem
        Inherits LinqEntityBase
        Implements ICloneable

#Region "Static Constructor"
        ''' <summary>
        ''' Initializes the <see cref="LineItem"/> class.
        ''' </summary>
        Shared Sub New()
            CodeSmith.Data.Rules.RuleManager.AddShared(Of LineItem)()
            AddSharedRules()
        End Sub
#End Region

#Region "Default Constructor"
        ''' <summary>
        ''' Initializes a new instance of the <see cref="LineItem"/> class.
        ''' </summary>
        <System.Diagnostics.DebuggerNonUserCode()> _
        Public Sub New()
            Initialize()
        End Sub

        Private Sub Initialize()
            _orders = Nothing
            OnCreated()
        End Sub
#End Region

#Region "Column Mapped Properties"

        Private _orderId As Integer

        ''' <summary>
        ''' Gets or sets the OrderId column value.
        ''' </summary>
        <System.Data.Linq.Mapping.Column(Name:="OrderId", Storage:="_orderId", DbType:="int NOT NULL", IsPrimaryKey:=True, CanBeNull:=False)> _
        <System.Runtime.Serialization.DataMember(Order:=1)> _
        Public Property OrderId() As Integer
            Get
                Return _orderId
            End Get
            Set(ByVal value As Integer)
                If ((Me._orderId = value) = False) Then
                    If (_orders.HasLoadedOrAssignedValue) Then
                        Throw New System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException()
                    End If
                    OnOrderIdChanging(value)
                    SendPropertyChanging("OrderId")
                    _orderId = value
                    SendPropertyChanged("OrderId")
                    OnOrderIdChanged()
                End If
            End Set
        End Property

        Private _lineNum As Integer

        ''' <summary>
        ''' Gets or sets the LineNum column value.
        ''' </summary>
        <System.Data.Linq.Mapping.Column(Name:="LineNum", Storage:="_lineNum", DbType:="int NOT NULL", IsPrimaryKey:=True, CanBeNull:=False)> _
        <System.Runtime.Serialization.DataMember(Order:=2)> _
        Public Property LineNum() As Integer
            Get
                Return _lineNum
            End Get
            Set(ByVal value As Integer)
                If ((Me._lineNum = value) = False) Then
                    OnLineNumChanging(value)
                    SendPropertyChanging("LineNum")
                    _lineNum = value
                    SendPropertyChanged("LineNum")
                    OnLineNumChanged()
                End If
            End Set
        End Property

        Private _itemId As String

        ''' <summary>
        ''' Gets or sets the ItemId column value.
        ''' </summary>
        <System.Data.Linq.Mapping.Column(Name:="ItemId", Storage:="_itemId", DbType:="varchar(10) NOT NULL", CanBeNull:=False)> _
        <ComponentModel.DataAnnotations.StringLength(10)> _
        <System.Runtime.Serialization.DataMember(Order:=3)> _
        Public Property ItemId() As String
            Get
                Return _itemId
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._itemId, value) = False) Then
                    OnItemIdChanging(value)
                    SendPropertyChanging("ItemId")
                    _itemId = value
                    SendPropertyChanged("ItemId")
                    OnItemIdChanged()
                End If
            End Set
        End Property

        Private _quantity As Integer

        ''' <summary>
        ''' Gets or sets the Quantity column value.
        ''' </summary>
        <System.Data.Linq.Mapping.Column(Name:="Quantity", Storage:="_quantity", DbType:="int NOT NULL", CanBeNull:=False)> _
        <System.Runtime.Serialization.DataMember(Order:=4)> _
        Public Property Quantity() As Integer
            Get
                Return _quantity
            End Get
            Set(ByVal value As Integer)
                If ((Me._quantity = value) = False) Then
                    OnQuantityChanging(value)
                    SendPropertyChanging("Quantity")
                    _quantity = value
                    SendPropertyChanged("Quantity")
                    OnQuantityChanged()
                End If
            End Set
        End Property

        Private _unitPrice As Decimal

        ''' <summary>
        ''' Gets or sets the UnitPrice column value.
        ''' </summary>
        <System.Data.Linq.Mapping.Column(Name:="UnitPrice", Storage:="_unitPrice", DbType:="decimal(10,2) NOT NULL", CanBeNull:=False)> _
        <System.Runtime.Serialization.DataMember(Order:=5)> _
        Public Property UnitPrice() As Decimal
            Get
                Return _unitPrice
            End Get
            Set(ByVal value As Decimal)
                If ((Me._unitPrice = value) = False) Then
                    OnUnitPriceChanging(value)
                    SendPropertyChanging("UnitPrice")
                    _unitPrice = value
                    SendPropertyChanged("UnitPrice")
                    OnUnitPriceChanged()
                End If
            End Set
        End Property
#End Region

#Region "Association Mapped Properties"

        Private  _orders As System.Data.Linq.EntityRef(Of Orders)

        ''' <summary>
        ''' Gets or sets the Orders association.
        ''' </summary>
        <System.Data.Linq.Mapping.Association(Name:="Orders_LineItem", Storage:="_orders", ThisKey:="OrderId", OtherKey:="OrderId", IsUnique:=true, IsForeignKey:=true, DeleteOnNull:=true)> _
        <System.Runtime.Serialization.DataMember(Order:=6, EmitDefaultValue:=False)> _
        Public Property Orders() As Orders
            Get
                If (serializing AndAlso Not _orders.HasLoadedOrAssignedValue) Then
                    Return Nothing
                Else
                    Return _orders.Entity
                End If
            End Get
            Set(ByVal value As Orders)
                Dim previousValue As Orders = _orders.Entity
                If ((Object.Equals(previousValue, value) = False) OrElse (Me._orders.HasLoadedOrAssignedValue = False)) Then
                    SendPropertyChanging("Orders")
                    If ((previousValue Is Nothing) = False) Then
                        _orders.Entity = Nothing
                        previousValue.LineItemList.Remove(Me)
                    End If
                    _orders.Entity = value
                    If ((value Is Nothing) = False) Then
                        value.LineItemList.Add(Me)
                        _orderId = value.OrderId
                    Else
                        _orderId = Nothing
                    End If
                    SendPropertyChanged("Orders")
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
        ''' <summary>Called when OrderId is changing.</summary>
        ''' <param name="value">The new value.</param>
        Partial Private Sub OnOrderIdChanging(ByVal value As Integer)
        End Sub
        ''' <summary>Called after OrderId has Changed.</summary>
        Partial Private Sub OnOrderIdChanged()
        End Sub
        ''' <summary>Called when LineNum is changing.</summary>
        ''' <param name="value">The new value.</param>
        Partial Private Sub OnLineNumChanging(ByVal value As Integer)
        End Sub
        ''' <summary>Called after LineNum has Changed.</summary>
        Partial Private Sub OnLineNumChanged()
        End Sub
        ''' <summary>Called when ItemId is changing.</summary>
        ''' <param name="value">The new value.</param>
        Partial Private Sub OnItemIdChanging(ByVal value As String)
        End Sub
        ''' <summary>Called after ItemId has Changed.</summary>
        Partial Private Sub OnItemIdChanged()
        End Sub
        ''' <summary>Called when Quantity is changing.</summary>
        ''' <param name="value">The new value.</param>
        Partial Private Sub OnQuantityChanging(ByVal value As Integer)
        End Sub
        ''' <summary>Called after Quantity has Changed.</summary>
        Partial Private Sub OnQuantityChanged()
        End Sub
        ''' <summary>Called when UnitPrice is changing.</summary>
        ''' <param name="value">The new value.</param>
        Partial Private Sub OnUnitPriceChanging(ByVal value As Decimal)
        End Sub
        ''' <summary>Called after UnitPrice has Changed.</summary>
        Partial Private Sub OnUnitPriceChanged()
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
        ''' Deserializes an instance of <see cref="LineItem"/> from XML.
        ''' </summary>
        ''' <param name="xml">The XML string representing a <see cref="LineItem"/> instance.</param>
        ''' <returns>An instance of <see cref="LineItem"/> that is deserialized from the XML string.</returns>
        Public Shared Function FromXml(ByVal xml As String) As LineItem
            Dim deserializer = New System.Runtime.Serialization.DataContractSerializer(GetType(LineItem))
            
            Using sr = New System.IO.StringReader(xml)
                Using reader = System.Xml.XmlReader.Create(sr)
                    Return TryCast(deserializer.ReadObject(reader), LineItem)
                End Using
            End Using
        End Function

        ''' <summary>
        ''' Deserializes an instance of <see cref="LineItem"/>.
        ''' </summary>
        ''' <param name="buffer">The byte array representing a <see cref="LineItem"/> instance.</param>
        ''' <returns>An instance of <see cref="LineItem"/> that is deserialized from the byte array.</returns>
        Public Shared Function FromBinary(ByVal buffer As Byte()) As LineItem
            Dim deserializer = New System.Runtime.Serialization.DataContractSerializer(GetType(LineItem))

            Using ms = New System.IO.MemoryStream(buffer)
                Using reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max)
                    Return TryCast(deserializer.ReadObject(reader), LineItem)
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
        Public Function Clone() As LineItem
            Return DirectCast(DirectCast(Me, ICloneable), LineItem).Clone()
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
            _orders = Detach(_orders)
        End Sub
#End Region
    End Class
End Namespace

