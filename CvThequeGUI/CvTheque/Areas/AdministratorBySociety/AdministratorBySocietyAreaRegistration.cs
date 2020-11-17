using System.Web.Mvc;

namespace CvTheque.Areas.AdministratorBySociety
{
    public class AdministratorBySocietyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdministratorBySociety";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdministratorBySociety_default",
                "AdministratorBySociety/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}