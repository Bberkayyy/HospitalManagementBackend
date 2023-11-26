
namespace Core.CrossCuttingConcerns.Exceptions;

public class ServiceExceptions : Exception
{
    public ServiceExceptions(string message) : base(message) { }
}
