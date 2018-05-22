//---------------------------------------------------------------------------
//   I N T E R M E C  T E C H N O L O G I E S  C O R P O R A T I O N
//   5 5 0  S E C O N D  S T R E E T
//   C E D A R  R A P I D S,  I O W A   U S A
//---------------------------------------------------------------------------
//   COPYRIGHT 2004 INTERMEC TECHNOLOGIES CORPORATION.
//   UNPUBLISHED - ALL RIGHTS RESERVED UNDER THE COPYRIGHT LAWS.
//   PROPRIETARY AND CONFIDENTIAL INFORMATION. DISTRIBUTION, USE
//   AND DISCLOSURE RESTRICTED BY INTERMEC TECHNOLOGIES CORPORATION.
//---------------------------------------------------------------------------

// AirlineSoftware.cpp : Defines the entry point for the DLL application.
//

#include "stdafx.h"
#include "AirlineSoftware.h"
#include <stdio.h>
#include <stdlib.h>
#include "Rijndael.h"
#include "IS9Cconfig.h"
#include "ITCADCMgmt.h"
#include "oemioctl.h"
#include "nLed.h"
//#include "AFX.h"
// #define SYMBOL

#ifdef SYMBOL
extern "C" __declspec(dllimport)void SetCleanRebootFlag(void); 
#endif

extern "C" BOOL KernelIoControl (DWORD dwIoControlCode, LPVOID lpInBuf, DWORD nInBufSize, 
		      LPVOID lpOutBuf, DWORD nOutBufSize, LPDWORD lpBytesReturned );

#define IOCTL_HAL_ITC_WRITE_PARM_BYTE    CTL_CODE(FILE_DEVICE_HAL, PLATFORM_ITC_IOCTL_BASE + 27, METHOD_BUFFERED, FILE_ANY_ACCESS)      
#define IOCTL_HAL_WARMBOOT	CTL_CODE( FILE_DEVICE_HAL, CORE_OEM_IOCTL_BASE + 4, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_HAL_COLDBOOT	CTL_CODE( FILE_DEVICE_HAL, CORE_OEM_IOCTL_BASE + 5, METHOD_BUFFERED, FILE_ANY_ACCESS)


#define ITC_CODE128_FNC1_NO_CHANGE 255
#define ITC_BC_LENGTH_NO_CHANGE 255
#define ITC_BC_LENGTH_NO_CHANGE 255
#define ITC_BC_LENGTH_NO_CHANGE 255

#ifdef __cplusplus
extern "C" {
#endif

BOOL WINAPI NLedSetDevice(UINT nDeviceID, void *pInput);
BOOL WINAPI NLedGetDeviceInfo( UINT nInfoId, void *pOutput );


#define NLED_NOTIFICATION	0
#define NLED_RADIO			1
#define NLED_ALPHA			2
#define NLED_SCAN			3
#define NLED_BATLOW			4
#define NLED_VIBRATE		5

#define NLED_OFF			0
#define NLED_ON				1
#define NLED_BLINK			2

#ifdef __cplusplus
}
#endif
BOOL APIENTRY DllMain( HANDLE hModule, 
                       DWORD  ul_reason_for_call, 
                       LPVOID lpReserved
					 )
{
    switch (ul_reason_for_call)
	{
		case DLL_PROCESS_ATTACH:
		case DLL_THREAD_ATTACH:
		case DLL_THREAD_DETACH:
		case DLL_PROCESS_DETACH:
			break;
    }
    return TRUE;
}



// This is an example of an exported function.
AIRLINESOFTWARE_API void Code93Active()
{
#ifndef SYMBOL
    IS9CConfig *pS9CConfig;

	HRESULT hrStatus = ITCDeviceOpen( TEXT("default"), IID_IS9CConfig, ITC_DHDEVFLAG_NODATA, (LPVOID *) &pS9CConfig );
    hrStatus = pS9CConfig->SetCode93(ITC_CODE93_ACTIVE,ITC_BARCODE_LENGTH ); 
    ITCDeviceClose( (IUnknown **) &pS9CConfig );
#endif
}

AIRLINESOFTWARE_API void Code93NotActive()
{
    IS9CConfig *pS9CConfig;

#ifndef SYMBOL
	HRESULT hrStatus = ITCDeviceOpen( TEXT("default"), IID_IS9CConfig, ITC_DHDEVFLAG_NODATA, (LPVOID *) &pS9CConfig );

    hrStatus = pS9CConfig->SetCode93(ITC_CODE93_NOTACTIVE,ITC_BARCODE_LENGTH );    
	ITCDeviceClose( (IUnknown **) &pS9CConfig );
#endif
}


//code 128
AIRLINESOFTWARE_API void Code128Active()
{
    IS9CConfig *pS9CConfig;

	HRESULT hrStatus = pS9CConfig->SetCode128(ITC_CODE128_ACTIVE ,ITC_EAN128_ID_REMOVE,
		ITC_CODE128_CIP128_NO_CHANGE,ITC_CODE128_FNC1_NO_CHANGE,ITC_BC_LENGTH_NO_CHANGE );  
    ITCDeviceClose( (IUnknown **) &pS9CConfig );
}

AIRLINESOFTWARE_API void Code128NotActive()
{
    IS9CConfig *pS9CConfig;

	HRESULT hrStatus = pS9CConfig->SetCode128(ITC_CODE128_NOTACTIVE ,ITC_EAN128_ID_REMOVE,
		ITC_CODE128_CIP128_NO_CHANGE,ITC_CODE128_FNC1_NO_CHANGE,ITC_BC_LENGTH_NO_CHANGE );   
	ITCDeviceClose( (IUnknown **) &pS9CConfig );
}
//


AIRLINESOFTWARE_API int SystemPowerStatus()

{
             SYSTEM_POWER_STATUS_EX2  powerStat;
//           powerStat = NULL;
             DWORD temp = 0;

             temp = GetSystemPowerStatusEx2(&powerStat,(DWORD)sizeof(SYSTEM_POWER_STATUS_EX2),TRUE);
/*             if (!temp)
             {
                         temp = GetLastError();
             }
*/
             if (powerStat.ACLineStatus == 1)
             {
						 return 1;
                     //    m_battstat = (L"Device is currently on AC power. Battery status is not available.");
                     //    m_progress.SetPos(0);
             }
 //            else if (powerStat.BatteryLifePercent >= 0 && powerStat.BatteryLifePercent <= 100)
 //            {
						 return 0;
                       //  m_progress.SetRange(0,100);
                       // m_progress.SetPos(powerStat.BatteryLifePercent);
                       //  CString tString;
                       //  tString.Format(L" %d%%",powerStat.BatteryLifePercent);
                       //  m_battstat = tString;
 //            }
   
}

AIRLINESOFTWARE_API void TurnOnRegistrySave()
{


            BOOL   bSuccess;
            DWORD   dwBytesReturned;
            BYTE    InBuff, OutBuff;

            InBuff  = ITC_REGISTRY_SAVE_ENABLE;
            OutBuff = 1; //enabled

 

            bSuccess = KernelIoControl(
                    IOCTL_HAL_ITC_WRITE_SYSPARM,
                    &InBuff,
                    sizeof(InBuff),
                    &OutBuff,
                    sizeof(OutBuff),
                    &dwBytesReturned );         
     //               if(!bSuccess)
     //      AfxMessageBox(_T("Failed to write reg enable"));

			InBuff = ITC_REGISTRY_LOCATION;
			OutBuff = 2; //Secure Digital

            bSuccess = KernelIoControl(
                    IOCTL_HAL_ITC_WRITE_SYSPARM,
                    &InBuff,
                    sizeof(InBuff),
                    &OutBuff,
                    sizeof(OutBuff),
                    &dwBytesReturned );

}

/* save
AIRLINESOFTWARE_API long GetTimeZone()

{

            DWORD dwRetVal = 0;

            TIME_ZONE_INFORMATION tzi;

 

            memset(&tzi, 0, sizeof(TIME_ZONE_INFORMATION));

 

            dwRetVal = GetTimeZoneInformation(&tzi);

 

            return tzi.Bias;

}

 

AIRLINESOFTWARE_API void SetTimeZone(long nOffset)

{

            DWORD dwRetVal = 0;

            BOOL bRetVal = FALSE;

            TIME_ZONE_INFORMATION tzi;

 

            memset(&tzi, 0, sizeof(TIME_ZONE_INFORMATION));

 

            dwRetVal = GetTimeZoneInformation(&tzi);

 

            tzi.Bias = nOffset;

 

            bRetVal = SetTimeZoneInformation(&tzi);

}

 
/*
/*

_TIME_ZONE_INFORMATION stTimeZone;
 
 memset(&stTimeZone, 0, sizeof(stTimeZone));
 GetTimeZoneInformation(&stTimeZone);
 
 stTimeZone.Bias=360;
 stTimeZone.DaylightBias=-60;
 
 memset(&stTimeZone.DaylightDate, 0, sizeof(SYSTEMTIME));
 memset(&stTimeZone.StandardDate, 0, sizeof(SYSTEMTIME));
 
 wcscpy(stTimeZone.DaylightName, _T("Central US (Daylight)"));
 wcscpy(stTimeZone.StandardName, _T("Central US"));
 
 SetTimeZoneInformation(&stTimeZone);




*/
AIRLINESOFTWARE_API void WarmBoot()
{
#ifndef SYMBOL
  DWORD cbRet;	
  KernelIoControl(IOCTL_HAL_WARMBOOT, NULL, 0, NULL, 0, &cbRet);
#else
   int IOCTL_HAL_REBOOT = 0x101003C;
   KernelIoControl(IOCTL_HAL_REBOOT, NULL, 0, NULL, 0,NULL);
#endif
}

AIRLINESOFTWARE_API void ColdBoot()
{
#ifndef SYMBOL
  DWORD cbRet;

  KernelIoControl(IOCTL_HAL_COLDBOOT, NULL, 0, NULL, 0, &cbRet);
#else
  SetCleanRebootFlag(); 
   int IOCTL_HAL_REBOOT = 0x101003C;
   KernelIoControl(IOCTL_HAL_REBOOT, NULL, 0, NULL, 0,NULL);
#endif
}

AIRLINESOFTWARE_API int aesEncrypt(
    const char *inputMode,
    const UINT8 *inputBuffer,
    const int inputLen,
    unsigned char *outputBuffer,
    const unsigned char *key, int inputKeyLength)
{
  class Rijndael rijndaelClass ;

  Rijndael::Mode mode ;
  Rijndael::KeyLength keyLength ;

  int rc ;

  if (!strcmp(inputMode, "ECB" )) mode = Rijndael::ECB  ; else
  if (!strcmp(inputMode, "CBC" )) mode = Rijndael::CBC  ; else
  if (!strcmp(inputMode, "CFB1")) mode = Rijndael::CFB1 ; else
  return -1001 ;
  
  if (inputKeyLength == 8 * 16) keyLength = Rijndael::Key16Bytes ; else
  if (inputKeyLength == 8 * 24) keyLength = Rijndael::Key24Bytes ; else
  if (inputKeyLength == 8 * 32) keyLength = Rijndael::Key32Bytes ; else
  return -1002 ;

  rc = rijndaelClass.init(mode, Rijndael::Encrypt, key, keyLength, (UINT8 *) 0 ) ;

  if (rc < 0) return rc ;

  rc = rijndaelClass.padEncrypt(inputBuffer, inputLen, outputBuffer) ;

  return rc ;
}

AIRLINESOFTWARE_API int aesDecrypt(
    const char *inputMode,
    const UINT8 *inputBuffer,
    const int inputLen,
    unsigned char *outputBuffer,
    const unsigned char *key, int inputKeyLength)
{
  class Rijndael rijndaelClass ;

  Rijndael::Mode mode ;
  Rijndael::KeyLength keyLength ;

  int rc ;

  if (!strcmp(inputMode, "ECB" )) mode = Rijndael::ECB  ; else
  if (!strcmp(inputMode, "CBC" )) mode = Rijndael::CBC  ; else
  if (!strcmp(inputMode, "CFB1")) mode = Rijndael::CFB1 ; else
  return -1001 ;
  
  if (inputKeyLength == 8 * 16) keyLength = Rijndael::Key16Bytes ; else
  if (inputKeyLength == 8 * 24) keyLength = Rijndael::Key24Bytes ; else
  if (inputKeyLength == 8 * 32) keyLength = Rijndael::Key32Bytes ; else
  return -1002 ;

  rc = rijndaelClass.init(mode, Rijndael::Decrypt, key, keyLength, (UINT8 *) 0 ) ;

  if (rc < 0) return rc ;

  rc = rijndaelClass.padDecrypt(inputBuffer, inputLen, outputBuffer) ;

  return rc ;
}



AIRLINESOFTWARE_API DWORD GetRegistryNumber(LPCTSTR lpSubKey, LPCTSTR lpEntry)

{	
	HKEY hKey = HKEY_LOCAL_MACHINE;
	
	LONG lResult = 0;
	
	HKEY hSubKey = NULL;
	
	DWORD dwType = 0;
	
	DWORD dwSize = 0;
	
	DWORD dwValue = 0;
	
	
	
	if ((lResult = RegOpenKeyEx(hKey, lpSubKey, 0, KEY_READ, &hSubKey)) == ERROR_SUCCESS)
		
	{
		
		if ((lResult = RegQueryValueEx(hSubKey, lpEntry, NULL, &dwType, NULL, &dwSize)) == ERROR_SUCCESS)
			
		{
			
			if (dwType == REG_DWORD)
				
			{
				
				lResult = RegQueryValueEx(hSubKey, lpEntry, NULL, &dwType, (LPBYTE)&dwValue, &dwSize);
				
			}
			
			else
				
			{
				
				lResult = -1;
				
			}
			
		}
		
		RegCloseKey(hSubKey);
		
	}
	
	
	
	return dwValue;
	
}

 

AIRLINESOFTWARE_API DWORD GetRegistryString(LPTSTR rValue, LPCTSTR lpSubKey, LPCTSTR lpEntry)

{
	HKEY hKey = HKEY_LOCAL_MACHINE;
	TCHAR szValue[256] ;

	LONG lResult = 0;
	
	HKEY hSubKey = NULL;
	
	DWORD dwType = 0;
	
	DWORD dwSize = 0;
	
	
	int i = 0;
	
	memset(szValue, 0, sizeof(szValue));
	
	
	
	if ((lResult = RegOpenKeyEx(hKey, lpSubKey, 0, KEY_READ, &hSubKey)) == ERROR_SUCCESS)
		
	{
		
		if ((lResult = RegQueryValueEx(hSubKey, lpEntry, NULL, &dwType, NULL, &dwSize)) == ERROR_SUCCESS)
			
		{
			
			if (dwSize <= sizeof(szValue))
				
			{
				
				if ((lResult = RegQueryValueEx(hSubKey, lpEntry, NULL, &dwType, (LPBYTE)szValue, &dwSize)) == ERROR_SUCCESS)
					
				{
					
					for(i=0;i<256;i++)
					{
						rValue[i] = szValue[i];
					}
					
					return 1;
					// return szValue;
					
				}
				
			}
			
			else
				
			{
				
				lResult = -2;
				
			}
			
		}
		
		RegCloseKey(hSubKey);
		
	}
	
	
	
	return 0;
	
}

AIRLINESOFTWARE_API void BeepSound() 
{

	PlaySound (TEXT("\\Windows\\goodread.WAV"), NULL, SND_SYNC);

}

AIRLINESOFTWARE_API void VibrateOFF()
{
	NLED_SETTINGS_INFO setinfo;

	setinfo.LedNum = 5;
	setinfo.OffOnBlink = 0;
	NLedSetDevice(NLED_SETTINGS_INFO_ID,&setinfo);	
}

AIRLINESOFTWARE_API void VibrateON()
{
	NLED_SETTINGS_INFO setinfo;

	setinfo.LedNum = 5;
	setinfo.OffOnBlink = 1;
	NLedSetDevice(NLED_SETTINGS_INFO_ID,&setinfo);		
}


AIRLINESOFTWARE_API wchar_t *AppendFileSegment(wchar_t *inptFileName, wchar_t *outpFileName)
{
	FILE *inptFilePntr, *outpFilePntr ;

	wchar_t readBuff[2] ;
	wchar_t apndBuff[2] ;

	readBuff[0] = L'r' ;
	readBuff[1] = 0 ;

	apndBuff[0] = L'a' ;
	apndBuff[1] = 0 ;

	inptFilePntr = _wfopen(inptFileName, readBuff) ;
	if (inptFilePntr == NULL) return inptFileName ;

	outpFilePntr = _wfopen(outpFileName, apndBuff) ;
	if (inptFilePntr == NULL) return outpFileName ;

	int nextChar ;

	while ((nextChar = fgetc(inptFilePntr)) != EOF)
	{
		fputc(nextChar, outpFilePntr) ;
	}

	return 0 ;
}
