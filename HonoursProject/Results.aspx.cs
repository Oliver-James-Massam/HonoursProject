using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using HonoursProject.Code.Results;
using Newtonsoft.Json;

namespace HonoursProject
{
    public partial class Results : System.Web.UI.Page
    {
        protected List<int[]> data;
        protected ResultCSV readResults;
        protected CSVDataRepresentation knnData;
        protected CSVDataRepresentation logregData;
        protected CSVDataRepresentation actualData;
        protected string[] COL_NAME = CSVDataRepresentation.COL_NAME;

        protected string newCols;
        protected string numPerCat_actual;
        protected string numPerCat_knn;
        protected string numPerCat_logreg;

        protected void Page_Load(object sender, EventArgs e)
        {
            readResults = new ResultCSV();
           
            data = readResults.readCSV(readResults.get_resultKNN());
            knnData = new CSVDataRepresentation(data);
            data = readResults.readCSV(readResults.get_resultLOGREG());
            logregData = new CSVDataRepresentation(data);
            data = readResults.readCSV(readResults.get_resultActual());
            actualData = new CSVDataRepresentation(data, true);

            allCategories();
            knnPredictedCategories();
            logregPredictedCategories();
            actualCategories();
        }

        public void allCategories()
        {
            int count = 0;
            List<string> tempCols = new List<string>();
            foreach (string str in COL_NAME)
            {
                if (count != 0)
                {
                    tempCols.Add(str);
                }
                count++;
            }
            newCols = JsonConvert.SerializeObject(tempCols);
        }

        public void knnPredictedCategories()
        {
            List<numberCategories> numCat = knnData.NumCategories;
            List<int> total = new List<int>();
            foreach (numberCategories nc in numCat)
            {
                total.Add(nc.Total);
            }
            numPerCat_knn = JsonConvert.SerializeObject(total);
        }

        public void logregPredictedCategories()
        {
            List<numberCategories> numCat = logregData.NumCategories;
            List<int> total = new List<int>();
            foreach (numberCategories nc in numCat)
            {
                total.Add(nc.Total);
            }
            numPerCat_logreg = JsonConvert.SerializeObject(total);
        }

        public void actualCategories()
        {
            List<numberCategories> numCat = actualData.NumCategories;
            List<int> total = new List<int>();
            foreach (numberCategories nc in numCat)
            {
                total.Add(nc.Total);
            }
            numPerCat_actual = JsonConvert.SerializeObject(total);
        }

        //public void calcAccuracy()
        //{
        //    foreach
        //}
    } 
}