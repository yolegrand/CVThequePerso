using CvTheque.Core.Models;
using CvTheque.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CvTheque.Data.DataRepositories
{
    public class CityRepository : ICityRepository<int, City>
    {
        private string connect = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        public void Create(City entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Add_City";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", entity.Name);
                        cmd.Parameters.AddWithValue("@Zip", entity.Zip);
                        cmd.Parameters.AddWithValue("@IsDelete", entity.IsDelete);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Delete from City where Id = @Param";
                    cmd.Parameters.AddWithValue("@param", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public IEnumerable<City> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from City";
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new City
                    {
                        Id = (int)r["Id"],
                        Name = r["Name"].ToString(),
                        Zip = (int)r["Zip"],
                        IsDelete = (bool)r["IsDelete"]
                    };
                }
            }
        }

        public City GetByName(string Name)
        {
            City City = new City();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from City where Name = @value";
                        cmd.Parameters.AddWithValue("@value", Name);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            City.Id = (int)r["Id"];
                            City.Name = r["Name"].ToString();
                            City.Zip = (int)r["Zip"];
                            City.IsDelete = (bool)r["IsDelete"];
                            return City;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public City GetOne(int Id)
        {
            City City = new City();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "select * from City where Id = @value";
                    cmd.Parameters.AddWithValue("@value", Id);
                    SqlDataReader r = cmd.ExecuteReader();
                    if (r.Read())
                    {
                        City.Id = (int)r["Id"];
                        City.Name = r["Name"].ToString();
                        City.Zip = (int)r["Zip"];
                        City.IsDelete = (bool)r["IsDelete"];
                        return City;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public void Update(int id, City entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Update_City";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Name", entity.Name);
                        cmd.Parameters.AddWithValue("@Zip", entity.Zip);
                        cmd.Parameters.AddWithValue("@IsDelete", entity.IsDelete);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
