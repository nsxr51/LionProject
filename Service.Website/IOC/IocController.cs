// /****************************** Module Header ******************************\
// Module Name:  IocController.cs
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
using Ninject;
using System.Reflection;
using Microsoft.Practices.ServiceLocation;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace Lion.Website.IOC
{
    public class IocController
    {
        public IocController()
        {
            IKernel kernel = new StandardKernel();
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(kernel));
            kernel.Load(Assembly.GetExecutingAssembly());

        }
    }
}