using CvTheque.Models;
using DalHttp.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CvTheque.Services
{
    public static class Mapper
    {
        public static Level MapToEntity(this LevelApp l)
        {
            return new Level
            {
                Id = l.Id,
                Name = l.Name,
                IsDelete = l.IsDelete
            };
        }

        public static LevelApp MapToEntity(this Level l)
        {
            return new LevelApp
            {
                Id = l.Id,
                Name = l.Name,
                IsDelete = l.IsDelete
            };
        }

        public static LanguageLevel MapToEntity(this LanguageLevelApp l)
        {
            return new LanguageLevel
            {
                Id = l.Id,
                Name = l.Name,
                IsDelete = l.IsDelete
            };
        }

        public static LanguageLevelApp MapToEntity(this LanguageLevel l)
        {
            return new LanguageLevelApp
            {
                Id = l.Id,
                Name = l.Name,
                IsDelete = l.IsDelete
            };
        }

        public static KnowledgeType MapToEntity(this KnowledgeTypeApp k)
        {
            return new KnowledgeType
            {
                Id = k.Id,
                Name = k.Name,
                IsDelete = k.IsDelete
            };
        }

        public static KnowledgeTypeApp MapToEntity(this KnowledgeType k)
        {
            return new KnowledgeTypeApp
            {
                Id = k.Id,
                Name = k.Name,
                IsDelete = k.IsDelete
            };
        }

        public static ProgramType MapToEntity(this ProgramTypeApp p)
        {
            return new ProgramType
            {
                Id = p.Id,
                Name = p.Name,
                IsDelete = p.IsDelete
            };
        }

        public static ProgramTypeApp MapToEntity(this ProgramType p)
        {
            return new ProgramTypeApp
            {
                Id = p.Id,
                Name = p.Name,
                IsDelete = p.IsDelete
            };
        }

        public static FunctionApp MapToEntity(this Function f)
        {
            return new FunctionApp
            {
                Id = f.Id,
                Name = f.Name,
                IsDelete = f.IsDelete
            };
        }

        public static Function MapToEntity(this FunctionApp f)
        {
            return new Function
            {
                Id = f.Id,
                Name = f.Name,
                IsDelete = f.IsDelete
            };
        }

        public static Sector MapToEntity(this SectorApp f)
        {
            return new Sector
            {
                Id = f.Id,
                Name = f.Name,
                IsDelete = f.IsDelete
            };
        }

        public static SectorApp MapToEntity(this Sector f)
        {
            return new SectorApp
            {
                Id = f.Id,
                Name = f.Name,
                IsDelete = f.IsDelete
            };
        }

        public static City MapToEntity(this CityApp c)
        {
            return new City
            {
                Id = c.Id,
                Name = c.Name,
                IsDelete = c.IsDelete,
                Zip = c.Zip
            };
        }

        public static CityApp MapToEntity(this City c)
        {
            return new CityApp
            {
                Id = c.Id,
                Name = c.Name,
                IsDelete = c.IsDelete,
                Zip = c.Zip
            };
        }

        public static SocietyApp MapToEntity(this Society s)
        {
            return new SocietyApp
            {
                Id = s.Id,
                Name = s.Name,
                IsDelete = s.IsDelete,
                City = s.City,
                Contact = s.Contact,
                Logo = s.Logo
            };
        }

        public static Society MapToEntity(this SocietyApp s)
        {
            return new Society
            {
                Id = s.Id,
                Name = s.Name,
                IsDelete = s.IsDelete,
                City = s.City,
                Contact = s.Contact,
                Logo = s.Logo
            };
        }

        public static Prospect MapToEntity(this ProspectApp p)
        {
            return new Prospect
            {
                Id = p.Id,
                Name = p.Name,
                IsDelete = p.IsDelete,
                City = p.City,
                Contact = p.Contact,
                SectorId = p.SectorId,
                SocietyId = p.SocietyId,
                Sectors = p.Sectors,
                Societies = p.Societies
            };
        }

        public static ProspectApp MapToEntity(this Prospect p)
        {
            return new ProspectApp
            {
                Id = p.Id,
                Name = p.Name,
                IsDelete = p.IsDelete,
                City = p.City,
                Contact = p.Contact,
                SectorId = p.SectorId,
                SocietyId = p.SocietyId,
                Societies = p.Societies
            };
        }

        public static ClientApp MapToEntity(this Client c)
        {
            return new ClientApp
            {
                Id = c.Id,
                Name = c.Name,
                IsDelete = c.IsDelete,
                City = c.City,
                Contact = c.Contact,
                SectorId = c.SectorId,
                SocietyId = c.SocietyId,
                Sectors = c.Sectors,
                Societies = c.Societies,
                Experiences = c.Experiences,
                Languages = c.Languages,
                Knowledge = c.Knowledge
            };
        }

        public static Client MapToEntity(this ClientApp c)
        {
            return new Client
            {
                Id = c.Id,
                Name = c.Name,
                IsDelete = c.IsDelete,
                City = c.City,
                Contact = c.Contact,
                SectorId = c.SectorId,
                SocietyId = c.SocietyId,
                Sectors = c.Sectors,
                Societies = c.Societies,
                Experiences = c.Experiences,
                Languages = c.Languages,
                Knowledge = c.Knowledge
            };
        }

        public static Experience MapToEntity(this ExperienceApp e)
        {
            return new Experience
            {
                Id = e.Id,
                BeginDate = e.BeginDate,
                IsDelete = e.IsDelete,
                EndDate = e.EndDate,
                Description = e.Description,
                ClientId = e.ClientId,
                UserId = e.UserId
            };
        }

        public static ExperienceApp MapToEntity(this Experience e)
        {
            return new ExperienceApp
            {
                Id = e.Id,
                BeginDate = e.BeginDate,
                IsDelete = e.IsDelete,
                EndDate = e.EndDate,
                Description = e.Description,
                ClientId = e.ClientId,
                UserId = e.UserId
            };
        }

        public static EducationApp MapToEntity(this Education e)
        {
            return new EducationApp
            {
                Id = e.Id,
                BeginDate = e.BeginDate,
                IsDelete = e.IsDelete,
                EndDate = e.EndDate,
                Name = e.Name,
                EducationLevel = e.EducationLevel,
                UserId = e.UserId,
                Users = e.Users,
                EducationLevels = e.EducationLevels
            };
        }

        public static Education MapToEntity(this EducationApp e)
        {
            return new Education
            {
                Id = e.Id,
                BeginDate = e.BeginDate,
                IsDelete = e.IsDelete,
                EndDate = e.EndDate,
                Name = e.Name,
                EducationLevel = e.EducationLevel,
                UserId = e.UserId,
                Users = e.Users,
                EducationLevels = e.EducationLevels
            };
        }

        public static Knowledge MapToEntity(this KnowledgeApp k)
        {
            return new Knowledge
            {
                Id = k.Id,
                KnowledgeTypeId = k.KnowledgeTypeId,
                Name = k.Name,
                IsDelete = k.IsDelete,
                KnowledgeTypes = k.KnowledgeTypes
            };
        }

        public static KnowledgeApp MapToEntity(this Knowledge k)
        {
            return new KnowledgeApp
            {
                Id = k.Id,
                KnowledgeTypeId = k.KnowledgeTypeId,
                Name = k.Name,
                KnowledgeTypes = k.KnowledgeTypes
            };
        }

        public static ProgramApp MapToEntity(this Program p)
        {
            return new ProgramApp
            {
                Id = p.Id,
                ProgramTypeId = p.ProgramTypeId,
                Name = p.Name
            };
        }

        public static Program MapToEntity(this ProgramApp p)
        {
            return new Program
            {
                Id = p.Id,
                ProgramTypeId = p.ProgramTypeId,
                Name = p.Name
            };
        }

        public static Language MapToEntity(this LanguageApp l)
        {
            return new Language
            {
                Id = l.Id,
                Name = l.Name
            };
        }

        public static LanguageApp MapToEntity(this Language l)
        {
            return new LanguageApp
            {
                Id = l.Id,
                Name = l.Name
            };
        }

        public static UserApp MapToEntity(this User u)
        {
            return new UserApp
            {
                Id = u.Id,
                Firstname = u.Firstname,
                LastName = u.LastName,
                Number = u.Number,
                Mail = u.Mail,
                PersonalMail = u.PersonalMail,
                Phone = u.Phone,
                PersonalPhone = u.PersonalPhone,
                Street = u.Street,
                Box = u.Box,
                City = u.City,
                Licence = u.Licence,
                Zip = u.Zip,
                PublicTransport = u.PublicTransport,
                IsDelete = u.IsDelete,
                NationalityId = u.NationalityId,
                SocietyId = u.SocietyId,
                Password = u.Password
            };
        }

        public static User MapToEntity(this UserApp u)
        {
            return new User
            {
                Id = u.Id,
                Firstname = u.Firstname,
                LastName = u.LastName,
                Number = u.Number,
                Mail = u.Mail,
                PersonalMail = u.PersonalMail,
                Phone = u.Phone,
                PersonalPhone = u.PersonalPhone,
                Street = u.Street,
                Box = u.Box,
                City = u.City,
                Licence = u.Licence,
                Zip = u.Zip,
                PublicTransport = u.PublicTransport,
                IsDelete = u.IsDelete,
                NationalityId = u.NationalityId,
                SocietyId = u.SocietyId,
                Password = u.Password
            };
        }

        public static EducationLevel MapToEntity(this EducationLevelApp e)
        {
            return new EducationLevel
            {
                Id = e.Id,
                Name = e.Name,
                IsDelete = e.IsDelete
            };
        }

        public static EducationLevelApp MapToEntity(this EducationLevel e)
        {
            return new EducationLevelApp
            {
                Id = e.Id,
                Name = e.Name,
                IsDelete = e.IsDelete
            };
        }
    }
}