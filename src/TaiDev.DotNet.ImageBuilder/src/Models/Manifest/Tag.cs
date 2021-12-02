﻿using System.ComponentModel;

namespace TaiDev.DotNet.ImageBuilder.Models.Manifest;

#nullable disable
[Description(
    "A tag object contains metadata about a Docker tag. It is a JSON object " +
    "with its tag name used as the attribute name."
    )]
public class Tag
{
    [Description(
        "An identifier used to conceptually group related tags in the readme " +
        "documentation."
        )]
    public string DocumentationGroup { get; set; }

    [Description(
        "Indicates whether the image should only be tagged with this tag on the " +
        "local machine that builds the image. The published image will not include " +
        "this tag. This is only used for advanced build dependency scenarios."
        )]
    public bool IsLocal { get; set; }

    [Description(
        "Indicates how this tag should not be documented in the readme file. Regardless of the " +
        "setting, the image will still be tagged with this tag and will still be published. " +
        "This is useful when deprecating a tag that still needs to be kept up-to-date " +
        "but not wanting it documented."
        )]
    [DefaultValue(TagDocumentationType.Documented)]
    public TagDocumentationType DocType { get; set; }

    [Description(
        "Description of where the tag should be syndicated to.")]
    public TagSyndication Syndication { get; set; }

    public Tag()
    {
    }
}
#nullable enable
