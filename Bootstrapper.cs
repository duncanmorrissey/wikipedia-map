using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.Diagnostics;
using Nancy.TinyIoc;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;

namespace WikipediaMap
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        //Overriding some default setup in order to see diagnostics for debugging. To view diagnostics, add /_Nancy to your localhost url
        protected override DiagnosticsConfiguration DiagnosticsConfiguration
        {
            get
            {
                /* To enable diagnostics, you must create a valid DiagnosticsConfiguration with a password. */

                return new DiagnosticsConfiguration { Password = "password" };
                //return base.DiagnosticsConfiguration;
            }
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            StaticConfiguration.EnableRequestTracing = true;
            //base.ApplicationStartup(container, pipelines);
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);
            nancyConventions.StaticContentsConventions
                .Add(StaticContentConventionBuilder.AddDirectory("Vendor/scripts"));
            nancyConventions.StaticContentsConventions
                .Add(StaticContentConventionBuilder.AddDirectory("Vendor/style"));
            nancyConventions.StaticContentsConventions
                .Add(StaticContentConventionBuilder.AddDirectory("Vendor/fonts"));
        }
    }
}