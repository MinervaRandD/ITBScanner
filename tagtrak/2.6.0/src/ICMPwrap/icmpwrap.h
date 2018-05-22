
// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the ICMPWRAP_EXPORTS
// symbol defined on the command line. this symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// ICMPWRAP_API functions as being imported from a DLL, wheras this DLL sees symbols
// defined with this macro as being exported.
#ifdef ICMPWRAP_EXPORTS
#define ICMPWRAP_API extern "C" __declspec(dllexport)
#else
#define ICMPWRAP_API __declspec(dllimport)
#endif

//extern ICMPWRAP_API int nIcmpwrap;

ICMPWRAP_API bool Init(WORD ThePacketSize);
ICMPWRAP_API void Shutdown();

ICMPWRAP_API bool Ping(TCHAR * TheAddress, char TheTTL, DWORD TheTimeoutMS);

ICMPWRAP_API long GetPingRTT();
ICMPWRAP_API void GetPingAddress(TCHAR * TheAddress, long TheAddressLen);

ICMPWRAP_API long Version();