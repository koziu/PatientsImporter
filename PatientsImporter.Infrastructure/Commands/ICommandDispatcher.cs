using System.Threading.Tasks;

namespace PatientsImporter.Infrastructure.Commands
{
  public interface ICommandDispatcher
  {
    Task DispatchAsync<T>(T command) where T : ICommand;
  }
}