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
    public class UserRepository : IUserRepository<int, User>
    {
        private string connect = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        private readonly RoleRepository _roleRepo = new RoleRepository();
        private readonly SocietyRepository _societyRepo = new SocietyRepository();
        private readonly NationalityRepository _nationalityRepo = new NationalityRepository();
        private readonly ExperienceRepository _experienceRepo = new ExperienceRepository();
        private readonly LanguageRepository _languageRepo = new LanguageRepository();
        private readonly KnowledgeRepository _knowledgeRepo = new KnowledgeRepository();
        private readonly EducationRepository _educationRepo = new EducationRepository();
        private readonly ProgramRepository _programRepo = new ProgramRepository();

        public bool Authentification(string EMail, string Pass)
        {
            User u = new User();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Authentification";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Mail", EMail);
                        cmd.Parameters.AddWithValue("@Password", Pass);
                        SqlDataReader r = cmd.ExecuteReader();

                        if (r.HasRows)
                        {
                            r.Read();
                            u.FirstName = r["FirstName"].ToString();
                            u.LastName = r["LastName"].ToString();
                            return u != null;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return u == null;
        }

        public User Check(User u)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_CheckUser";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Mail", u.Mail);
                        cmd.Parameters.AddWithValue("@Password", u.Password);
                        SqlDataReader r = cmd.ExecuteReader();

                        if (r.HasRows)
                        {
                            r.Read();
                            u.FirstName = r["FirstName"].ToString();
                            u.LastName = r["LastName"].ToString();
                            u.Mail = r["Mail"].ToString();
                            u.Roles = _roleRepo.GetRole((int)r["Id"]);
                            u.SocietyId = (int)r["SocietyId"];
                            return u;
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

        public void Create(User entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Add_User";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Firstname", entity.FirstName);
                        cmd.Parameters.AddWithValue("@Lastname", entity.LastName);
                        cmd.Parameters.AddWithValue("@Street", entity.Street);
                        cmd.Parameters.AddWithValue("@City", entity.City);
                        cmd.Parameters.AddWithValue("@Number", entity.Number);
                        cmd.Parameters.AddWithValue("@Zip", entity.Zip);
                        cmd.Parameters.AddWithValue("@Phone", entity.Phone);
                        cmd.Parameters.AddWithValue("@PersonalPhone", entity.PersonalPhone);
                        cmd.Parameters.AddWithValue("@Mail", entity.Mail);
                        cmd.Parameters.AddWithValue("@PersonalMail", entity.PersonalMail);
                        cmd.Parameters.AddWithValue("@Box", entity.Box);
                        cmd.Parameters.AddWithValue("@Licence", entity.Licence);
                        cmd.Parameters.AddWithValue("@PublicTransport", entity.PublicTransport);
                        cmd.Parameters.AddWithValue("@SocietyId", entity.SocietyId);
                        cmd.Parameters.AddWithValue("@IsDelete", entity.IsDelete);
                        cmd.Parameters.AddWithValue("@pass", entity.Password);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void CreateCv(User entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Create_CV";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Firstname", entity.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", entity.LastName);
                        cmd.Parameters.AddWithValue("@Street", entity.Street);
                        cmd.Parameters.AddWithValue("@City", entity.City);
                        cmd.Parameters.AddWithValue("@Number", entity.Number);
                        cmd.Parameters.AddWithValue("@Zip", entity.Zip);
                        cmd.Parameters.AddWithValue("@Phone", entity.Phone);
                        cmd.Parameters.AddWithValue("@PersonalPhone", entity.PersonalPhone);
                        cmd.Parameters.AddWithValue("@Mail", entity.Mail);
                        cmd.Parameters.AddWithValue("@PersonalMail", entity.PersonalMail);
                        cmd.Parameters.AddWithValue("@Box", entity.Box);
                        cmd.Parameters.AddWithValue("@Licence", entity.Licence);
                        cmd.Parameters.AddWithValue("@PublicTransport", entity.PublicTransport);
                        cmd.Parameters.AddWithValue("@Nationality", entity.NationalityID); 
                        cmd.Parameters.AddWithValue("@SocietyId", entity.SocietyId);
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
                        cmd.CommandText = "Delete from Users where Id = @Param";
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

        public IEnumerable<User> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from Users";
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new User
                        {
                            Id = (int)r["Id"],
                            FirstName = r["FirstName"].ToString(),
                            LastName = r["LastName"].ToString(),
                            City = r["City"].ToString()
                            
                        };
                    }
                }
            }
        }

        public User GetByCity(string City)
        {
            User User = new User();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Users where City = @value";
                        cmd.Parameters.AddWithValue("@value", City);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            User.Id = (int)r["Id"];
                            User.FirstName = r["FirstName"].ToString();
                            User.LastName = r["LastName"].ToString();
                            if (User.Box != null)
                                User.Box = (int)r["Box"];
                            User.City = r["City"].ToString();
                            User.Licence = (bool)r["Licence"];
                            User.Mail = r["Mail"].ToString();
                            User.PersonalMail = r["PersonalMail"].ToString();
                            User.Phone = (int)r["Phone"];
                            User.PersonalPhone = (int)r["PersonalPhone"];
                            User.Number = (int)r["Number"];
                            User.Street = r["Street"].ToString();
                            User.Zip = (int)r["Zip"];
                            User.PublicTransport = (bool)r["PublicTransport"];
                            User.SocietyId = (int)r["SocietyId"];
                            User.IsDelete = (bool)r["IsDelete"];
                            User.Password = "********";
                            return User;
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

        public User GetByFirstName(string FirstName)
        {
            User User = new User();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Users where FirstName = @value";
                        cmd.Parameters.AddWithValue("@value", FirstName);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            User.Id = (int)r["Id"];
                            User.FirstName = r["FirstName"].ToString();
                            User.LastName = r["LastName"].ToString();
                            if (User.Box != null)
                                User.Box = (int)r["Box"];
                            User.City = r["City"].ToString();
                            User.Licence = (bool)r["Licence"];
                            User.Mail = r["Mail"].ToString();
                            User.PersonalMail = r["PersonalMail"].ToString();
                            User.Phone = (int)r["Phone"];
                            User.PersonalPhone = (int)r["PersonalPhone"];
                            User.Number = (int)r["Number"];
                            User.Street = r["Street"].ToString();
                            User.Zip = (int)r["Zip"];
                            User.PublicTransport = (bool)r["PublicTransport"];
                            User.SocietyId = (int)r["SocietyId"];
                            User.IsDelete = (bool)r["IsDelete"];
                            User.Password = "********";
                            return User;
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

        public User GetByLastName(string LastName)
        {
            User User = new User();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select u.SocietyId, u.Id, u.FirstName, u.LastName, u.Mail, r.Name as role from Users u join UserRole ur on u.Id = ur.UserId"
                            + " join Roles r on r.Id = ur.RoleId"
                           + " where LastName = @value";
                        cmd.Parameters.AddWithValue("@value", LastName);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            User.Id = (int)r["Id"];
                            User.FirstName = r["FirstName"].ToString();
                            User.LastName = r["LastName"].ToString();
                            User.Societies = _societyRepo.GetSocietyByUser((int)r["Id"]);
                            User.Nationalities = _nationalityRepo.GetNationality((int)r["Id"]);
                            User.Roles = _roleRepo.GetRole((int)r["Id"]);
                            User.SocietyId = (int)r["SocietyId"];
                            return User;
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

        public IEnumerable<ViewUser> GetByLinkEducation(int Id)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from Users u join Education e on u.Id = e.UserId"
                        + " where e.UserId = @value";
                    cmd.Parameters.AddWithValue("@value", Id);
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new ViewUser
                        {
                            Lastname = r["LastName"].ToString()
                        };
                    }
                }
            }
        }

        public User GetByMail(string Mail)
        {
            User User = new User();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Users where Mail = @value";
                        cmd.Parameters.AddWithValue("@value", Mail);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            User.Id = (int)r["Id"];
                            User.FirstName = r["FirstName"].ToString();
                            User.LastName = r["LastName"].ToString();
                            if (User.Box != null)
                                User.Box = (int)r["Box"];
                            User.City = r["City"].ToString();
                            User.Licence = (bool)r["Licence"];
                            User.Mail = r["Mail"].ToString();
                            User.PersonalMail = r["PersonalMail"].ToString();
                            User.Phone = (int)r["Phone"];
                            User.PersonalPhone = (int)r["PersonalPhone"];
                            User.Number = (int)r["Number"];
                            User.Street = r["Street"].ToString();
                            User.Zip = (int)r["Zip"];
                            User.PublicTransport = (bool)r["PublicTransport"];
                            User.SocietyId = (int)r["SocietyId"];
                            User.IsDelete = (bool)r["IsDelete"];
                            User.Password = "********";
                            User.Societies = _societyRepo.GetSocietyByUser((int)r["Id"]);
                            User.Nationalities = _nationalityRepo.GetNationality((int)r["Id"]);
                            User.Roles = _roleRepo.GetRole((int)r["Id"]);
                            return User;
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

        public User GetByPersonalMail(string PersonalMail)
        {
            User User = new User();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Users where PersonalMail = @value";
                        cmd.Parameters.AddWithValue("@value", PersonalMail);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            User.Id = (int)r["Id"];
                            User.FirstName = r["FirstName"].ToString();
                            User.LastName = r["LastName"].ToString();
                            if (User.Box != null)
                                User.Box = (int)r["Box"];
                            User.City = r["City"].ToString();
                            User.Licence = (bool)r["Licence"];
                            User.Mail = r["Mail"].ToString();
                            User.PersonalMail = r["PersonalMail"].ToString();
                            User.Phone = (int)r["Phone"];
                            User.PersonalPhone = (int)r["PersonalPhone"];
                            User.Number = (int)r["Number"];
                            User.Street = r["Street"].ToString();
                            User.Zip = (int)r["Zip"];
                            User.PublicTransport = (bool)r["PublicTransport"];
                            User.SocietyId = (int)r["SocietyId"];
                            User.IsDelete = (bool)r["IsDelete"];
                            User.Password = "********";
                            return User;
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

        public User GetByPersonalPhone(int PersonalPhone)
        {
            User User = new User();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Users where PersonalPhone = @value";
                        cmd.Parameters.AddWithValue("@value", PersonalPhone);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            User.Id = (int)r["Id"];
                            User.FirstName = r["FirstName"].ToString();
                            User.LastName = r["LastName"].ToString();
                            if (User.Box != null)
                                User.Box = (int)r["Box"];
                            User.City = r["City"].ToString();
                            User.Licence = (bool)r["Licence"];
                            User.Mail = r["Mail"].ToString();
                            User.PersonalMail = r["PersonalMail"].ToString();
                            User.Phone = (int)r["Phone"];
                            User.PersonalPhone = (int)r["PersonalPhone"];
                            User.Number = (int)r["Number"];
                            User.Street = r["Street"].ToString();
                            User.Zip = (int)r["Zip"];
                            User.PublicTransport = (bool)r["PublicTransport"];
                            User.SocietyId = (int)r["SocietyId"];
                            User.IsDelete = (bool)r["IsDelete"];
                            User.Password = "********";
                            return User;
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

        public User GetByPhone(int Phone)
        {
            User User = new User();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Users where Phone = @value";
                        cmd.Parameters.AddWithValue("@value", Phone);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            User.Id = (int)r["Id"];
                            User.FirstName = r["FirstName"].ToString();
                            User.LastName = r["LastName"].ToString();
                            if (User.Box != null)
                                User.Box = (int)r["Box"];
                            User.City = r["City"].ToString();
                            User.Licence = (bool)r["Licence"];
                            User.Mail = r["Mail"].ToString();
                            User.PersonalMail = r["PersonalMail"].ToString();
                            User.Phone = (int)r["Phone"];
                            User.PersonalPhone = (int)r["PersonalPhone"];
                            User.Number = (int)r["Number"];
                            User.Street = r["Street"].ToString();
                            User.Zip = (int)r["Zip"];
                            User.PublicTransport = (bool)r["PublicTransport"];
                            User.SocietyId = (int)r["SocietyId"];
                            User.IsDelete = (bool)r["IsDelete"];
                            User.Password = "********";
                            return User;
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

        public User GetOne(int Id)
        {
            User User = new User();
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Users where Id = @value";
                        cmd.Parameters.AddWithValue("@value", Id);
                        SqlDataReader r = cmd.ExecuteReader();
                        if (r.Read())
                        {
                            User.Id = (int)r["Id"];
                            User.FirstName = r["FirstName"].ToString();
                            User.LastName = r["LastName"].ToString();
                            if (User.Box != null)
                            User.Box = (int)r["Box"];
                            User.City = r["City"].ToString();
                            User.Licence = (bool)r["Licence"];
                            User.Mail = r["Mail"].ToString();
                            User.PersonalMail = r["PersonalMail"].ToString();
                            User.Phone = (int)r["Phone"];
                            User.PersonalPhone = (int)r["PersonalPhone"];
                            User.Number = (int)r["Number"];
                            User.Street = r["Street"].ToString();
                            User.Zip = (int)r["Zip"];
                            User.PublicTransport = (bool)r["PublicTransport"];
                            User.SocietyId = (int)r["SocietyId"];
                            User.IsDelete = (bool)r["IsDelete"];
                            User.Password = "********";
                            User.Nationalities = _nationalityRepo.GetNationality((int)r["Id"]);
                            User.Experiences = _experienceRepo.GetExperience((int)r["Id"]);
                            User.Languages = _languageRepo.GetLanguage((int)r["Id"]);
                            User.Knowledges = _knowledgeRepo.GetKnowledge((int)r["Id"]);
                            User.Educations = _educationRepo.GetByLinkEducation((int)r["Id"]);
                            User.Programs = _programRepo.GetProgram((int)r["Id"]);
                            return User;
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

        public void Update(int id, User entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Update_Users";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Firstname", entity.FirstName);
                        cmd.Parameters.AddWithValue("@Lastname", entity.LastName);
                        cmd.Parameters.AddWithValue("@Street", entity.Street);
                        cmd.Parameters.AddWithValue("@City", entity.City);
                        cmd.Parameters.AddWithValue("@Number", entity.Number);
                        cmd.Parameters.AddWithValue("@Zip", entity.Zip);
                        cmd.Parameters.AddWithValue("@Phone", entity.Phone);
                        cmd.Parameters.AddWithValue("@PersonalPhone", entity.PersonalPhone);
                        cmd.Parameters.AddWithValue("@Mail", entity.Mail);
                        cmd.Parameters.AddWithValue("@PersonalMail", entity.PersonalMail);
                        cmd.Parameters.AddWithValue("@Box", entity.Box);
                        cmd.Parameters.AddWithValue("@Licence", entity.Licence);
                        cmd.Parameters.AddWithValue("@PublicTransport", entity.PublicTransport);
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

        public IEnumerable<ViewUser> GetUserBySociety(int SocietyId)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from Users u join UserRole us on u.Id = us.UserId"
                        + " join Roles r on r.Id = us.RoleId"
                        + " where SocietyId = @value";
                    cmd.Parameters.AddWithValue("@value", SocietyId);
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new ViewUser
                        {
                            Id = (int)r["Id"],
                            FirstName = r["FirstName"].ToString(),
                            Lastname = r["LastName"].ToString(),
                            city = r["City"].ToString(),

                        };
                    }
                }
            }
        }

        public IEnumerable<ViewUser> GetDevelopperBySociety(int SocietyId)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from Users u join UserRole us on u.Id = us.UserId"
                        + " join Roles r on r.Id = us.RoleId"
                        + " where SocietyId = @value"
                        + " and r.Name like 'Developper'";
                    cmd.Parameters.AddWithValue("@value", SocietyId);
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        yield return new ViewUser
                        {
                            Id = (int)r["Id"],
                            FirstName = r["FirstName"].ToString(),
                            Lastname = r["LastName"].ToString(),
                            city = r["City"].ToString(),
                            SocietyId = (int)r["SocietyId"]

                        };
                    }
                }
            }
        }

        public void CreateEducation(Education entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Add_DevelopperEducation";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", entity.Name);
                        cmd.Parameters.AddWithValue("@EducationLevel", entity.EducationLevel);
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

        public void CreateExperience(Experience entity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_Add_DevelopperExperience";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ClientId", entity.ClientId);
                        cmd.Parameters.AddWithValue("@Description", entity.Description);
                        cmd.Parameters.AddWithValue("@BeginDate", DateTime.Parse(entity.BeginDate.ToString()));
                        cmd.Parameters.AddWithValue("@EndDate", DateTime.Parse(entity.EndDate.ToString()));
                        cmd.Parameters.AddWithValue("@FunctionId", entity.FunctionId);
                        cmd.Parameters.AddWithValue("@KnowledgeId", entity.KnowledgeId);
                        cmd.Parameters.AddWithValue("@UserId", entity.UserId);
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
