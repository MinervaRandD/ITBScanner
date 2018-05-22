/* this ALWAYS GENERATED file contains the definitions for the interfaces */


/* File created by MIDL compiler version 3.02.88 */
/* at Fri Nov 08 13:57:26 2002
 */
/* Compiler settings for .\common\IADC.idl:
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

#ifndef __IADC_h__
#define __IADC_h__

#ifdef __cplusplus
extern "C"{
#endif 

/* Forward Declarations */ 

#ifndef __IADC_FWD_DEFINED__
#define __IADC_FWD_DEFINED__
typedef interface IADC IADC;
#endif 	/* __IADC_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"
#include "IADCDevice.h"
#include "IADCDataServer.h"

void __RPC_FAR * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void __RPC_FAR * ); 

#ifndef __IADC_INTERFACE_DEFINED__
#define __IADC_INTERFACE_DEFINED__

/****************************************
 * Generated header for interface: IADC
 * at Fri Nov 08 13:57:26 2002
 * using MIDL 3.02.88
 ****************************************/
/* [unique][helpstring][uuid][object] */ 


typedef 
enum tagITCAttrib
    {	ITC_ATTR_DEVICE_ENABLE	= ITC_DHATTR_DEVICE_ENABLE,
	ITC_ATTR_READFILTER	= ITC_DHATTR_READFILTER,
	ITC_ATTR_DI_GRID	= ITC_DSATTR_DI_GRID,
	ITC_MULTICLIENT_ENABLE	= ITC_DSATTR_MULTICLIENT_ENABLE
    }	ITC_ADC_ATTRIBUTE_ID;


EXTERN_C const IID IID_IADC;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    interface DECLSPEC_UUID("BF32EFE2-E845-11d2-BEAE-0060970791B6")
    IADC : public IUnknown
    {
    public:
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Initialize( 
            /* [string][in] */ LPCTSTR pszDeviceName,
            /* [in] */ ITC_DEVICE_FLAGS eDeviceFlags) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Read( 
            /* [size_is][out][in] */ BYTE __RPC_FAR rgbDataBuffer[  ],
            /* [in] */ DWORD dwDataBufferSize,
            /* [out][in] */ DWORD __RPC_FAR *pnBytesReturned,
            /* [out][in] */ SYSTEMTIME __RPC_FAR *pSystemTime,
            /* [in] */ DWORD dwTimeout) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE CancelReadRequest( 
            /* [in] */ BOOL FlushBufferedData,
            /* [out][in] */ WORD __RPC_FAR *pwTotalDiscardedMessages,
            /* [out][in] */ DWORD __RPC_FAR *pdwTotalDiscardedBytes) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetAttribute( 
            /* [in] */ ITC_ADC_ATTRIBUTE_ID eAttribID,
            /* [size_is][in] */ BYTE __RPC_FAR rgbData[  ],
            /* [in] */ DWORD nBufferSize) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE QueryAttribute( 
            /* [in] */ ITC_ADC_ATTRIBUTE_ID eAttribID,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize,
            /* [out] */ DWORD __RPC_FAR *pnBufferData) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Clone( 
            IADC __RPC_FAR *__RPC_FAR *ppvObj) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE QueryData( 
            /* [out] */ DWORD __RPC_FAR *dwTotalBufferedBytes,
            /* [out] */ WORD __RPC_FAR *wNumberOfMessages,
            /* [out] */ DWORD __RPC_FAR *dwNextMessageSize) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IADCVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IADC __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IADC __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IADC __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Initialize )( 
            IADC __RPC_FAR * This,
            /* [string][in] */ LPCTSTR pszDeviceName,
            /* [in] */ ITC_DEVICE_FLAGS eDeviceFlags);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Read )( 
            IADC __RPC_FAR * This,
            /* [size_is][out][in] */ BYTE __RPC_FAR rgbDataBuffer[  ],
            /* [in] */ DWORD dwDataBufferSize,
            /* [out][in] */ DWORD __RPC_FAR *pnBytesReturned,
            /* [out][in] */ SYSTEMTIME __RPC_FAR *pSystemTime,
            /* [in] */ DWORD dwTimeout);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *CancelReadRequest )( 
            IADC __RPC_FAR * This,
            /* [in] */ BOOL FlushBufferedData,
            /* [out][in] */ WORD __RPC_FAR *pwTotalDiscardedMessages,
            /* [out][in] */ DWORD __RPC_FAR *pdwTotalDiscardedBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetAttribute )( 
            IADC __RPC_FAR * This,
            /* [in] */ ITC_ADC_ATTRIBUTE_ID eAttribID,
            /* [size_is][in] */ BYTE __RPC_FAR rgbData[  ],
            /* [in] */ DWORD nBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryAttribute )( 
            IADC __RPC_FAR * This,
            /* [in] */ ITC_ADC_ATTRIBUTE_ID eAttribID,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize,
            /* [out] */ DWORD __RPC_FAR *pnBufferData);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Clone )( 
            IADC __RPC_FAR * This,
            IADC __RPC_FAR *__RPC_FAR *ppvObj);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryData )( 
            IADC __RPC_FAR * This,
            /* [out] */ DWORD __RPC_FAR *dwTotalBufferedBytes,
            /* [out] */ WORD __RPC_FAR *wNumberOfMessages,
            /* [out] */ DWORD __RPC_FAR *dwNextMessageSize);
        
        END_INTERFACE
    } IADCVtbl;

    interface IADC
    {
        CONST_VTBL struct IADCVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IADC_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IADC_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IADC_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IADC_Initialize(This,pszDeviceName,eDeviceFlags)	\
    (This)->lpVtbl -> Initialize(This,pszDeviceName,eDeviceFlags)

#define IADC_Read(This,rgbDataBuffer,dwDataBufferSize,pnBytesReturned,pSystemTime,dwTimeout)	\
    (This)->lpVtbl -> Read(This,rgbDataBuffer,dwDataBufferSize,pnBytesReturned,pSystemTime,dwTimeout)

#define IADC_CancelReadRequest(This,FlushBufferedData,pwTotalDiscardedMessages,pdwTotalDiscardedBytes)	\
    (This)->lpVtbl -> CancelReadRequest(This,FlushBufferedData,pwTotalDiscardedMessages,pdwTotalDiscardedBytes)

#define IADC_SetAttribute(This,eAttribID,rgbData,nBufferSize)	\
    (This)->lpVtbl -> SetAttribute(This,eAttribID,rgbData,nBufferSize)

#define IADC_QueryAttribute(This,eAttribID,rgbBuffer,dwBufferSize,pnBufferData)	\
    (This)->lpVtbl -> QueryAttribute(This,eAttribID,rgbBuffer,dwBufferSize,pnBufferData)

#define IADC_Clone(This,ppvObj)	\
    (This)->lpVtbl -> Clone(This,ppvObj)

#define IADC_QueryData(This,dwTotalBufferedBytes,wNumberOfMessages,dwNextMessageSize)	\
    (This)->lpVtbl -> QueryData(This,dwTotalBufferedBytes,wNumberOfMessages,dwNextMessageSize)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADC_Initialize_Proxy( 
    IADC __RPC_FAR * This,
    /* [string][in] */ LPCTSTR pszDeviceName,
    /* [in] */ ITC_DEVICE_FLAGS eDeviceFlags);


void __RPC_STUB IADC_Initialize_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADC_Read_Proxy( 
    IADC __RPC_FAR * This,
    /* [size_is][out][in] */ BYTE __RPC_FAR rgbDataBuffer[  ],
    /* [in] */ DWORD dwDataBufferSize,
    /* [out][in] */ DWORD __RPC_FAR *pnBytesReturned,
    /* [out][in] */ SYSTEMTIME __RPC_FAR *pSystemTime,
    /* [in] */ DWORD dwTimeout);


void __RPC_STUB IADC_Read_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADC_CancelReadRequest_Proxy( 
    IADC __RPC_FAR * This,
    /* [in] */ BOOL FlushBufferedData,
    /* [out][in] */ WORD __RPC_FAR *pwTotalDiscardedMessages,
    /* [out][in] */ DWORD __RPC_FAR *pdwTotalDiscardedBytes);


void __RPC_STUB IADC_CancelReadRequest_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADC_SetAttribute_Proxy( 
    IADC __RPC_FAR * This,
    /* [in] */ ITC_ADC_ATTRIBUTE_ID eAttribID,
    /* [size_is][in] */ BYTE __RPC_FAR rgbData[  ],
    /* [in] */ DWORD nBufferSize);


void __RPC_STUB IADC_SetAttribute_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADC_QueryAttribute_Proxy( 
    IADC __RPC_FAR * This,
    /* [in] */ ITC_ADC_ATTRIBUTE_ID eAttribID,
    /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
    /* [in] */ DWORD dwBufferSize,
    /* [out] */ DWORD __RPC_FAR *pnBufferData);


void __RPC_STUB IADC_QueryAttribute_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADC_Clone_Proxy( 
    IADC __RPC_FAR * This,
    IADC __RPC_FAR *__RPC_FAR *ppvObj);


void __RPC_STUB IADC_Clone_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADC_QueryData_Proxy( 
    IADC __RPC_FAR * This,
    /* [out] */ DWORD __RPC_FAR *dwTotalBufferedBytes,
    /* [out] */ WORD __RPC_FAR *wNumberOfMessages,
    /* [out] */ DWORD __RPC_FAR *dwNextMessageSize);


void __RPC_STUB IADC_QueryData_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IADC_INTERFACE_DEFINED__ */


/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif
