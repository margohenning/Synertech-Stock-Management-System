@ECHO off
call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\Tools\VsDevCmd"
ECHO.
@ECHO ON
sqlmetal /server:DESKTOP-UPNNGRH\MARGOSQLSERVER /database:ssms  /namespace:ssms.LTS /user:sa /password:root /code:"C:\ssms\ssms\ssms\LTS\LTSBase.cs" /views /functions /sprocs /language:c# /context:LTSBase
@ECHO OFF
ECHO.
ECHO Done...
ECHO.
PAUSE