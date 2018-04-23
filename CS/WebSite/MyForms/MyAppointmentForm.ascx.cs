using System;
using System.Web.UI;
using DevExpress.XtraScheduler;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxScheduler.Internal;

public partial class AppointmentForm : UserControl {
	public bool CanShowReminders {
		get {
			return ((AppointmentFormTemplateContainer)Parent).Control.Storage.EnableReminders;
		}
	}

    protected void Page_Load(object sender, EventArgs e) {
		tbSubject.Focus();
	}
	public override void DataBind() {
		base.DataBind();

		AppointmentFormTemplateContainer container = (AppointmentFormTemplateContainer)Parent;
		Appointment apt = container.Appointment;
		edtLabel.SelectedIndex = apt.LabelId;
		edtStatus.SelectedIndex = apt.StatusId;
		if (!Object.Equals(apt.ResourceId, Resource.Empty.Id))
			edtResource.Value = apt.ResourceId.ToString();
		else
			edtResource.Value = SchedulerIdHelper.EmptyResourceId;

		AppointmentRecurrenceForm1.Visible = container.ShouldShowRecurrence;

		if (container.Appointment.HasReminder) {
			cbReminder.Value = container.Appointment.Reminder.TimeBeforeStart.ToString();
			chkReminder.Checked = true;
		}
		else {
			cbReminder.ClientEnabled = false;
		}

		btnOk.ClientSideEvents.Click = container.SaveHandler;
		btnCancel.ClientSideEvents.Click = container.CancelHandler;
		btnDelete.ClientSideEvents.Click = container.DeleteHandler;

	}    
}
