using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CustomerBusinessLayer
    {
        public IEnumerable<Customer> Customers
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<Customer> Customers = new List<Customer>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllCustomers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Customer Customer = new Customer();
                        Customer.ID = Convert.ToInt32(rdr["Id"]);
                        Customer.Name = rdr["Name"].ToString();
                        Customer.Gender = rdr["Gender"].ToString();
                        Customer.City = rdr["City"].ToString();
                        if (!(rdr["DateOfBirth"] is DBNull))
                        {
                            Customer.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                        }
                        Customers.Add(Customer);
                    }
                }
                return Customers;
            }
        }

        public void AddCustomer(Customer customer)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = customer.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = customer.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = customer.City;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = customer.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SaveCustomer(Customer customer)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSaveCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramID = new SqlParameter();
                paramID.ParameterName = "@ID";
                paramID.Value = customer.ID;
                cmd.Parameters.Add(paramID);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = customer.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = customer.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = customer.City;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = customer.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void DeleteCustomer(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramID = new SqlParameter();
                paramID.ParameterName = "@ID";
                paramID.Value = id;
                cmd.Parameters.Add(paramID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
