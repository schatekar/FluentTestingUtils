Unit testing Web API controller comes with lot of setting up code. In my blog posts [Fluent controller builder for unit testing Web API controllers](http://schatekar.blogspot.co.uk/2013/10/fluent-controller-builder-for-unit.html) and [update of it] (http://schatekar.blogspot.co.uk/2013/10/fluent-controller-builder-updates.html) I talk about fluently unit testing Web API controllers. This repository has all the code referred in the blog post

Here is a sample of how to use the fluent controller builder

```
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
```
