using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxScheduler;
using DevExpress.XtraScheduler;
using DevExpress.Web.ASPxScheduler.Internal;

public partial class _Default : System.Web.UI.Page {
    ASPxSchedulerStorage Storage { get { return this.ASPxScheduler1.Storage; } }
    public static Random RandomInstance = new Random();

    protected void Page_Init(object sender, EventArgs e) {
        ASPxScheduler1.Start = DateTime.Now.Date;
    
    }
    
    protected void Page_Load(object sender, EventArgs e) {
        SetupMappings();
        ResourceFiller.FillResources(this.ASPxScheduler1.Storage, 3);
        Labeller.AddLabels(this.ASPxScheduler1.Storage);
        Statusser.AddStatuses(this.ASPxScheduler1.Storage);

        ASPxScheduler1.AppointmentDataSource = appointmentDataSource;
        ASPxScheduler1.DataBind();

    }

    #region Data Fill


    CustomEventList GetCustomEvents() {
        CustomEventList events = Session["ListBoundModeObjects"] as CustomEventList;
        if (events == null) {
            events = GenerateCustomEventList();
            Session["ListBoundModeObjects"] = events;
        }
        return events;
    }

    #region Random events generation
    CustomEventList GenerateCustomEventList() {
        CustomEventList eventList = new CustomEventList();
        int count = Storage.Resources.Count;
        for (int i = 0; i < count; i++) {
            Resource resource = Storage.Resources[i];
            string subjPrefix = resource.Caption + "'s ";

            eventList.Add(CreateEvent(resource.Id, subjPrefix + "meeting", 2, 2));
            eventList.Add(CreateEvent(resource.Id, subjPrefix + "travel", 3, 0));
            eventList.Add(CreateEvent(resource.Id, subjPrefix + "time off", 0, 1));
        }
        return eventList;
    }
    CustomEvent CreateEvent(object resourceId, string subject, int status, int label) {
        CustomEvent customEvent = new CustomEvent();
        customEvent.Subject = subject;
        customEvent.OwnerId = resourceId;
        Random rnd = RandomInstance;
        int rangeInHours = 48;
        customEvent.StartTime = DateTime.Today + TimeSpan.FromHours(rnd.Next(0, rangeInHours));
        customEvent.EndTime = customEvent.StartTime + TimeSpan.FromHours(rnd.Next(0, rangeInHours / 8));
        customEvent.Status = status;
        customEvent.Label = label;
        customEvent.Id = "ev" + customEvent.GetHashCode();
        return customEvent;
    }
    #endregion


    void SetupMappings() {
        ASPxAppointmentMappingInfo mappings = Storage.Appointments.Mappings;
        Storage.BeginUpdate();
        try {
            mappings.AppointmentId = "Id";
            mappings.Start = "StartTime";
            mappings.End = "EndTime";
            mappings.Subject = "Subject";
            mappings.AllDay = "AllDay";
            mappings.Description = "Description";
            mappings.Label = "Label";
            mappings.Location = "Location";
            mappings.RecurrenceInfo = "RecurrenceInfo";
            mappings.ReminderInfo = "ReminderInfo";
            mappings.ResourceId = "OwnerId";
            mappings.Status = "Status";
            mappings.Type = "EventType";
        }
        finally {
            Storage.EndUpdate();
        }
    }
    #endregion


    protected void ASPxScheduler1_AppointmentFormShowing(object sender, AppointmentFormEventArgs e) {
        e.Container = new MyAppointmentFormTemplateContainer((ASPxScheduler)sender);

    }

    protected void ASPxScheduler1_AppointmentInserting(object sender, PersistentObjectCancelEventArgs e) {
        ASPxSchedulerStorage storage = (ASPxSchedulerStorage)sender;
        Appointment apt = (Appointment)e.Object;
        storage.SetAppointmentId(apt, "a" + apt.GetHashCode());
    }

    protected void appointmentsDataSource_ObjectCreated(object sender, ObjectDataSourceEventArgs e) {
        e.ObjectInstance = new CustomEventDataSource(GetCustomEvents());
    }
    protected void ASPxScheduler1_BeforeExecuteCallbackCommand(object sender, SchedulerCallbackCommandEventArgs e) {
        if(e.CommandId == SchedulerCallbackCommandId.AppointmentSave) {
            e.Command = new MyAppointmentSaveCallbackCommand((ASPxScheduler)sender);
        }
    }
    protected void ASPxScheduler1_InitNewAppointment(object sender, AppointmentEventArgs e) {
        e.Appointment.AllDay = true;
    }
}
