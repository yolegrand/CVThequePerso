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
    public class EducationRepository : IEducationRepository<int, Education>
    {
        private readonly string connect = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        private readonly EducationLevelRepository _educLevelRepo = new EducationLevelRepository();

        public void Create(Education entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Add_Education";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BeginDate", DateTime.Parse(entity.BeginDate.ToString()));
                        cmd.Parameters.AddWithValue("@EndDate", DateTime.Parse(entity.EndDate.ToString()));
                        cmd.Parameters.AddWithValue("@Name", entity.Name);
                        cmd.Parameters.AddWithValue("@EducationLevel", entity.EducationLevel);
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
                        cmd.CommandText = "Delete from Education where Id = @Param";
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

        public IEnumerable<Education> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from Education";
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new Education
                        {
                            Id = (int)r["Id"],
                            EndDate = (DateTime)r["EndDate"],
                            BeginDate = (DateTime)r["BeginDate"],
                            Name = r["Name"].ToString(),
                            EducationLevel = (int)r["EducationLevel"],
                            UserId = (int)r["UserId"],
                            IsDelete = (bool)r["IsDelete"]
                        };
                    }
                }
            }
        }

        public IEnumerable<ViewEducation> GetByLinkEducation(int Id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select e.Id, e.Name, e.BeginDate, e.EndDate, el.Name as NameL from Education e"
                        + " join EducationLevel el on el.Id = e.EducationLevel"
                        + " join Users u on e.UserId = u.Id"
                        + " where e.UserId = @value";
                    cmd.Parameters.AddWithValue("@value", Id);
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new ViewEducation
                        {
                            Id = (int)r["Id"],
                            Name = r["Name"].ToString(),
                            BeginDate = (DateTime)r["BeginDate"],
                            EndDate = (DateTime)r["EndDate"],
                            Level = r["NameL"].ToString()
                        };
                    }
                }
            }
        }

        public Education GetOne(int Id)
        {
            Education Education = new Education();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select e.Id, e.BeginDate, e.EndDate, e.Name, e.UserId, e.EducationLevel,"
                            + " e.IsDelete, l.Name as Namel from Education e"
                            + " join EducationLevel l on l.Id = e.EducationLevel"
                            + " where e.Id = @value";
                        cmd.Parameters.AddWithValue("@value", Id);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            Education.Id = (int)r["Id"];
                            Education.BeginDate = (DateTime)r["BeginDate"];
                            Education.EndDate = (DateTime)r["EndDate"];
                            Education.Name = r["Name"].ToString();
                            Education.UserId = (int)r["UserId"];
                            Education.EducationLevel = (int)r["EducationLevel"];
                            Education.IsDelete = (bool)r["IsDelete"];
                            Education.EducationLevels = _educLevelRepo.GetByLinkEducation((int)r["Id"]);
                            Education.Level = r["NameL"].ToString();
                            return Education;
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

        public void Update(int id, Education entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Update_Education";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@BeginDate", entity.BeginDate);
                        cmd.Parameters.AddWithValue("@EndDate", entity.EndDate);
                        cmd.Parameters.AddWithValue("@Name", entity.Name);
                        cmd.Parameters.AddWithValue("@EducationLevel", entity.EducationLevel);
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

        public void updateEducationDevelopper(int id, Education entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Update_EducationDevelopper";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@UserId", entity.UserId);
                        cmd.Parameters.AddWithValue("@EducationLevel", entity.EducationLevel);
                        cmd.Parameters.AddWithValue("@Name", entity.Name);
                        cmd.Parameters.AddWithValue("@BeginDate", DateTime.Parse(entity.BeginDate.ToString()));
                        cmd.Parameters.AddWithValue("@EndDate", DateTime.Parse(entity.EndDate.ToString()));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public Education GetByName(string Name)
        {
            Education Education = new Education();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Education where Name = @value";
                        cmd.Parameters.AddWithValue("@value", Name);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            Education.Id = (int)r["Id"];
                            Education.BeginDate = (DateTime)r["BeginDate"];
                            Education.EndDate = (DateTime)r["EndDate"];
                            Education.Name = r["Name"].ToString();
                            Education.UserId = (int)r["UserId"];
                            Education.EducationLevel = (int)r["EducationLevel"];
                            Education.IsDelete = (bool)r["IsDelete"];
                            Education.EducationLevels = _educLevelRepo.GetByLinkEducation((int)r["Id"]);
                            return Education;
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

        public IEnumerable<ViewEducation> GetEducation(int Id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select e.Name, el.Name as EducationLevel from Education e"
                        + " join EducationLevel el on el.Id = e.EducationLevel"
                        + " join Users u on u.Id = e.UserId"
                        + " join Experience ex on ex.UserId = u.Id"
                        + " join Client c on c.Id = ex.ClientId"
                        + " where c.Id = @value";
                    cmd.Parameters.AddWithValue("@value", Id);
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new ViewEducation
                        {
                            Name = r["Name"].ToString(),
                            Level = r["EducationLevel"].ToString()
                        };
                    }
                }
            }
        }
    }
}
