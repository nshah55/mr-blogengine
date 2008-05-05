using System.Configuration;
using System.Threading;
using MbUnit.Framework;
using Microsoft.VisualStudio.WebHost;
using WatiN.Core;

namespace BenLovell.BlogEngine.Tests.Acceptance
{
	[TestFixture(ApartmentState = ApartmentState.STA)]
	public class AddPostFixture
	{
		private Server webServer;
		private int port;
		private string webDir;

		[TestFixtureSetUp]
		public void Setup()
		{
			port = int.Parse(ConfigurationManager.AppSettings["webPort"]);
			webDir = ConfigurationManager.AppSettings["webDirectory"];

			webServer = new Server(port, "/", webDir);
			webServer.Start();
		}

		private string BuildTestUrl(string path)
		{
			const string URL_FORMAT = "http://localhost:{0}/{1}";
			return string.Format(URL_FORMAT, port, path);
		}

		[Test]
		public void AddPost_ShouldRenderAddForm_AndConfirmPostSaved()
		{
			using(IE browser = new IE(BuildTestUrl("post/add.aspx")))
			{
				Assert.IsTrue(browser.ContainsText("Ben Lovell's Blog"), 
					"No header text found");
				Assert.IsTrue(browser.ContainsText("Add Post"), 
					"Add Post not found");

				browser.TextField(Find.ByName("post.Title")).TypeText("Title");
				browser.TextField(Find.ByName("post.Description")).TypeText("Description");
				browser.TextField(Find.ByName("post.Content")).TypeText("Content");
				browser.Button(Find.ByValue("Submit")).Click();
				
				Assert.IsTrue(browser.ContainsText(@"The post titled: 'Title' was created!"), 
					"Correct confirmation was not displayed");
			}
		}

		[Test]
		public void Save_should_fail_when_GET_attempted()
		{
			using (IE browser = new IE(BuildTestUrl("post/save.aspx")))
			{
				Assert.IsTrue(browser.ContainsText(
					@"Access to the action [save] on controller [post] is not allowed to the http verb [GET]."),
					"Action accessible via GET");
			}
		}

		[TestFixtureTearDown]
		public void TearDown()
		{
			webServer.Stop();
		}
	}
}