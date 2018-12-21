#!/bin/bash
set -e

cd TLSharp.Core
rm -rf bin
dotnet pack
dotnet nuget push bin/Debug/*.nupkg --source http://api.nuget.org/v3/index.json --api-key $TLSHARP_NUGET_API_KEY
