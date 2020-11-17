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
    public class ProspectRepository : IProspectRepository<int, Prospect>
    {
        private string connect = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        private readonly SectorRepository _sectorRepo = new SectorRepository();
        private readonly SocietyRepository _societyRepo = new SocietyRepository();

        public void Create(Prospect entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Add_Prospect";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", entity.Name);
                        cmd.Parameters.AddWithValue("@Contact", entity.Contact);
                        cmd.Parameters.AddWithValue("@City", entity.City);
                        cmd.Parameters.AddWithValue("@SectorId", entity.SectorId);
                        cmd.Parameters.AddWithValue("@SocietyId", entity.SocietyId);
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
                        cmd.CommandText = "Delete from Prospect where Id = @Param";
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

        public IEnumerable<Prospect> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                { 
                    cmd.CommandText = "select * from Prospect";
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new Prospect
                        {
                            Id = (int)r["Id"],
                            Name = r["Name"].ToString(),
                            City = r["City"].ToString(),
                            Contact = r["Contact"].ToString(),
                            SectorId = (int)r["SectorId"],
                            SocietyId = (int)r["SocietyId"],
                            IsDelete = (bool)r["IsDelete"]
                        };
                    }
                }
            }
        }

        public Prospect GetByContact(string Name)
        {
            Prospect Prospect = new Prospect();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Prospect where Contact = @value";
                        cmd.Parameters.AddWithValue("@value", Name);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            Prospect.Id = (int)r["Id"];
                            Prospect.Name = r["Name"].ToString();
                            Prospect.Contact = r["Contact"].ToString();
                            Prospect.City = r["City"].ToString();
                            Prospect.SocietyId = (int)r["SocietyId"];
                            Prospect.SectorId = (int)r["SectorId"];
                            Prospect.IsDelete = (bool)r["IsDelete"];
                            Prospect.Sectors = _sectorRepo.GetSectorByProspect((int)r["Id"]);
                            Prospect.Societies = _societyRepo.GetSocietyByProspect((int)r["Id"]);
                            return Prospect;
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

        public Prospect GetByName(string Name)
        {
            Prospect Prospect = new Prospect();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Prospect where Name = @value";
                        cmd.Parameters.AddWithValue("@value", Name);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            Prospect.Id = (int)r["Id"];
                            Prospect.Name = r["Name"].ToString();
                            Prospect.Contact = r["Contact"].ToString();
                            Prospect.City = r["City"].ToString();
                            Prospect.SocietyId = (int)r["SocietyId"];
                            Prospect.SectorId = (int)r["SectorId"];
                            Prospect.IsDelete = (bool)r["IsDelete"];
                            Prospect.Sectors = _sectorRepo.GetSectorByProspect((int)r["Id"]);
                            Prospect.Societies = _societyRepo.GetSocietyByProspect((int)r["Id"]);
                            return Prospect;
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

        public Prospect GetOne(int Id)
        {
            Prospect Prospect = new Prospect();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Prospect where Id = @value";
                        cmd.Parameters.AddWithValue("@value", Id);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            Prospect.Id = (int)r["Id"];
                            Prospect.Name = r["Name"].ToString();
                            Prospect.Contact = r["Contact"].ToString();
                            Prospect.City = r["City"].ToString();
                            Prospect.SocietyId = (int)r["SocietyId"];
                            Prospect.SectorId = (int)r["SectorId"];
                            Prospect.IsDelete = (bool)r["IsDelete"];
                            Prospect.Sectors = _sectorRepo.GetSectorByProspect((int)r["Id"]);
                            Prospect.Societies = _societyRepo.GetSocietyByProspect((int)r["Id"]);
                            return Prospect;
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

        public void Update(int id, Prospect entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Update_Prospect";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Name", entity.Name);
                        cmd.Parameters.AddWithValue("@Contact", entity.Contact);
                        cmd.Parameters.AddWithValue("@City", entity.City);
                        cmd.Parameters.AddWithValue("@SectorId", entity.SectorId);
                        cmd.Parameters.AddWithValue("@SocietyId", entity.SocietyId);
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
