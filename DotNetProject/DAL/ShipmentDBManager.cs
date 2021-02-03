using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using BOL;
namespace DAL
{
    public class ShipmentDBManager
    {
        public static readonly string connString = string.Empty;
        static ShipmentDBManager()
        {
            connString = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;

        }
        public static Shipment  newShipment(Shipment newShipment)
        {
            {

                // bool status = false;
                try
                {
                    using (MySqlConnection con = new MySqlConnection(connString))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        string query = "INSERT INTO Shipments (FullName,MobileNumber,BuildingName,Area,State,City,Pincode) " +
                            "VALUES (@fullname,@mobilenumber,@buildingname,@area,@state,@city,@pincode )";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.Add(new MySqlParameter("@fullname", newShipment.FullName));
                        cmd.Parameters.Add(new MySqlParameter("@mobilenumber", newShipment.MobileNumber));
                        cmd.Parameters.Add(new MySqlParameter("@buildingname", newShipment.BuildingName));
                        cmd.Parameters.Add(new MySqlParameter("@area", newShipment.Area));
                        cmd.Parameters.Add(new MySqlParameter("@state", newShipment.State));
                        cmd.Parameters.Add(new MySqlParameter("@city", newShipment.City));
                        cmd.Parameters.Add(new MySqlParameter("@pincode", newShipment.Pincode));
                        cmd.ExecuteNonQuery();// DML
                        //status = true;

                        if (con.State == ConnectionState.Open)
                            con.Close();
                    }
                }
                catch (MySqlException ex)
                {
                    string message = ex.Message;
                    throw ex;
                }
                return newShipment;


            }
        }
    }
}

