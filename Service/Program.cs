// /****************************** Module Header ******************************\
// Module Name:  Program.cs
// Project:      Service
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
using Lion.Website;
using Topshelf;

namespace Lion.Service
{
    class Program
    {
        private static void Main(string[] args)
        {
            HostFactory.Run(factory =>
            {
                // Provide the service's behavior using our custom
                //  ServiceHost class
                //
                factory.Service<ServiceHost>(service =>
                {
                    service.ConstructUsing(name => new ServiceHost());
                    service.WhenStarted(sh => sh.Start());
                    service.WhenShutdown(sh => sh.Shutdown());
                    service.WhenStopped(sh => sh.Stop());
                });

                // Now define some attributes of the service overall
                //
                factory.RunAsLocalSystem();

                // Provide the metadata to the service control
                //
                factory.SetServiceName("NetworkAnalyst");
                factory.SetDisplayName("NetworkAnalyst");
                factory.SetDescription("A custom service that hosts an Angular website using OWIN");
            });
        }
    }
}