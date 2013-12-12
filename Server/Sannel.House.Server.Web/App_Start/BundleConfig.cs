﻿/*
Copyright 2013 Sannel Software, L.L.C.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Sannel.House.Server.Web.App_Start
{
	public static class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/Scripts/Libraries")
				.Include("~/Scripts/jquery-2.0.3.js",
				"~/Scripts/knockout-3.0.0.js",
				"~/Scripts/jquery.signalR-2.0.0.js"));
			bundles.Add(new ScriptBundle("~/Scripts/Main")
				.Include("~/Scripts/Account.js",
				"~/Scripts/Room.js",
				"~/Scripts/Site.js"));

			bundles.Add(new ScriptBundle("~/Scripts/modernizr")
				.Include("~/modernizr-*"));

			bundles.Add(new StyleBundle("~/Css/Main")
				.Include("~/Css/Animation.css",
				"~/Css/Site.css",
				"~/Css/min-width500.css",
				"~/Css/min-width700.css",
				"~/Css/min-width1200.css"));
		}
	}
}