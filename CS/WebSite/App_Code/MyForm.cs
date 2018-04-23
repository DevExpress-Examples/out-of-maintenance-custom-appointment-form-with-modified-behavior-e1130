using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxScheduler.Internal;
using DevExpress.XtraScheduler;

public class MyAppointmentFormTemplateContainer : AppointmentFormTemplateContainer {
	public MyAppointmentFormTemplateContainer(ASPxScheduler control)
		: base(control) {
	}
}
public class MyAppointmentSaveCallbackCommand : AppointmentFormSaveCallbackCommand {
	public MyAppointmentSaveCallbackCommand(ASPxScheduler control)
		: base(control) {
	}
	protected internal new MyAppointmentFormController Controller { get { return (MyAppointmentFormController)base.Controller; } } 

	protected override void AssignControllerValues() {

        base.AssignControllerValues();

		ASPxDateEdit edtStartDate = (ASPxDateEdit)FindControlByID("edtStartDate");
        ASPxDateEdit edtStartTime = (ASPxDateEdit)FindControlByID("edtStartTime");
		ASPxDateEdit edtEndDate = (ASPxDateEdit)FindControlByID("edtEndDate");
        ASPxDateEdit edtEndTime = (ASPxDateEdit)FindControlByID("edtEndTime");
        ASPxCheckBox chkAllDay = (ASPxCheckBox)FindControlByID("chkAllDay");
        ASPxComboBox cbResource = (ASPxComboBox)FindControlByID("edtResource");
        

		if(edtStartDate != null && edtStartTime != null)
            Controller.Start = edtStartDate.Date.Date + edtStartTime.Date.TimeOfDay;
        if(edtEndDate != null && edtEndTime != null)
        Controller.End = edtEndDate.Date.Date + edtEndTime.Date.TimeOfDay;
    if(chkAllDay != null)
        Controller.AllDay = chkAllDay.Checked;

    if(cbResource.SelectedItem != null)
        Controller.ResourceId = cbResource.SelectedItem.Value;

    DateTime clientStart = FromClientTime(Controller.Start);
        AssignControllerRecurrenceValues(clientStart);

      

	}

	protected override AppointmentFormController CreateAppointmentFormController(Appointment apt) {
		return new MyAppointmentFormController(Control, apt);
	}

    protected override void FinalizeExecute() {
        base.FinalizeExecute();
        if(!Controller.AllDay) 
            base.Control.ActiveViewType = SchedulerViewType.Day;
    }

}

public class MyAppointmentFormController : AppointmentFormController {

	public MyAppointmentFormController(ASPxScheduler control, Appointment apt)
		: base(control, apt) {
    }
}
