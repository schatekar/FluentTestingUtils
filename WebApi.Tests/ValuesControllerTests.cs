using System.Linq;
using Core.WebApi;
using NUnit.Framework;
using WebApi.Controllers;

namespace WebApi.Tests
{
    [TestFixture]
    public class ValuesControllerTests
    {

        [Test]
        public void GetReturnsTwoValues()
        {
            var controller = new ValuesController();
            Configure.Controller(controller).AsHaving(b =>
            {
                b.PostRequest().At("http://localhost/api/values");
                b.UsingDefaultRoute().HavingRouteData("controller", "values");
            });

            var values = controller.Get();
            Assert.That(values.Count(), Is.EqualTo(2));
        }
    }
}
