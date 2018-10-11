using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using LibSVMsharp;
using LibSVMsharp.Helpers;
using LibSVMsharp.Extensions;
using System.Diagnostics;
using System.Globalization;

namespace HonoursProject.Code.SVM
{
    public static class svmModel
    {
        private static string dataFilePathTrain;
        private static string dataFilePathTest;

        //https://www.svm-tutorial.com/2014/10/svm-tutorial-classify-text-csharp/
        public static void intantiateTrainingCSV()
        {
            dataFilePathTrain = System.Web.Hosting.HostingEnvironment.MapPath(@"~\Files\train.csv");
            dataFilePathTest = System.Web.Hosting.HostingEnvironment.MapPath(@"~\Files\test.csv");
            var dataTable = DataTable.New.ReadCsv(dataFilePathTrain);

            List<string> dates = dataTable.Rows.Select(row => row["Dates"]).ToList();
            List<string> categories = dataTable.Rows.Select(row => row["Category"]).ToList();
            List<string> descripts = dataTable.Rows.Select(row => row["Descript"]).ToList();
            List<string> days = dataTable.Rows.Select(row => row["DayOfWeek"]).ToList();
            List<string> districts = dataTable.Rows.Select(row => row["PdDistrict"]).ToList();
            List<string> resolutions = dataTable.Rows.Select(row => row["Resolution"]).ToList();
            List<string> adresses = dataTable.Rows.Select(row => row["Address"]).ToList();
            List<double> x = dataTable.Rows.Select(row => double.Parse(row["X"], CultureInfo.InvariantCulture)).ToList();
            List<double> y = dataTable.Rows.Select(row => double.Parse(row["Y"], CultureInfo.InvariantCulture)).ToList();

            // Convert CSV file to txt
        }

        public static void tweetDataToFile()
        {
            //Translate twitter data gathered to form a prediction
        }

        //https://www.svm-tutorial.com/text-classification-prepare-data/
        //https://github.com/ccerhan/LibSVMsharp
        public static void basicClassification()
        {
            SVMProblem trainProblem = SVMProblemHelper.Load(dataFilePathTrain);
            SVMProblem testProblem = SVMProblemHelper.Load(dataFilePathTest);

            //Dont know what this is, research to be done

            //// Normalize the datasets if you want: L2 Norm => x / ||x||
            //trainingSet = trainingSet.Normalize(SVMNormType.L2);
            //testSet = testSet.Normalize(SVMNormType.L2);

            SVMParameter parameter = new SVMParameter();
            parameter.Type = SVMType.C_SVC;
            parameter.Kernel = SVMKernelType.RBF;
            parameter.C = 1;
            parameter.Gamma = 1;

            //Dont know what this is, research to be done

            //// Do cross validation to check this parameter set is correct for the dataset or not
            //double[] crossValidationResults; // output labels
            //int nFold = 5;
            //trainingSet.CrossValidation(parameter, nFold, out crossValidationResults);

            //// Evaluate the cross validation result
            //// If it is not good enough, select the parameter set again
            //double crossValidationAccuracy = trainingSet.EvaluateClassificationProblem(crossValidationResults);

            SVMModel model = trainProblem.Train(parameter);

            //// Save the model
            //SVM.SaveModel(model, @"Model\wine_model.txt");

            // Predict the instances in the test set
            double[] testResults = testProblem.Predict(model);

            //----------------------------------------------------NOT MY WORK--------------------------------------------------------------------
            // Edited only for server scenario
            //https://github.com/ccerhan/LibSVMsharp/blob/master/LibSVMsharp.Examples.Classification/Program.cs
            // Evaluate the test results
            int[,] confusionMatrix;
            double testAccuracy = trainProblem.EvaluateClassificationProblem(testResults, model.Labels, out confusionMatrix);

            // Print formatted confusion matrix
            Debug.Write(String.Format("{0,6}", ""));
            for (int i = 0; i < model.Labels.Length; i++)
                Debug.Write(String.Format("{0,5}", "(" + model.Labels[i] + ")"));
            Debug.WriteLine("");
            for (int i = 0; i < confusionMatrix.GetLength(0); i++)
            {
                Debug.Write(String.Format("{0,5}", "(" + model.Labels[i] + ")"));
                for (int j = 0; j < confusionMatrix.GetLength(1); j++)
                    Debug.Write(String.Format("{0,5}", confusionMatrix[i, j]));
                Debug.WriteLine("");
            }
        }
    }
}