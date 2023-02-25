
cd Assets\Framework\
copy *.cs D:\lquinones\SampleCSharpPlugin\DLLTest_GetFilesFromUnity
cd D:\lquinones\SampleCSharpPlugin\DLLTest_GetFilesFromUnity

Msbuild DLLTest.csproj > logBuild.log
cd D:\lquinones\lab\_FeaturesSamplesRepo\__LearnjamTest\testunityprojectpackage
git add .
git commit -m "Updating DLL Library"
git push origin main > log.log
