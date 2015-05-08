using System;
using DevReactor.Toolbox.API.Sessions;

namespace Research.API
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            DevReactor.Toolbox.Tools.Logger.Instance.LogInfo("Research.Api started");

            SessionManager.Instance.Purge();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            DevReactor.Toolbox.Tools.Logger.Instance.LogInfo("Research.Api ended");
        }
    }
}