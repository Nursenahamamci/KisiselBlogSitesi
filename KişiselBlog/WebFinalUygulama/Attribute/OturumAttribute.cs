using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace WebFinalUygulama.Attribute
{
    public class OturumAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cerez = filterContext.HttpContext.Request.Cookies
                .Get(FormsAuthentication.FormsCookieName);
            if (cerez == null)
            {
                ///oturum yoksa yönlendirme yapılacak
                ///

                filterContext.Result = new RedirectResult("../Oturum/KullaniciGiris");

            }
            else
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                var bilet = FormsAuthentication.Decrypt(cerez.Value);

                var kullaniciNesne = ser.Deserialize<Kullanici>(bilet.UserData);


            }
        }
    }
}