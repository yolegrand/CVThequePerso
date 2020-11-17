using CvTheque.Core.Models;
using CvTheque.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCvTheque.Models
{
    public class UserApp
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Mail { get; set; }
        public string PersonalMail { get; set; }
        public int Phone { get; set; }
        public int PersonalPhone { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int? Box { get; set; }
        public int Zip { get; set; }
        public string City { get; set; }
        public bool Licence { get; set; }
        public bool PublicTransport { get; set; }
        public int SocietyId { get; set; }
        public bool IsDelete { get; set; }
        public string Password { get; set; }
        public IEnumerable<ViewRole> Roles { get; set; }
        public IEnumerable<ViewSociety> Societies { get; set; }
        public IEnumerable<ViewNationality> Nationalities { get; set; }
        public IEnumerable<ViewLanguage> Languages { get; set; }
        public IEnumerable<LanguageLevel> LanguageLevels { get; set; }
        public IEnumerable<ViewEducation> Educations { get; set; }
        public IEnumerable<ViewExperience> Experiences { get; set; }
        public IEnumerable<ViewKnowledge> Knowledges { get; set; }
        public IEnumerable<ViewProgram> Programs { get; set; }
        public IEnumerable<ProgramType> ProgramTypes { get; set; }
        public int NationalityID { get; set; }
        public int LanguageId { get; set; }
        public int LanguageLevelId { get; set; }
        public int ProgramId { get; set; }
        public int ProgramTypeId { get; set; }
        public int ProgramLevelId { get; set; }
        public string Education { get; set; }
        public int EducationLevelId { get; set; }
        public int ExperienceId { get; set; }
        public int ExperienceLevelId { get; set; }
        public int KnowledgeId { get; set; }
        public int KnowledgeLevelId { get; set; }
        public int KnowledgeTypeId { get; set; }
        public int FunctionId { get; set; }
        public DateTime ExperienceBeginDate { get; set; }
        public DateTime ExperienceEndDate { get; set; }
        public DateTime EducationBeginDate { get; set; }
        public DateTime EducationEndDate { get; set; }
        public string ExperienceDescription { get; set; }
        public int ClientId { get; set; }

    }
}