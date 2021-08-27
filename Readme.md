<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1130)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MyForm.cs](./CS/WebSite/App_Code/MyForm.cs) (VB: [MyForm.vb](./VB/WebSite/App_Code/MyForm.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
* [MyAppointmentForm.ascx](./CS/WebSite/MyForms/MyAppointmentForm.ascx) (VB: [MyAppointmentForm.ascx](./VB/WebSite/MyForms/MyAppointmentForm.ascx))
* [MyAppointmentForm.ascx.cs](./CS/WebSite/MyForms/MyAppointmentForm.ascx.cs) (VB: [MyAppointmentForm.ascx.vb](./VB/WebSite/MyForms/MyAppointmentForm.ascx.vb))
<!-- default file list end -->
# Custom appointment form with modified behavior


<p>This example illustrates how the appointment form can be customized to meet the following requirements:</p><p>All-Day event is the default and start & end times are hidden until the user unchecks the AllDay box at which point the time editors should be displayed. Default start time is 8:00 and end time - 17:00. <br />
If the All Day Event box is unchecked in the appointment editing form, the users should be automatically routed to Day View.<br />
Different types of appointments should be color coded, e.g. employee vacation and personal time off requested.  Those appointments that have not yet been approved by management should be highlighted.</p><p>Solution:<br />
A custom appointment form is constructed. To implement check/uncheck logic, client-side methods of the corresponding controls are used (<a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxClassesScriptsASPxClientControl_SetVisibletopic">SetVisible</a>). New appointment is initialized to All-Day by default via the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxSchedulerASPxScheduler_InitNewAppointmenttopic">InitNewAppointment</a> event. To change the active view to the Day View after a save command is executed, the <strong>FinalizeExecute()</strong> method of a custom MyAppointmentSaveCallbackCommand, inherited from the <strong>AppointmentFormSaveCallbackCommand</strong>, is overridden.<br />
To indicate different appointment types, custom labels and status are used.</p><p><strong>See Also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/K18145">How to modify the appointment editing form for working with custom fields (step-by-step guide)</a></p>

<br/>


