@ECHO OFF

:: This is a script manager for front-end installation, reinstallation, build and watch for changes.
:: Additional a feature for listing all versions related to front-end development.

ECHO.
ECHO *******************
ECHO * Script manager  *
ECHO *******************
ECHO.

IF [%1]==[] CALL :DEFAULT_CASE
SET ACTION=%1
2>NUL CALL :CASE_%ACTION%
EXIT /B

:CASE_i
:CASE_install
  ECHO Installing front-end packages
  ECHO.
  CALL npm install 
  CALL sm build
  GOTO END_CASE
:CASE_r
:CASE_reinstall
  ECHO Reinstalling front-end
  ECHO.
  CALL sm delete
  CALL sm install
  CALL sm watch
GOTO END_CASE
:CASE_d
:CASE_delete
  ECHO Deleting front-end packages
  ECHO.
  rd /s /q .\node_modules
  GOTO END_CASE  
:CASE_b
:CASE_build
  ECHO Running production build
  ECHO.
  CALL npm run build
  GOTO END_CASE
:CASE_s
:CASE_start
  ECHO Start server and for changes and rebuilding
  ECHO.
  CALL npm start
  GOTO END_CASE
:CASE_v
:CASE_version
  ECHO Getting all front-end versions
  ECHO.

  ECHO npm
  CALL npm -v
  ECHO.

  ECHO npx (npm client tools)
  CALL npx -v
  ECHO.

  ECHO node.js
  CALL node -v
  ECHO.

  ECHO gulp
  CALL gulp -v
  ECHO.

  ECHO chocolatey
  CALL choco -v
  ECHO.

  ECHO yarn
  CALL yarn -v
  ECHO.

  ECHO webpack (local reported by NPM)
  CALL npm list webpack
  ECHO.
  
  ECHO webpack (global reported by NPM)
  CALL npm view webpack version
  ECHO.
  
  ECHO webpack (local) Note! This might fail if webpack is not globally installed. If so press CTRL+C to abort!
  CALL webpack --version
  ECHO.

  GOTO END_CASE
:DEFAULT_CASE
  ECHO Action missing, valid actions are:
  ECHO  [i]nstall
  ECHO  [d]elete
  ECHO  [r]einstall
  ECHO  [b]uild
  ECHO  [s]erver
  ECHO  [v]version
  GOTO END_CASE
:END_CASE
  GOTO :EOF
