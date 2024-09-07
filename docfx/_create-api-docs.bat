:: DELETE
rmdir /q /s _site
rmdir /q /s api

:: GENERATE
docfx .\docfx.json

:: Copy index.html
robocopy "." "./_site" "index.html"

pause