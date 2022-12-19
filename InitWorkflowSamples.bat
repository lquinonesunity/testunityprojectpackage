git pull
git add .
git commit -m "Update Samples"
git push origin main
cd ..\JustPackageBranch\
rmdir /s /q testunityprojectpackage
DownloadSamplesCopyToMainRepo.bat