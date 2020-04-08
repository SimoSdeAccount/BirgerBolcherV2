using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Controls;

namespace BirgerBolcherV2
{
    class DataGridFylder
    {
        private SqlConnection con;
        private DataGrid grid;
        private string view;
        public DataGridFylder(SqlConnection c)
        {
            con = c;
        }
        public DataGrid getsetDataGrid
        {
            get { return grid; }
            set { grid = value; }
        }
        public string getsetView
        {
            get { return view; }
            set { view = value; }
        }
        public void Fyld()
        {
            SqlDataAdapter loadBolchersda = new SqlDataAdapter();
            DataTable bolcherdt = new DataTable();
            loadBolchersda.SelectCommand = new SqlCommand(view, con);
            loadBolchersda.Fill(bolcherdt);
            grid.ItemsSource = bolcherdt.DefaultView;
        }
    }
}
