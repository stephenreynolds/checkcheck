# CheckCheck
Short for "Checksum Checker", this is a terminal tool for comparing files against a checksum to verify file integrity.

Supports MD5, SHA1, SHA256, SHA384, and SHA512.

## Prerequisites

## Compiling
From the .NET Core CLI, run `dotnet build` to compile and `dotnet run` to run.

To compile to an executable, run `dotnet publish -c Release -r win10-x64` (replacing win10-x64 with your platform). 

See https://docs.microsoft.com/en-us/dotnet/core/rid-catalog for a list of platform runtime identifiers.

See https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish for more info.

## Usage
Run `./checkcheck --help` for usage info:
```
-f, --file        Required. File to be checked.
-h, --hash        Required. Hash to compare against file.
-a, --algorithm   Required. Algorithm that was used to generate the hash.
--help            Display this help screen.
--version         Display version information.
```
Arguments are case-insensitive.

### Example
`./checkcheck -f file.exe -h C3499C2729730A7F807EFB8676A92DCB6F8A3F8F -a sha1`
