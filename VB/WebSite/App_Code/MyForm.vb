Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.Web.ASPxScheduler.Internal
Imports DevExpress.XtraScheduler

Public Class MyAppointmentFormTemplateContainer
	Inherits AppointmentFormTemplateContainer
	Public Sub New(ByVal control As ASPxScheduler)
		MyBase.New(control)
	End Sub
End Class
Public Class MyAppointmentSaveCallbackCommand
	Inherits AppointmentFormSaveCallbackCommand
	Public Sub New(ByVal control As ASPxScheduler)
		MyBase.New(control)
	End Sub
	Protected Friend Shadows ReadOnly Property Controller() As MyAppointmentFormController
		Get
			Return CType(MyBase.Controller, MyAppointmentFormController)
		End Get
	End Property

	Protected Overrides Sub AssignControllerValues()

		MyBase.AssignControllerValues()

		Dim edtStartDate As ASPxDateEdit = CType(FindControlByID("edtStartDate"), ASPxDateEdit)
		Dim edtStartTime As ASPxDateEdit = CType(FindControlByID("edtStartTime"), ASPxDateEdit)
		Dim edtEndDate As ASPxDateEdit = CType(FindControlByID("edtEndDate"), ASPxDateEdit)
		Dim edtEndTime As ASPxDateEdit = CType(FindControlByID("edtEndTime"), ASPxDateEdit)
		Dim chkAllDay As ASPxCheckBox = CType(FindControlByID("chkAllDay"), ASPxCheckBox)
		Dim cbResource As ASPxComboBox = CType(FindControlByID("edtResource"), ASPxComboBox)


		If edtStartDate IsNot Nothing AndAlso edtStartTime IsNot Nothing Then
			Controller.Start = edtStartDate.Date.Date + edtStartTime.Date.TimeOfDay
		End If
		If edtEndDate IsNot Nothing AndAlso edtEndTime IsNot Nothing Then
		Controller.End = edtEndDate.Date.Date + edtEndTime.Date.TimeOfDay
		End If
	If chkAllDay IsNot Nothing Then
		Controller.AllDay = chkAllDay.Checked
	End If

	If cbResource.SelectedItem IsNot Nothing Then
		Controller.ResourceId = cbResource.SelectedItem.Value
	End If

	Dim clientStart As DateTime = FromClientTime(Controller.Start)
		AssignControllerRecurrenceValues(clientStart)



	End Sub

	Protected Overrides Function CreateAppointmentFormController(ByVal apt As Appointment) As AppointmentFormController
		Return New MyAppointmentFormController(Control, apt)
	End Function

	Protected Overrides Sub FinalizeExecute()
		MyBase.FinalizeExecute()
		If (Not Controller.AllDay) Then
			MyBase.Control.ActiveViewType = SchedulerViewType.Day
		End If
	End Sub

End Class

Public Class MyAppointmentFormController
	Inherits AppointmentFormController

	Public Sub New(ByVal control As ASPxScheduler, ByVal apt As Appointment)
		MyBase.New(control, apt)
	End Sub
End Class
