$build = $env:windir+'\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe'
Write-Verbose "Build Target"
&$build .\Midgard.Base32.csproj /p:Configuration=Release 
Write-Verbose "Update NuGet"
NuGet.exe update -self
Write-Verbose "Write nupkg"
NuGet.exe pack .\Midgard.Base32.csproj -Symbols -Prop Configuration=Release

Write-Verbose "Push nupkg"
ls *.nupkg | %{  NuGet.exe push $_ }

# NuGet.exe push .\Midgard.Base32.nupkg
# NuGet.exe push .\Midgard.Base32.symbols.nupkg

Write-Verbose "Cleanup"
ls *.nupkg | rm