using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineBase
{
    public partial class Form1 : Form
    {
               private SqlConnection conn;
        private DataSet dataS;
        private SqlDataAdapter adap;

        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Desktop\интерес\MineBase\MineBase\dbmine.mdf;Integrated Security=True");
            adap = new SqlDataAdapter();
            dataS = new DataSet();
            adap.SelectCommand = new SqlCommand("Select * from MineDB", conn);

            adap.InsertCommand = new SqlCommand("Insert into MineDB (Id, Password, NamePC) values (@Id, @Pass, @name)", conn);
            adap.InsertCommand.Parameters.Add("@Id", SqlDbType.NChar, 20, "Id");
            adap.InsertCommand.Parameters.Add("@Pass", SqlDbType.Int, 20, "Password");
            adap.InsertCommand.Parameters.Add("@name", SqlDbType.Char, 20, "NamePC");

            adap.UpdateCommand = new SqlCommand("Update MineDB (Id, Password, NamePC) values (@Id, @Pass, @name)", conn);
            adap.UpdateCommand.Parameters.Add("@Id", SqlDbType.NChar, 20, "Id");
            adap.UpdateCommand.Parameters.Add("@Pass", SqlDbType.Int, 20, "Password");
            adap.UpdateCommand.Parameters.Add("@name", SqlDbType.Char, 20, "NamePC");

            adap.DeleteCommand = new SqlCommand("delete from MineDB where Id=@Id", conn);
            adap.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, 10, "Id");

            adap.Fill(dataS, "MineDB");
            infoMine.DataSource = dataS.Tables["MineDB"];
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            adap.Update(dataS.Tables["MineDB"]);
        }
    }
}
