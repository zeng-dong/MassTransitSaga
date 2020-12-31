using MassTransitSaga.Configuration;
using Serilog;
using System;

namespace TestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = SerilogConfigurator.CreateConfiguration()
                .CreateLogger();

            Log.Verbose("This is a verbose statement");
            Log.Debug("This is a debug statement");
            Log.Information("This is a info statement");
            Log.Warning("This is a warning statement");
            Log.Error(new IndexOutOfRangeException(), "This is an error statement");
            Log.Fatal(new AggregateException(), "This is an fatal statement");

            var user = new User { Id = Guid.NewGuid(), Name = "Tester", Timestamp = DateTime.UtcNow };
            Log.Information("Hello, {@User}!", user);
            Log.Warning($"Hello again, {user}!");
        }
    }

    class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
