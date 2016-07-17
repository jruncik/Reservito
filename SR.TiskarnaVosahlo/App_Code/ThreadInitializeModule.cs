using System;
using System.Diagnostics;
using System.Threading;
using System.Web;
using System.Web.SessionState;
using TV.Core;
using TV.Core.Context;

public class ThreadInitializeModule : IHttpModule
{
    public ThreadInitializeModule()
    {
    }

    public String ModuleName
    {
        get { return "ThreadInitializeModule"; }
    }

    public void Dispose()
    {
    }

    public void Init(HttpApplication application)
    {
        application.PreRequestHandlerExecute += Application_PreRequestHandlerExecute;
        application.PostRequestHandlerExecute += Application_PostRequestHandlerExecute;
    }

    private void Application_PreRequestHandlerExecute(object sender, EventArgs e)
    {
        HttpApplication app = sender as HttpApplication;
        if (app.Context.Session != null && app.Context.Session.SessionID != null)
        {
            SessionId sessionId = new SessionId(app.Context.Session.SessionID);
            UserContext.SetupThreadContext(sessionId);
        }
    }

    private void Application_PostRequestHandlerExecute(object sender, EventArgs e)
    {
        HttpApplication app = sender as HttpApplication;
        if (app.Context.Session != null && app.Context.Session.SessionID != null)
        {
            SessionId sessionId = new SessionId(app.Context.Session.SessionID);
            UserContext.CleanupThreadContext(sessionId);
        }
    }
}