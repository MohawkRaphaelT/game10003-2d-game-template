:: DELETE
rmdir /q /s _site
rmdir /q /s api

:: GENERATE
docfx .\docfx.json

pause