@ECHO off
call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\Tools\VsDevCmd"
ECHO.
@ECHO ON
sqlmetal /server:TIAAN-PC /database:ssms  /namespace:ssms.LTS /user:sa /password:root /code:"C:\Users\Tiaan\Desktop\Doc's\3rd Year 2nd semester\ITSP301\Synnertech\s\ssms\ssms\LTS\LTSBase.cs" /views /functions /sprocs /language:c# /context:LTSBase
@ECHO OFF
ECHO.
ECHO Done...
ECHO.
PAUSE