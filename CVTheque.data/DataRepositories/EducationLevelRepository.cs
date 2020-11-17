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
    public class EducationLevelRepository : IEducationLevelRepository<int, EducationLevel>
    {
        private string connect = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

        public void Create(EducationLevel entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Add_EducationLevel";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", entity.Name);
                        cmd.Parameters.AddWithValue("@IsDelete", entity.IsDelete);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
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
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Delete from EducationLevel where Id = @Param";
                        cmd.Parameters.AddWithValue("@param", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public IEnumerable<EducationLevel> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from EducationLevel";
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new EducationLevel
                        {
                            Id = (int)r["Id"],
                            Name = r["Name"].ToString(),
                            IsDelete = (bool)r["IsDelete"]
                        };
                    }
                }
            }
        }

        public IEnumerable<EducationLevel> GetByLinkEducation(int Id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from EducationLevel el join Education e on el.Id = e.EducationLevel"
                        + " where e.EducationLevel = @value";
                    cmd.Parameters.AddWithValue("@value", Id);
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new EducationLevel
                        {
                            Id = (int)r["Id"],
                            Name = r["Name"].ToString()
                        };
                    }
                }
            }
        }

        public EducationLevel GetByName(string Name)
        {
            EducationLevel level = new EducationLevel();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from EducationLevel where Name = @value";
                        cmd.Parameters.AddWithValue("@value", Name);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            level.Id = (int)r["Id"];
                            level.Name = r["Name"].ToString();
                            level.IsDelete = (bool)r["IsDelete"];
                            return level;
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

        public EducationLevel GetOne(int Id)
        {
            EducationLevel level = new EducationLevel();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from EducationLevel where Id = @value";
                        cmd.Parameters.AddWithValue("@value", Id);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            level.Id = (int)r["Id"];
                            level.Name = r["Name"].ToString();
                            level.IsDelete = (bool)r["IsDelete"];
                            return level;
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

        public void Update(int id, EducationLevel entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Update_EducationLevel";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Name", entity.Name);
                        cmd.Parameters.AddWithValue("@IsDelete", entity.IsDelete);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
