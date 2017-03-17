using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace testProject
{
    public class Program
    {
        public static void Main(string[] args)
        {


            // Test one
            Car carone = new testProject.Car();
            Car cartwo = new testProject.Car();

            carone.Color = "red";
            carone.Size = "ONElarge";
            carone.ID = 1;

            cartwo.Color = "blue";
            cartwo.Size = "TWOlarge";
            cartwo.ID = 2;

            List<string> allDifferences = Program.differences(carone, cartwo);

            // Test two
            Pie pieOne = new testProject.Pie();
            pieOne.time = new DateTime(2016, 3, 3);

            Pie pieTwo = new testProject.Pie();
            pieTwo.time = new DateTime(2016, 4, 9);

            //List<string> allDifferences = differences(pieOne, pieTwo);

            if (allDifferences.Count != 0) {

                for (int i = 0; i < allDifferences.Count; i++)
                {

                    Debug.WriteLine(allDifferences[i]);
                }


            }

        } //End method

        public static List<string> differences<T>(T argOne, T argTwo)
        {

            List<string> differences = new List<string>();

            if (argOne != null && argTwo != null)
            {

               
                Type type = typeof(T);

                PropertyInfo[] array = type.GetProperties(BindingFlags.Public);

                foreach (PropertyInfo pi in type.GetProperties())
                {

                    object oneObject = type.GetProperty(pi.Name).GetValue(argOne);
                    object twoObject = type.GetProperty(pi.Name).GetValue(argTwo);

                    string stringObjectOne;
                    string stringObjectTwo;

                    // DateTime formatting 
                    if (oneObject.GetType() == typeof(DateTime) && twoObject.GetType() == typeof(DateTime))
                    {

                        DateTime dateObject = (DateTime)oneObject;
                        stringObjectOne = dateObject.ToString("dd/M/yyyy");

                        DateTime dateObjectTwo = (DateTime)twoObject;
                        stringObjectTwo = dateObjectTwo.ToString("dd/M/yyyy");

                    }

                    stringObjectOne = oneObject.ToString();
                    stringObjectTwo = twoObject.ToString();


                    if (stringObjectOne.Equals(stringObjectTwo) == true)
                    {
                        // There is no difference
                    }
                    else
                    {


                        differences.Add("differences: The property is " + FormatPropertyName(type.GetProperty(pi.Name).Name) + ". First Object has a result of: " +  stringObjectOne + " Second Object is " + stringObjectTwo);

                    }

                }

                return differences;

            } else {

                return differences;
            }
           
           
        } // end difference method 

        public static string FormatPropertyName(string arg1)
        {

            string result = arg1;
            StringBuilder sb = new StringBuilder();

            foreach (char c in result)
            {

                if (Char.IsUpper(c))
                {
                    sb.Append(" ");
                    sb.Append(c);

                } else {
                    sb.Append(c);
                }

                
            }


            return sb.ToString();

        }


    } // end class

}
