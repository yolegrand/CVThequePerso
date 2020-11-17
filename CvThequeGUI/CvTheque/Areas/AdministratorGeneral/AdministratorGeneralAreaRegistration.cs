using System.Web.Mvc;

namespace CvTheque.Areas.AdministratorGeneral
{
    public class AdministratorGeneralAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdministratorGeneral";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdministratorGeneral_default",
                "AdministratorGeneral/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}