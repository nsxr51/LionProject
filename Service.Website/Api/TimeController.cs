// /****************************** Module Header ******************************\
// Module Name:  TimeController.cs
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
using System.Web.Http;

namespace Service.Website.Api
{
    [RoutePrefix("time")]
    public class TimeController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(DateTimeOffset.Now);
        }
    }
}