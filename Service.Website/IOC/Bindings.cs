using Microsoft.Practices.ServiceLocation;
//using NetworkAnalyst.MCTR7200Controller;
// /****************************** Module Header ******************************\
// Module Name:  Bindings.cs
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
using Ninject.Modules;
using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Configuration;


namespace Lion.Website.IOC
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        

    }
}