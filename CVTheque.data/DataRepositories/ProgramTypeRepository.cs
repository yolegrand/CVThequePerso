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
    public class ProgramTypeRepository : IProgramTypeRepository<int, ProgramType>
    {
        private string connect = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        public void Create(ProgramType entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Add_SP_ProgramType";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", entity.Name);
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
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Delete from ProgramType where Id = @Param";
                        cmd.Parameters.AddWithValue("@param", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public IEnumerable<ProgramType> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from ProgramType";
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new ProgramType
                        {
                            Id = (int)r["Id"],
                            Name = r["Name"].ToString(),
                            IsDelete = (bool)r["Isdelete"]
                        };
                    }
                }
            }
        }

        public ProgramType GetByName(string Name)
        {
            ProgramType programType = new ProgramType();
            //Knowledge knowledge = new Knowledge();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from ProgramType where Name = @value";
                        cmd.Parameters.AddWithValue("@value", Name);
                        cmd.ExecuteScalar();
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            programType.Id = (int)r["Id"];
                            programType.Name = r["Name"].ToString();
                            programType.IsDelete = (bool)r["IsDelete"];
                            //knowledgeType.Knowledges = knowledge.GetLinKnowledge(int)r["Id"]
                            return programType;
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

        public ProgramType GetOne(int Id)
        {
            ProgramType programType = new ProgramType();
            //Knowledge knowledge = new Knowledge();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from ProgramType where Id = @value";
                        cmd.Parameters.AddWithValue("@value", Id);
                        cmd.ExecuteScalar();
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            programType.Id = (int)r["Id"];
                            programType.Name = r["Name"].ToString();
                            programType.IsDelete = (bool)r["IsDelete"];
                            //knowledgeType.Knowledges = knowledge.GetLinKnowledge(int)r["Id"]
                            return programType;
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

        public IEnumerable<ViewProgramType> GetType(int Id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from ProgramType pt join Program p on pt.Id = p.ProgramTypeId"
                        + " where p.Id = @value";
                    cmd.Parameters.AddWithValue("@value", Id);
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new ViewProgramType
                        {
                            Name = r["Name"].ToString()
                        };
                    }
                }
            }
        }

        public void Update(int id, ProgramType entity)
        {
            using(SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SP_Update_ProgramType";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@IsDelete", entity.IsDelete);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
