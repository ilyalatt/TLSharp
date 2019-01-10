[![NuGet](https://img.shields.io/nuget/v/TLSharp.Fork.svg)](https://nuget.org/packages/TLSharp.Fork) 

## Changes

# 0.0.1-preview002
* netstandard support

# dev branch
* a new RPC transport generator which is based on .tl schema files
* fully redesigned functional-oriented RPC transport (based on [LanguageExt](https://github.com/louthy/language-ext))
* deserialization without unneeded reflection
* RPC backround receive (vs pull after sending in the original library)
* RPC queue (it is needed to fix a simultaneos requests problem)
* enhanced exceptions, common TlException abstract class for all library exceptions
* major refactoring of the whole library, a lot of breaking changes because of it
* TLSharp.Example project
