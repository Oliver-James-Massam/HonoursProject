using HonoursProject.Code.SVM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HonoursProject
{
    public partial class SVM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            calcSVM();
        }

        protected void UpdatePage_Click(object sender, EventArgs e)
        {

        }

        private void calcSVM()
        {
            svmModel.intantiateTrainingCSV();
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            calcSVM();
            //Breaks becasue file is too large
            //if (FileUploadControl.HasFile)
            //{
            //    try
            //    {
            //        string filename = Path.GetFileName(FileUploadControl.FileName);
            //        //FileUploadControl.SaveAs(Server.MapPath("~/") + filename);
            //        StatusLabel.Text = "Upload status: File uploaded!";
            //    }
            //    catch (Exception ex)
            //    {
            //        StatusLabel.Text = "The file could not be uploaded. The following error occured: " + ex.Message;
            //    }
            //}
        }
    }
}