/*******************************************************************************
 *
 *  FILE NAME:   ITCADCMgmt.h
 *  PURPOSE:     Contains the ADC Device Management API function definitions.
 *
 *  AUTHOR:      J. Hunt
 *
 *  COPYRIGHT (c) 2000 INTERMEC TECHNOLOGIES CORPORATION, ALL RIGHTS RESERVED
 *
 ******************************************************************************/
// #define SYMBOL

#ifndef INCLUDED_ITCADCMGMT_H                /* Has this file been included before?  */
#define INCLUDED_ITCADCMGMT_H                /* No, remember it has been now         */
#pragma once

////////////////////////////////////////////////////////////////
//  #INCLUDES   
#include <windows.h>
#include "IADC.h"
//
////////////////////////////////////////////////////////////////
//  #DEFINES   
//      NONE
//
////////////////////////////////////////////////////////////////
//   ENUMS   
//      NONE
//
//

////////////////////////////////////////////////////////////////
//
// PURPOSE:     Open an ADC Device connection
//
// DESCRIPTION:
//  See function protocol below for parameter description.  This
//  function creates the COM object associated with the specified
//  device and returns the specified interface.  Since this
//  is a COM inteface - AddRef, Release, and QueryInterface calls must 
//  follow normal COM rules.  HOWEVER, ITCDeviceClose must be called 
//  once to for every call to ITCDeviceOpen.
//  
// RETURNS:
//
//      HRESULT - indicates success or failure.  Use the
//          macros SUCCEEDED() or FAILED() to test for success
//          and failure.  The following error codes are 
//          returned for failure:
//          
//          ITC_DEVMGMT_INV_DEV_E - Invalid device name
//          ITC_DEVMGMT_INV_FLG_E - Device does not support the 
//              device flag specified in eDeviceFlags.
//          ITC_DEVMGMT_INIT_E    - Device Failed to initialized
//
////////////////////////////////////////////////////////////////
#ifndef SYMBOL
HRESULT __declspec(dllexport) __cdecl ITCDeviceOpen( 

    /* in */    LPCTSTR pszDeviceName,  // Logical Name of the device on which to establish 
                                        //  communication.  If the device name is "default", 
                                        //  then the default device on the unit will be referenced.

    /* in */    REFIID 		iid,        // The identifier of the COM interface being requested.

    /* in */    ITC_DEVICE_FLAGS eDeviceFlags,
                                        // Enumeration that identifies the read characteristics as follows:

                                        //  ITC_DHDEVFLAG_READAHEAD - Data is buffered on behalf of the calling 
                                        //      applications. Data Buffering starts after the first call to 
                                        //      IADC::Read ().
                                        //  ITC_DHDEVFLAG_NONREADAHEAD - Non-read ahead (the default). Data is not 
                                        //      buffered and data is not read from the device until the 
                                        //      application issues a read request using IADC::Read ().
                                        //  ITC_DHDEVFLAG_NODATA - The client application is managing the device 
                                        //      to set its configuration or control its interface but not to 
                                        //      collect data from the device.  


    /* out*/    void**  ppvObject       // A pointer to the interface pointer identified by iid. If the 
                                        //  object does not support this interface, ppvObject is set to NULL.

);
#else
#define ITCDeviceOpen(x)
#endif
//
////////////////////////////////////////////////////////////////
//
// PURPOSE:     Closes an ADC Device connection.
//
// DESCRIPTION: 
//  Closes the device connection opened by ITCDeviceOpen().  After
//  ITCDeviceClose is called, the pointer ppvObject pointer
//  is NULL'd since it is no longer valid.
//
//  This function decrements the object's reference count.  Alternatively, 
//  IUnknown::Release() could be used and, in fact, must be use if reference 
//  counting is performed with IUnknown::AddRef() and IUnknown::QueryInterface().
//
//  RETURNS:
//      HRESULT - indicates success or failure.  Use the
//          macros SUCCEEDED() or FAILED() to test for success
//          and failure.  The following error codes are 
//          returned for failure:
//
////////////////////////////////////////////////////////////////

#ifndef SYMBOL
HRESULT __declspec(dllexport) __cdecl ITCDeviceClose(
    /* in/out */  IUnknown 	**ppvObject // A pointer to the interface pointer created by ITCDeviceOpen.  
                                        //  If successful, on output, this pointer is set to NULL. 
);
#else
#define ITCDeviceClose(x)
#endif
//
#endif
//
//  END OF FILE:  ITCADCMgmt.h
//  COPYRIGHT (c) 2000 INTERMEC TECHNOLOGIES CORPORATION, ALL RIGHTS RESERVED
//    

