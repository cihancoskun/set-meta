﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Castle.Windsor;
using Castle.Windsor.Installer;
using ServiceStack.Text;

using SetMeta.Web.Helpers;
using SetMeta.Web.ViewModels;

namespace SetMeta.Web
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            MvcHandler.DisableMvcResponseHeader = true;

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            PrepareIocContainer();

            PrepareLocalizationStrings();
        }

        private void PrepareLocalizationStrings()
        {
            var enTexts = new Dictionary<string, string>();
            var trTexts = new Dictionary<string, string>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ConfigurationManager.AppSettings["SetLocaleApiKey"]);

                SetLocalizationStringsDictionary(client, trTexts, ConstHelper.tr);
                SetLocalizationStringsDictionary(client, enTexts, ConstHelper.en);
            }

            Application.Add(ConstHelper.CultureNameTR, trTexts);
            Application.Add(ConstHelper.CultureNameEN, enTexts);
        }

        private static void SetLocalizationStringsDictionary(HttpClient client, IDictionary<string, string> dictionary, string languageKey)
        {
            var page = 1;
            while (page > 0)
            {
                var response = client.GetStringAsync(string.Format("http://setlocale.azurewebsites.net/api/locales?lang={0}&page={1}", languageKey, page));
                response.Wait();

                var responseBody = response.Result;
                var items = JsonSerializer.DeserializeFromString<List<NameValue>>(responseBody);

                if (items == null || !items.Any())
                {
                    page = 0;
                    continue;
                }

                foreach (var item in items)
                {
                    if (dictionary.ContainsKey(item.Name))
                    {
                        dictionary[item.Name] = item.Value;
                    }
                    else
                    {
                        dictionary.Add(item.Name, item.Value);
                    }
                }

                page++;
            }
        }

        private static void PrepareIocContainer()
        {
            var container = new WindsorContainer().Install(FromAssembly.This());
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));
        }

        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Headers.Remove("X-Powered-By");
            HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
            HttpContext.Current.Response.Headers.Remove("X-AspNetMvc-Version");

            HttpContext.Current.Response.Headers.Set("Server", string.Format("Web Server ({0}) ", Environment.MachineName));
        }
    }
}