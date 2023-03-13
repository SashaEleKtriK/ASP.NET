using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace RSVP
{
    public partial class Reg : System.Web.UI.Page
    {
        public string Err = string.Empty;
        public string ErrHtml(string err)
        {
            StringBuilder html = new StringBuilder();
            html.Append($"<div><h1>{err}</h1></div>");
            return html.ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                GuestResponse rsvp = new GuestResponse(name.Text,
               email.Text, phone.Text, CheckBoxYN.Checked);
                ResponseRepository.GetRepository().AddResponse(rsvp);

                if (CheckBoxYN.Checked)
                {
                    Report report1 = new Report(TextBoxTitle.Text, TextBoxTextAnnot.Text);
                    rsvp.Reports.Add(report1);
                    if (TextBoxTitle2.Text != "" || TextBoxTextAnnot2.Text != "")
                    {
                        Report report2 = new Report(TextBoxTitle2.Text, TextBoxTextAnnot2.Text);
                        rsvp.Reports.Add(report2);
                    }
                }
                try
                {
                    SampleContext context = new SampleContext();
                    context.GuestResponses.Add(rsvp);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                   Err  =  ErrHtml("Ошибка " + ex.Message);
                }

                if (rsvp.WillAttend.HasValue && rsvp.WillAttend.Value)
                {
                    Response.Redirect("seeyouthere.html");
                }
                else
                {
                    Response.Redirect("sorryyoucantcome.html");
                }

            }

        }
    }
}