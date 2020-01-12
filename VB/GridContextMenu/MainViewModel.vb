Imports DevExpress.Mvvm
Imports System
Imports System.Collections.ObjectModel
Imports System.Linq

Public Class MainViewModel
    Inherits ViewModelBase

    Public Sub New()
        Me.DeleteCommand = New DelegateCommand(Of Item)(AddressOf Delete)
        Me.DuplicateCommand = New DelegateCommand(Of Item)(AddressOf Duplicate)
    End Sub

    Protected _Items As ObservableCollection(Of Item)

    Public ReadOnly Property Items As ObservableCollection(Of Item)
        Get

            If Me._Items Is Nothing Then
                Me._Items = New ObservableCollection(Of Item)()
                Dim r As Random = New Random()
                Dim i As Integer = 0

                While i < 150
                    Dim value As Item = New Item()
                    value.Name = String.Format("Name #{0}", i)
                    value.Age = r.[Next](40) + 20
                    value.DateTime = DateTime.Today.AddDays(r.[Next](30) - 15)
                    value.IsSelected = r.[Next](2) > 0
                    Me._Items.Add(value)
                    i = i + 1
                End While
            End If

            Return Me._Items
        End Get
    End Property

    Protected _SelectedItem As Item

    Public Property SelectedItem As Item
        Get
            Return Me._SelectedItem
        End Get
        Set(ByVal value As Item)
            Me.SetProperty(Me._SelectedItem, value, "SelectedItem")
        End Set
    End Property

    Public Property DeleteCommand As DelegateCommand(Of Item)

    Public Sub Delete(ByVal item As Item)
        If Me.Items.Contains(item) Then
            Dim index = Me.Items.IndexOf(item)
            Me.Items.Remove(item)
            Me.SelectedItem = If(Me.Items.Count < index, Me.Items(index), Me.Items.FirstOrDefault())
        End If
    End Sub

    Public Property DuplicateCommand As DelegateCommand(Of Item)

    Public Sub Duplicate(ByVal item As Item)
        Dim index = Me.Items.IndexOf(item)
        Dim newItem = New Item() With {
                .Name = item.Name,
                .Age = item.Age,
                .DateTime = item.DateTime,
                .IsSelected = item.IsSelected
            }
        Me.Items.Insert(index + 1, newItem)
        Me.SelectedItem = newItem
    End Sub
End Class