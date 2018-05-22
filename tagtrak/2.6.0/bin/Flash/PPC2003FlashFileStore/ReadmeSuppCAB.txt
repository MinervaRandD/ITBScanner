
Version 53 created on 05/05/05
Updated 80211pm. Moved re-authenticate in EndGroup call into the Network configlet. This fixes problem that was seen when remotely updating units.

version 52 created on 05/05/05
new version of uroddsvc.dll to fix suspend resume problem	
new version of swld26c.dll to get rid of blank SSID

Version 51 created on 04/25/05
New versions of prismnds and samsung nic drivers.
Rogue AP detection fixes.  Supports forcing long preamble.  
RSSI calibration support.  
Improved media connect/disconnect notification.  
"Hard" roaming improvements.  
Fixed improper WPA2 and CCKM support indication.  
Fixed supported 802.11 rates indicated in association request frames.

Version 50 created on 04/18/05
New 80211Conf that checks for valid length of PSK.  New Samsung with IBSS changes for WiFi compliance.

Version 49 created on 04/15/05
New PrismNDS Version 3.1.13 build 39 Signals media disconnect on SSID change to synchronize with supplicant
2.2b of uroddsvc supplicant adds robustness to finding 802.11 adapter after warm booting
New Samsung radio driver fixes issues with flight mode and connect events.

Version 48 created on 04/05/05
2.1e of uroddsvc that fixes a problem with the ZAPI_Notification thread making sure it does not
respond to notification from other nics.  Fixing a problem encountered with the IBM Webspere VPN
Client.

Version 47 created on 03/30/05
2.1d of uroddsvc that fixes a problem with the ZAPI_Notification thread was exiting when 
switching to ethernet.  When switching back no thread so no bind notification so no connecting
to the desired AP.
Also the samsung 802.11 driver is now included in the CAB file.

Version 46 created on 03/24/05
New version prismnds.dll Allowing APDensity 1-8 (SR05068001)

Version 45 created on 03/23/05
Version 2.1c of uroddsvc.dll
Fixed zniczio.dll to properly handle MEDIA_SPECIFIC indications and the data passed with them.
This to support the supplicant properly handling MIC countermeasures.
Latest password prompting changes.

Version 44 created on 03/17/05
Version 2.1b of urodsvc.dll
Fixed CEDev00008032 which fixes problem with adhoc mode.
Also changed receive thread to block on association event instead of polling.

Version 43 created on 03/7/05
Change for fixing Mixed Cell support for Samsung Radio
Changes to 80211pm.dll for IVA changes
Added CertInportUI.exe that goes into Windows directory.
Changes to enroll for command line option and for CK30/31 support.

Version 42 created on 02/11/05
Updated to use Funk Software Toolkit build 1559.
Fixing problem with using PEAP with MSCHAPv2 against a Cisco ACS server.
Code that supports Funk CCX 1 Oids (for Samsung Radio)
For Radios/terminals that are capable (not 7xx)...WPA2 / AES CCMP and CCX v 2
Supplicant now checks for radio capabilities (eg AES and CCKM) if supported by radio, feature enabled.
Cab File will NOT install on 700s that do not have 802.11 set to installed in eparms.
Password prompting fixes/improvements
For the PRISMNDS.dll: fixes (memory leak, ELP in firmware) that fix the battery rundown problem. 

Version 2005 created on 01/05/05
This is for a GRA using the new 1559 toolkit to fix PEAP with MSCHAPV2....This has not has much testing.

Version 40 Created on 11/09/04
Update to prismnds.dll FW: 1.10.03 Build 131 PRISMNDS: 3.1.8

Version 39 Created on 10/20/04
Fixed problem with wrong cabreset.dll getting into cab 38

Version 38 Created on 10/19/04
Updated PRISMNDS.dll version “3.1.8 build 31”
It has the 19:25 hang fix in it.


Version 37 Created on 9/20/04
Added the Prismnds driver into the cab file.  The cab file is the intended to
be the single point of distribution for netowrk related stuff, so driver updates
are now included here.

Version 36 Created on 9/7/04
Support for network-eap added to TLS and TTLS.
Fixed problem with Cybertan Radio

Version 35 Created on 8/24/04
New 80211pm and 80211conf that checks for old encryption method and removes all of those entries.

Version 34 Created on 8/24/04
New 80211pm and 80211conf that allow storage and encryption of longer passwords and passphrases.



version 32 created on 7/20/04

Added UserName prompting
Added DetectRogueAPs flag to allow shutting that off.
Rogue AP reg key set by cab if it does not already exist in the profile
Certificates restored if registry restore is used (MasterKeyInReg...)
Added Password Expiration/Changing Handling
Changed Certificate importing to der and pvk files as converted from pfx (PKCS12) file.
ZIO renamed back to UIO for other utility apps.
80211api should be backwards compatible
Added cert dialog button to PEAP and TTLS dialogs
Updated cert GUI to be more intuitive




LZ
