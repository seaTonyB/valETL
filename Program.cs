using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ValantETL
{
    public class MarketingETL
    {
        //file paths
        const string dataSourceFilePath = @".\CodingExercise\MarketingDataFile.txt";
        const string dataTargetFilePath = @".\CodingExercise\MarketingDataFileOut.txt";
        const string dataFormat = "MMddyyyy";
        static DateTime endDate = DateTime.Now;

        //to allow testing
        public static string stringReadFromSourceFile;
        public static List<String> StagingList1;
        public static List<String> TargetList = new List<string>();

        static void Main(string[] args)
        {

            CheckDataForDatePattern(dataFormat);

        }



        /// <summary>
        /// Checks that data matches a data format pattern and occures before today
        /// </summary>
        /// <param name="dataFormat"></param>
        public static void CheckDataForDatePattern(string dataFormat)
        {
            try
            {
                DateTime dateTime;
                //Put source data into string and strip out line feeds
                stringReadFromSourceFile = System.IO.File.ReadAllText(dataSourceFilePath).Replace("\r", "");
                //split into 8 character list 
                var stageList1 = Split(stringReadFromSourceFile, 8);
                
                //put into StagingList1
                StagingList1 = new List<string>(stageList1);

                foreach (string dateval in StagingList1)
                {
                    //check for match then output 
                    if (DateTime.TryParseExact(dateval, dataFormat, CultureInfo.InvariantCulture,
          DateTimeStyles.None, out dateTime))
                    {

                        if (dateTime < endDate)
                        {
                            Console.WriteLine(dateTime.ToString("MM/dd/yyyy"));
                            TargetList.Add(dateTime.ToString("MM/dd/yyyy"));
                        }

                    }
                }

                
                //output to file
                CreateTargetFile(dataTargetFilePath);



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }



        public static void ConvertDataAnotherWay()
        {

        }

        public static string GetDateLessThanToday(string inDate)
        {
            string rtn = null;
            if (DateTime.Parse(inDate) < DateTime.Now)
            {
                rtn = inDate;
            }
            return rtn;
        }

        public static void CreateTargetFile(string targetPath)
        {
            System.IO.File.WriteAllLines(targetPath, TargetList.ToList());

        }




        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }



    }
}
