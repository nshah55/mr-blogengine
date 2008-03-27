using Castle.MonoRail.Framework;

namespace BenLovell.BlogEngine.Web.Controllers
{
	[Layout("default")]
	public class PostController : Controller
	{
		public void Add()
		{
			RenderView("add");
		}
	}
}