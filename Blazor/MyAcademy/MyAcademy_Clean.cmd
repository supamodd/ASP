@echo off
rem Cleans leftovers that break the build after renaming Academy -> MyAcademy.
rem Place this file in Blazor\MyAcademy and run it (double-click).

cd /d "%~dp0"

echo Removing Data\AcademyContext.cs (old context from the rename)...
if exist "Data\AcademyContext.cs" del /f /q "Data\AcademyContext.cs"

echo Removing bin ...
if exist "bin" rmdir /s /q "bin"

echo Removing obj ...
if exist "obj" rmdir /s /q "obj"

echo.
echo Done. Now rebuild the project in Visual Studio (Build - Rebuild Solution).
pause
