using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ICommand = Microsoft.DotNet.ImageBuilder.Commands.ICommand;

namespace Microsoft.DotNet.ImageBuilder
{
    public static class ImageBuilder
    {
        private static CompositionContainer s_container;

        public static CompositionContainer Container
        {
            get
            {
                if (s_container == null)
                {
                    string dllLocation = Assembly.GetExecutingAssembly().Location;
                    DirectoryCatalog catalog = new DirectoryCatalog(Path.GetDirectoryName(dllLocation), Path.GetFileName(dllLocation));
                    s_container = new CompositionContainer(catalog);
                }

                return s_container;
            }
        }

        public static int Main(string[] args)
        {
            int result = 0;

            try
            {
                ICommand[] commands = Container.GetExportedValues<ICommand>().ToArray();

                RootCommand rootCliCommand = new RootCommand();

                foreach (ICommand command in commands)
                {
                    rootCliCommand.AddCommand(command.GetCliCommand());
                }

                Parser parser = new CommandLineBuilder(rootCliCommand)
                    .UseDefaults()
                    .UseMiddleware(context =>
                    {
                        if (context.ParseResult.CommandResult.Command != rootCliCommand)
                        {
                            // Capture the Docker version and info in the output

                        }
                    })
                    .UseMiddleware(context =>
                    {

                    })
                    .Build();
                return parser.Invoke(args);
            }
            catch (Exception e)
            {

                result = 1;
            }

            return result;
        }
    }
}
