﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace monopoly.logic.classes
{
    [Serializable]
    public class cConfig
    {
        #region "vars"
        private static cConfig myInstance;
        private String myFile;
        private String mySchemaFile;


        private DataSet myDTS;

        private Dictionary<String, String> myConfigValues;
        private Dictionary<String, String> mySystemValues;
        private Dictionary<String, String> myLoggerValues;
        private Dictionary<String, String> myServerValues;
        private Dictionary<String, String> myClientValues;
        private Dictionary<String, String> myClientHistoryServers;
        private Dictionary<String, String> myClientHistoryNames;
        private Dictionary<String, String> myGameValues;
        private Dictionary<String, String> myStreetsValues;
        private Dictionary<String, List<int>> myStreetValues;
        private Dictionary<String, String> myRegularSquaresValues;
        private Dictionary<String, Dictionary<String,String>> myRegularSquareValues;
        private Dictionary<String, String> myTrainSquaresValues;
        private Dictionary<String, Dictionary<String, String>> myTrainSquareValues;
        private Dictionary<String, String> myWaterPowerSquaresValues;
        private Dictionary<String, Dictionary<String, String>> myWaterPowerSquareValues;
        private Dictionary<String, String> myTaxSquaresValues;
        private Dictionary<String, Dictionary<String, String>> myTaxSquareValues;
        private Dictionary<String, String> myCommunityCardsValues;
        private Dictionary<String, Dictionary<String, String>> myCommunityCardValues;
        private Dictionary<String, String> myActionCardsValues;
        private Dictionary<String, Dictionary<String, String>> myActionCardValues;
        

        #endregion

        #region "constructor"
        private cConfig()
        {
            this.myConfigValues = new Dictionary<string, string>();
            this.myLoggerValues = new Dictionary<string, string>();
            this.mySystemValues = new Dictionary<string, string>();
            
            this.myServerValues = new Dictionary<string, string>();
            this.myClientValues = new Dictionary<string, string>();
                        
            this.myClientHistoryNames = new Dictionary<string, string>();
            this.myClientHistoryServers = new Dictionary<string, string>();
            
            this.myGameValues = new Dictionary<string, string>();

            this.myStreetsValues = new Dictionary<String, String>(); 
            this.myStreetValues = new Dictionary<string, List<int>>();
            this.myRegularSquaresValues = new Dictionary<string, string>(); 
            this.myRegularSquareValues = new Dictionary<string, Dictionary<String,String>>();
            this.myTrainSquaresValues = new Dictionary<string, string>();
            this.myTrainSquareValues = new Dictionary<string, Dictionary<String, String>>();
            this.myWaterPowerSquaresValues = new Dictionary<string, string>();
            this.myWaterPowerSquareValues = new Dictionary<string, Dictionary<String, String>>();
            this.myTaxSquaresValues = new Dictionary<string, string>();
            this.myTaxSquareValues = new Dictionary<string, Dictionary<String, String>>();

            this.myCommunityCardsValues = new Dictionary<string, string>();
            this.myCommunityCardValues = new Dictionary<string, Dictionary<string, string>>();
            this.myActionCardsValues = new Dictionary<string, string>();
            this.myActionCardValues = new Dictionary<string, Dictionary<string, string>>();
            

            this.myFile = monopoly.logic.Properties.Settings.Default.myCFGFile;

            this.mySchemaFile = monopoly.logic.Properties.Settings.Default.mySchemaFile ;


            this.myDTS = new DataSet();
            this.myDTS.ReadXmlSchema(this.mySchemaFile);


            System.IO.FileStream fsRead = new System.IO.FileStream(this.myFile, System.IO.FileMode.Open);

            this.myDTS.ReadXml(fsRead);
            fsRead.Close();

            fillConfigValues();
            fillSystemValues();
            fillLoggerValues();
            fillServerValues();
            fillClientValues();
            fillClientHistoryServersValues();
            fillClientHistoryNamesValues();
            fillGameValues();
            fillStreetsValues();
            fillStreetValues();
            fillRegularSquaresValues();
            fillRegularSquareValues();
            fillTrainSquaresValues();
            fillTrainSquareValues();
            fillWaterPowerSqauresValues();
            fillWaterPowerSqaureValues();
            fillTaxSqauresValues();
            fillTaxSqaureValues();
            fillCommunityCardsValues();
            fillCommunityCardValues();
            fillActionCardsValues();
            fillActionCardValues();


        }
        public static cConfig getInstance
        {
             get
              {

                if (myInstance == null)
                {
                    myInstance = new cConfig ();
                }
                return myInstance;
                 }

            
        }



        #endregion

        #region "functions"

        private void fillConfigValues()
        {
            DataRow r = this.myDTS.Tables["Config"].Rows[0];
            foreach (DataColumn c in this.myDTS.Tables["Config"].Columns)
            {
                this.myConfigValues.Add(c.ColumnName, r[c].ToString() ); 
            }
        }

        private void fillSystemValues()
        {
            String ConfigID = this.myConfigValues["Config_Id"];
            DataRow r = this.myDTS.Tables["System"].Select(String.Format("Config_Id = {0}", ConfigID))[0];
            foreach (DataColumn c in this.myDTS.Tables["System"].Columns)
            {
                this.mySystemValues.Add(c.ColumnName, r[c].ToString()); 
            }

        }

        private void fillLoggerValues()
        {
            String SystemID = this.mySystemValues["System_Id"];
            DataRow r = this.myDTS.Tables["Logger"].Select(String.Format("System_Id = {0}", SystemID))[0];
            foreach (DataColumn c in this.myDTS.Tables["Logger"].Columns)
            {
                this.myLoggerValues.Add(c.ColumnName, r[c].ToString());
            }

        }

        private void fillServerValues()
        {
            String ConfigID = this.myConfigValues["Config_Id"];
            DataRow r = this.myDTS.Tables["Server"].Select(String.Format("Config_Id = {0}", ConfigID))[0];
            foreach (DataColumn c in this.myDTS.Tables["Server"].Columns)
            {
                this.myServerValues.Add(c.ColumnName, r[c].ToString());
            }
        }   

        private void fillClientValues()
        {
            String ConfigID = this.myConfigValues["Config_Id"];
            DataRow r = this.myDTS.Tables["Client"].Select(String.Format("Config_Id = {0}", ConfigID))[0];
            foreach (DataColumn c in this.myDTS.Tables["Client"].Columns)
            {
                this.myClientValues.Add(c.ColumnName, r[c].ToString());
            }
        }

        private void fillClientHistoryServersValues()
        {
            String ClientID = this.myClientValues["Client_Id"];
            foreach (DataRow r in this.myDTS.Tables["ClientHistoryServer"].Select(String.Format("ClientHistoryServers_Id = {0}", 0)))
            {
                this.myClientHistoryServers.Add(r["id"].ToString() , r["ClientHistoryServer_text"].ToString());  
            }
        }
        
        private void fillClientHistoryNamesValues()
        {
            String ClientID = this.myClientValues["Client_Id"];
            foreach (DataRow r in this.myDTS.Tables["ClientHistoryName"].Select(String.Format("ClientHistoryNames_Id = {0}", 0))) 
            {
                this.myClientHistoryNames.Add(r["id"].ToString(), r["ClientHistoryName_text"].ToString());  

            }
        }

        private void fillGameValues()
        {
            String ConfigID = this.myConfigValues["Config_Id"];
            DataRow r = this.myDTS.Tables["Game"].Select(String.Format("Config_Id = {0}", ConfigID))[0];
            foreach (DataColumn c in this.myDTS.Tables["Game"].Columns)
            {
                this.myGameValues.Add(c.ColumnName, r[c].ToString());
            }

        }

        private void fillStreetsValues()
        {
            String GameID = this.myGameValues["Game_Id"];
            DataRow r = this.myDTS.Tables["Streets"].Select(String.Format("Game_Id = {0}",GameID))[0];
            foreach (DataColumn c in this.myDTS.Tables["Streets"].Columns)
            {
                this.myStreetsValues.Add(c.ColumnName, r[c].ToString());
            }
        }

        private void fillStreetValues()
        {
            String StreetsID = this.myStreetsValues["Streets_Id"];
            foreach(DataRow r in this.myDTS.Tables["Street"].Select(String.Format("Streets_Id = {0}", StreetsID)))
            {
                String tmpColor="";
                foreach (DataColumn c in this.myDTS.Tables["Street"].Columns)
                {
                    if (c.ColumnName.ToLower() == "color") tmpColor = r[c].ToString();
                }
                List<int> tmpList = new List<int>();

                String StreetID = r["Street_Id"].ToString();
                foreach (DataRow r2 in this.myDTS.Tables["Squares"].Select(String.Format("Street_Id = {0}", StreetID)))
                {
                    String Squares_ID = r2["Squares_Id"].ToString();
                    foreach (DataRow r3 in this.myDTS.Tables["ID"].Select(String.Format("Squares_Id = {0}", Squares_ID)))
                    {

                        int ID = Convert.ToInt32(r3["ID_Column"].ToString());
                        tmpList.Add(ID);
                    }

                }
  
                this.myStreetValues.Add(tmpColor , tmpList);

            }
            

        }

        private void fillRegularSquaresValues()
        {
            String GameID = this.myGameValues["Game_Id"];
            DataRow r = this.myDTS.Tables["RegularSquares"].Select(String.Format("Game_Id = {0}", GameID))[0];
            foreach (DataColumn c in this.myDTS.Tables["RegularSquares"].Columns)
            {
                this.myRegularSquaresValues .Add(c.ColumnName, r[c].ToString());
            }
        }

        private void fillRegularSquareValues()
        {
            String RegularSquaresID = this.myRegularSquaresValues["RegularSquares_Id"];
            foreach (DataRow r in this.myDTS.Tables["RegularSquare"].Select(String.Format("RegularSquares_Id = {0}", RegularSquaresID)))
            {
                String ID = "";
                String RegularSquareID = "";
                Dictionary<String, String> dict = new Dictionary<string, string>();
                foreach (DataColumn c in this.myDTS.Tables["RegularSquare"].Columns)
                {
                    dict.Add(c.ColumnName, r[c].ToString()); 
                    if (c.ColumnName.ToLower() == "id") ID = r[c].ToString();
                    if (c.ColumnName.ToLower() == "RegularSquare_Id".ToLower()) RegularSquareID = r[c].ToString();
                }

                foreach (DataRow r2 in this.myDTS.Tables["rents"].Select(String.Format("RegularSquare_Id = {0}", RegularSquareID)))
                {
                    String RentsID = "";
                    RentsID = r2["Rents_Id"].ToString();
                    
                    foreach (DataRow r3 in this.myDTS.Tables["level"].Select(String.Format("Rents_Id = {0}", RentsID)))
                    {
                        dict.Add(r3["id"].ToString(), r3["level_text"].ToString());
                    }
                }

                this.myRegularSquareValues.Add(ID, dict);
            }

        }

        private void fillTrainSquaresValues()
        {
            String GameID = this.myGameValues["Game_Id"];
            DataRow r = this.myDTS.Tables["TrainSquares"].Select(String.Format("Game_Id = {0}", GameID))[0];
            foreach (DataColumn c in this.myDTS.Tables["TrainSquares"].Columns)
            {
                this.myTrainSquaresValues.Add(c.ColumnName, r[c].ToString());
            }
        }

        private void fillTrainSquareValues()
        {
            String TrainSquaresID = this.myTrainSquaresValues["TrainSquares_Id"];
            foreach (DataRow r in this.myDTS.Tables["TrainSquare"].Select(String.Format("TrainSquares_Id = {0}", TrainSquaresID)))
            {
                String ID = "";
                Dictionary<String, String> dict = new Dictionary<string, string>();
                foreach (DataColumn c in this.myDTS.Tables["TrainSquare"].Columns)
                {
                    dict.Add(c.ColumnName, r[c].ToString());
                    if (c.ColumnName.ToLower() == "id") ID = r[c].ToString();
                }
                foreach (DataRow r2 in this.myDTS.Tables["rents"].Select(String.Format("TrainSquare_Id = {0}", TrainSquaresID)))
                {
                    String RentsID = "";
                    RentsID = r2["Rents_Id"].ToString();

                    foreach (DataRow r3 in this.myDTS.Tables["level"].Select(String.Format("Rents_Id = {0}", RentsID)))
                    {
                        dict.Add(r3["id"].ToString(), r3["level_text"].ToString());
                    }
                }
                this.myTrainSquareValues.Add(ID, dict);
            }
        }

        private void fillWaterPowerSqauresValues()
        {
            String GameID = this.myGameValues["Game_Id"];
            DataRow r = this.myDTS.Tables["WaterPowerSquares"].Select(String.Format("Game_Id = {0}", GameID))[0];
            foreach (DataColumn c in this.myDTS.Tables["WaterPowerSquares"].Columns)
            {
                this.myWaterPowerSquaresValues.Add(c.ColumnName, r[c].ToString());
            }
        }

        private void fillWaterPowerSqaureValues()
        {
            String WaterPowerSquaresID = this.myWaterPowerSquaresValues["WaterPowerSquares_Id"];
            foreach (DataRow r in this.myDTS.Tables["WaterPowerSquare"].Select(String.Format("WaterPowerSquares_Id = {0}", WaterPowerSquaresID)))
            {
                String ID = "";
                String WaterPowerSquareID = "";
                Dictionary<String, String> dict = new Dictionary<string, string>();
                foreach (DataColumn c in this.myDTS.Tables["WaterPowerSquare"].Columns)
                {
                    dict.Add(c.ColumnName, r[c].ToString());
                    if (c.ColumnName.ToLower() == "id") ID = r[c].ToString();
                    if (c.ColumnName.ToLower() == "WaterPowerSquare_Id".ToLower()) WaterPowerSquareID = r[c].ToString();
                }

                foreach (DataRow r2 in this.myDTS.Tables["rents"].Select(String.Format("WaterPowerSquare_Id = {0}", WaterPowerSquareID)))
                {
                    String RentsID = "";
                    RentsID = r2["Rents_Id"].ToString();

                    foreach (DataRow r3 in this.myDTS.Tables["level"].Select(String.Format("Rents_Id = {0}", RentsID)))
                    {
                        dict.Add(r3["id"].ToString(), r3["level_text"].ToString());
                    }
                }

                this.myWaterPowerSquareValues.Add(ID, dict);
            }

        }

        private void fillTaxSqauresValues()
        {
            String GameID = this.myGameValues["Game_Id"];
            DataRow r = this.myDTS.Tables["TaxSquares"].Select(String.Format("Game_Id = {0}", GameID))[0];
            foreach (DataColumn c in this.myDTS.Tables["TaxSquares"].Columns)
            {
                this.myTaxSquaresValues.Add(c.ColumnName, r[c].ToString());
            }
        }

        private void fillTaxSqaureValues()
        {
            String TaxSquaresID = this.myTaxSquaresValues["TaxSquares_Id"];
            foreach (DataRow r in this.myDTS.Tables["TaxSquare"].Select(String.Format("TaxSquares_Id = {0}", TaxSquaresID)))
            {

                String ID = "";
                Dictionary<String, String> dict = new Dictionary<string, string>();
                foreach (DataColumn c in this.myDTS.Tables["TaxSquare"].Columns)
                {
                    dict.Add(c.ColumnName, r[c].ToString());
                    if (c.ColumnName.ToLower() == "id") ID = r[c].ToString();
                    
                }

               
                this.myTaxSquareValues.Add(ID, dict);
            }

        }

        private void fillCommunityCardsValues()
        {
            String GameID = this.myGameValues["Game_Id"];
            DataRow r = this.myDTS.Tables["CommunityCards"].Select(String.Format("Game_Id = {0}", GameID))[0];
            foreach (DataColumn c in this.myDTS.Tables["CommunityCards"].Columns)
            {
                this.myCommunityCardsValues.Add(c.ColumnName, r[c].ToString());
            }
        }
        private void fillCommunityCardValues()
        {
            String CommunityCardsID = this.myCommunityCardsValues["CommunityCards_Id"];
            foreach (DataRow r in this.myDTS.Tables["CommunityCard"].Select(String.Format("CommunityCards_Id = {0}", CommunityCardsID)))
            {

                String ID = "";
                Dictionary<String, String> dict = new Dictionary<string, string>();
                foreach (DataColumn c in this.myDTS.Tables["CommunityCard"].Columns)
                {
                    dict.Add(c.ColumnName, r[c].ToString());
                    if (c.ColumnName.ToLower() == "id") ID = r[c].ToString();

                }


                this.myCommunityCardValues.Add(ID, dict);
            }
        }

        private void fillActionCardsValues()
        {
            String GameID = this.myGameValues["Game_Id"];
            DataRow r = this.myDTS.Tables["ActionCards"].Select(String.Format("Game_Id = {0}", GameID))[0];
            foreach (DataColumn c in this.myDTS.Tables["ActionCards"].Columns)
            {
                this.myActionCardsValues.Add(c.ColumnName, r[c].ToString());
            }
        }

        private void fillActionCardValues()
        {
            String ActionCardsID = this.myActionCardsValues["ActionCards_Id"];
            foreach (DataRow r in this.myDTS.Tables["ActionCard"].Select(String.Format("ActionCards_Id = {0}", ActionCardsID)))
            {

                String ID = "";
                Dictionary<String, String> dict = new Dictionary<string, string>();
                foreach (DataColumn c in this.myDTS.Tables["ActionCard"].Columns)
                {
                    dict.Add(c.ColumnName, r[c].ToString());
                    if (c.ColumnName.ToLower() == "id") ID = r[c].ToString();

                }


                this.myActionCardValues.Add(ID, dict);
            }
        }

        #endregion


        #region "properties"

        public Dictionary<String, String> Config { get { return this.myConfigValues; } }
        public Dictionary<String, String> _System { get { return this.mySystemValues; } }
        public Dictionary<String, String> Logger { get { return this.myLoggerValues; } }
        public Dictionary<String, String> Server { get { return this.myServerValues; } }
        public Dictionary<String, String> Client { get { return this.myClientValues; } }
        public Dictionary<String, String> ClientHistoryServers { get { return this.myClientHistoryServers; } }
        public Dictionary<String, String> ClientHistoryNames { get { return this.myClientHistoryNames; } }
        public Dictionary<String, String> Game { get { return this.myGameValues; } }
        public Dictionary<String, List<int>> Streets { get { return this.myStreetValues; } }
        public Dictionary<String, Dictionary<String, String>> RegularSquares { get { return this.myRegularSquareValues; } }
        public Dictionary<String, Dictionary<String, String>> TrainSquares { get { return this.myTrainSquareValues; } }
        public Dictionary<String, Dictionary<String, String>> WaterPowerSquares { get { return this.myWaterPowerSquareValues; } }

        public Dictionary<String, Dictionary<String, String>> TaxSquares { get { return this.myTaxSquareValues; } }

        public Dictionary<String, Dictionary<string, string>> CommunityCards { get { return this.myCommunityCardValues; } }

        public Dictionary<String, Dictionary<string, string>> ActionCards { get { return this.myActionCardValues; } }

        #endregion

    }
}
