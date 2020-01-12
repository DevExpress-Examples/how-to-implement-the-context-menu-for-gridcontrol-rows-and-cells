Imports DevExpress.Mvvm
Imports System

Namespace GridContextMenu

	Public Class Item
		Inherits BindableBase

		Protected _Name As String
		Public Property Name() As String
			Get
				Return Me._Name
			End Get
			Set(ByVal value As String)
				Me.SetProperty(Me._Name, value, "Name")
			End Set
		End Property

		Protected _Age As Integer
		Public Property Age() As Integer
			Get
				Return Me._Age
			End Get
			Set(ByVal value As Integer)
				Me.SetProperty(Me._Age, value, "Age")
			End Set
		End Property

		Protected _DateTime As Date
		Public Property Date() As Date
			Get
				Return Me._DateTime
			End Get
			Set(ByVal value As Date)
				Me.SetProperty(Me._DateTime, value, "DateTime")
			End Set
		End Property

		Protected _IsSelected As Boolean
		Public Property IsSelected() As Boolean
			Get
				Return Me._IsSelected
			End Get
			Set(ByVal value As Boolean)
				Me.SetProperty(Me._IsSelected, value, "IsSelected")
			End Set
		End Property
	End Class
End Namespace
