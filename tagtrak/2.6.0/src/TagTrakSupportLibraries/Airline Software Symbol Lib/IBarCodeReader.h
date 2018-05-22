/* this ALWAYS GENERATED file contains the definitions for the interfaces */


/* File created by MIDL compiler version 3.02.88 */
/* at Fri Nov 08 13:57:43 2002
 */
/* Compiler settings for .\common\IBarCodeReader.idl:
    Oicf (OptLev=i2), W1, Zp8, env=Win32, ms_ext, c_ext
    error checks: none
*/
//@@MIDL_FILE_HEADING(  )
#include "rpc.h"
#include "rpcndr.h"
#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __IBarCodeReader_h__
#define __IBarCodeReader_h__

#ifdef __cplusplus
extern "C"{
#endif 

/* Forward Declarations */ 

#ifndef __IBarCodeReaderControl_FWD_DEFINED__
#define __IBarCodeReaderControl_FWD_DEFINED__
typedef interface IBarCodeReaderControl IBarCodeReaderControl;
#endif 	/* __IBarCodeReaderControl_FWD_DEFINED__ */


#ifndef __IBarCodeReaderConfig_FWD_DEFINED__
#define __IBarCodeReaderConfig_FWD_DEFINED__
typedef interface IBarCodeReaderConfig IBarCodeReaderConfig;
#endif 	/* __IBarCodeReaderConfig_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"
#include "IADCDevice.h"
#include "IADC.h"

void __RPC_FAR * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void __RPC_FAR * ); 

/****************************************
 * Generated header for interface: __MIDL_itf_IBarCodeReader_0000
 * at Fri Nov 08 13:57:43 2002
 * using MIDL 3.02.88
 ****************************************/
/* [local] */ 



#pragma pack(push, IBarCodeReader_IDL)

#pragma pack(1)


extern RPC_IF_HANDLE __MIDL_itf_IBarCodeReader_0000_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_IBarCodeReader_0000_v0_0_s_ifspec;

#ifndef __IBarCodeReaderControl_INTERFACE_DEFINED__
#define __IBarCodeReaderControl_INTERFACE_DEFINED__

/****************************************
 * Generated header for interface: IBarCodeReaderControl
 * at Fri Nov 08 13:57:43 2002
 * using MIDL 3.02.88
 ****************************************/
/* [unique][helpstring][uuid][object] */ 


typedef 
enum tagBCReaderDataSourceTypeEnum
    {	ITC_DATASOURCE_USERINPUT	= 0x1,
	ITC_DATASOURCE_READER_COMMAND	= 0x2,
	ITC_DATASOURCE_EASYSET	= 0x3,
	ITC_DATASOURCE_ALL	= 0xffffffff
    }	ITC_BARCODEREADER_DATASOURCE_TYPE;

typedef struct  tagBarCodeReaderGrid
    {
    ITC_DI_GRID stDIGrid;
    ITC_DDBARCODE_GRID stDDGrid;
    DWORD dwDataSourceTypeMask;
    }	ITC_BARCODEREADER_GRID;

typedef 
enum tagITCBarCodeReaderAttributes
    {	ITC_RDRATTR_GRID	= ITC_DSATTR_LAST,
	ITC_RDRATTR_SCANNER_ENABLE	= ITC_RDRATTR_GRID + 1,
	ITC_RDRATTR_LASER_POWER_ON	= ITC_RDRATTR_SCANNER_ENABLE + 1,
	ITC_RDRATTR_GOOD_READ_LED_ENABLE	= ITC_RDRATTR_LASER_POWER_ON + 1,
	ITC_RDRATTR_DATA_VALID_LED_ENABLE	= ITC_RDRATTR_GOOD_READ_LED_ENABLE + 1,
	ITC_RDRATTR_TONE_ENABLE	= ITC_RDRATTR_DATA_VALID_LED_ENABLE + 1,
	ITC_RDRATTR_VOLUME_LEVEL	= ITC_RDRATTR_TONE_ENABLE + 1,
	ITC_RDRATTR_TONE_FREQUENCY	= ITC_RDRATTR_VOLUME_LEVEL + 1,
	ITC_RDRATTR_GOOD_READ_BEEPS_NUMBER	= ITC_RDRATTR_TONE_FREQUENCY + 1,
	ITC_RDRATTR_GOOD_READ_BEEP_DURATION	= ITC_RDRATTR_GOOD_READ_BEEPS_NUMBER + 1,
	ITC_RDRATTR_GOOD_READ_LED_DURATION	= ITC_RDRATTR_GOOD_READ_BEEP_DURATION + 1,
	ITC_RDRATTR_PDF417_CRACKLE	= ITC_RDRATTR_GOOD_READ_LED_DURATION + 1,
	ITC_RDRATTR_PDF417_LED_FLICKER	= ITC_RDRATTR_PDF417_CRACKLE + 1
    }	ITC_BARCODEREADER_ATTRIBUTE_ID;

typedef 
enum tagITCBeepType
    {	ITC_LOW_BEEP	= 1,
	ITC_HIGH_BEEP	= ITC_LOW_BEEP + 1,
	ITC_CUSTOM_BEEP	= ITC_HIGH_BEEP + 1
    }	ITC_BEEP_TYPE;

typedef struct  tagITCBeepSpec
    {
    ITC_BEEP_TYPE eBeepType;
    WORD wPitch;
    WORD wOnDuration;
    WORD wOffDuration;
    }	ITC_BEEP_SPEC;

typedef 
enum tagITCLaserLEDID
    {	ITC_BARCODE_LASER_DATA_VALID_LED	= 1,
	ITC_BARCODE_LASER_GOOD_READ_LED	= ITC_BARCODE_LASER_DATA_VALID_LED + 1
    }	ITC_BARCODE_LASER_LED_ID;

typedef struct  tagITCBarCodeDetails
    {
    WORD wStructSize;
    ITC_BARCODE_SYMBOLOGY_ID eSymbology;
    ITC_BARCODE_DATATYPE eDataType;
    DWORD dwDataSourceTypeMask;
    SYSTEMTIME stTimeStamp;
    }	ITC_BARCODE_DATA_DETAILS;

typedef 
enum tagBeepVolume
    {	ITC_BEEP_VOLUME_LOW	= 0,
	ITC_BEEP_VOLUME_MEDIUM	= 2,
	ITC_BEEP_VOLUME_HIGH	= 1
    }	ITC_BEEP_VOLUME;

typedef 
enum tagGoodReadBeepsNumber
    {	ITC_NUM_BEEPS_NONE	= 0,
	ITC_NUM_BEEPS_ONE	= 1,
	ITC_NUM_BEEPS_TWO	= 2
    }	ITC_GOOD_READ_BEEPS_NUMBER;

typedef 
enum tagPdf417Crackle
    {	ITC_PDF417_CRACKLE_OFF	= 0,
	ITC_PDF417_CRACKLE_ON	= 1
    }	ITC_PDF417_CRACKLE;

typedef 
enum tagPdf417LedFlicker
    {	ITC_PDF417_FLICKER_OFF	= 0,
	ITC_PDF417_FLICKER_ON	= 1
    }	ITC_PDF417_LED_FLICKER;


EXTERN_C const IID IID_IBarCodeReaderControl;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    interface DECLSPEC_UUID("BF32EFE1-E845-11d2-BEAE-0060970791B6")
    IBarCodeReaderControl : public IUnknown
    {
    public:
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Initialize( 
            /* [string][in] */ LPCTSTR pszDeviceName,
            /* [in] */ ITC_DEVICE_FLAGS eDeviceFlags) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Read( 
            /* [size_is][out][in] */ BYTE __RPC_FAR rgbDataBuffer[  ],
            /* [in] */ DWORD dwDataBufferSize,
            /* [out] */ DWORD __RPC_FAR *pnBytesReturned,
            /* [out][in] */ ITC_BARCODE_DATA_DETAILS __RPC_FAR *pBarCodeDataDetails,
            /* [in] */ DWORD dwTimeout) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE CancelReadRequest( 
            /* [in] */ BOOL FlushBufferedData,
            /* [out][in] */ WORD __RPC_FAR *pwTotalDiscardedMessages,
            /* [out][in] */ DWORD __RPC_FAR *pdwTotalDiscardedBytes) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE QueryAttribute( 
            /* [in] */ ITC_BARCODEREADER_ATTRIBUTE_ID eAttr,
            /* [size_is][out] */ BYTE __RPC_FAR rgbAttrBuffer[  ],
            /* [in] */ DWORD dwAttrBufferSize) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetAttribute( 
            /* [in] */ ITC_BARCODEREADER_ATTRIBUTE_ID eAttr,
            /* [size_is][out] */ BYTE __RPC_FAR rgbAttrBuffer[  ],
            /* [in] */ DWORD dwAttrBufferSize) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE TriggerScanner( 
            /* [in] */ BOOL fScannerOn) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE IssueBeep( 
            /* [size_is][in] */ ITC_BEEP_SPEC __RPC_FAR rgBeepRequests[  ],
            /* [in] */ DWORD dwNumberOfBeeps) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Reset( 
            /* [in] */ BOOL fWarmReset) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE ControlLED( 
            /* [in] */ ITC_BARCODE_LASER_LED_ID eLED,
            /* [in] */ BOOL fLedOn) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IBarCodeReaderControlVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IBarCodeReaderControl __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IBarCodeReaderControl __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IBarCodeReaderControl __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Initialize )( 
            IBarCodeReaderControl __RPC_FAR * This,
            /* [string][in] */ LPCTSTR pszDeviceName,
            /* [in] */ ITC_DEVICE_FLAGS eDeviceFlags);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Read )( 
            IBarCodeReaderControl __RPC_FAR * This,
            /* [size_is][out][in] */ BYTE __RPC_FAR rgbDataBuffer[  ],
            /* [in] */ DWORD dwDataBufferSize,
            /* [out] */ DWORD __RPC_FAR *pnBytesReturned,
            /* [out][in] */ ITC_BARCODE_DATA_DETAILS __RPC_FAR *pBarCodeDataDetails,
            /* [in] */ DWORD dwTimeout);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *CancelReadRequest )( 
            IBarCodeReaderControl __RPC_FAR * This,
            /* [in] */ BOOL FlushBufferedData,
            /* [out][in] */ WORD __RPC_FAR *pwTotalDiscardedMessages,
            /* [out][in] */ DWORD __RPC_FAR *pdwTotalDiscardedBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryAttribute )( 
            IBarCodeReaderControl __RPC_FAR * This,
            /* [in] */ ITC_BARCODEREADER_ATTRIBUTE_ID eAttr,
            /* [size_is][out] */ BYTE __RPC_FAR rgbAttrBuffer[  ],
            /* [in] */ DWORD dwAttrBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetAttribute )( 
            IBarCodeReaderControl __RPC_FAR * This,
            /* [in] */ ITC_BARCODEREADER_ATTRIBUTE_ID eAttr,
            /* [size_is][out] */ BYTE __RPC_FAR rgbAttrBuffer[  ],
            /* [in] */ DWORD dwAttrBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *TriggerScanner )( 
            IBarCodeReaderControl __RPC_FAR * This,
            /* [in] */ BOOL fScannerOn);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *IssueBeep )( 
            IBarCodeReaderControl __RPC_FAR * This,
            /* [size_is][in] */ ITC_BEEP_SPEC __RPC_FAR rgBeepRequests[  ],
            /* [in] */ DWORD dwNumberOfBeeps);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Reset )( 
            IBarCodeReaderControl __RPC_FAR * This,
            /* [in] */ BOOL fWarmReset);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ControlLED )( 
            IBarCodeReaderControl __RPC_FAR * This,
            /* [in] */ ITC_BARCODE_LASER_LED_ID eLED,
            /* [in] */ BOOL fLedOn);
        
        END_INTERFACE
    } IBarCodeReaderControlVtbl;

    interface IBarCodeReaderControl
    {
        CONST_VTBL struct IBarCodeReaderControlVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IBarCodeReaderControl_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IBarCodeReaderControl_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IBarCodeReaderControl_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IBarCodeReaderControl_Initialize(This,pszDeviceName,eDeviceFlags)	\
    (This)->lpVtbl -> Initialize(This,pszDeviceName,eDeviceFlags)

#define IBarCodeReaderControl_Read(This,rgbDataBuffer,dwDataBufferSize,pnBytesReturned,pBarCodeDataDetails,dwTimeout)	\
    (This)->lpVtbl -> Read(This,rgbDataBuffer,dwDataBufferSize,pnBytesReturned,pBarCodeDataDetails,dwTimeout)

#define IBarCodeReaderControl_CancelReadRequest(This,FlushBufferedData,pwTotalDiscardedMessages,pdwTotalDiscardedBytes)	\
    (This)->lpVtbl -> CancelReadRequest(This,FlushBufferedData,pwTotalDiscardedMessages,pdwTotalDiscardedBytes)

#define IBarCodeReaderControl_QueryAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)	\
    (This)->lpVtbl -> QueryAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)

#define IBarCodeReaderControl_SetAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)	\
    (This)->lpVtbl -> SetAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)

#define IBarCodeReaderControl_TriggerScanner(This,fScannerOn)	\
    (This)->lpVtbl -> TriggerScanner(This,fScannerOn)

#define IBarCodeReaderControl_IssueBeep(This,rgBeepRequests,dwNumberOfBeeps)	\
    (This)->lpVtbl -> IssueBeep(This,rgBeepRequests,dwNumberOfBeeps)

#define IBarCodeReaderControl_Reset(This,fWarmReset)	\
    (This)->lpVtbl -> Reset(This,fWarmReset)

#define IBarCodeReaderControl_ControlLED(This,eLED,fLedOn)	\
    (This)->lpVtbl -> ControlLED(This,eLED,fLedOn)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring] */ HRESULT STDMETHODCALLTYPE IBarCodeReaderControl_Initialize_Proxy( 
    IBarCodeReaderControl __RPC_FAR * This,
    /* [string][in] */ LPCTSTR pszDeviceName,
    /* [in] */ ITC_DEVICE_FLAGS eDeviceFlags);


void __RPC_STUB IBarCodeReaderControl_Initialize_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IBarCodeReaderControl_Read_Proxy( 
    IBarCodeReaderControl __RPC_FAR * This,
    /* [size_is][out][in] */ BYTE __RPC_FAR rgbDataBuffer[  ],
    /* [in] */ DWORD dwDataBufferSize,
    /* [out] */ DWORD __RPC_FAR *pnBytesReturned,
    /* [out][in] */ ITC_BARCODE_DATA_DETAILS __RPC_FAR *pBarCodeDataDetails,
    /* [in] */ DWORD dwTimeout);


void __RPC_STUB IBarCodeReaderControl_Read_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IBarCodeReaderControl_CancelReadRequest_Proxy( 
    IBarCodeReaderControl __RPC_FAR * This,
    /* [in] */ BOOL FlushBufferedData,
    /* [out][in] */ WORD __RPC_FAR *pwTotalDiscardedMessages,
    /* [out][in] */ DWORD __RPC_FAR *pdwTotalDiscardedBytes);


void __RPC_STUB IBarCodeReaderControl_CancelReadRequest_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IBarCodeReaderControl_QueryAttribute_Proxy( 
    IBarCodeReaderControl __RPC_FAR * This,
    /* [in] */ ITC_BARCODEREADER_ATTRIBUTE_ID eAttr,
    /* [size_is][out] */ BYTE __RPC_FAR rgbAttrBuffer[  ],
    /* [in] */ DWORD dwAttrBufferSize);


void __RPC_STUB IBarCodeReaderControl_QueryAttribute_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IBarCodeReaderControl_SetAttribute_Proxy( 
    IBarCodeReaderControl __RPC_FAR * This,
    /* [in] */ ITC_BARCODEREADER_ATTRIBUTE_ID eAttr,
    /* [size_is][out] */ BYTE __RPC_FAR rgbAttrBuffer[  ],
    /* [in] */ DWORD dwAttrBufferSize);


void __RPC_STUB IBarCodeReaderControl_SetAttribute_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IBarCodeReaderControl_TriggerScanner_Proxy( 
    IBarCodeReaderControl __RPC_FAR * This,
    /* [in] */ BOOL fScannerOn);


void __RPC_STUB IBarCodeReaderControl_TriggerScanner_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IBarCodeReaderControl_IssueBeep_Proxy( 
    IBarCodeReaderControl __RPC_FAR * This,
    /* [size_is][in] */ ITC_BEEP_SPEC __RPC_FAR rgBeepRequests[  ],
    /* [in] */ DWORD dwNumberOfBeeps);


void __RPC_STUB IBarCodeReaderControl_IssueBeep_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IBarCodeReaderControl_Reset_Proxy( 
    IBarCodeReaderControl __RPC_FAR * This,
    /* [in] */ BOOL fWarmReset);


void __RPC_STUB IBarCodeReaderControl_Reset_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IBarCodeReaderControl_ControlLED_Proxy( 
    IBarCodeReaderControl __RPC_FAR * This,
    /* [in] */ ITC_BARCODE_LASER_LED_ID eLED,
    /* [in] */ BOOL fLedOn);


void __RPC_STUB IBarCodeReaderControl_ControlLED_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IBarCodeReaderControl_INTERFACE_DEFINED__ */


#ifndef __IBarCodeReaderConfig_INTERFACE_DEFINED__
#define __IBarCodeReaderConfig_INTERFACE_DEFINED__

/****************************************
 * Generated header for interface: IBarCodeReaderConfig
 * at Fri Nov 08 13:57:43 2002
 * using MIDL 3.02.88
 ****************************************/
/* [unique][helpstring][uuid][object] */ 


#define ITC_IBC_MAX_CONFIG_CHARS 256
#define ITC_MAX_POSSIBLE_DECODES 30
typedef struct  tagBarCodeSymbologyStat
    {
    unsigned short usNumberDecoded;
    unsigned short usPriorityOrder;
    }	ITC_BARCODE_SYMBOLOGY_STAT;

typedef struct  tagITCBarCodeReaderStats
    {
    DWORD dwTriggerCount;
    DWORD dwScanCount;
    DWORD dwLabelsTransmitted;
    USHORT usSymbologyDataLength;
    ITC_BARCODE_SYMBOLOGY_STAT rgHistoryTable[ 30 ];
    }	ITC_BARCODEREADER_STATISTICS;

typedef struct  tagBarCodeSystemInfo
    {
    DWORD dwRamSize;
    USHORT usFlashSize;
    USHORT fFlashPresent;
    CHAR rgcVersion[ 12 ];
    }	ITC_BARC0DEREADER_SYSTEM_INFO;


EXTERN_C const IID IID_IBarCodeReaderConfig;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    interface DECLSPEC_UUID("51720B02-7014-11d2-BDF4-0060970791B6")
    IBarCodeReaderConfig : public IBarCodeReaderControl
    {
    public:
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetConfig( 
            /* [in] */ LPCTSTR pszConfig) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetConfig( 
            /* [size_is][out][in] */ TCHAR __RPC_FAR rgszConfig[  ],
            /* [in] */ DWORD ncConfigBufferSize) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetStatistics( 
            /* [out][in] */ ITC_BARCODEREADER_STATISTICS __RPC_FAR *pStatsBuffer,
            /* [in] */ DWORD dwStatsBufferSize) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE ResetStatistics( void) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetAnalysis( void) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE ReadAnalysis( 
            /* [size_is][out] */ BYTE __RPC_FAR rgbAnalysisBuffer[  ],
            /* [in] */ DWORD dwAnalysisBufferSize) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE DownloadBarCodeReader( 
            /* [in] */ LPCTSTR pszReaderProgramFile) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetSystemInfo( 
            /* [out][in] */ ITC_BARC0DEREADER_SYSTEM_INFO __RPC_FAR *pSysInfoBuffer,
            /* [in] */ DWORD dwSysInfoBufferSize) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IBarCodeReaderConfigVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IBarCodeReaderConfig __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IBarCodeReaderConfig __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IBarCodeReaderConfig __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Initialize )( 
            IBarCodeReaderConfig __RPC_FAR * This,
            /* [string][in] */ LPCTSTR pszDeviceName,
            /* [in] */ ITC_DEVICE_FLAGS eDeviceFlags);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Read )( 
            IBarCodeReaderConfig __RPC_FAR * This,
            /* [size_is][out][in] */ BYTE __RPC_FAR rgbDataBuffer[  ],
            /* [in] */ DWORD dwDataBufferSize,
            /* [out] */ DWORD __RPC_FAR *pnBytesReturned,
            /* [out][in] */ ITC_BARCODE_DATA_DETAILS __RPC_FAR *pBarCodeDataDetails,
            /* [in] */ DWORD dwTimeout);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *CancelReadRequest )( 
            IBarCodeReaderConfig __RPC_FAR * This,
            /* [in] */ BOOL FlushBufferedData,
            /* [out][in] */ WORD __RPC_FAR *pwTotalDiscardedMessages,
            /* [out][in] */ DWORD __RPC_FAR *pdwTotalDiscardedBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryAttribute )( 
            IBarCodeReaderConfig __RPC_FAR * This,
            /* [in] */ ITC_BARCODEREADER_ATTRIBUTE_ID eAttr,
            /* [size_is][out] */ BYTE __RPC_FAR rgbAttrBuffer[  ],
            /* [in] */ DWORD dwAttrBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetAttribute )( 
            IBarCodeReaderConfig __RPC_FAR * This,
            /* [in] */ ITC_BARCODEREADER_ATTRIBUTE_ID eAttr,
            /* [size_is][out] */ BYTE __RPC_FAR rgbAttrBuffer[  ],
            /* [in] */ DWORD dwAttrBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *TriggerScanner )( 
            IBarCodeReaderConfig __RPC_FAR * This,
            /* [in] */ BOOL fScannerOn);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *IssueBeep )( 
            IBarCodeReaderConfig __RPC_FAR * This,
            /* [size_is][in] */ ITC_BEEP_SPEC __RPC_FAR rgBeepRequests[  ],
            /* [in] */ DWORD dwNumberOfBeeps);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Reset )( 
            IBarCodeReaderConfig __RPC_FAR * This,
            /* [in] */ BOOL fWarmReset);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ControlLED )( 
            IBarCodeReaderConfig __RPC_FAR * This,
            /* [in] */ ITC_BARCODE_LASER_LED_ID eLED,
            /* [in] */ BOOL fLedOn);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetConfig )( 
            IBarCodeReaderConfig __RPC_FAR * This,
            /* [in] */ LPCTSTR pszConfig);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetConfig )( 
            IBarCodeReaderConfig __RPC_FAR * This,
            /* [size_is][out][in] */ TCHAR __RPC_FAR rgszConfig[  ],
            /* [in] */ DWORD ncConfigBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetStatistics )( 
            IBarCodeReaderConfig __RPC_FAR * This,
            /* [out][in] */ ITC_BARCODEREADER_STATISTICS __RPC_FAR *pStatsBuffer,
            /* [in] */ DWORD dwStatsBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ResetStatistics )( 
            IBarCodeReaderConfig __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetAnalysis )( 
            IBarCodeReaderConfig __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ReadAnalysis )( 
            IBarCodeReaderConfig __RPC_FAR * This,
            /* [size_is][out] */ BYTE __RPC_FAR rgbAnalysisBuffer[  ],
            /* [in] */ DWORD dwAnalysisBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *DownloadBarCodeReader )( 
            IBarCodeReaderConfig __RPC_FAR * This,
            /* [in] */ LPCTSTR pszReaderProgramFile);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetSystemInfo )( 
            IBarCodeReaderConfig __RPC_FAR * This,
            /* [out][in] */ ITC_BARC0DEREADER_SYSTEM_INFO __RPC_FAR *pSysInfoBuffer,
            /* [in] */ DWORD dwSysInfoBufferSize);
        
        END_INTERFACE
    } IBarCodeReaderConfigVtbl;

    interface IBarCodeReaderConfig
    {
        CONST_VTBL struct IBarCodeReaderConfigVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IBarCodeReaderConfig_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IBarCodeReaderConfig_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IBarCodeReaderConfig_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IBarCodeReaderConfig_Initialize(This,pszDeviceName,eDeviceFlags)	\
    (This)->lpVtbl -> Initialize(This,pszDeviceName,eDeviceFlags)

#define IBarCodeReaderConfig_Read(This,rgbDataBuffer,dwDataBufferSize,pnBytesReturned,pBarCodeDataDetails,dwTimeout)	\
    (This)->lpVtbl -> Read(This,rgbDataBuffer,dwDataBufferSize,pnBytesReturned,pBarCodeDataDetails,dwTimeout)

#define IBarCodeReaderConfig_CancelReadRequest(This,FlushBufferedData,pwTotalDiscardedMessages,pdwTotalDiscardedBytes)	\
    (This)->lpVtbl -> CancelReadRequest(This,FlushBufferedData,pwTotalDiscardedMessages,pdwTotalDiscardedBytes)

#define IBarCodeReaderConfig_QueryAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)	\
    (This)->lpVtbl -> QueryAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)

#define IBarCodeReaderConfig_SetAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)	\
    (This)->lpVtbl -> SetAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)

#define IBarCodeReaderConfig_TriggerScanner(This,fScannerOn)	\
    (This)->lpVtbl -> TriggerScanner(This,fScannerOn)

#define IBarCodeReaderConfig_IssueBeep(This,rgBeepRequests,dwNumberOfBeeps)	\
    (This)->lpVtbl -> IssueBeep(This,rgBeepRequests,dwNumberOfBeeps)

#define IBarCodeReaderConfig_Reset(This,fWarmReset)	\
    (This)->lpVtbl -> Reset(This,fWarmReset)

#define IBarCodeReaderConfig_ControlLED(This,eLED,fLedOn)	\
    (This)->lpVtbl -> ControlLED(This,eLED,fLedOn)


#define IBarCodeReaderConfig_SetConfig(This,pszConfig)	\
    (This)->lpVtbl -> SetConfig(This,pszConfig)

#define IBarCodeReaderConfig_GetConfig(This,rgszConfig,ncConfigBufferSize)	\
    (This)->lpVtbl -> GetConfig(This,rgszConfig,ncConfigBufferSize)

#define IBarCodeReaderConfig_GetStatistics(This,pStatsBuffer,dwStatsBufferSize)	\
    (This)->lpVtbl -> GetStatistics(This,pStatsBuffer,dwStatsBufferSize)

#define IBarCodeReaderConfig_ResetStatistics(This)	\
    (This)->lpVtbl -> ResetStatistics(This)

#define IBarCodeReaderConfig_SetAnalysis(This)	\
    (This)->lpVtbl -> SetAnalysis(This)

#define IBarCodeReaderConfig_ReadAnalysis(This,rgbAnalysisBuffer,dwAnalysisBufferSize)	\
    (This)->lpVtbl -> ReadAnalysis(This,rgbAnalysisBuffer,dwAnalysisBufferSize)

#define IBarCodeReaderConfig_DownloadBarCodeReader(This,pszReaderProgramFile)	\
    (This)->lpVtbl -> DownloadBarCodeReader(This,pszReaderProgramFile)

#define IBarCodeReaderConfig_GetSystemInfo(This,pSysInfoBuffer,dwSysInfoBufferSize)	\
    (This)->lpVtbl -> GetSystemInfo(This,pSysInfoBuffer,dwSysInfoBufferSize)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring] */ HRESULT STDMETHODCALLTYPE IBarCodeReaderConfig_SetConfig_Proxy( 
    IBarCodeReaderConfig __RPC_FAR * This,
    /* [in] */ LPCTSTR pszConfig);


void __RPC_STUB IBarCodeReaderConfig_SetConfig_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IBarCodeReaderConfig_GetConfig_Proxy( 
    IBarCodeReaderConfig __RPC_FAR * This,
    /* [size_is][out][in] */ TCHAR __RPC_FAR rgszConfig[  ],
    /* [in] */ DWORD ncConfigBufferSize);


void __RPC_STUB IBarCodeReaderConfig_GetConfig_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IBarCodeReaderConfig_GetStatistics_Proxy( 
    IBarCodeReaderConfig __RPC_FAR * This,
    /* [out][in] */ ITC_BARCODEREADER_STATISTICS __RPC_FAR *pStatsBuffer,
    /* [in] */ DWORD dwStatsBufferSize);


void __RPC_STUB IBarCodeReaderConfig_GetStatistics_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IBarCodeReaderConfig_ResetStatistics_Proxy( 
    IBarCodeReaderConfig __RPC_FAR * This);


void __RPC_STUB IBarCodeReaderConfig_ResetStatistics_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IBarCodeReaderConfig_SetAnalysis_Proxy( 
    IBarCodeReaderConfig __RPC_FAR * This);


void __RPC_STUB IBarCodeReaderConfig_SetAnalysis_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IBarCodeReaderConfig_ReadAnalysis_Proxy( 
    IBarCodeReaderConfig __RPC_FAR * This,
    /* [size_is][out] */ BYTE __RPC_FAR rgbAnalysisBuffer[  ],
    /* [in] */ DWORD dwAnalysisBufferSize);


void __RPC_STUB IBarCodeReaderConfig_ReadAnalysis_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IBarCodeReaderConfig_DownloadBarCodeReader_Proxy( 
    IBarCodeReaderConfig __RPC_FAR * This,
    /* [in] */ LPCTSTR pszReaderProgramFile);


void __RPC_STUB IBarCodeReaderConfig_DownloadBarCodeReader_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IBarCodeReaderConfig_GetSystemInfo_Proxy( 
    IBarCodeReaderConfig __RPC_FAR * This,
    /* [out][in] */ ITC_BARC0DEREADER_SYSTEM_INFO __RPC_FAR *pSysInfoBuffer,
    /* [in] */ DWORD dwSysInfoBufferSize);


void __RPC_STUB IBarCodeReaderConfig_GetSystemInfo_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IBarCodeReaderConfig_INTERFACE_DEFINED__ */


/****************************************
 * Generated header for interface: __MIDL_itf_IBarCodeReader_0159
 * at Fri Nov 08 13:57:43 2002
 * using MIDL 3.02.88
 ****************************************/
/* [local] */ 



#pragma pack(pop, IBarCodeReader_IDL)


extern RPC_IF_HANDLE __MIDL_itf_IBarCodeReader_0159_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_IBarCodeReader_0159_v0_0_s_ifspec;

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif
