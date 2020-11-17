using CvTheque.Core.Models;
using CvTheque.Core.Repositories;
using CvTheque.Data.DataRepositoties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CvTheque.Data.DataRepositories
{
    public class ClientRepository : IClientRpository<int, Client>
    {
        private readonly string connect = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        private readonly SectorRepository _sectorRepo = new SectorRepository();
        private readonly SocietyRepository _societyRepo = new SocietyRepository();
        public void Create(Client entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Add_Client";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", entity.Name);
                        cmd.Parameters.AddWithValue("@Contact", entity.Contact);
                        cmd.Parameters.AddWithValue("@City", entity.City);
                        cmd.Parameters.AddWithValue("@SectorId", entity.SectorId);
                        cmd.Parameters.AddWithValue("@SocietyId", entity.SocietyId);
                        cmd.Parameters.AddWithValue("@IsDelete", entity.IsDelete);
                        cmd.ExecuteNonQuery();
                    }
                };
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
                        cmd.CommandText = "Delete from Client where Id = @Param";
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

        public IEnumerable<Client> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from Client";
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new Client
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

        public Client GetByContact(string Contact)
        {
            Client Client = new Client();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.ExecuteScalar();
                        cmd.CommandText = "select * from Client where Contact = @value";
                        cmd.Parameters.AddWithValue("@value", Contact);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            Client.Id = (int)r["Id"];
                            Client.Name = r["Name"].ToString();
                            Client.Contact = r["Contact"].ToString();
                            Client.City = r["City"].ToString();
                            Client.SocietyId = (int)r["SocietyId"];
                            Client.SectorId = (int)r["SectorId"];
                            Client.IsDelete = (bool)r["IsDelete"];
                            Client.Sectors = _sectorRepo.GetSectorByClient((int)r["Id"]);
                            Client.Societies = _societyRepo.GetSocietyByClient((int)r["Id"]);
                            return Client;
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

        public Client GetByName(string Name)
        {
            Client Client = new Client();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Client where Name = @value";
                        cmd.Parameters.AddWithValue("@value", Name);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            Client.Id = (int)r["Id"];
                            Client.Name = r["Name"].ToString();
                            Client.Contact = r["Contact"].ToString();
                            Client.City = r["City"].ToString();
                            Client.SocietyId = (int)r["SocietyId"];
                            Client.SectorId = (int)r["SectorId"];
                            Client.IsDelete = (bool)r["IsDelete"];
                            Client.Sectors = _sectorRepo.GetSectorByClient((int)r["Id"]);
                            Client.Societies = _societyRepo.GetSocietyByClient((int)r["Id"]);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return Client;
        }

        public Client GetOne(int Id)
        {
            Client Client = new Client();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Client where Id = @value";
                        cmd.Parameters.AddWithValue("@value", Id);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            Client.Id = (int)r["Id"];
                            Client.Name = r["Name"].ToString();
                            Client.Contact = r["Contact"].ToString();
                            Client.City = r["City"].ToString();
                            Client.SocietyId = (int)r["SocietyId"];
                            Client.SectorId = (int)r["SectorId"];
                            Client.IsDelete = (bool)r["IsDelete"];
                            Client.Sectors = _sectorRepo.GetSectorByClient((int)r["Id"]);
                            Client.Societies = _societyRepo.GetSocietyByClient((int)r["Id"]);
                            return Client;
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

        public void Update(int id, Client entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Update_Client";
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
