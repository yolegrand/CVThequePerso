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
    public class ExperienceRepository : IExperienceRepository<int, Experience>
    {
        private string connect = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        private readonly FunctionRepository _functionRepo = new FunctionRepository();
        public void Create(Experience entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Add_Experience";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BeginDate", entity.BeginDate);
                        cmd.Parameters.AddWithValue("@EndDate", entity.EndDate);
                        cmd.Parameters.AddWithValue("@Description", entity.Description);
                        cmd.Parameters.AddWithValue("@ClientId", entity.ClientId);
                        cmd.Parameters.AddWithValue("@UserId", entity.UserId);
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
                        cmd.CommandText = "Delete from Experience where Id = @Param";
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

        public IEnumerable<Experience> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Experience";
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    yield return new Experience
                    {
                        Id = (int)r["Id"],
                        EndDate = (DateTime)r["EndDate"],
                        BeginDate = (DateTime)r["BeginDate"],
                        Description = r["Description"].ToString(),
                        ClientId = (int)r["ClientId"],
                        UserId = (int)r["UserId"],
                        IsDelete = (bool)r["IsDelete"]
                    };
                }
            }
        }

        public Experience GetOne(int Id)
        {
            Experience Experience = new Experience();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Experience where Id = @value";
                        cmd.Parameters.AddWithValue("@value", Id);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            Experience.Id = (int)r["Id"];
                            Experience.BeginDate = (DateTime)r["BeginDate"];
                            Experience.EndDate = (DateTime)r["EndDate"];
                            Experience.Description = r["Description"].ToString();
                            Experience.ClientId = (int)r["ClientId"];
                            Experience.UserId = (int)r["UserId"];
                            Experience.IsDelete = (bool)r["IsDelete"];
                            return Experience;
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

        public IEnumerable<ViewExperience> GetExperience(int Id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select e.Id, e.BeginDate, e.EndDate, e.Description from Experience e"
                        + " where e.UserId = @value";
                    cmd.Parameters.AddWithValue("@value", Id);
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new ViewExperience
                        {
                            Id = (int)r["Id"],
                            BeginDate = (DateTime)r["BeginDate"],
                            EndDate = (DateTime)r["EndDate"],
                            Description = r["Description"].ToString(),
                            Functions = _functionRepo.GetFunction((int)r["Id"])
                        };
                    }
                }
            }
        }

        public void Update(int id, Experience entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Update_Experience";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@BeginDate", entity.BeginDate);
                        cmd.Parameters.AddWithValue("@EndDate", entity.EndDate);
                        cmd.Parameters.AddWithValue("@Description", entity.Description);
                        cmd.Parameters.AddWithValue("@ClientId", entity.ClientId);
                        cmd.Parameters.AddWithValue("@UserId", entity.UserId);
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
