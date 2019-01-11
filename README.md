[![NuGet](https://img.shields.io/nuget/v/TLSharp.Fork.svg)](https://nuget.org/packages/TLSharp.Fork) 

## Changes

# dev branch

* layer 82
* a new RPC transport generator which is based on .tl schema files
* completely redesigned function-oriented RPC transport (based on [LanguageExt](https://github.com/louthy/language-ext))
* elimination of all reflection usages (even in deserialization)
* RPC backround receive (vs pull after sending in the original library)
* RPC queue (it is needed to fix a simultaneos requests problem)
* session atomic-like updates (with a backup file usage)
* enhanced exceptions, common TlException abstract class for all library exceptions
* major refactoring of the whole library, a lot of breaking changes because of it
* TLSharp.Example project

# 0.0.1-preview002

* netstandard support
