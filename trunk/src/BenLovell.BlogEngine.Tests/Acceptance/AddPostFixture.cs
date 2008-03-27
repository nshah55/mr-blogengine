using System.Threading;
using MbUnit.Framework;
using WatiN.Core;

namespace BenLovell.BlogEngine.Tests.Acceptance
{
	[TestFixture(ApartmentState = ApartmentState.STA)]
	public class AddPostFixture
	{
		[Test]
		public void AddPost_ShouldRenderAddForm_AndConfirmPostSaved()
		{
			using(IE browser = new IE("http://localhost:16489/post/add.aspx"))
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
	}
}