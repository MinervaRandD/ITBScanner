/* this ALWAYS GENERATED file contains the definitions for the interfaces */


/* File created by MIDL compiler version 3.02.88 */
/* at Fri Nov 08 13:57:35 2002
 */
/* Compiler settings for .\common\IADCDevice.idl:
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

#ifndef __IADCDevice_h__
#define __IADCDevice_h__

#ifdef __cplusplus
extern "C"{
#endif 

/* Forward Declarations */ 

#ifndef __IADCDevice_FWD_DEFINED__
#define __IADCDevice_FWD_DEFINED__
typedef interface IADCDevice IADCDevice;
#endif 	/* __IADCDevice_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

void __RPC_FAR * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void __RPC_FAR * ); 

/****************************************
 * Generated header for interface: __MIDL_itf_IADCDevice_0000
 * at Fri Nov 08 13:57:35 2002
 * using MIDL 3.02.88
 ****************************************/
/* [local] */ 



#pragma pack(push, IADCDevice_IDL)

#pragma pack(1)
#ifndef INCLUDED_BARCODESYMBOLOGYSYMBOLS_H
#define INCLUDED_BARCODESYMBOLOGYSYMBOLS_H
typedef 
enum tagBarCodeSymbologyId
    {	BARCODE_SYMBOLOGY_CODE39	= 1,
	BARCODE_SYMBOLOGY_CODE93	= BARCODE_SYMBOLOGY_CODE39 + 1,
	BARCODE_SYMBOLOGY_CODE49	= BARCODE_SYMBOLOGY_CODE93 + 1,
	BARCODE_SYMBOLOGY_I2OF5	= BARCODE_SYMBOLOGY_CODE49 + 1,
	BARCODE_SYMBOLOGY_CODABAR	= BARCODE_SYMBOLOGY_I2OF5 + 1,
	BARCODE_SYMBOLOGY_UPC	= BARCODE_SYMBOLOGY_CODABAR + 1,
	BARCODE_SYMBOLOGY_CODE128	= BARCODE_SYMBOLOGY_UPC + 1,
	BARCODE_SYMBOLOGY_CODE16K	= BARCODE_SYMBOLOGY_CODE128 + 1,
	BARCODE_SYMBOLOGY_PLESSEY	= BARCODE_SYMBOLOGY_CODE16K + 1,
	BARCODE_SYMBOLOGY_CODE11	= BARCODE_SYMBOLOGY_PLESSEY + 1,
	BARCODE_SYMBOLOGY_MSI	= BARCODE_SYMBOLOGY_CODE11 + 1,
	BARCODE_SYMBOLOGY_PDF417	= BARCODE_SYMBOLOGY_MSI + 1,
	BARCODE_SYMBOLOGY_D2OF5	= BARCODE_SYMBOLOGY_PDF417 + 1,
	BARCODE_SYMBOLOGY_TELEPEN	= BARCODE_SYMBOLOGY_D2OF5 + 1,
	BARCODE_SYMBOLOGY_MATRIX2OF5	= BARCODE_SYMBOLOGY_TELEPEN + 1,
	BARCODE_SYMBOLOGY_CODABLOCK	= BARCODE_SYMBOLOGY_MATRIX2OF5 + 1,
	BARCODE_SYMBOLOGY_ANKERCODE	= BARCODE_SYMBOLOGY_CODABLOCK + 1,
	BARCODE_SYMBOLOGY_MAXICODE	= BARCODE_SYMBOLOGY_ANKERCODE + 1,
	BARCODE_SYMBOLOGY_OTHERBC	= BARCODE_SYMBOLOGY_MAXICODE + 1,
	BARCODE_SYMBOLOGY_SYSTEM_EX	= BARCODE_SYMBOLOGY_OTHERBC + 1,
	BARCODE_SYMBOLOGY_NON_BARCODE	= BARCODE_SYMBOLOGY_SYSTEM_EX + 1,
	BARCODE_SYMBOLOGY_DUPLICATE	= BARCODE_SYMBOLOGY_NON_BARCODE + 1,
	BARCODE_SYMBOLOGY_UNKNOWN	= 32
    }	ITC_BARCODE_SYMBOLOGY_ID;

typedef 
enum tagBarCodeSymbologyMask
    {	BARCODE_SYMBOLOGY_CODE39_MASK	= 1 << BARCODE_SYMBOLOGY_CODE39 - 1,
	BARCODE_SYMBOLOGY_CODE93_MASK	= 1 << BARCODE_SYMBOLOGY_CODE93 - 1,
	BARCODE_SYMBOLOGY_CODE49_MASK	= 1 << BARCODE_SYMBOLOGY_CODE49 - 1,
	BARCODE_SYMBOLOGY_I2OF5_MASK	= 1 << BARCODE_SYMBOLOGY_I2OF5 - 1,
	BARCODE_SYMBOLOGY_CODABAR_MASK	= 1 << BARCODE_SYMBOLOGY_CODABAR - 1,
	BARCODE_SYMBOLOGY_UPC_MASK	= 1 << BARCODE_SYMBOLOGY_UPC - 1,
	BARCODE_SYMBOLOGY_CODE128_MASK	= 1 << BARCODE_SYMBOLOGY_CODE128 - 1,
	BARCODE_SYMBOLOGY_CODE16K_MASK	= 1 << BARCODE_SYMBOLOGY_CODE16K - 1,
	BARCODE_SYMBOLOGY_PLESSEY_MASK	= 1 << BARCODE_SYMBOLOGY_PLESSEY - 1,
	BARCODE_SYMBOLOGY_CODE11_MASK	= 1 << BARCODE_SYMBOLOGY_CODE11 - 1,
	BARCODE_SYMBOLOGY_MSI_MASK	= 1 << BARCODE_SYMBOLOGY_MSI - 1,
	BARCODE_SYMBOLOGY_PDF417_MASK	= 1 << BARCODE_SYMBOLOGY_PDF417 - 1,
	BARCODE_SYMBOLOGY_D2OF5_MASK	= 1 << BARCODE_SYMBOLOGY_D2OF5 - 1,
	BARCODE_SYMBOLOGY_TELEPEN_MASK	= 1 << BARCODE_SYMBOLOGY_TELEPEN - 1,
	BARCODE_SYMBOLOGY_MATRIX2OF5_MASK	= 1 << BARCODE_SYMBOLOGY_MATRIX2OF5 - 1,
	BARCODE_SYMBOLOGY_CODABLOCK_MASK	= 1 << BARCODE_SYMBOLOGY_CODABLOCK - 1,
	BARCODE_SYMBOLOGY_ANKERCODE_MASK	= 1 << BARCODE_SYMBOLOGY_ANKERCODE - 1,
	BARCODE_SYMBOLOGY_MAXICODE_MASK	= 1 << BARCODE_SYMBOLOGY_MAXICODE - 1,
	BARCODE_SYMBOLOGY_OTHERBC_MASK	= 1 << BARCODE_SYMBOLOGY_OTHERBC - 1,
	BARCODE_SYMBOLOGY_SYSTEM_EX_MASK	= 1 << BARCODE_SYMBOLOGY_SYSTEM_EX - 1,
	BARCODE_SYMBOLOGY_NON_BARCODE_MASK	= 1 << BARCODE_SYMBOLOGY_NON_BARCODE - 1,
	BARCODE_SYMBOLOGY_DUPLICATE_MASK	= 1 << BARCODE_SYMBOLOGY_DUPLICATE - 1,
	BARCODE_SYMBOLOGY_UNKNOWN_MASK	= 1 << BARCODE_SYMBOLOGY_UNKNOWN - 1,
	BARCODE_SYMBOLOGY_ALL_MASK	= 0xffffffff
    }	ITC_BARCODE_SYMBOLOGY_MASK;

typedef 
enum tagBarCodeDataType
    {	BARCODE_DATA_TYPE_UNKNOWN	= 0,
	BARCODE_DATA_TYPE_ASCII	= 1,
	BARCODE_DATA_TYPE_UNICODE	= 2,
	BARCODE_DATA_TYPE_DOUBLE_BYTE	= 3
    }	ITC_BARCODE_DATATYPE;

#endif
typedef struct  tagItcBarCodeGrid
    {
    DWORD dwSymbologyMask;
    }	ITC_DDBARCODE_GRID;



extern RPC_IF_HANDLE __MIDL_itf_IADCDevice_0000_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_IADCDevice_0000_v0_0_s_ifspec;

#ifndef __IADCDevice_INTERFACE_DEFINED__
#define __IADCDevice_INTERFACE_DEFINED__

/****************************************
 * Generated header for interface: IADCDevice
 * at Fri Nov 08 13:57:35 2002
 * using MIDL 3.02.88
 ****************************************/
/* [unique][helpstring][uuid][object] */ 


typedef 
enum tagDeviceFlags
    {	ITC_DHDEVFLAG_NONREADAHEAD	= 1,
	ITC_DHDEVFLAG_READAHEAD	= 2,
	ITC_DHDEVFLAG_NODATA	= 3
    }	ITC_DEVICE_FLAGS;

typedef 
enum tagDeviceAttributes
    {	ITC_DHATTR_DEVICE_ENABLE	= 1,
	ITC_DHATTR_READFILTER	= 2,
	ITC_DHATTR_LAST	= 64
    }	ITC_DEVICE_HANDLER_ATTRIBUTE_ID;

typedef /* [public] */ struct  __MIDL_IADCDevice_0001
    {
    WORD nDataBytes;
    BYTE rgbGrid[ 128 ];
    }	ITC_DD_GRID;

typedef /* [public] */ struct  __MIDL_IADCDevice_0002
    {
    WORD nDataMaskChars;
    TCHAR szDataMask[ 33 ];
    }	ITC_DI_GRID;

typedef WORD ITC_DEVICE_HANDLE;

typedef 
enum tagDS_DATACLASS
    {	ITC_DC_PROCESS_READER_CMD	= 0x2,
	ITC_DC_DI_LAST	= 0x4
    }	ITC_DS_DATACLASS;

typedef /* [public] */ struct  __MIDL_IADCDevice_0003
    {
    WORD nFilterChars;
    TCHAR szFilter[ 240 ];
    }	ITC_READFILTER;

typedef 
enum tagITC_UNSOLICITED_SEQUENCE_NUM
    {	ITC_UNSOLICITED_SEQUENCE_NUMBER	= 0
    }	ITC_IADCDEVICE_UNSOLICITED_SEQUENCE_NUM;

typedef 
enum tagITC_UNSOLICITED_CLIENT_HANDLE
    {	ITC_UNSOLICITED_CLIENT_HANDLE	= 0
    }	ITC_IADCDEVICE_UNSOLICITED_CLIENT_HANDLE;

typedef struct  tagITC_IADCDEVICE_DATA_DETAILS
    {
    WORD wStructSize;
    BYTE __RPC_FAR *pITCEndDeviceData;
    DWORD dwITCEndDeviceBytesReturned;
    DWORD dwITCDataFormat;
    }	ITC_ADCDEVICE_DATA_DETAILS;


enum tagSpecialDeviceHandles
    {	ITC_OPEN_HANDLE_ASSIGNED_BY_DEVICE	= 0xffff,
	ITC_NO_DEVICE_HANDLE	= 0xfffe
    };

EXTERN_C const IID IID_IADCDevice;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    interface DECLSPEC_UUID("3D090831-EED6-11d2-9F1A-00C04F86C055")
    IADCDevice : public IUnknown
    {
    public:
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Initialize( 
            /* [in] */ LPCTSTR pszCommPort,
            /* [in] */ LPCTSTR pszDeviceSubKey) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Read( 
            /* [out] */ WORD __RPC_FAR *pbSequenceNum,
            /* [out] */ WORD __RPC_FAR *pbClientHandle,
            /* [out] */ DWORD __RPC_FAR *pdwDataClass,
            /* [in] */ BYTE __RPC_FAR *pBuffer,
            /* [in] */ DWORD dwBufferSize,
            /* [out] */ DWORD __RPC_FAR *pnBytesReturned,
            /* [out] */ ITC_ADCDEVICE_DATA_DETAILS __RPC_FAR *pDataDetails) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Open( 
            /* [in] */ WORD wSequenceNum,
            /* [in] */ ITC_DEVICE_FLAGS stDevFlags,
            /* [out][in] */ ITC_DEVICE_HANDLE __RPC_FAR *pwClientHandle) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Close( 
            /* [in] */ WORD bSequenceNum,
            /* [in] */ WORD bClientHandle) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Write( 
            /* [in] */ WORD wSequenceNum,
            /* [in] */ BYTE __RPC_FAR *pWriteBuffer,
            /* [in] */ DWORD dwBytesWrite,
            /* [out] */ BYTE __RPC_FAR *pWriteRspBuffer,
            /* [in] */ DWORD dwWriteRspBufferSize,
            /* [out] */ DWORD __RPC_FAR *pdwBytesReturned) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE ReadDataClass( 
            /* [in] */ WORD bSequenceNum,
            /* [in] */ WORD bClientHandle,
            /* [in] */ DWORD dwDataClass,
            /* [in] */ BOOL fDiscardQueuedData) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE CancelRequest( 
            /* [in] */ WORD bSequenceNum,
            /* [in] */ WORD bClientHandle) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetAttribute( 
            /* [in] */ WORD bSequenceNum,
            /* [in] */ ITC_DEVICE_HANDLER_ATTRIBUTE_ID eAttribID,
            /* [in] */ BYTE __RPC_FAR *pbData) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE QueryAttribute( 
            /* [in] */ WORD bSequenceNum,
            /* [in] */ ITC_DEVICE_HANDLER_ATTRIBUTE_ID eAttribID,
            /* [out] */ BYTE __RPC_FAR *pbBuffer,
            /* [in] */ DWORD dwBufferSize,
            /* [out] */ DWORD __RPC_FAR *pnBufferData) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE MatchGrid( 
            /* [in] */ BYTE __RPC_FAR *pbData,
            /* [in] */ DWORD nDataSize,
            /* [in] */ DWORD dwDataClass,
            /* [in] */ BYTE __RPC_FAR *pbGrid,
            /* [in] */ DWORD nGridSize,
            /* [out] */ BOOL __RPC_FAR *pfMatched) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IADCDeviceVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IADCDevice __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IADCDevice __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IADCDevice __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Initialize )( 
            IADCDevice __RPC_FAR * This,
            /* [in] */ LPCTSTR pszCommPort,
            /* [in] */ LPCTSTR pszDeviceSubKey);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Read )( 
            IADCDevice __RPC_FAR * This,
            /* [out] */ WORD __RPC_FAR *pbSequenceNum,
            /* [out] */ WORD __RPC_FAR *pbClientHandle,
            /* [out] */ DWORD __RPC_FAR *pdwDataClass,
            /* [in] */ BYTE __RPC_FAR *pBuffer,
            /* [in] */ DWORD dwBufferSize,
            /* [out] */ DWORD __RPC_FAR *pnBytesReturned,
            /* [out] */ ITC_ADCDEVICE_DATA_DETAILS __RPC_FAR *pDataDetails);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Open )( 
            IADCDevice __RPC_FAR * This,
            /* [in] */ WORD wSequenceNum,
            /* [in] */ ITC_DEVICE_FLAGS stDevFlags,
            /* [out][in] */ ITC_DEVICE_HANDLE __RPC_FAR *pwClientHandle);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Close )( 
            IADCDevice __RPC_FAR * This,
            /* [in] */ WORD bSequenceNum,
            /* [in] */ WORD bClientHandle);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Write )( 
            IADCDevice __RPC_FAR * This,
            /* [in] */ WORD wSequenceNum,
            /* [in] */ BYTE __RPC_FAR *pWriteBuffer,
            /* [in] */ DWORD dwBytesWrite,
            /* [out] */ BYTE __RPC_FAR *pWriteRspBuffer,
            /* [in] */ DWORD dwWriteRspBufferSize,
            /* [out] */ DWORD __RPC_FAR *pdwBytesReturned);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ReadDataClass )( 
            IADCDevice __RPC_FAR * This,
            /* [in] */ WORD bSequenceNum,
            /* [in] */ WORD bClientHandle,
            /* [in] */ DWORD dwDataClass,
            /* [in] */ BOOL fDiscardQueuedData);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *CancelRequest )( 
            IADCDevice __RPC_FAR * This,
            /* [in] */ WORD bSequenceNum,
            /* [in] */ WORD bClientHandle);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetAttribute )( 
            IADCDevice __RPC_FAR * This,
            /* [in] */ WORD bSequenceNum,
            /* [in] */ ITC_DEVICE_HANDLER_ATTRIBUTE_ID eAttribID,
            /* [in] */ BYTE __RPC_FAR *pbData);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryAttribute )( 
            IADCDevice __RPC_FAR * This,
            /* [in] */ WORD bSequenceNum,
            /* [in] */ ITC_DEVICE_HANDLER_ATTRIBUTE_ID eAttribID,
            /* [out] */ BYTE __RPC_FAR *pbBuffer,
            /* [in] */ DWORD dwBufferSize,
            /* [out] */ DWORD __RPC_FAR *pnBufferData);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *MatchGrid )( 
            IADCDevice __RPC_FAR * This,
            /* [in] */ BYTE __RPC_FAR *pbData,
            /* [in] */ DWORD nDataSize,
            /* [in] */ DWORD dwDataClass,
            /* [in] */ BYTE __RPC_FAR *pbGrid,
            /* [in] */ DWORD nGridSize,
            /* [out] */ BOOL __RPC_FAR *pfMatched);
        
        END_INTERFACE
    } IADCDeviceVtbl;

    interface IADCDevice
    {
        CONST_VTBL struct IADCDeviceVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IADCDevice_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IADCDevice_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IADCDevice_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IADCDevice_Initialize(This,pszCommPort,pszDeviceSubKey)	\
    (This)->lpVtbl -> Initialize(This,pszCommPort,pszDeviceSubKey)

#define IADCDevice_Read(This,pbSequenceNum,pbClientHandle,pdwDataClass,pBuffer,dwBufferSize,pnBytesReturned,pDataDetails)	\
    (This)->lpVtbl -> Read(This,pbSequenceNum,pbClientHandle,pdwDataClass,pBuffer,dwBufferSize,pnBytesReturned,pDataDetails)

#define IADCDevice_Open(This,wSequenceNum,stDevFlags,pwClientHandle)	\
    (This)->lpVtbl -> Open(This,wSequenceNum,stDevFlags,pwClientHandle)

#define IADCDevice_Close(This,bSequenceNum,bClientHandle)	\
    (This)->lpVtbl -> Close(This,bSequenceNum,bClientHandle)

#define IADCDevice_Write(This,wSequenceNum,pWriteBuffer,dwBytesWrite,pWriteRspBuffer,dwWriteRspBufferSize,pdwBytesReturned)	\
    (This)->lpVtbl -> Write(This,wSequenceNum,pWriteBuffer,dwBytesWrite,pWriteRspBuffer,dwWriteRspBufferSize,pdwBytesReturned)

#define IADCDevice_ReadDataClass(This,bSequenceNum,bClientHandle,dwDataClass,fDiscardQueuedData)	\
    (This)->lpVtbl -> ReadDataClass(This,bSequenceNum,bClientHandle,dwDataClass,fDiscardQueuedData)

#define IADCDevice_CancelRequest(This,bSequenceNum,bClientHandle)	\
    (This)->lpVtbl -> CancelRequest(This,bSequenceNum,bClientHandle)

#define IADCDevice_SetAttribute(This,bSequenceNum,eAttribID,pbData)	\
    (This)->lpVtbl -> SetAttribute(This,bSequenceNum,eAttribID,pbData)

#define IADCDevice_QueryAttribute(This,bSequenceNum,eAttribID,pbBuffer,dwBufferSize,pnBufferData)	\
    (This)->lpVtbl -> QueryAttribute(This,bSequenceNum,eAttribID,pbBuffer,dwBufferSize,pnBufferData)

#define IADCDevice_MatchGrid(This,pbData,nDataSize,dwDataClass,pbGrid,nGridSize,pfMatched)	\
    (This)->lpVtbl -> MatchGrid(This,pbData,nDataSize,dwDataClass,pbGrid,nGridSize,pfMatched)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADCDevice_Initialize_Proxy( 
    IADCDevice __RPC_FAR * This,
    /* [in] */ LPCTSTR pszCommPort,
    /* [in] */ LPCTSTR pszDeviceSubKey);


void __RPC_STUB IADCDevice_Initialize_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADCDevice_Read_Proxy( 
    IADCDevice __RPC_FAR * This,
    /* [out] */ WORD __RPC_FAR *pbSequenceNum,
    /* [out] */ WORD __RPC_FAR *pbClientHandle,
    /* [out] */ DWORD __RPC_FAR *pdwDataClass,
    /* [in] */ BYTE __RPC_FAR *pBuffer,
    /* [in] */ DWORD dwBufferSize,
    /* [out] */ DWORD __RPC_FAR *pnBytesReturned,
    /* [out] */ ITC_ADCDEVICE_DATA_DETAILS __RPC_FAR *pDataDetails);


void __RPC_STUB IADCDevice_Read_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADCDevice_Open_Proxy( 
    IADCDevice __RPC_FAR * This,
    /* [in] */ WORD wSequenceNum,
    /* [in] */ ITC_DEVICE_FLAGS stDevFlags,
    /* [out][in] */ ITC_DEVICE_HANDLE __RPC_FAR *pwClientHandle);


void __RPC_STUB IADCDevice_Open_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADCDevice_Close_Proxy( 
    IADCDevice __RPC_FAR * This,
    /* [in] */ WORD bSequenceNum,
    /* [in] */ WORD bClientHandle);


void __RPC_STUB IADCDevice_Close_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADCDevice_Write_Proxy( 
    IADCDevice __RPC_FAR * This,
    /* [in] */ WORD wSequenceNum,
    /* [in] */ BYTE __RPC_FAR *pWriteBuffer,
    /* [in] */ DWORD dwBytesWrite,
    /* [out] */ BYTE __RPC_FAR *pWriteRspBuffer,
    /* [in] */ DWORD dwWriteRspBufferSize,
    /* [out] */ DWORD __RPC_FAR *pdwBytesReturned);


void __RPC_STUB IADCDevice_Write_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADCDevice_ReadDataClass_Proxy( 
    IADCDevice __RPC_FAR * This,
    /* [in] */ WORD bSequenceNum,
    /* [in] */ WORD bClientHandle,
    /* [in] */ DWORD dwDataClass,
    /* [in] */ BOOL fDiscardQueuedData);


void __RPC_STUB IADCDevice_ReadDataClass_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADCDevice_CancelRequest_Proxy( 
    IADCDevice __RPC_FAR * This,
    /* [in] */ WORD bSequenceNum,
    /* [in] */ WORD bClientHandle);


void __RPC_STUB IADCDevice_CancelRequest_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADCDevice_SetAttribute_Proxy( 
    IADCDevice __RPC_FAR * This,
    /* [in] */ WORD bSequenceNum,
    /* [in] */ ITC_DEVICE_HANDLER_ATTRIBUTE_ID eAttribID,
    /* [in] */ BYTE __RPC_FAR *pbData);


void __RPC_STUB IADCDevice_SetAttribute_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADCDevice_QueryAttribute_Proxy( 
    IADCDevice __RPC_FAR * This,
    /* [in] */ WORD bSequenceNum,
    /* [in] */ ITC_DEVICE_HANDLER_ATTRIBUTE_ID eAttribID,
    /* [out] */ BYTE __RPC_FAR *pbBuffer,
    /* [in] */ DWORD dwBufferSize,
    /* [out] */ DWORD __RPC_FAR *pnBufferData);


void __RPC_STUB IADCDevice_QueryAttribute_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IADCDevice_MatchGrid_Proxy( 
    IADCDevice __RPC_FAR * This,
    /* [in] */ BYTE __RPC_FAR *pbData,
    /* [in] */ DWORD nDataSize,
    /* [in] */ DWORD dwDataClass,
    /* [in] */ BYTE __RPC_FAR *pbGrid,
    /* [in] */ DWORD nGridSize,
    /* [out] */ BOOL __RPC_FAR *pfMatched);


void __RPC_STUB IADCDevice_MatchGrid_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IADCDevice_INTERFACE_DEFINED__ */


/****************************************
 * Generated header for interface: __MIDL_itf_IADCDevice_0144
 * at Fri Nov 08 13:57:35 2002
 * using MIDL 3.02.88
 ****************************************/
/* [local] */ 



#pragma pack(pop, IADCDevice_IDL)


extern RPC_IF_HANDLE __MIDL_itf_IADCDevice_0144_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_IADCDevice_0144_v0_0_s_ifspec;

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif
