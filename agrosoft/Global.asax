<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
    
    void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
        if (Context.Request.Cookies[FormsAuthentication.FormsCookieName] != null)
        {
            // Извлекаем куку с аутентификационными данными
            HttpCookie cookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];

            // Дешифруем ее в тикет
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);

            // Создаем пользовательский контекст
            FormsIdentity identity = new FormsIdentity(ticket);
            System.Security.Principal.GenericPrincipal principal = new System.Security.Principal.GenericPrincipal(identity,
                new string[] { AuthCookieParce.UserRole(identity.Name) });

            // Клеим его к текущему HTTP-контексту
            Context.User = principal;
        }
    }
    
       
</script>
