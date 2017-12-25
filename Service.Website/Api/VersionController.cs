// /****************************** Module Header ******************************\
// Module Name:  VersionController.cs
// Project:      Service.Website
// Solution:      ElynxToolsBundle
// Copyright (c) Elbit Systems Ltd. Corporation.
// 
// Author: Arie Vainstein
// Creation Date: 03/20/2017
// 
// This source is subject to the Elbit Systems Ltd. Public License.
// All other rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

using System.Diagnostics;
using System.Reflection;
using System.Web.Http;

namespace Service.Website.Api
{
    [RoutePrefix("version")]
    public class VersionController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            var filename = Assembly.GetExecutingAssembly().Location;

            if (filename == null) return NotFound();

            var fvi = FileVersionInfo.GetVersionInfo(filename);
            return Ok(fvi.ProductVersion);
        }
    }
}