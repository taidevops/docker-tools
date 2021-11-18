# Base Image Dependency Flow

One of the requirements for .NET Docker is to have its images rebuilt whenever a base image has changed and have them published as soon as possible.  For example, if an updated image of `alpine:3.9` is made available, all of the .NET Dockerfiles which contain `FROM alpine:3.9` should be rebuilt, including their dependencies.  This ensures a high degree of confidence by consumers of the .NET Docker images that the images include the latest patches.  As part of the .NET Docker engineering system there is an automated workflow that helps with managing this requirement.

## Tracking Base Image Digests
The first step is to make sure that we can easily determine which version of the base image that each of the .NET Docker images are dependent upon.  This is done by tracking the base image's [digest](https://docs.docker.com/engine/reference/commandline/pull/#pull-an-image-by-digest-immutable-identifier).  A digest is a unique identifier of an image.  If a newer version of the image is published, it will have a different digest value.

When an image is built, the value of its base image's digest is stored in what's called an image info file.  This JSON file contains useful metadata about images that can be easily consumed by the engineering system.
