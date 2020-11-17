using CvTheque.Core.Models;
using CvTheque.Core.Repositories;
using CvTheque.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CvTheque.Data.DataRepositories
{
    public class SocietyRepository : ISocietyRepository<int, Society>
    {
        private string connect = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        public void Create(Society entity)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SP_Add_Society";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@Contact", entity.Contact);
                cmd.Parameters.AddWithValue("@City", entity.City);
                cmd.Parameters.AddWithValue("@Logo", entity.Logo);
                cmd.Parameters.AddWithValue("@IsDelete", entity.IsDelete);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Delete from Society where Id = @Param";
                cmd.Parameters.AddWithValue("@param", id);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Society> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Society";
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Society
                    {
                        Id = (int)r["Id"],
                        Name = r["Name"].ToString(),
                        IsDelete = (bool)r["IsDelete"],
                        City = r["City"].ToString(),
                        Contact = r["Contact"].ToString(),
                        Logo = r["Logo"].ToString()
                    };
                }
            }
        }

        public IEnumerable<ViewSociety> GetSocietyByClient(int Id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Society s join Client c on s.Id = c.SocietyId"
                    + " where c.Id = @value";
                cmd.Parameters.AddWithValue("@value", Id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewSociety
                    {
                        Name = r["Name"].ToString()
                    };
                }
            }
        }

        public IEnumerable<ViewSociety> GetSocietyByProspect(int Id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select s.Name from Society s join Prospect p on s.Id = p.SocietyId"
                    + " where p.Id = @value";
                cmd.Parameters.AddWithValue("@value", Id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewSociety
                    {
                        Name = r["Name"].ToString()
                    };
                }
            }
        }

        public Society GetByName(string Name)
        {
            Society Society = new Society();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Society where Name = @value";
                        cmd.Parameters.AddWithValue("@value", Name);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            Society.Id = (int)r["Id"];
                            Society.Name = r["Name"].ToString();
                            Society.IsDelete = (bool)r["IsDelete"];
                            Society.City = r["City"].ToString();
                            Society.Contact = r["Contact"].ToString();
                            Society.Logo = r["Logo"].ToString();
                            return Society;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public Society GetOne(int Id)
        {
            Society Society = new Society();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Society where Id = @value";
                        cmd.Parameters.AddWithValue("@value", Id);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            Society.Id = (int)r["Id"];
                            Society.Name = r["Name"].ToString();
                            Society.IsDelete = (bool)r["IsDelete"];
                            Society.City = r["City"].ToString();
                            Society.Contact = r["Contact"].ToString();
                            Society.Logo = r["Logo"].ToString();
                            return Society;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public void Update(int id, Society entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Update_Society";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Name", entity.Name);
                        cmd.Parameters.AddWithValue("@IsDelete", entity.IsDelete);
                        cmd.Parameters.AddWithValue("@Contact", entity.Contact);
                        cmd.Parameters.AddWithValue("@City", entity.City);
                        cmd.Parameters.AddWithValue("@Logo", entity.Logo); 
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public IEnumerable<ViewSociety> GetSocietyByUser(int Id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select s.Name from Society s join Users u on s.Id = u.SocietyId"
                    + " where u.Id = @value";
                cmd.Parameters.AddWithValue("@value", Id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new ViewSociety
                    {
                        Name = r["Name"].ToString()
                    };
                }
            }
        }

        public IEnumerable<Society> GetSocietyByUserName(string Name)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select s.Name, s.Id from Society s join Users u on s.Id = u.SocietyId"
                    + " where u.LastName = @value";
                cmd.Parameters.AddWithValue("@value", Name);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Society
                    {
                        Id = (int)r["Id"],
                        Name = r["Name"].ToString()
                    };
                }
            }
        }
    }
}
