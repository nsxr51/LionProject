// /****************************** Module Header ******************************\
// Module Name:  ServiceHost.cs
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
using System.Threading;
using Microsoft.Owin.Hosting;
using Microsoft.AspNet.SignalR.Client;

namespace Lion.Website
{
    /// <summary>
    /// The class that provides the actions to perform when starting/stopping the service.
    /// </summary>
    public class ServiceHost
    {
        // Create the variable for our self-hosted server
        //
        private IDisposable _server;

        public static CancellationTokenSource _token = new CancellationTokenSource();
        // Just hard-code the address for now
        //
        private string _baseAddress = "http://*:7331";

        public ServiceHost()
        {
            Console.WriteLine("ServiceHost constructed");
        }

        public void Start()
        {
            Console.WriteLine("ServiceHost started");

            // Start up the server by providing our OWIN Startup class as the source type.
            //  We also save the return object so we can dispose of it properly when the
            //  service is shutdown
            //
            _server = WebApp.Start<Startup>(url: _baseAddress);
            Console.WriteLine("Server running at {0}", _baseAddress);

            //System.Diagnostics.Process.Start("http://localhost:7331");
        }

        public void Shutdown()
        {
            Console.WriteLine("ServiceHost shutting down");
        }

        public void Stop()
        {
            Console.WriteLine("Server shutting down");

            // Dispose of the server object since we're shutting everything down
            //
            _server.Dispose();
            _token.Cancel();
            Console.WriteLine("ServiceHost stopped");
        }
    }
}