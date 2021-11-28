using System;
using System.Threading.Tasks;
using Moq;
using TaiDev.DotNet.ImageBuilder.Commands;
using TaiDev.DotNet.ImageBuilder.Tests.Helpers;
using Xunit;

namespace TaiDev.DotNet.ImageBuilder.Tests;

#nullable disable
public class GenerateReadmesCommandTests
{
    private const string ProductFamilyReadmePath = "ProductFamilyReadme.md";
    private const string RepoReadmePath = "RepoReadme.md";
    private const string DefaultReadme = "Default Readme Contents";
    private const string ReadmeTemplatePath = "Readme.Template.md";
    private const string AboutRepoTemplatePath = "About.repo.Template.md";
    private const string AboutRepoTemplate =
@"Referenced Template Content";
    private const string ReadmeTemplate =
@"About {{if IS_PRODUCT_FAMILY:Product Family^else:{{SHORT_REPO}}}}
{{if !IS_PRODUCT_FAMILY:{{InsertTemplate(join(filter([""About"", SHORT_REPO, ""Template"", ""md""], len), "".""))}}}}";


    private readonly Exception _exitException = new Exception();
    private Mock<IEnvironmentService> _environmentServiceMock;

    [Fact]
    public async Task GenerateReadmesCommand_Canonical()
    {
        using TempFolderContext tempFolderContext = TestHelper.UseTempFolder();
        GenerateReadmesCommand command = InitializeCommand(tempFolderContext);

        await command.ExecuteAsync();
    }

    private GenerateReadmesCommand InitializeCommand(
        TempFolderContext tempFolderContext,
        string readmeTemplate = ReadmeTemplate,
        string productFamilyReadme = DefaultReadme,
        string repoReadme = DefaultReadme,
        bool allowOptionalTemplates = true,
        bool validate = false)
    {
        DockerfileHelper.CreateFile(ProductFamilyReadmePath, tempFolderContext, productFamilyReadme);
        DockerfileHelper.CreateFile(RepoReadmePath, tempFolderContext, repoReadme);

        DockerfileHelper.CreateFile(AboutRepoTemplatePath, tempFolderContext, AboutRepoTemplate);

        string templatePath = null!;
        if (readmeTemplate != null)
        {
            DockerfileHelper.CreateFile(ReadmeTemplatePath, tempFolderContext, readmeTemplate);
            templatePath = ReadmeTemplatePath;
        }

        _environmentServiceMock = new Mock<IEnvironmentService>();
        _environmentServiceMock
            .Setup(o => o.Exit(1))
            .Throws(_exitException);

        GenerateReadmesCommand command = new GenerateReadmesCommand(_environmentServiceMock.Object);
        command.Options.AllowOptionalTemplates = allowOptionalTemplates;
        command.Options.Validate = validate;

        return command;
    }
}
#nullable enable
