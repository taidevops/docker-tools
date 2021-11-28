
namespace TaiDev.DotNet.ImageBuilder;

public interface ILoggerService
{
    void WriteError(string error);
    void WriteHeading(string heading);
    void WriteMessage();
    void WriteMessage(string message);
    void WriteSubheading(string subheading);
}
