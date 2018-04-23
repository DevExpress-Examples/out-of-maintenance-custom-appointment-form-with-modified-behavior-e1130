<%@ Control Language="C#" AutoEventWireup="true" Inherits="AppointmentForm" CodeFile="MyAppointmentForm.ascx.cs" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v8.2, Version=8.2.2.0, Culture=neutral, PublicKeyToken=9b171c9fd64da1d1"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v8.2" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v8.2" Namespace="DevExpress.Web.ASPxScheduler.Controls" TagPrefix="dxsc" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v8.2" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>

<table class="dxscAppointmentForm" cellpadding="0" cellspacing="0" style="width: 100%; height: 230px;">
    <tr>
        <td class="dxscDoubleCell" colspan="2">
            <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell">
                        <dxe:ASPxLabel ID="lblSubject" runat="server" AssociatedControlID="tbSubject" Text="Subject:">
                        </dxe:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dxe:ASPxTextBox ClientInstanceName="_dx" ID="tbSubject" runat="server" Width="100%" Text='<%# ((MyAppointmentFormTemplateContainer)Container).Appointment.Subject %>' />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr> 
        <td class="dxscSingleCell">
            <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell">
                        <dxe:ASPxLabel ID="lblLocation" runat="server" AssociatedControlID="tbLocation" Text="Location:">
                        </dxe:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dxe:ASPxTextBox ClientInstanceName="_dx" ID="tbLocation" runat="server" Width="100%" Text='<%# ((MyAppointmentFormTemplateContainer)Container).Appointment.Location %>' />
                    </td>
                </tr>
            </table>
        </td>
        <td class="dxscSingleCell">
            <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell" style="padding-left: 25px;">
                        <dxe:ASPxLabel ID="lblLabel" runat="server" AssociatedControlID="edtLabel" Text="Label:">
                        </dxe:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dxe:ASPxComboBox ClientInstanceName="_dx" ID="edtLabel" runat="server" Width="100%" DataSource='<%# ((MyAppointmentFormTemplateContainer)Container).LabelDataSource %>' />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="dxscSingleCell">
            <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell">
                        <dxe:ASPxLabel ID="lblStartDate" runat="server" AssociatedControlID="edtStartDate" Text="Start date:" Wrap="false">
                        </dxe:ASPxLabel>
                    </td>
                    <td class="dxscControlCell" >
                        <dxe:ASPxDateEdit ClientInstanceName="_dx_edtStartDate" ID="edtStartDate" runat="server"  Width="100%" Date='<%# ((MyAppointmentFormTemplateContainer)Container).Start %>' EditFormat="Date" />
                    </td>
                </tr>
            </table><table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell">
                        <dxe:ASPxLabel ID="lblStartTime" runat="server" AssociatedControlID="edtStartTime" Text="Start time:" Wrap="false" ClientInstanceName="_dx_lblStartTime">
                        </dxe:ASPxLabel>
                    </td>
                    <td class="dxscControlCell" >
                        <dxe:ASPxDateEdit ClientInstanceName="_dx_edtStartTime" ID="edtStartTime" runat="server" Width="100%"  Date='<%# ((MyAppointmentFormTemplateContainer)Container).Start %>' EditFormat="Custom" EditFormatString="t" />
                    </td>
                </tr>
            </table>
        </td>
        <td class="dxscSingleCell">
            <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell" style="padding-left: 25px;">
                        <dxe:ASPxLabel runat="server" ID="lblEndDate" Text="End date:" Wrap="false" AssociatedControlID="edtEndDate"/>
                    </td>
                    <td class="dxscControlCell">
                        <dxe:ASPxDateEdit id="edtEndDate" runat="server" ClientInstanceName="_dx_edtEndDate" Date='<%# ((MyAppointmentFormTemplateContainer)Container).End %>'
                            EditFormat="Date" Width="100%">
                        </dxe:ASPxDateEdit>
                    </td>
                </tr>
            </table><table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell" style="padding-left: 25px;">
                        <dxe:ASPxLabel runat="server" ID="lblEndTime" Text="End time:" Wrap="false" AssociatedControlID="edtEndTime" ClientInstanceName="_dx_lblEndTime"/>
                    </td>
                    <td class="dxscControlCell">
                        <dxe:ASPxDateEdit id="edtEndTime" runat="server" ClientInstanceName="_dx_edtEndTime" Date='<%# ((MyAppointmentFormTemplateContainer)Container).End %>'
                            EditFormat="Custom" EditFormatString="t" Width="100%" >
                        </dxe:ASPxDateEdit>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="dxscSingleCell">
            <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell">
                        <dxe:ASPxLabel ID="lblStatus" runat="server" AssociatedControlID="edtStatus" Text="Show time as:" Wrap="false">
                        </dxe:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dxe:ASPxComboBox ClientInstanceName="_dx" ID="edtStatus" runat="server" Width="100%" DataSource='<%# ((MyAppointmentFormTemplateContainer)Container).StatusDataSource %>' />
                    </td>
                </tr>
            </table>
        </td>
        <td class="dxscSingleCell" style="padding-left: 22px;">
            <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 20px; height: 20px;">
                        <dxe:ASPxCheckBox ClientInstanceName="_dx_chkAllDay" ID="chkAllDay" runat="server" Checked='<%# ((MyAppointmentFormTemplateContainer)Container).Appointment.AllDay %>' EnableClientSideAPI="True" >
                            <ClientSideEvents CheckedChanged="function(s, e) {OnChkAllDayCheckedChanged(s, e)}" Init="function(s, e) {OnChkAllDayInit(s, e)}"></clientsideevents>
                        </dxe:ASPxCheckBox>
                    </td>
                    <td style="padding-left: 2px;">
                        <dxe:ASPxLabel ID="lblAllDay" runat="server" Text="All day event" AssociatedControlID="chkAllDay" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
<% if(CanShowReminders) { %>
        <td class="dxscSingleCell">
<% } else { %>
        <td class="dxscDoubleCell" colspan="2">
<% } %>
            <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell">
                        <dxe:ASPxLabel ID="lblResource" runat="server" AssociatedControlID="edtResource" Text="Resource:">
                        </dxe:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dxe:ASPxComboBox ClientInstanceName="_dx" ID="edtResource" runat="server" Width="100%" DataSource='<%# ((MyAppointmentFormTemplateContainer)Container).ResourceDataSource %>' Enabled='<%# ((AppointmentFormTemplateContainer)Container).CanEditResource %>' />
                    </td>
                </tr>
            </table>
        </td>
<% if(CanShowReminders) { %>
        <td class="dxscSingleCell">
            <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell" style="padding-left: 22px;">
                        <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 20px; height: 20px;">
                                    <dxe:ASPxCheckBox ClientInstanceName="_dx" ID="chkReminder" runat="server"> 
                                        <ClientSideEvents CheckedChanged="function(s, e) { OnChkReminderCheckedChanged(s, e); }" />
                                    </dxe:ASPxCheckBox>
                                </td>
                                <td style="padding-left: 2px;">
                                    <dxe:ASPxLabel ID="lblReminder" runat="server" Text="Reminder" AssociatedControlID="chkReminder" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="dxscControlCell" style="padding-left: 3px">
                        <dxe:ASPxComboBox  ID="cbReminder" ClientInstanceName="_dxAppointmentForm_cbReminder" runat="server" Width="100%" DataSource='<%# ((MyAppointmentFormTemplateContainer)Container).ReminderDataSource %>' />
                    </td>
                </tr>
            </table>
        </td>
<% } %>
    </tr>
    <tr>
        <td class="dxscDoubleCell" colspan="2" style="height: 90px;">
            <dxe:ASPxMemo ClientInstanceName="_dx" ID="tbDescription" runat="server" Width="100%" Rows="6" Text='<%# ((MyAppointmentFormTemplateContainer)Container).Appointment.Description %>' />
        </td>
    </tr>
</table>
                        
<dxsc:AppointmentRecurrenceForm ID="AppointmentRecurrenceForm1" runat="server"
    IsRecurring='<%# ((MyAppointmentFormTemplateContainer)Container).Appointment.IsRecurring %>' 
    DayNumber='<%# ((MyAppointmentFormTemplateContainer)Container).RecurrenceDayNumber %>' 
    End='<%# ((MyAppointmentFormTemplateContainer)Container).RecurrenceEnd %>' 
    Month='<%# ((MyAppointmentFormTemplateContainer)Container).RecurrenceMonth %>' 
    OccurrenceCount='<%# ((MyAppointmentFormTemplateContainer)Container).RecurrenceOccurrenceCount %>' 
    Periodicity='<%# ((MyAppointmentFormTemplateContainer)Container).RecurrencePeriodicity %>' 
    RecurrenceRange='<%# ((MyAppointmentFormTemplateContainer)Container).RecurrenceRange %>' 
    Start='<%# ((MyAppointmentFormTemplateContainer)Container).RecurrenceStart %>' 
    WeekDays='<%# ((MyAppointmentFormTemplateContainer)Container).RecurrenceWeekDays %>' 
    WeekOfMonth='<%# ((MyAppointmentFormTemplateContainer)Container).RecurrenceWeekOfMonth %>' 
    RecurrenceType='<%# ((MyAppointmentFormTemplateContainer)Container).RecurrenceType %>'
    IsFormRecreated='<%# ((MyAppointmentFormTemplateContainer)Container).IsFormRecreated %>' >
</dxsc:AppointmentRecurrenceForm>
                   
<table cellpadding="0" cellspacing="0" style="width: 100%; height: 35px;">
    <tr>
        <td style="width: 100%; height: 100%;" align="center">
            <table style="height: 100%;">
                <tr>
                    <td>
                        <dxe:ASPxButton runat="server" ClientInstanceName="_dx" ID="btnOk" Text="OK" UseSubmitBehavior="false" AutoPostBack="false" 
                            EnableViewState="false" Width="91px"/>
                    </td>
                    <td>
                        <dxe:ASPxButton runat="server" ClientInstanceName="_dx" ID="btnCancel" Text="Cancel" UseSubmitBehavior="false" AutoPostBack="false" EnableViewState="false" 
                            Width="91px" CausesValidation="False" />
                    </td>
                    <td>
                        <dxe:ASPxButton runat="server" ClientInstanceName="_dx" ID="btnDelete" Text="Delete" UseSubmitBehavior="false"
                            AutoPostBack="false" EnableViewState="false" Width="91px"
                            Enabled='<%# ((MyAppointmentFormTemplateContainer)Container).CanDeleteAppointment %>'
                            CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table cellpadding="0" cellspacing="0" style="width: 100%;">
    <tr>
        <td style="width: 100%;" align="left">
            <dxsc:ASPxSchedulerStatusInfo runat="server" ID="schedulerStatusInfo" Priority="1" MasterControlId='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).ControlId %>' />
        </td>
    </tr>
</table>
<script id="dxss_MyForm" type="text/javascript">
    function OnChkReminderCheckedChanged(s, e) {
        var isReminderEnabled = s.GetValue();
        if (isReminderEnabled)
            _dxAppointmentForm_cbReminder.SetSelectedIndex(3);
        else
            _dxAppointmentForm_cbReminder.SetSelectedIndex(-1);
            
        _dxAppointmentForm_cbReminder.SetEnabled(isReminderEnabled);
        
    }
    
    function HideTimeControls(s, e) {
		_dx_lblStartTime.SetVisible(false);
	    _dx_edtStartTime.SetVisible(false);
	    _dx_lblEndTime.SetVisible(false);
	    _dx_edtEndTime.SetVisible(false);
    }
    
    function InitializeTimeControls(s, e) {
   		_dx_lblStartTime.SetVisible(true);
	    _dx_edtStartTime.SetVisible(true);
	    _dx_lblEndTime.SetVisible(true);
	    _dx_edtEndTime.SetVisible(true);	

	    var starttime = _dx_edtStartDate.GetDate();
	    _dx_edtStartTime.SetValue(new Date(starttime.getFullYear(),starttime.getMonth(),starttime.getDate(),8,0,0));
	    var endtime = _dx_edtEndDate.GetDate();
	    _dx_edtEndTime.SetDate(new Date(endtime.getFullYear(),endtime.getMonth(),endtime.getDate(),17,0,0));
	    
    }
    
   	var allday_unchecked = true;

    function OnChkAllDayInit(s, e) {
    	if (_dx_chkAllDay.GetChecked()){
    	    HideTimeControls(s, e);
    	    allday_unchecked = false;
    	    }
    }
    
    function OnChkAllDayCheckedChanged(s, e) {
         if (_dx_chkAllDay.GetChecked())
            HideTimeControls(s,e);
        else 
            InitializeTimeControls(s,e);
            var endtime = _dx_edtEndDate.GetDate();
            if (! allday_unchecked) {
	        _dx_edtEndDate.SetDate(new Date(endtime.getFullYear(),endtime.getMonth(),endtime.getDate()-1,endtime.getHours(),endtime.getMinutes(),endtime.getSeconds()));
	        allday_unchecked = true;
	        }

    }
</script>