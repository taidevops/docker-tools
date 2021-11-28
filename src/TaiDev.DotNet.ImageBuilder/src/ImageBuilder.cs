using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using TaiDev.DotNet.ImageBuilder;
using ICommand = TaiDev.DotNet.ImageBuilder.Commands.ICommand;

int result = 0;

try
{
    ICommand[] commands = ImageBuilder.Container.GetExportedValues<ICommand>().ToArray();

    RootCommand rootCliCommand = new RootCommand();

    foreach (ICommand command in commands)
    {
        rootCliCommand.AddCommand(command.GetCliCommand());
    }

    Parser parser = new CommandLineBuilder(rootCliCommand)
        .UseDefaults()
        .Build();
    return parser.Invoke(args);
}
catch (Exception ex)
{
    Logger.WriteError(ex.ToString());

    result = 1;
}

return result;

public static class ImageBuilder
{
    private static CompositionContainer? s_container;

    public static CompositionContainer Container
    {
        get
        {
            if (s_container == null)
            {
                string dllLocation = Assembly.GetExecutingAssembly().Location;
                DirectoryCatalog catalog = new DirectoryCatalog(Path.GetDirectoryName(dllLocation.AsSpan()).ToString(), Path.GetFileName(dllLocation));
                s_container = new CompositionContainer(catalog);
            }

            return s_container;
        }
    }
}
