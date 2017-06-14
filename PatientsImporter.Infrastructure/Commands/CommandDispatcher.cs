using System;
using System.Threading.Tasks;
using Autofac;

namespace PatientsImporter.Infrastructure.Commands
{
  public class CommandDispatcher : ICommandDispatcher
  {
    private readonly IComponentContext _context;
    public CommandDispatcher(IComponentContext context)
    {
      _context = context;
    }
    public async Task DispatchAsync<T>(T command) where T : ICommand
    {
      if (command == null)
      {
        //TODO : LOG
        throw new ArgumentNullException(nameof(command),
                    $"Command: '{typeof(T).Name}' nie może być NULL.");
      }
      var handler = _context.Resolve<ICommandHandler<T>>();
      await handler.HandleAsync(command);
    }
  }
}