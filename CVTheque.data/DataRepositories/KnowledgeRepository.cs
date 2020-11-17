using CvTheque.Core.Models;
using CvTheque.Core.Repositories;
using CvTheque.Core.ViewModels;
using CvTheque.Data.DataRepositoties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CvTheque.Data.DataRepositories
{
    public class KnowledgeRepository : IKnowledgeRepository<int, Knowledge>
    {
        private readonly string connect = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        private readonly KnowledgeTypeRepository _knowledgeType = new KnowledgeTypeRepository();
        public void Create(Knowledge entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Add_Knowledge";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", entity.Name);
                        cmd.Parameters.AddWithValue("@KnowledgeTypeId", entity.KnowledgeTypeId);
                        cmd.Parameters.AddWithValue("@IsDelete", entity.IsDelete);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void CreateKnowledgeDevelopper(Knowledge entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Add_UserKnowledge";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", entity.UserId);
                        cmd.Parameters.AddWithValue("@KnowledgeId", entity.KnowledgeId);
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
                        cmd.CommandText = "Delete from Knowledge where Id = @Param";
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

        public IEnumerable<Knowledge> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from Knowledge";
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new Knowledge
                        {
                            Id = (int)r["Id"],
                            Name = r["Name"].ToString(),
                            KnowledgeTypeId = (int)r["KnowledgeTypeId"],
                            //IsDelete = (bool)r["IsDelete"],
                            KnowledgeTypes = _knowledgeType.GetType((int)r["Id"]),
                            
                        };
                    }
                }
            }
        }

        public Knowledge GetByName(string Name)
        {
            Knowledge Knowledge = new Knowledge();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Knowledge where Name = @value";
                        cmd.Parameters.AddWithValue("@value", Name);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            Knowledge.Id = (int)r["Id"];
                            Knowledge.Name = r["Name"].ToString();
                            Knowledge.KnowledgeTypeId = (int)r["KnowledgeTypeId"];
                            return Knowledge;
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

        public IEnumerable<ViewKnowledge> GetKnowledge(int Id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select k.Id as Id, k.Name as NameK, l.Name as NameL from Knowledge k"
                        + " join UserKnowledge uk on k.Id = uk.KnowledgeId"
                        + " join Level l on l.Id = uk.LevelId"
                        + " where uk.UserId = @value";
                    cmd.Parameters.AddWithValue("@value", Id);
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new ViewKnowledge
                        {
                            Id = (int)r["Id"],
                            Name = r["NameK"].ToString(),
                            Level = r["NameL"].ToString()
                        };
                    }
                }
            }
        }

        public IEnumerable<Knowledge> GetKnowledgeByUser(int Id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select k.Id as Id, k.Name as NameK, l.Name as NameL from Knowledge k"
                        + " join UserKnowledge uk on k.Id = uk.KnowledgeId"
                        + " join Level l on l.Id = uk.LevelId"
                        + " where uk.UserId = @value";
                    cmd.Parameters.AddWithValue("@value", Id);
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new Knowledge
                        {
                            Id = (int)r["Id"],
                            Name = r["NameK"].ToString(),
                            Level = r["NameL"].ToString()
                        };
                    }
                }
            }
        }

        public Knowledge GetOne(int Id)
        {
            Knowledge Knowledge = new Knowledge();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select k.Name, k.Id, k.KnowledgeTypeId, l.Name as NameL , uk.Id as ukId from Knowledge k"
                            + " join UserKnowledge uk on K.Id = uk.KnowledgeId"
                            + " join Level l on l.Id = uk.LevelId"
                            + " where K.Id = @value";
                        cmd.Parameters.AddWithValue("@value", Id);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            Knowledge.Id = (int)r["Id"];
                            Knowledge.Name = r["Name"].ToString();
                            Knowledge.KnowledgeTypeId = (int)r["KnowledgeTypeId"];
                            //Knowledge.IsDelete = (bool)r["IsDelete"];
                            Knowledge.KnowledgeTypes = _knowledgeType.GetType((int)r["Id"]);
                            Knowledge.Level = r["NameL"].ToString();
                            Knowledge.UserKnowledgeId = (int)r["ukId"];
                            return Knowledge;
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

        public void Update(int id, Knowledge entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Update_Knowledge";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Name", entity.Name);
                        cmd.Parameters.AddWithValue("@KnowledgeTypeId", entity.KnowledgeTypeId);
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


        public void updateKnowledgeDevelopper(int id, Knowledge entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Update_KnowledgeDevelopper";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@UserId", entity.UserId);
                        cmd.Parameters.AddWithValue("@KnowledgeId", entity.KnowledgeId);
                        cmd.Parameters.AddWithValue("@LevelId", entity.LevelId);
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
