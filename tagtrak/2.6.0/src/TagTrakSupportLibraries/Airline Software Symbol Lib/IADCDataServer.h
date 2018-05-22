/* this ALWAYS GENERATED file contains the definitions for the interfaces */


/* File created by MIDL compiler version 3.02.88 */
/* at Fri Nov 08 13:57:31 2002
 */
/* Compiler settings for .\common\IADCDataServer.idl:
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

#ifndef __IADCDataServer_h__
#define __IADCDataServer_h__

#ifdef __cplusplus
extern "C"{
#endif 

/* Forward Declarations */ 

#ifndef __IADCDataServer_FWD_DEFINED__
#define __IADCDataServer_FWD_DEFINED__
typedef interface IADCDataServer IADCDataServer;
#endif 	/* __IADCDataServer_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"
#include "IADCDevice.h"

void __RPC_FAR * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void __RPC_FAR * ); 

#ifndef __IADCDataServer_INTERFACE_DEFINED__
#define __IADCDataServer_INTERFACE_DEFINED__

/****************************************
 * Generated header for interface: IADCDataServer
 * at Fri Nov 08 13:57:31 2002
 * using MIDL 3.02.88
 ****************************************/
/* [unique][helpstring][uuid][object] */ 


typedef 
enum tagDataServerAttributes
    {	ITC_DSATTR_DEVICE_ENABLE	= ITC_DHATTR_DEVICE_ENABLE,
	ITC_DSATTR_DI_GRID	= ITC_DHATTR_LAST,
	ITC_DSATTR_DD_GRID	= ITC_DSATTR_DI_GRID + 1,
	ITC_DSATTR_DATACLASS	= ITC_DSATTR_DD_GRID + 1,
	ITC_DSATTR_MULTICLIENT_ENABLE	= ITC_DSATTR_DATACLASS + 1,
	ITC_DSATTR_CLIENT_DEVICE_HANDLE	= ITC_DSATTR_MULTICLIENT_ENABLE + 1,
	ITC_DSATTR_LAST	= 128
    }	ITC_DATASERVER_ATTRIBUTE_ID;

typedef /* [public] */ 
enum __MIDL_IADCDataServer_0001
    {	POST_AUTOMATIC_READ	= 0,
	LAST_ACTION	= POST_AUTOMATIC_READ + 1
    }	ACTIONS;

typedef /* [public] */ struct  __MIDL_IADCDataServer_0002
    {
    ITC_DS_DATACLASS DC;
    USHORT rgActions[ 32 ];
    }	DATACLASS_ACTIONS;


EXTERN_C const IID IID_IADCDataServer;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    interface DECLSPEC_UUID("A3D165D1-E893-11d2-9F18-00C04F86C055")
    IADCDataServer : public IUnknown
    {
    public:
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Initialize( 
            /* [in] */ LPCTSTR lpDeviceName,
            /* [in] */ ITC_DEVICE_FLAGS dwFlags) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Read( 
            /* [out] */ ITC_DS_DATACLASS __RPC_FAR *DataClass,
            /* [size_is][in] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize,
            /* [out] */ DWORD __RPC_FAR *pdwBytesRead,
            /* [in] */ DWORD dwTimeout) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Write( 
            /* [size_is][in] */ BYTE __RPC_FAR rgbWriteBuffer[  ],
            /* [in] */ DWORD dwWriteBufferSize,
            /* [size_is][out] */ BYTE __RPC_FAR rgbRspBuffer[  ],
            /* [in] */ DWORD dwRspBufferSize,
            /* [out] */ DWORD __RPC_FAR *pdwBytesReturn,
            /* [in] */ DWORD dwTimeout) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE CancelReadRequest( 
            /* [in] */ BOOL FlushBufferedData,
            /* [out] */ WORD __RPC_FAR *wTotalDiscardedMessages,
            /* [out] */ DWORD __RPC_FAR *dwTotalDiscardedBytes) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetAttribute( 
            /* [in] */ ITC_DATASERVER_ATTRIBUTE_ID eAttribID,
            /* [size_is][in] */ BYTE __RPC_FAR rgbData[  ],
            /* [in] */ DWORD dwBufferSize) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE QueryAttribute( 
            /* [in] */ ITC_DATASERVER_ATTRIBUTE_ID eAttribID,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize,
            /* [out] */ DWORD __RPC_FAR *pdwBytesReturn) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE QueryData( 
            /* [in] */ ITC_DS_DATACLASS DataClass,
            /* [out] */ DWORD __RPC_FAR *dwTotalBufferedBytes,
            /* [out] */ WORD __RPC_FAR *wNumberOfMessages,
            /* [out] */ DWORD __RPC_FAR *dwNextMessageSize) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IADCDataServerVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IADCDataServer __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IADCDataServer __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IADCDataServer __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Initialize )( 
            IADCDataServer __RPC_FAR * This,
            /* [in] */ LPCTSTR lpDeviceName,
            /* [in] */ ITC_DEVICE_FLAGS dwFlags);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Read )( 
            IADCDataServer __RPC_FAR * This,
            /* [out] */ ITC_DS_DATACLASS __RPC_FAR *DataClass,
            /* [size_is][in] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize,
            /* [out] */ DWORD __RPC_FAR *pdwBytesRead,
            /* [in] */ DWORD dwTimeout);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Write )( 
            IADCDataServer __RPC_FAR * This,
            /* [size_is][in] */ BYTE __RPC_FAR rgbWriteBuffer[  ],
            /* [in] */ DWORD dwWriteBufferSize,
            /* [size_is][out] */ BYTE __RPC_FAR rgbRspBuffer[  ],
            /* [in] */ DWORD dwRspBufferSize,
            /* [out] */ DWORD __RPC_FAR *pdwBytesReturn,
            /* [in] */ DWORD dwTimeout);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *CancelReadRequest )( 
            IADCDataServer __RPC_FAR * This,
            /* [in] */ BOOL FlushBufferedData,
            /* [out] */ WORD __RPC_FAR *wTotalDiscardedMessages,
            /* [out] */ DWORD __RPC_FAR *dwTotalDiscardedBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetAttribute )( 
            IADCDataServer __RPC_FAR * This,
            /* [in] */ ITC_DATASERVER_ATTRIBUTE_ID eAttribID,
            /* [size_is][in] */ BYTE __RPC_FAR rgbData[  ],
            /* [in] */ DWORD dwBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryAttribute )( 
            IADCDataServer __RPC_FAR * This,
            /* [in] */ ITC_DATASERVER_ATTRIBUTE_ID eAttribID,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize,
            /* [out] */ DWORD __RPC_FAR *pdwBytesReturn);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryData )( 
            IADCDataServer __RPC_FAR * This,
            /* [in] */ ITC_DS_DATACLASS DataClass,
            /* [out] */ DWORD __RPC_FAR *dwTotalBufferedBytes,
            /* [out] */ WORD __RPC_FAR *wNumberOfMessages,
            /* [out] */ DWORD __RPC_FAR *dwNextMessageSize);
        
        END_INTERFACE
    } IADCDataServerVtbl;

    interface IADCDataServer
    {
        CONST_VTBL struct IADCDataServerVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IADCDataServer_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IADCDataServer_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IADCDataServer_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IADCDataServer_Initialize(This,lpDeviceName,dwFlags)	\
    (This)->lpVtbl -> Initialize(This,lpDeviceName,dwFlags)

#define IADCDataServer_Read(This,DataClass,rgbBuffer,dwBufferSize,pdwBytesRead,dwTimeout)	\
    (This)->lpVtbl -> Read(This,DataClass,rgbBuffer,dwBufferSize,pdwBytesRead,dwTimeout)

#define IADCDataServer_Write(This,rgbWriteBuffer,dwWriteBufferSize,rgbRspBuffer,dwRspBufferSize,pdwBytesReturn,dwTimeout)	\
    (This)->lpVtbl -> Write(This,rgbWriteBuffer,dwWriteBufferSize,rgbRspBuffer,dwRspBufferSize,pdwBytesReturn,dwTimeout)

#define IADCDataServer_CancelReadRequest(This,FlushBufferedData,wTotalDiscardedMessages,dwTotalDiscardedBytes)	\
    (This)->lpVtbl -> CancelReadRequest(This,FlushBufferedData,wTotalDiscardedMessages,dwTotalDiscardedBytes)

#define IADCDataServer_SetAttribute(This,eAttribID,rgbData,dwBufferSize)	\
    (This)->lpVtbl -> SetAttribute(This,eAttribID,rgbData,dwBufferSize)

#define IADCDataServer_QueryAttribute(This,eAttribID,rgbBuffer,dwBufferSize,pdwBytesReturn)	\
    (This)->lpVtbl -> QueryAttribute(This,eAttribID,rgbBuffer,dwBufferSize,pdwBytesReturn)

#define IADCDataServer_QueryData(This,DataClass,dwTotalBufferedBytes,wNumberOfMessages,dwNextMessageSize)	\
    (This)->lpVtbl -> QueryData(This,DataClass,dwTotalBufferedBytes,wNumberOfMessages,dwNextMessageSize)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADCDataServer_Initialize_Proxy( 
    IADCDataServer __RPC_FAR * This,
    /* [in] */ LPCTSTR lpDeviceName,
    /* [in] */ ITC_DEVICE_FLAGS dwFlags);


void __RPC_STUB IADCDataServer_Initialize_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADCDataServer_Read_Proxy( 
    IADCDataServer __RPC_FAR * This,
    /* [out] */ ITC_DS_DATACLASS __RPC_FAR *DataClass,
    /* [size_is][in] */ BYTE __RPC_FAR rgbBuffer[  ],
    /* [in] */ DWORD dwBufferSize,
    /* [out] */ DWORD __RPC_FAR *pdwBytesRead,
    /* [in] */ DWORD dwTimeout);


void __RPC_STUB IADCDataServer_Read_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADCDataServer_Write_Proxy( 
    IADCDataServer __RPC_FAR * This,
    /* [size_is][in] */ BYTE __RPC_FAR rgbWriteBuffer[  ],
    /* [in] */ DWORD dwWriteBufferSize,
    /* [size_is][out] */ BYTE __RPC_FAR rgbRspBuffer[  ],
    /* [in] */ DWORD dwRspBufferSize,
    /* [out] */ DWORD __RPC_FAR *pdwBytesReturn,
    /* [in] */ DWORD dwTimeout);


void __RPC_STUB IADCDataServer_Write_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADCDataServer_CancelReadRequest_Proxy( 
    IADCDataServer __RPC_FAR * This,
    /* [in] */ BOOL FlushBufferedData,
    /* [out] */ WORD __RPC_FAR *wTotalDiscardedMessages,
    /* [out] */ DWORD __RPC_FAR *dwTotalDiscardedBytes);


void __RPC_STUB IADCDataServer_CancelReadRequest_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADCDataServer_SetAttribute_Proxy( 
    IADCDataServer __RPC_FAR * This,
    /* [in] */ ITC_DATASERVER_ATTRIBUTE_ID eAttribID,
    /* [size_is][in] */ BYTE __RPC_FAR rgbData[  ],
    /* [in] */ DWORD dwBufferSize);


void __RPC_STUB IADCDataServer_SetAttribute_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADCDataServer_QueryAttribute_Proxy( 
    IADCDataServer __RPC_FAR * This,
    /* [in] */ ITC_DATASERVER_ATTRIBUTE_ID eAttribID,
    /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
    /* [in] */ DWORD dwBufferSize,
    /* [out] */ DWORD __RPC_FAR *pdwBytesReturn);


void __RPC_STUB IADCDataServer_QueryAttribute_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADCDataServer_QueryData_Proxy( 
    IADCDataServer __RPC_FAR * This,
    /* [in] */ ITC_DS_DATACLASS DataClass,
    /* [out] */ DWORD __RPC_FAR *dwTotalBufferedBytes,
    /* [out] */ WORD __RPC_FAR *wNumberOfMessages,
    /* [out] */ DWORD __RPC_FAR *dwNextMessageSize);


void __RPC_STUB IADCDataServer_QueryData_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IADCDataServer_INTERFACE_DEFINED__ */


/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif
