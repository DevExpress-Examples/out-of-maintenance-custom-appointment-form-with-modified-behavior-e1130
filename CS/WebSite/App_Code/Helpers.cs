using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxScheduler;
using DevExpress.XtraScheduler;
using System.Drawing;

public class ResourceFiller {
    public static string[] Users = new string[] { "Sarah Brighton", "Ryan Fischer", "Andrew Miller" };
    public static string[] Usernames = new string[] { "sbrighton", "rfischer", "amiller" };

    public static void FillResources(ASPxSchedulerStorage storage, int count) {
        ResourceCollection resources = storage.Resources.Items;
        storage.BeginUpdate();
        try {
            int cnt = Math.Min(count, Users.Length);
            for (int i = 1; i <= cnt; i++) {
                resources.Add(new Resource(Usernames[i - 1], Users[i - 1]));
            }
        }
        finally {
            storage.EndUpdate();
        }
    }
}


public class Labeller {
    public static void AddLabels(ASPxSchedulerStorage storage) {
        AppointmentLabelCollection lc = storage.Appointments.Labels;
        lc.Clear();
        lc.Add(Color.LightGreen,"Vacation","&Vacation");
        lc.Add(Color.Lavender, "Time Off", "Time &Off");
        lc.Add(Color.AntiqueWhite, "Business", "&Business");
    
    }
}


public class Statusser {
    public static void AddStatuses(ASPxSchedulerStorage storage) {
        AppointmentStatusCollection sc = storage.Appointments.Statuses;
        sc.Add(Color.Red, "Not Approved", "Not Approved");
    }

}