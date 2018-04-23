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
Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.XtraScheduler
Imports System.Drawing

Public Class ResourceFiller
	Public Shared Users() As String = { "Sarah Brighton", "Ryan Fischer", "Andrew Miller" }
	Public Shared Usernames() As String = { "sbrighton", "rfischer", "amiller" }

	Public Shared Sub FillResources(ByVal storage As ASPxSchedulerStorage, ByVal count As Integer)
		Dim resources As ResourceCollection = storage.Resources.Items
		storage.BeginUpdate()
		Try
			Dim cnt As Integer = Math.Min(count, Users.Length)
			For i As Integer = 1 To cnt
				resources.Add(New Resource(Usernames(i - 1), Users(i - 1)))
			Next i
		Finally
			storage.EndUpdate()
		End Try
	End Sub
End Class


Public Class Labeller
	Public Shared Sub AddLabels(ByVal storage As ASPxSchedulerStorage)
		Dim lc As AppointmentLabelCollection = storage.Appointments.Labels
		lc.Clear()
		lc.Add(Color.LightGreen,"Vacation","&Vacation")
		lc.Add(Color.Lavender, "Time Off", "Time &Off")
		lc.Add(Color.AntiqueWhite, "Business", "&Business")

	End Sub
End Class


Public Class Statusser
	Public Shared Sub AddStatuses(ByVal storage As ASPxSchedulerStorage)
		Dim sc As AppointmentStatusCollection = storage.Appointments.Statuses
		sc.Add(Color.Red, "Not Approved", "Not Approved")
	End Sub

End Class