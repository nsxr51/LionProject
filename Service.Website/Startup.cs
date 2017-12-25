// /****************************** Module Header ******************************\
// Module Name:  Startup.cs
// Project:      Service.Website
// Solution:      ElynxToolsBundle
// Copyright (c) Elbit Systems Ltd. Corporation.
// 
// Author: Arie Vainstein
// Creation Date: 03/07/2017
// 
// This source is subject to the Elbit Systems Ltd. Public License.
// All other rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/
using System.Web.Http;
using Microsoft.Owin.Security;
using System.Web.Http.Cors;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Nancy.ViewEngines;
using Owin;
using Owin.WebSocket.Extensions;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(Lion.Website.Startup))]

namespace Lion.Website
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        //
        public void Configuration(IAppBuilder appBuilder)
        {
            // We're going to hang the web API off off the /api "sub"-url so that we
            //  leave the root url open for the Angular 2 website.
            //
            //appBuilder.MapWebSocketRoute<ElynxWebSocket>();
            var configH = new HubConfiguration();
            configH.EnableJSONP = true;
            appBuilder.MapSignalR(configH);
            appBuilder.Map("/api", api =>
            {
                // Create our config object we'll use to configure the API
                //
                var config = new HttpConfiguration();

                // Enable CORS
                var cors = new EnableCorsAttribute("*", "*", "*");
                config.EnableCors(cors);

                // Use attribute routing
                //
                config.MapHttpAttributeRoutes();
                // Now add in the WebAPI middleware

                //
                api.UseCors(CorsOptions.AllowAll).UseWebApi(config);
            });

            appBuilder.Map("/signalr", map =>
            {
                // Setup the CORS middleware to run before SignalR.
                // By default this will allow all origins. You can 
                // configure the set of origins and/or http verbs by
                // providing a cors options with a different policy.
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                    // You can enable JSONP by uncommenting line below.
                    // JSONP requests are insecure but some older browsers (and some
                    // versions of IE) require JSONP to work cross domain
                     EnableJSONP = true
                };
                var cors = new EnableCorsAttribute("*", "*", "*");
                // Run the SignalR pipeline. We're not using MapSignalR
                // since this branch already runs under the "/signalr"
                // path.
                map.RunSignalR(hubConfiguration);
            });
            // Add Nancy to the OWIN pipeline.
            //  Note, because this is registered last we don't need to worry 
            //  about falling-through to any other middleware. Any requests to
            //  /api/... will be handled by WebAPI first, and anything else
            //  will fall through to Nancy
            //
            appBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            appBuilder.UseNancy();
        }
    }
}