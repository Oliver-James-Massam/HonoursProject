using HonoursProject.Code.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HonoursProject
{
    public partial class ResultsBig : System.Web.UI.Page
    {
        protected List<int[]> data;
        protected ResultCSV readResults;
        protected CSVDataRepresentation knnData;
        protected CSVDataRepresentation logregData;
        protected CSVDataRepresentation actualData;
        protected string[] COL_NAME = CSVDataRepresentation.COL_NAME;

        protected List<int[]> data2;
        protected ResultCSV readResults2;
        protected CSVDataRepresentation actualDataWithTraining;

        protected string newCols;
        protected string numPerCat_actual;
        protected string numPerCat_knn;
        protected string numPerCat_logreg;
        protected string numPerCat_actual_With_Training;
        protected string numPerCat_knn_With_Training;
        protected string numPerCat_logreg_With_Training;
        protected string knnAcc;
        protected string logregAcc;

        protected List<double> calcKNN = new List<double>();
        protected List<double> calcLOGREG = new List<double>();
        protected List<double> calcActual = new List<double>();

        protected double knnCorrect = 0;
        protected double logregCorrect = 0;
        protected string knnCorrect_JS;
        protected string logregCorrect_JS;

        protected double knnCorrect_With_Training = 0;
        protected double logregCorrect_With_Training = 0;
        protected string knnCorrect_JS_With_Training;
        protected string logregCorrect_JS_With_Training;

        protected void Page_Load(object sender, EventArgs e)
        {
            readResults = new ResultCSV();

            data = readResults.readCSV(readResults.get_resultKNN());
            knnData = new CSVDataRepresentation(data);
            data = readResults.readCSV(readResults.get_resultLOGREG());
            logregData = new CSVDataRepresentation(data);
            data = readResults.readCSV(readResults.get_resultActual());
            actualData = new CSVDataRepresentation(data, true);

            readResults2 = new ResultCSV(false);
            data2 = readResults2.readCSV(readResults2.getAltActual2());
            actualDataWithTraining = new CSVDataRepresentation(data2, true);

            allCategories();
            knnPredictedCategories();
            logregPredictedCategories();
            actualCategories();
            actualCategoriesWithTraining();
            calcAccuracy();
            calcAccuracyWithTraining();
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
                total.Add(nc.Total*10000*2);
            }
            numPerCat_actual = JsonConvert.SerializeObject(total);
        }

        public void calcAccuracy ()
        {
            double knnCorrect = 0;
            double logregCorrect = 0;

            List<numberCategories> numCat = logregData.NumCategories;
            double total_Predictions_logreg = 0;

            foreach (numberCategories nc in numCat)
            {
                total_Predictions_logreg += nc.Total;
            }

            List<numberCategories> numCat2 = knnData.NumCategories;
            double total_Predictions_knn = 0;

            foreach (numberCategories nc in numCat2)
            {
                total_Predictions_knn += nc.Total;
            }

            List<numberCategories> numCat3 = actualData.NumCategories;
            double total_Predictions_actual = 0;

            foreach (numberCategories nc in numCat3)
            {
                total_Predictions_actual += nc.Total;
            }

            List<numberCategories> calcActual = actualData.NumCategories;
            List<numberCategories> calcKnn = knnData.NumCategories;
            List<numberCategories> calcLogreg = logregData.NumCategories;

            for(int i = 0; i < calcActual.Count; i++)
            {
                double actualNum = calcActual.ElementAt(i).Total;
                double knnNum = calcKnn.ElementAt(i).Total;
                double logregNum = calcLogreg.ElementAt(i).Total;

                actualNum = (actualNum / total_Predictions_actual) * 100;
                knnNum = (knnNum / total_Predictions_knn) * 100;
                logregNum = (logregNum / total_Predictions_logreg) * 100;

                if (actualNum >= knnNum)
                {
                    knnCorrect += knnNum;
                }
                else
                {
                    knnCorrect += actualNum;
                }

                if (actualNum >= logregNum)
                {
                    logregCorrect += logregNum;
                }
                else
                {
                    logregCorrect += actualNum;
                }
            }
            int linesInCSV = 878050;
            metric1.InnerHtml += "" + linesInCSV;
            linesInCSV = 884263;
            metric2.InnerHtml += "" + linesInCSV;

            knnAccuracy.InnerHtml = knnCorrect + "%";
            logregAccuracy.InnerHtml = logregCorrect + "%";
            knnCorrect_JS = JsonConvert.SerializeObject(knnCorrect);
            logregCorrect_JS = JsonConvert.SerializeObject(logregCorrect);
        }

        public void actualCategoriesWithTraining()
        {
            List<numberCategories> numCat = actualDataWithTraining.NumCategories;
            List<int> total = new List<int>();
            foreach (numberCategories nc in numCat)
            {
                total.Add(nc.Total);
            }
            numPerCat_actual_With_Training = JsonConvert.SerializeObject(total);
        }

        public void calcAccuracyWithTraining()
        {
            double knnCorrect = 0;
            double logregCorrect = 0;

            List<numberCategories> numCat = logregData.NumCategories;
            double total_Predictions_logreg = 0;

            foreach (numberCategories nc in numCat)
            {
                total_Predictions_logreg += nc.Total;
            }

            List<numberCategories> numCat2 = knnData.NumCategories;
            double total_Predictions_knn = 0;

            foreach (numberCategories nc in numCat2)
            {
                total_Predictions_knn += nc.Total;
            }

            List<numberCategories> numCat3 = actualDataWithTraining.NumCategories;
            double total_Predictions_actual = 0;

            foreach (numberCategories nc in numCat3)
            {
                total_Predictions_actual += nc.Total;
            }

            List<numberCategories> calcActual = actualDataWithTraining.NumCategories;
            List<numberCategories> calcKnn = knnData.NumCategories;
            List<numberCategories> calcLogreg = logregData.NumCategories;

            for (int i = 0; i < calcActual.Count; i++)
            {
                double actualNum = calcActual.ElementAt(i).Total;
                double knnNum = calcKnn.ElementAt(i).Total;
                double logregNum = calcLogreg.ElementAt(i).Total;

                actualNum = (actualNum / total_Predictions_actual) * 100;
                knnNum = (knnNum / total_Predictions_knn) * 100;
                logregNum = (logregNum / total_Predictions_logreg) * 100;

                if (actualNum >= knnNum)
                {
                    knnCorrect += knnNum;
                }
                else
                {
                    knnCorrect += actualNum;
                }

                if (actualNum >= logregNum)
                {
                    logregCorrect += logregNum;
                }
                else
                {
                    logregCorrect += actualNum;
                }
            }
            //int linesInCSV = 878050;
            //metric1.InnerHtml += "" + linesInCSV;
            //linesInCSV = 884263;
            //metric2.InnerHtml += "" + linesInCSV;

            knnAccuracy2.InnerHtml = knnCorrect + "%";
            logregAccuracy2.InnerHtml = logregCorrect + "%";
            knnCorrect_JS_With_Training = JsonConvert.SerializeObject(knnCorrect);
            logregCorrect_JS_With_Training = JsonConvert.SerializeObject(logregCorrect);
        }

    }
}