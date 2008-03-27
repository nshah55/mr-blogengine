using System;
using System.Web;
using Castle.Core.Resource;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace BenLovell.BlogEngine.Web
{
	public class Global : HttpApplication, IContainerAccessor
	{
		private static IWindsorContainer container;

		protected void Application_Start(object sender, EventArgs e)
		{
			container = new WindsorContainer(new XmlInterpreter(new ConfigResource()));
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{
			container.Dispose();
		}

		public IWindsorContainer Container
		{
			get { return container; }
		}
	}
}