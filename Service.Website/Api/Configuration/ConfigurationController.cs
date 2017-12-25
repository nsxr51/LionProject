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
using Microsoft.Practices.ServiceLocation;
using System.ComponentModel;
using System.Net.Http;
using System;
using System.Data;
using System.Net;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Lion.Configurator;
using Microsoft.Owin.Security.Provider;
using Nancy;
using Nancy.Diagnostics;
using HttpStatusCode = System.Net.HttpStatusCode;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Services;
using Nancy.Session;

namespace Lion.Website.Api.Configuration
{
    [RoutePrefix("configuration")]
    public class ConfigurationController : ApiController
    {
        private const string sessionKey = "progress";

        public Configurator.Configurator _config;

        public ConfigurationController()
        {
            _config = Configurator.Configurator.Instanse;
        }

        [Route("GetProjectList")]
        public IHttpActionResult Get()
        {
            return Json(_config.ProjectsList);
        }

        [Route("GetPcList")]
        public IHttpActionResult GetPcList()
        {
            return Ok(_config.PcsList.GetXmlFile());
        }

        [HttpPost]
        [Route("uploadXmlPcs")]
        public IHttpActionResult Save(HttpRequestMessage request)
        {
            try
            {
                string res = request.Content.ReadAsStringAsync().Result;
                var i = res.IndexOf("<?xml");
                var e = res.IndexOf("PC>") + 3;
                var xml = res.Substring(i, e - i);
                _config.PcsList.LoadFromXmlFile(xml);
                return Ok("Success");
            }
            catch (Exception e)
            {
                return BadRequest("Error: " + e.Message);
            }
        }

        [HttpGet]
        [Route("downloadXmlFile")]
        public IHttpActionResult Download()
        {
            return Ok(_config.PcsList.GetXmlFile());
        }

        [HttpPost]
        [Route("upload")]
        public IHttpActionResult Upload(HttpRequestMessage msg)
        {
            for (int i = 0; i < 100; i++)
            {
                var z = msg.CreateResponse(HttpStatusCode.OK, "dsds", "text/xml");
                Thread.Sleep(100);
            }
            return Json("dsds");
        }

        [WebMethod(EnableSession = true)]
        [Route("upload")]
        public static string Upload()
        {
            return HttpContext.Current.Session[sessionKey] == null ? "1"
                : "s";
        }
    }
}