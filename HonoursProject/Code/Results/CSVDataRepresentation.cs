using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HonoursProject.Code.Results
{
    public class CSVDataRepresentation
    {
        public enum COL { Id, ARSON, ASSAULT, BADCHECKS, BRIBERY, BURGLARY, DISORDERLYCONDUCT, DRIVINGUNDERTHEINFLUENCE, DRUG_NARCOTIC, DRUNKENNESS, EMBEZZLEMENT, EXTORTION,
            FAMILYOFFENSES, FORGERY_COUNTERFEITING, FRAUD, GAMBLING, KIDNAPPING, LARCENY_THEFT, LIQUORLAWS, LOITERING, MISSINGPERSON, NONCRIMINAL, OTHEROFFENSES, 
            PORNOGRAPHY_OBSCENEMAT, PROSTITUTION, RECOVEREDVEHICLE, ROBBERY, RUNAWAY, SECONDARYCODES, SEXOFFENSESFORCIBLE, SEXOFFENSESNONFORCIBLE, STOLENPROPERTY, SUICIDE,
            SUSPICIOUSOCC, TREA, TRESPASS, VANDALISM, VEHICLETHEFT, WARRANTS, WEAPONLAWS
        };
        public enum COL_ACC
        {
            Id, ARSON, ASSAULT, BRIBERY, BURGLARY, DISORDERLYCONDUCT, DRIVINGUNDERTHEINFLUENCE, DRUG_NARCOTIC, DRUNKENNESS, EMBEZZLEMENT, EXTORTION,
            FAMILYOFFENSES, FRAUD, GAMBLING, KIDNAPPING, LARCENY_THEFT, LIQUORLAWS, LOITERING, MISSINGPERSON, NONCRIMINAL, OTHEROFFENSES,
            PORNOGRAPHY_OBSCENEMAT, PROSTITUTION, ROBBERY, RUNAWAY, SECONDARYCODES, SEXOFFENSESFORCIBLE, SEXOFFENSESNONFORCIBLE, STOLENPROPERTY, SUICIDE,
            SUSPICIOUSOCC, TRESPASS, VANDALISM, VEHICLETHEFT, WARRANTS, WEAPONLAWS
        };
        public static readonly string[] COL_NAME = {
            "Id","Arson","Assault","Bad Checks","Bribery","Burglary","Disorderly Conduct","Driving Under The Influence","Drug/Narcotic","Drunkenness","Embezzlement","Extortion",
            "Family Offenses","Forgery/Counterfeiting","Fraud","Gambling","Kidnapping","Larceny/Theft","Liquor Laws","Loitering","Missing Person","Non-Criminal","Other Offenses",
            "Pornography/Obscene Mat","Prostitution","Recovered Vehicle","Robbery","Runaway","Secondary Codes","Sex Offenses Forcible","Sex Offenses Non Forcible",
            "Stolen Property","Suicide","Suspicious Occ","Trea","Trespass","Vandalism","Vehicle Theft","Warrants","Weapon Laws"
        };
        public static readonly string[] COL_NAME_ACC = {
            "Id","Arson","Assault","Bribery","Burglary","Disorderly Conduct","Driving Under The Influence","Drug/Narcotic","Drunkenness","Embezzlement","Extortion",
            "Family Offenses","Fraud","Gambling","Kidnapping","Larceny/Theft","Liquor Laws","Loitering","Missing Person","Non-Criminal","Other Offenses",
            "Pornography/Obscene Mat","Prostitution","Robbery","Runaway","Secondary Codes","Sex Offenses Forcible","Sex Offenses Non Forcible",
            "Stolen Property","Suicide","Suspicious Occ","Trespass","Vandalism","Vehicle Theft","Warrants","Weapon Laws"
        };

        //public struct occurenceCategory
        //{
        //    public int id;
        //    public string category;
        //}

        //struct numberCategories
        //{
        //    public string category;
        //    public int total;
        //}

        private List<occurenceCategory> occCategory;
        private List<numberCategories> numCategories;

        public List<occurenceCategory> OccCategory { get => occCategory; set => occCategory = value; }
        public List<numberCategories> NumCategories { get => numCategories; set => numCategories = value; }

        public CSVDataRepresentation(List<int[]> results, bool isAccuracy = false)
        {
            OccCategory = new List<occurenceCategory>();
            NumCategories = new List<numberCategories>();

            //if (isAccuracy == true)
            //{
            //    calculateCategoryTotalOccurenceAccuracy(results);
            //}
            //else
            //{
                for (int i = 1; i < COL_NAME.Length; i++)
                {
                    numberCategories numCat = new numberCategories();
                    numCat.Category = COL_NAME[i];
                    numCat.Total = 0;
                    NumCategories.Add(numCat);
                }
                calculateCategoryTotalOccurence(results);
            //}
        }

        public void calculateCategoryTotalOccurence(List<int[]> results)
        {
            foreach(int[] row in results)
            {
                occurenceCategory occCat = new occurenceCategory();
                occCat.Id = row[0];
                for(int i = 1; i < COL_NAME.Length; i++)
                {
                    // Change row to row[i-1]
                    //if(row[i-1] == 1)
                    if(row[i] == 1)
                    {
                        occCat.Category = COL_NAME[i];
                        OccCategory.Add(occCat);
                        numberCategories numCat = NumCategories[i-1];
                        int oldTot = numCat.Total;
                        int newTot = oldTot + 1;
                        NumCategories[i-1].Total = newTot;
                        break;
                    }
                }
            }
        }

        //public void calculateCategoryTotalOccurenceAccuracy(List<int[]> results)
        //{
        //    foreach (int[] row in results)
        //    {
        //        occurenceCategory occCat = new occurenceCategory();
        //        occCat.Id = row[0];
        //        for (int i = 1; i < COL_NAME_ACC.Length; i++)
        //        {
        //            if (row[i] == 1)
        //            {
        //                occCat.Category = COL_NAME_ACC[i];
        //                OccCategory.Add(occCat);
        //                numberCategories numCat = NumCategories[i - 1];
        //                numCat.Total++;
        //                NumCategories[i - 1] = numCat;
        //                break;
        //            }
        //        }
        //    }
        //}
    }
}