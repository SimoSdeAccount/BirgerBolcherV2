using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BirgerBolcherV2
{
    class IndsætBolche
    {
        private SqlConnection con;
        private string[] parametre;
        private string[] værdier;
        public IndsætBolche(SqlConnection c) 
        {
            con = c;
        }
        public string[] getsetParametre
        {
            get { return parametre; }
            set { parametre = value; }
        }
        public string[] getsetVærdier
        {
            get { return værdier; }
            set { værdier = value; }
        }
        public void Indsæt()
        {
            SqlCommand opretBolcheCmd = new SqlCommand("InsertBolche", con);
            opretBolcheCmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < parametre.Length; i++)
            {
                opretBolcheCmd.Parameters.AddWithValue(parametre[i], værdier[i]);
            }
            con.Open();
            opretBolcheCmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
