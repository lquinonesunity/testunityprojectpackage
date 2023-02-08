cd Assets\Framework\
copy *.cs ..\..\..\DLLTest_GetFilesFromUnity
cd ..\..\..\DLLTest_GetFilesFromUnity
Msbuild DLLTest.csproj
cd ..\testunityprojectpackage
git add .
git commit -m "Updating DLL Library"
git push origin main > log.log
