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

// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the AIRLINESOFTWARE_EXPORTS
// symbol defined on the command line. this symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// AIRLINESOFTWARE_API functions as being imported from a DLL, wheras this DLL sees symbols
// defined with this macro as being exported.
#ifdef AIRLINESOFTWARE_EXPORTS
#define AIRLINESOFTWARE_API __declspec(dllexport)
#else
#define AIRLINESOFTWARE_API __declspec(dllimport)
#endif

// This class is exported from the AirlineSoftware.dll
class AIRLINESOFTWARE_API CAirlineSoftware {
public:
	CAirlineSoftware(void);
	// TODO: add your methods here.
};

extern "C" AIRLINESOFTWARE_API void Code93Active();
extern "C" AIRLINESOFTWARE_API void Code93NotActive();
extern "C" AIRLINESOFTWARE_API void Code128Active();
extern "C" AIRLINESOFTWARE_API void Code128NotActive();
extern "C" AIRLINESOFTWARE_API int SystemPowerStatus();
extern "C" AIRLINESOFTWARE_API void TurnOnRegistrySave();
extern "C" AIRLINESOFTWARE_API void WarmBoot();
extern "C" AIRLINESOFTWARE_API void ColdBoot();
extern "C" AIRLINESOFTWARE_API DWORD GetRegistryNumber(LPCTSTR lpSubKey, LPCTSTR lpEntry);
extern "C" AIRLINESOFTWARE_API void BeepSound();
extern "C" AIRLINESOFTWARE_API void VibrateON();
extern "C" AIRLINESOFTWARE_API void VibrateOFF();
extern "C" AIRLINESOFTWARE_API wchar_t *AppendFileSegment(wchar_t *inptFileName, wchar_t *outpFileName) ;

extern "C" AIRLINESOFTWARE_API int fnTest10(int value);

extern "C" AIRLINESOFTWARE_API DWORD GetRegistryString(LPTSTR rValue, LPCTSTR lpSubKey, LPCTSTR lpEntry);

extern "C" AIRLINESOFTWARE_API int aesEncrypt(
    const char *inputMode,
    const UINT8 *inputBuffer,
    const int inputLen,
    unsigned char *outputBuffer,
    const unsigned char *key, int inputKeyLength);

extern "C" AIRLINESOFTWARE_API int aesDecrypt(
    const char *inputMode,
    const UINT8 *inputBuffer,
    const int inputLen,
    unsigned char *outputBuffer,
    const unsigned char *key, int inputKeyLength);



