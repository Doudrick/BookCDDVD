@echo off
echo[
echo[
echo Ready to install DB Engines, if not running as elevated, answer "yes" to UAC!
echo[ 
echo[
pause
"%~dp0AccessDatabaseEngine.exe" /passive
"%~dp0AccessDatabaseEngine_X64.exe" /passive
echo[
echo[
echo Finished installation!
echo[
echo[
pause