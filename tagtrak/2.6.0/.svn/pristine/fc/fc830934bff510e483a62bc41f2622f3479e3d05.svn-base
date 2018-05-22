// icmpwrap.cpp : Defines the entry point for the DLL application.
//

#include "stdafx.h"
#include "icmpwrap.h"

#define MAX_ENTRYLEN 255
#define DLL_VERSION 1

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

WSADATA wsad;
HANDLE hIcmp;
LPVOID lpData = NULL;
LPVOID lpRevBuffer = NULL;
int InitCount = 0;
WORD PacketSize = 0;

ICMPWRAP_API bool Init(WORD ThePacketSize)
{
	// If already initialized, do not reinitialize.
	if (InitCount > 0) 
	{
		InitCount++;
		return true;
	}
	else
	{
		InitCount++;
	}

	// Start up winsock
	if (WSAStartup(0x0101, &wsad) != 0)
	{
		return false;
	}

	// Start ICMP
	hIcmp = IcmpCreateFile();
	if(hIcmp == INVALID_HANDLE_VALUE)
	{
		// Close/free
		WSACleanup();
		return false;
	}

	PacketSize = ThePacketSize;

	return true;
}

ICMPWRAP_API void Shutdown()
{
	// Only shut down if necessary
	if (InitCount == 0)
	{
		return;
	}
	
	InitCount--;

	// Shutdown only if last Shutdown call
	if (InitCount == 0)
	{
		// Close/free
		IcmpCloseHandle(hIcmp);
		WSACleanup();
	}
}

TCHAR PingAddress[20];
long PingRtt;

// Send an ICMP packet to the specified address with the specified TTL
ICMPWRAP_API bool Ping(TCHAR * TheAddress, char TheTTL, DWORD TheTimeoutMS)
{
	if(InitCount == 0) return false;

	IPAddr ipa;

	in_addr iAddr;

	// Convert wide address to multi-byte char address
	char Addr[32];
	wcstombs(Addr, TheAddress, 32);

	ipa = inet_addr(Addr);
	if(ipa == INADDR_NONE)
	{
		return false;
	}

	//Build the options
	IP_OPTION_INFORMATION ioi;
	ioi.Ttl = TheTTL;
	ioi.Tos = 8;

	// Send the ping
	lpData = LocalAlloc(LPTR, PacketSize);
	lpRevBuffer = LocalAlloc(LPTR, sizeof(ICMP_ECHO_REPLY)*PacketSize);

	DWORD ReplyCount = IcmpSendEcho(hIcmp, ipa, lpData, PacketSize, &ioi, lpRevBuffer, (sizeof(ICMP_ECHO_REPLY)*PacketSize), TheTimeoutMS);
	if(ReplyCount == 0)
	{
		// ICMP Failed

		LocalFree(lpData);
		LocalFree(lpRevBuffer);

		return false;
	}
	else
	{
		// Get the ping information and extract the round trip time and data size
		ICMP_ECHO_REPLY * sIcmp;

		sIcmp = (ICMP_ECHO_REPLY*)lpRevBuffer;
		PingRtt = sIcmp->RoundTripTime;
		ipa = sIcmp->Address;
		
		// Format address for output
		iAddr.S_un.S_addr = ipa;
		wsprintf(PingAddress, TEXT("%S"), inet_ntoa(iAddr));
		
		LocalFree(lpData);
		LocalFree(lpRevBuffer);

		// ICMP Succeeded
		return true;
	}
}

ICMPWRAP_API long GetPingRTT()
{
	return PingRtt;
}

ICMPWRAP_API void GetPingAddress(TCHAR * TheAddress, long TheAddressLen)
{
	// Make sure there's enough room
	if(wcslen(PingAddress) > (DWORD)TheAddressLen) return;

	wcscpy(TheAddress, PingAddress);

	return;
}

ICMPWRAP_API long Version()
{
	return DLL_VERSION;
}