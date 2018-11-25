using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace HonoursProject.Code.Results
{
    //private static string _resultKNN = @"~\Files\results_KNN_Old.csv";
    //private static string _resultLOGREG = @"~\Files\results_LOGREG_Old.csv";
    //private static string _resultActual = @"~\Files\results_Accuracy_OLD.csv";

    public class ResultCSV
    {
        private string altKNN = @"~\Files\results_KNN_5050.csv";
        private string altLOGREG = @"~\Files\results_LOGREG_5050.csv";
        private string altActual = @"~\Files\results_Accuracy_5050.csv";

        private string altActual2 = @"~\Files\results_Accuracy_ofTrainWithActualCategories.csv";

        private string _resultKNN = @"~\Files\results_KNN_Old.csv";
        private string _resultLOGREG = @"~\Files\results_LOGREG_Old.csv";
        private string _resultActual = @"~\Files\results_Accuracy_OLD.csv";

        //https://www.svm-tutorial.com/2014/10/svm-tutorial-classify-text-csharp/
        public ResultCSV()
        {
            _resultKNN = System.Web.Hosting.HostingEnvironment.MapPath(_resultKNN);
            _resultLOGREG = System.Web.Hosting.HostingEnvironment.MapPath(_resultLOGREG);
            _resultActual = System.Web.Hosting.HostingEnvironment.MapPath(_resultActual);
        }

        public ResultCSV(string filepathKNN, string filepathLOGREG, string filepathACTUAL)
        {
            _resultKNN = System.Web.Hosting.HostingEnvironment.MapPath(filepathKNN);
            _resultLOGREG = System.Web.Hosting.HostingEnvironment.MapPath(filepathLOGREG);
            _resultActual = System.Web.Hosting.HostingEnvironment.MapPath(filepathACTUAL);
        }

        public ResultCSV(bool isAlt)
        {
            if(isAlt == true)
            {
                altKNN = System.Web.Hosting.HostingEnvironment.MapPath(altKNN);
                altLOGREG = System.Web.Hosting.HostingEnvironment.MapPath(altLOGREG);
                altActual = System.Web.Hosting.HostingEnvironment.MapPath(altActual);
            }
            else
            {
                _resultKNN = System.Web.Hosting.HostingEnvironment.MapPath(_resultKNN);
                _resultLOGREG = System.Web.Hosting.HostingEnvironment.MapPath(_resultLOGREG);
                altActual2 = System.Web.Hosting.HostingEnvironment.MapPath(altActual2);
            }
        }

        public List<int[]> readCSV(string filePath)
        {
            //Debug.WriteLine("Start Read");
            StreamReader sr = new StreamReader(filePath);
            //Debug.WriteLine("Open File");
            List<int[]> lines = new List<int[]>();
            int row = 0;
            while (!sr.EndOfStream)
            {
                if(row > 0)
                {
                    string[] line = sr.ReadLine().Split(',');
                    //StringBuilder outStr = new StringBuilder("");
                    //foreach (string test in line)
                    //{
                    //    outStr = outStr.Append(","+test);
                    //}
                    
                    int[] valueLine = Array.ConvertAll(line, int.Parse);
                    lines.Add(valueLine);
                    row++;
                    //Debug.WriteLine(row);
                    //Debug.WriteLine(outStr);
                }
                else
                {
                    sr.ReadLine().Split(',');
                    row++;
                }
            }

            return lines;
        }

        public string get_resultKNN()
        {
            return _resultKNN;
        }

        public string get_resultLOGREG()
        {
            return _resultLOGREG;
        }

        public string get_resultActual()
        {
            return _resultActual;
        }

        public string getAltKNN()
        {
            return altKNN;
        }

        public string getAltLOGREG()
        {
            return altLOGREG;
        }

        public string getAltActual()
        {
            return altActual;
        }

        public string getAltActual2()
        {
            return altActual2;
        }
    }
}