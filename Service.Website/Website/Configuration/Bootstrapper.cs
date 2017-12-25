// /****************************** Module Header ******************************\
// Module Name:  Bootstrapper.cs
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

using System;
using Microsoft.Practices.ServiceLocation;
using Nancy;
using Nancy.Conventions;
using Nancy.TinyIoc;
using Lion.Website.IOC;

namespace Lion.Website.Website.Configuration
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        private readonly IocController _controller = new IocController();

        protected override void ApplicationStartup(TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            // Add a view location convention that looks for views in a folder
            //  named "views" next to the module class
            //
            //this.Conventions.ViewLocationConventions.Add((viewName, model, context) => string.Format("Website/Modules/{0}/views/{1}", context.ModuleName, viewName));
            this.Conventions.ViewLocationConventions.Add(
                (viewName, model, context) => string.Format("App/{0}", viewName));
            // Add a new path for static content so our typescript files located in
            //  the 'App' folder can be served to SystemJS
            //
            this.Conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/","App"));
        }

        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);
        }
    }
}