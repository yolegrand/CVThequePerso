using CvTheque.Core.Models;
using CvTheque.Core.Repositories;
using CvTheque.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CvTheque.Data.DataRepositoties
{
    public class LevelRepository : ILevelRepository<int, Level>
    {
        private string connect = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        public void Create(Level entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Add_Level";
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
                        cmd.CommandText = "Delete from Level where Id = @Param";
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

        public IEnumerable<Level> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from Level";
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new Level
                        {
                            Id = (int)r["Id"],
                            Name = r["Name"].ToString(),
                            IsDelete = (bool)r["IsDelete"]
                        };
                    }
                }
            }
        }

        public Level GetByName(string Name)
        {
            Level level = new Level();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Level where Name = @value";
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

        public IEnumerable<ViewLevel> GetLevel(int Id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                { 
                    cmd.CommandText = "select l.Name from Lev)" +
                        "{ l join UserKnowledge uk on l.Id = uk.LevelId"
                        + " join ExperienceKnowledge ek on ek.KnowledgeId = uk.KnowledgeId"
                        + " join Experience e on e.ID = ek.ExperienceId"
                        + " join Client c on c.Id = e.ClientId"
                        + " where e.ClientId = @value";
                    cmd.Parameters.AddWithValue("@value", Id);
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new ViewLevel
                        {
                            Name = r["Name"].ToString()
                        };
                    }
                }
            }
        }

        public Level GetOne(int Id)
        {
            Level level = new Level();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Level where Id = @value";
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public void Update(int id, Level entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Update_Level";
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
