echo mml2vgm

del /Q .\output\*.*
xcopy .\mml2vgm\bin\Release\*.* .\output\mml2vgm /E /R /Y /I /K
del /Q .\output\mml2vgm\*.pdb

xcopy .\mml2vgm\sample\* .\output\mml2vgm\sample\ /E /R /Y /I /K
pause

xcopy .\mvc\bin\Release\*.* .\output\mml2vgm /E /R /Y /I /K

xcopy .\mml2vgmIDE\bin\Release\*.* .\output\mml2vgmIDE /E /R /Y /I /K
copy /Y .\CHANGE.txt .\output
copy /Y .\IDE.txt .\output
copy /Y .\Script.txt .\output
copy /Y .\..\LICENSE.txt .\output
copy /Y .\..\mml2vgm_MMLCommandMemo.txt .\output
copy /Y .\..\mml2vgm_MMLCommandMemo.txt .\output\mml2vgmIDE
copy /Y .\..\mmlCommandTable.md .\output
copy /Y .\..\README.md .\output
copy /Y .\..\ZGMspec.txt .\output
copy /Y .\..\m98�R�}���h�E���t�@�����X.pdf .\output
copy /Y .\..\PSG2.txt .\output
copy /Y .\..\YM2609.txt .\output
copy /Y .\..\maseChangeMML.md .\output
copy /Y .\removeZoneIdent.bat .\output
del /Q .\output\mml2vgmIDE\*.pdb
del /Q .\output\mml2vgmIDE\*.config
del /Q .\output\mml2vgmIDE\*.wav
del /Q .\output\mml2vgm\*.pdb
del /Q .\output\mml2vgm\*.config
del /Q bin.zip
powershell Compress-Archive -Path .\output\* -D bin
pause
