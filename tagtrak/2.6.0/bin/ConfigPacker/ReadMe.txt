ConfigPacker
============

	Takes XML config files, checks them for validity and packs them in an encrypted BIN file 
	together with all the required logos.
	
Usage:
------
	1. Run ConfigPacker.exe once to create base directories.
	2. Place XML files in ".\ConfigXML\[CARRIER]\Config.xml". ([CARRIER} MUST be a 2 character code).
	3. Place Image logos in ".\Images\[CARRIER]\". (3 Files: AdminLogo.bmp; InitLogo.bmp; ScanLogo.bmp).
	4. Run ConfigPacker.exe
	5. BIN files will be output to ".\ConfigBIN\[CARRIER]\ScannerConfig.bin" for each carrier present 
	   in the ConfigXML directory.