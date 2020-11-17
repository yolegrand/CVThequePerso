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
    public class ProgramRepository : IProgramRepository<int, Program>
    {
        private string connect = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        private readonly ProgramTypeRepository _programType = new ProgramTypeRepository();

        public void Create(Program entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Add_Program";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", entity.Name);
                        cmd.Parameters.AddWithValue("@IsDelete", entity.IsDelete);
                        cmd.Parameters.AddWithValue("@ProgramTypeId", entity.ProgramTypeId);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void CreateProgramDevelopper(Program entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Add_UserProgram";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", entity.UserId);
                        cmd.Parameters.AddWithValue("@ProgramId", entity.ProgramId);
                        cmd.Parameters.AddWithValue("@LevelId", entity.LevelId);
                        cmd.ExecuteNonQuery();
                    }
                };
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
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Delete from Program where Id = @Param";
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

        public IEnumerable<Program> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from Program";
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new Program
                        {
                            Id = (int)r["Id"],
                            Name = r["Name"].ToString(),
                            ProgramTypeId = (int)r["ProgramTypeId"],
                            IsDelete = (bool)r["IsDelete"],
                            ProgramTypes = _programType.GetType((int)r["Id"])
                        };
                    }
                }
            }
        }

        public Program GetByName(string Name)
        {
            Program Program = new Program();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Program where Name = @value";
                        cmd.Parameters.AddWithValue("@value", Name);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            Program.Id = (int)r["Id"];
                            Program.Name = r["Name"].ToString();
                            Program.ProgramTypeId = (int)r["ProgramTypeId"];
                            Program.IsDelete = (bool)r["IsDelete"];
                            Program.ProgramTypes = _programType.GetType((int)r["Id"]);
                            return Program;
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

        public IEnumerable<ViewProgram> GetProgram(int Id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select distinct p.Name as Name, l.Name as NameL from Program p"
                        + " join UserProgram up on p.Id = up.ProgramId"
                        + " join Level l on l.Id = up.LevelId"
                        + " join ExperienceProgram ep on ep.ProgramId = up.ProgramId"
                        + " join Experience e on e.Id = ep.ExperienceId"
                        + " where up.UserId = @value";
                    cmd.Parameters.AddWithValue("@value", Id);
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new ViewProgram
                        {
                            Name = r["Name"].ToString(),
                            Level = r["NameL"].ToString()
                        };
                    }
                }
            }
        }

        public Program GetOne(int Id)
        {
            Program Program = new Program();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Program where Id = @value";
                        cmd.Parameters.AddWithValue("@value", Id);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            Program.Id = (int)r["Id"];
                            Program.Name = r["Name"].ToString();
                            Program.ProgramTypeId = (int)r["ProgramTypeId"];
                            Program.IsDelete = (bool)r["IsDelete"];
                            Program.ProgramTypes = _programType.GetType((int)r["Id"]);
                            return Program;
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

        public void Update(int id, Program entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Update_Program";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Name", entity.Name);
                        cmd.Parameters.AddWithValue("@IsDelete", entity.IsDelete);
                        cmd.Parameters.AddWithValue("@ProgramTypeId", entity.ProgramTypeId);
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
