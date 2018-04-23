Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports DevExpress.XtraScheduler
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.Web.ASPxScheduler.Internal

Partial Public Class AppointmentForm
	Inherits UserControl
	Public ReadOnly Property CanShowReminders() As Boolean
		Get
			Return (CType(Parent, AppointmentFormTemplateContainer)).Control.Storage.EnableReminders
		End Get
	End Property

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		tbSubject.Focus()
	End Sub
	Public Overrides Overloads Sub DataBind()
		MyBase.DataBind()

		Dim container As AppointmentFormTemplateContainer = CType(Parent, AppointmentFormTemplateContainer)
		Dim apt As Appointment = container.Appointment
		edtLabel.SelectedIndex = apt.LabelId
		edtStatus.SelectedIndex = apt.StatusId
		If (Not Object.Equals(apt.ResourceId, Resource.Empty.Id)) Then
			edtResource.Value = apt.ResourceId.ToString()
		Else
			edtResource.Value = SchedulerIdHelper.EmptyResourceId
		End If

		AppointmentRecurrenceForm1.Visible = container.ShouldShowRecurrence

		If container.Appointment.HasReminder Then
			cbReminder.Value = container.Appointment.Reminder.TimeBeforeStart.ToString()
			chkReminder.Checked = True
		Else
			cbReminder.ClientEnabled = False
		End If

		btnOk.ClientSideEvents.Click = container.SaveHandler
		btnCancel.ClientSideEvents.Click = container.CancelHandler
		btnDelete.ClientSideEvents.Click = container.DeleteHandler

	End Sub
End Class
