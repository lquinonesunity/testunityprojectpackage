cd Assets\Framework\
copy *.cs ..\..\..\DLLTest_GetFilesFromUnity
cd ..\..\..\DLLTest_GetFilesFromUnity
mkdir somelep
msbuild DLLTest.csproj
cd ..\testunityprojectpackage
git add .
git commit -m "Updating DLL Library"
git push origin main > log.log
