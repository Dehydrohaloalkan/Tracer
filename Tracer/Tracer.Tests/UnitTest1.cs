using Tracer.Example.Classes;

namespace Tracer.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Tracer_OneThread_ReturnThreadCount()
        {
            // Arrange
            var tracer = new Core.Tracer();
            var first = new FirstClass(tracer);

            // Act
            first.Sleep100WithTrace();
            var result = tracer.GetTraceResult();

            // Assert
            Assert.That(result.Threads.Count, Is.EqualTo(1));
        }

        [Test]
        public void Tracer_OneThread_ReturnThreadInfo()
        {
            // Arrange
            var tracer = new Core.Tracer();
            var first = new FirstClass(tracer);

            // Act
            first.Sleep100WithTrace();
            var result = tracer.GetTraceResult();

            // Assert
            Assert.Multiple(() =>
            {
                var r = result.Threads[0];
                Assert.That(r.ThreadId, Is.EqualTo(0));
                Assert.That(r.Time, Is.InRange(100, 150));
                Assert.That(r.Methods.Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void Tracer_OneThread_ReturnMethodInfo()
        {
            // Arrange
            var tracer = new Core.Tracer();
            var first = new FirstClass(tracer);

            // Act
            first.Sleep100WithTrace();
            var result = tracer.GetTraceResult();

            // Assert
            Assert.Multiple(() =>
            {
                var r = result.Threads[0].Methods[0];
                Assert.That(r.Name, Is.EqualTo("Sleep100WithTrace"));
                Assert.That(r.ClassName, Is.EqualTo("FirstClass"));
                Assert.That(r.Time.TotalMilliseconds, Is.InRange(100, 150));
                Assert.That(r.Methods.Count, Is.EqualTo(0));
            });
        }

        [Test]
        public void Tracer_TwoThread_ReturnThreadCount()
        {
            // Arrange
            var tracer = new Tracer.Core.Tracer();
            var second = new SecondClass(tracer);
            var first = new FirstClass(tracer);

            // Act
            var thread1 = new Thread(() => second.Sleep500WithTrace());
            thread1.Start();

            var thread2 = new Thread(() => first.Sleep100WithTrace());
            thread2.Start();

            thread1.Join();
            thread2.Join();

            var result = tracer.GetTraceResult();

            // Assert
            Assert.That(result.Threads.Count, Is.EqualTo(2));
        }

        [Test]
        public void Tracer_TwoThread_ReturnThread1Info()
        {
            // Arrange
            var tracer = new Tracer.Core.Tracer();
            var second = new SecondClass(tracer);
            var first = new FirstClass(tracer);

            // Act
            var thread1 = new Thread(() => second.Sleep500WithTrace());
            thread1.Start();

            var thread2 = new Thread(() => first.Sleep100WithTrace());
            thread2.Start();

            thread1.Join();
            thread2.Join();

            var result = tracer.GetTraceResult();

            // Assert
            Assert.Multiple(() =>
            {
                var r = result.Threads[0];
                Assert.That(r.ThreadId, Is.EqualTo(0));
                Assert.That(r.Time, Is.InRange(500, 550));
                Assert.That(r.Methods.Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void Tracer_TwoThread_ReturnThread2Info()
        {
            // Arrange
            var tracer = new Tracer.Core.Tracer();
            var second = new SecondClass(tracer);
            var first = new FirstClass(tracer);

            // Act
            var thread1 = new Thread(() => second.Sleep500WithTrace());
            thread1.Start();

            var thread2 = new Thread(() => first.Sleep100WithTrace());
            thread2.Start();

            thread1.Join();
            thread2.Join();

            var result = tracer.GetTraceResult();

            // Assert
            Assert.Multiple(() =>
            {
                var r = result.Threads[1];
                Assert.That(r.ThreadId, Is.EqualTo(1));
                Assert.That(r.Time, Is.InRange(100, 150));
                Assert.That(r.Methods.Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void Tracer_ThreadWithTwoMethods_ReturnMethodCount()
        {
            // Arrange
            var tracer = new Tracer.Core.Tracer();
            var second = new SecondClass(tracer);
            var first = new FirstClass(tracer);

            // Act
            first.Sleep100WithTrace();
            second.Sleep500WithTrace();
            var result = tracer.GetTraceResult();

            // Assert
            Assert.That(result.Threads[0].Methods.Count, Is.EqualTo(2));
        }
    }
}