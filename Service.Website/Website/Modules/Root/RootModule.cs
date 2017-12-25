// /****************************** Module Header ******************************\
// Module Name:  RootModule.cs
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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using Nancy;
using Nancy.Owin;

using WebSocketAccept = System.Action<
    System.Collections.Generic.IDictionary<string, object>, // WebSocket Accept parameters
    System.Func< // WebSocketFunc callback
        System.Collections.Generic.IDictionary<string, object>, // WebSocket environment
        System.Threading.Tasks.Task>>;

using WebSocketSendAsync = System.Func<
    System.ArraySegment<byte>, // data
    int, // message type
    bool, // end of message
    System.Threading.CancellationToken, // cancel
    System.Threading.Tasks.Task>;
// closeStatusDescription

using WebSocketReceiveAsync = System.Func<
    System.ArraySegment<byte>, // data
    System.Threading.CancellationToken, // cancel
    System.Threading.Tasks.Task<
        System.Tuple< // WebSocketReceiveTuple
            int, // messageType
            bool, // endOfMessage
            int?, // count
            int?, // closeStatus
            string>>>; // closeStatusDescription

using WebSocketCloseAsync = System.Func<
    int, // closeStatus
    string, // closeDescription
    System.Threading.CancellationToken, // cancel
    System.Threading.Tasks.Task>;
namespace Lion.Website.Website.Modules.Root
{
    public class RootModule : NancyModule
    {
        public RootModule()
        {
            // Define a single route that returns our index.html view
            //
            Get["/"] = _ => View["index"];
            Get["/{uri*}"] = _ => View["index"];
        }
    }
}