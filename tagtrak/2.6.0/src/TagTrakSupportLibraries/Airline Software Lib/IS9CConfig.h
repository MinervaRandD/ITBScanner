/* this ALWAYS GENERATED file contains the definitions for the interfaces */


/* File created by MIDL compiler version 3.02.88 */
/* at Fri Nov 08 13:57:56 2002
 */
/* Compiler settings for .\IS9CConfig.idl:
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

#ifndef __IS9CConfig_h__
#define __IS9CConfig_h__

#ifdef __cplusplus
extern "C"{
#endif 

/* Forward Declarations */ 

#ifndef __IS9CConfig_FWD_DEFINED__
#define __IS9CConfig_FWD_DEFINED__
typedef interface IS9CConfig IS9CConfig;
#endif 	/* __IS9CConfig_FWD_DEFINED__ */


#ifndef __IS9CConfig2_FWD_DEFINED__
#define __IS9CConfig2_FWD_DEFINED__
typedef interface IS9CConfig2 IS9CConfig2;
#endif 	/* __IS9CConfig2_FWD_DEFINED__ */


#ifndef __IS9CConfig3_FWD_DEFINED__
#define __IS9CConfig3_FWD_DEFINED__
typedef interface IS9CConfig3 IS9CConfig3;
#endif 	/* __IS9CConfig3_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"
#include "IBarCodeReader.h"

void __RPC_FAR * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void __RPC_FAR * ); 

/****************************************
 * Generated header for interface: __MIDL_itf_IS9CConfig_0000
 * at Fri Nov 08 13:57:56 2002
 * using MIDL 3.02.88
 ****************************************/
/* [local] */ 



#pragma pack(push, IS9CConfig_IDL)

#pragma pack(1)


extern RPC_IF_HANDLE __MIDL_itf_IS9CConfig_0000_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_IS9CConfig_0000_v0_0_s_ifspec;

#ifndef __IS9CConfig_INTERFACE_DEFINED__
#define __IS9CConfig_INTERFACE_DEFINED__

/****************************************
 * Generated header for interface: IS9CConfig
 * at Fri Nov 08 13:57:56 2002
 * using MIDL 3.02.88
 ****************************************/
/* [unique][helpstring][uuid][object] */ 


#define ITC_BC_LENGTH_NO_CHANGE	255
#define ITC_CODE128_FNC1_NO_CHANGE   255
typedef 
enum tagCode39Decoding
    {	ITC_CODE39_NOTACTIVE	= 0,
	ITC_CODE39_ACTIVE	= 1,
	ITC_CODE39_NO_CHANGE	= 255
    }	ITC_CODE39_DECODING;

typedef 
enum tagCode39Format
    {	ITC_CODE39_FORMAT_STANDARD43	= 0,
	ITC_CODE39_FORMAT_FULLASCII	= 1,
	ITC_CODE39_FORMAT_NO_CHANGE	= 255
    }	ITC_CODE39_FORMAT;

typedef 
enum tagCode39StartStop
    {	ITC_CODE39_SS_NOTXMIT	= 0,
	ITC_CODE39_SS_XMIT	= 1,
	ITC_CODE39_SS_NO_CHANGE	= 255
    }	ITC_CODE39_START_STOP;

typedef 
enum tagCode39StartStopChars
    {	ITC_CODE39_SS_CHARS_DOLLARSIGN	= 0,
	ITC_CODE39_SS_CHARS_ASTERISK	= 1,
	ITC_CODE39_SS_CHARS_BOTH	= 2,
	ITC_CODE39_SS_CHARS_NO_CHANGE	= 255
    }	ITC_CODE39_SS_CHARS;

typedef 
enum tagCode39CheckDigit
    {	ITC_CODE39_CHECK_NOTUSED	= 0,
	ITC_CODE39_CHECK_MOD43_XMIT	= 1,
	ITC_CODE39_CHECK_MOD43_NOTXMIT	= 2,
	ITC_CODE39_CHECK_FRENCH_CIP_XMIT	= 3,
	ITC_CODE39_CHECK_FRENCH_CIP_NOTXMIT	= 4,
	ITC_CODE39_CHECK_ITALIAN_CPI_XMIT	= 5,
	ITC_CODE39_CHECK_ITALIAN_CPI_NOTXMIT	= 6,
	ITC_CODE39_CHECK_NO_CHANGE	= 255
    }	ITC_CODE39_CHECK_DIGIT;

typedef 
enum tagCodabarDecoding
    {	ITC_CODABAR_NOTACTIVE	= 0,
	ITC_CODABAR_ACTIVE	= 1,
	ITC_CODABAR_NO_CHANGE	= 255
    }	ITC_CODABAR_DECODING;

typedef 
enum tagCodabarStartStop
    {	ITC_CODABAR_SS_NOTXMIT	= 0,
	ITC_CODABAR_SS_LOWERABCD	= 1,
	ITC_CODABAR_SS_UPPERABCD	= 2,
	ITC_CODABAR_SS_LOWERABCDTN	= 3,
	ITC_CODABAR_SS_DC1TODC4	= 4,
	ITC_CODABAR_SS_NO_CHANGE	= 255
    }	ITC_CODABAR_START_STOP;

typedef 
enum tagCodabarClsi
    {	ITC_CODABAR_CLSI_NOTACTIVE	= 0,
	ITC_CODABAR_CLSI_ACTIVE	= 1,
	ITC_CODABAR_CLSI_NO_CHANGE	= 255
    }	ITC_CODABAR_CLSI;

typedef 
enum tagCodabarCheckDigit
    {	ITC_CODABAR_CHECK_NOTUSED	= 0,
	ITC_CODABAR_CHECK_XMIT	= 1,
	ITC_CODABAR_CHECK_NOTXMIT	= 2,
	ITC_CODABAR_CHECK_NO_CHANGE	= 255
    }	ITC_CODABAR_CHECK_DIGIT;

typedef 
enum tagCode93Decoding
    {	ITC_CODE93_NOTACTIVE	= 0,
	ITC_CODE93_ACTIVE	= 1,
	ITC_CODE93_NO_CHANGE	= 255
    }	ITC_CODE93_DECODING;

typedef 
enum tagCode128Decoding
    {	ITC_CODE128_NOTACTIVE	= 0,
	ITC_CODE128_ACTIVE	= 1,
	ITC_CODE128_NO_CHANGE	= 255
    }	ITC_CODE128_DECODING;

typedef 
enum tagEan128Identifier
    {	ITC_EAN128_ID_REMOVE	= 0,
	ITC_EAN128_ID_INCLUDE	= 1,
	ITC_EAN128_ID_NO_CHANGE	= 255
    }	ITC_EAN128_IDENTIFIER;

typedef 
enum tagCode128Cip128
    {	ITC_CODE128_CIP128_NOTACTIVE	= 0,
	ITC_CODE128_CIP128_ACTIVE	= 1,
	ITC_CODE128_CIP128_NO_CHANGE	= 255
    }	ITC_CODE128_CIP128;

typedef 
enum tagInterleaved2of5Decoding
    {	ITC_INTERLEAVED2OF5_NOTACTIVE	= 0,
	ITC_INTERLEAVED2OF5_ACTIVE	= 1,
	ITC_INTERLEAVED2OF5_NO_CHANGE	= 255
    }	ITC_INTERLEAVED2OF5_DECODING;

typedef 
enum tagInterleaved2of5CheckDigit
    {	ITC_INTERLEAVED2OF5_CHECK_NOTUSED	= 0,
	ITC_INTERLEAVED2OF5_CHECK_MOD10_XMIT	= 1,
	ITC_INTERLEAVED2OF5_CHECK_MOD10_NOTXMIT	= 2,
	ITC_INTERLEAVED2OF5_CHECK_FRENCH_CIP_XMIT	= 3,
	ITC_INTERLEAVED2OF5_CHECK_FRENCH_CIP_NOTXMIT	= 4,
	ITC_INTERLEAVED2OF5_CHECK_NO_CHANGE	= 255
    }	ITC_INTERLEAVED2OF5_CHECK_DIGIT;

typedef 
enum tagMatrix2of5Decoding
    {	ITC_MATRIX2OF5_NOTACTIVE	= 0,
	ITC_MATRIX2OF5_ACTIVE	= 1,
	ITC_MATRIX2OF5_NO_CHANGE	= 255
    }	ITC_MATRIX2OF5_DECODING;

typedef 
enum tagMsiDecoding
    {	ITC_MSI_NOTACTIVE	= 0,
	ITC_MSI_ACTIVE	= 1,
	ITC_MSI_NO_CHANGE	= 255
    }	ITC_MSI_DECODING;

typedef 
enum tagMsiCheckDigit
    {	ITC_MSI_CHECK_MOD10_XMIT	= 0,
	ITC_MSI_CHECK_MOD10_NOTXMIT	= 1,
	ITC_MSI_CHECK_DOUBLEMOD10_XMIT	= 2,
	ITC_MSI_CHECK_DOUBLEMOD10_NOTXMIT	= 3,
	ITC_MSI_CHECK_NO_CHANGE	= 255
    }	ITC_MSI_CHECK_DIGIT;

typedef 
enum tagPdf417Decoding
    {	ITC_PDF417_NOTACTIVE	= 0,
	ITC_PDF417_ACTIVE	= 1,
	ITC_PDF417_NO_CHANGE	= 255
    }	ITC_PDF417_DECODING;

typedef 
enum tagPdf417MacroPdf
    {	ITC_PDF417_MACRO_UNBUFFERED	= 0,
	ITC_PDF417_MACRO_BUFFERED	= 1,
	ITC_PDF417_MACRO_NO_CHANGE	= 255
    }	ITC_PDF417_MACRO_PDF;

typedef 
enum tagPdf417ControlHeader
    {	ITC_PDF417_CTRL_HEADER_NOTXMIT	= 0,
	ITC_PDF417_CTRL_HEADER_XMIT	= 1,
	ITC_PDF417_CTRL_HEADER_NO_CHANGE	= 255
    }	ITC_PDF417_CTRL_HEADER;

typedef 
enum tagPdf417FileName
    {	ITC_PDF417_FILE_NAME_NOTXMIT	= 0,
	ITC_PDF417_FILE_NAME_XMIT	= 1,
	ITC_PDF417_FILE_NAME_NO_CHANGE	= 255
    }	ITC_PDF417_FILE_NAME;

typedef 
enum tagPdf417SegmentCount
    {	ITC_PDF417_SEGMENT_COUNT_NOTXMIT	= 0,
	ITC_PDF417_SEGMENT_COUNT_XMIT	= 1,
	ITC_PDF417_SEGMENT_COUNT_NO_CHANGE	= 255
    }	ITC_PDF417_SEGMENT_COUNT;

typedef 
enum tagPdf417TimeStamp
    {	ITC_PDF417_TIME_STAMP_NOTXMIT	= 0,
	ITC_PDF417_TIME_STAMP_XMIT	= 1,
	ITC_PDF417_TIME_STAMP_NO_CHANGE	= 255
    }	ITC_PDF417_TIME_STAMP;

typedef 
enum tagPdf417Sender
    {	ITC_PDF417_SENDER_NOTXMIT	= 0,
	ITC_PDF417_SENDER_XMIT	= 1,
	ITC_PDF417_SENDER_NO_CHANGE	= 255
    }	ITC_PDF417_SENDER;

typedef 
enum tagPdf417Addressee
    {	ITC_PDF417_ADDRESSEE_NOTXMIT	= 0,
	ITC_PDF417_ADDRESSEE_XMIT	= 1,
	ITC_PDF417_ADDRESSEE_NO_CHANGE	= 255
    }	ITC_PDF417_ADDRESSEE;

typedef 
enum tagPdf417FileSize
    {	ITC_PDF417_FILE_SIZE_NOTXMIT	= 0,
	ITC_PDF417_FILE_SIZE_XMIT	= 1,
	ITC_PDF417_FILE_SIZE_NO_CHANGE	= 255
    }	ITC_PDF417_FILE_SIZE;

typedef 
enum tagPdf417Checksum
    {	ITC_PDF417_CHECKSUM_NOTXMIT	= 0,
	ITC_PDF417_CHECKSUM_XMIT	= 1,
	ITC_PDF417_CHECKSUM_NO_CHANGE	= 255
    }	ITC_PDF417_CHECKSUM;

typedef 
enum tagPlesseyDecoding
    {	ITC_PLESSEY_NOTACTIVE	= 0,
	ITC_PLESSEY_ACTIVE	= 1,
	ITC_PLESSEY_NO_CHANGE	= 255
    }	ITC_PLESSEY_DECODING;

typedef 
enum tagPlesseyCheckDigit
    {	ITC_PLESSEY_CHECK_NOTXMIT	= 0,
	ITC_PLESSEY_CHECK_XMIT	= 1,
	ITC_PLESSEY_CHECK_NO_CHANGE	= 255
    }	ITC_PLESSEY_CHECK_DIGIT;

typedef 
enum tagStandard2of5Decoding
    {	ITC_STANDARD2OF5_NOTACTIVE	= 0,
	ITC_STANDARD2OF5_ACTIVE	= 1,
	ITC_STANDARD2OF5_NO_CHANGE	= 255
    }	ITC_STANDARD2OF5_DECODING;

typedef 
enum tagStandard2of5Format
    {	ITC_STANDARD2OF5_FORMAT_IDENTICON	= 0,
	ITC_STANDARD2OF5_FORMAT_COMPUTER_IDENTICS	= 1,
	ITC_STANDARD2OF5_FORMAT_NO_CHANGE	= 255
    }	ITC_STANDARD2OF5_FORMAT;

typedef 
enum tagStandard2of5CheckDigit
    {	ITC_STANDARD2OF5_CHECK_NOTUSED	= 0,
	ITC_STANDARD2OF5_CHECK_XMIT	= 1,
	ITC_STANDARD2OF5_CHECK_NOTXMIT	= 2,
	ITC_STANDARD2OF5_CHECK_NO_CHANGE	= 255
    }	ITC_STANDARD2OF5_CHECK_DIGIT;

typedef 
enum tagTelepenDecoding
    {	ITC_TELEPEN_NOTACTIVE	= 0,
	ITC_TELEPEN_ACTIVE	= 1,
	ITC_TELEPEN_NO_CHANGE	= 255
    }	ITC_TELEPEN_DECODING;

typedef 
enum tagTelepenFormat
    {	ITC_TELEPEN_FORMAT_ASCII	= 0,
	ITC_TELEPEN_FORMAT_NUMERIC	= 1,
	ITC_TELEPEN_FORMAT_NO_CHANGE	= 255
    }	ITC_TELEPEN_FORMAT;

typedef 
enum tagUpcEanDecoding
    {	ITC_UPCEAN_NOTACTIVE	= 0,
	ITC_UPCEAN_ACTIVE	= 1,
	ITC_UPCEAN_NO_CHANGE	= 255
    }	ITC_UPCEAN_DECODING;

typedef 
enum tagUpcASelect
    {	ITC_UPCA_DEACTIVATE	= 0,
	ITC_UPCA_ACTIVATE	= 1,
	ITC_UPCA_NO_CHANGE	= 255
    }	ITC_UPCA_SELECT;

typedef 
enum tagUpcESelect
    {	ITC_UPCE_DEACTIVATE	= 0,
	ITC_UPCE_ACTIVATE	= 1,
	ITC_UPCE_NO_CHANGE	= 255
    }	ITC_UPCE_SELECT;

typedef 
enum tagEan8Select
    {	ITC_EAN8_DEACTIVATE	= 0,
	ITC_EAN8_ACTIVATE	= 1,
	ITC_EAN8_NO_CHANGE	= 255
    }	ITC_EAN8_SELECT;

typedef 
enum tagEan13Select
    {	ITC_EAN13_DEACTIVATE	= 0,
	ITC_EAN13_ACTIVATE	= 1,
	ITC_EAN13_NO_CHANGE	= 255
    }	ITC_EAN13_SELECT;

typedef 
enum tagUpcEanAddonDigits
    {	ITC_UPCEAN_ADDON_NOT_REQUIRED	= 0,
	ITC_UPCEAN_ADDON_REQUIRED	= 1,
	ITC_UPCEAN_ADDON_NO_CHANGE	= 255
    }	ITC_UPCEAN_ADDON_DIGITS;

typedef 
enum tagUpcEanAddonTwo
    {	ITC_UPCEAN_ADDON_TWO_NOTACTIVE	= 0,
	ITC_UPCEAN_ADDON_TWO_ACTIVE	= 1,
	ITC_UPCEAN_ADDON_TWO_NO_CHANGE	= 255
    }	ITC_UPCEAN_ADDON_TWO;

typedef 
enum tagUpcEanAddonFive
    {	ITC_UPCEAN_ADDON_FIVE_NOTACTIVE	= 0,
	ITC_UPCEAN_ADDON_FIVE_ACTIVE	= 1,
	ITC_UPCEAN_ADDON_FIVE_NO_CHANGE	= 255
    }	ITC_UPCEAN_ADDON_FIVE;

typedef 
enum tagUpcACheckDigit
    {	ITC_UPCA_CHECK_NOTXMIT	= 0,
	ITC_UPCA_CHECK_XMIT	= 1,
	ITC_UPCA_CHECK_NO_CHANGE	= 255
    }	ITC_UPCA_CHECK_DIGIT;

typedef 
enum tagUpcECheckDigit
    {	ITC_UPCE_CHECK_NOTXMIT	= 0,
	ITC_UPCE_CHECK_XMIT	= 1,
	ITC_UPCE_CHECK_NO_CHANGE	= 255
    }	ITC_UPCE_CHECK_DIGIT;

typedef 
enum tagEan8CheckDigit
    {	ITC_EAN8_CHECK_NOTXMIT	= 0,
	ITC_EAN8_CHECK_XMIT	= 1,
	ITC_EAN8_CHECK_NO_CHANGE	= 255
    }	ITC_EAN8_CHECK_DIGIT;

typedef 
enum tagEan13CheckDigit
    {	ITC_EAN13_CHECK_NOTXMIT	= 0,
	ITC_EAN13_CHECK_XMIT	= 1,
	ITC_EAN13_CHECK_NO_CHANGE	= 255
    }	ITC_EAN13_CHECK_DIGIT;

typedef 
enum tagUpcANumberSystem
    {	ITC_UPCA_NUM_SYS_NOTXMIT	= 0,
	ITC_UPCA_NUM_SYS_XMIT	= 1,
	ITC_UPCA_NUM_SYS_NO_CHANGE	= 255
    }	ITC_UPCA_NUMBER_SYSTEM;

typedef 
enum tagUpcENumberSystem
    {	ITC_UPCE_NUM_SYS_NOTXMIT	= 0,
	ITC_UPCE_NUM_SYS_XMIT	= 1,
	ITC_UPCE_NUM_SYS_NO_CHANGE	= 255
    }	ITC_UPCE_NUMBER_SYSTEM;

typedef 
enum tagUpcAReencode
    {	ITC_UPCA_XMIT_AS_EAN13	= 0,
	ITC_UPCA_XMIT_AS_UPCA	= 1,
	ITC_UPCA_XMIT_NO_CHANGE	= 255
    }	ITC_UPCA_REENCODE;

typedef 
enum tagUpcEReencode
    {	ITC_UPCE_XMIT_AS_UPCE	= 0,
	ITC_UPCE_XMIT_AS_UPCA	= 1,
	ITC_UPCE_XMIT_NO_CHANGE	= 255
    }	ITC_UPCE_REENCODE;

typedef 
enum tagEan8Reencode
    {	ITC_EAN8_XMIT_AS_EAN8	= 0,
	ITC_EAN8_XMIT_AS_EAN13	= 1,
	ITC_EAN8_XMIT_NO_CHANGE	= 255
    }	ITC_EAN8_REENCODE;

typedef 
enum tagBarcodeLengthId
    {	ITC_BARCODE_LENGTH	= 0,
	ITC_BARCODE_FIXED_LENGTH	= 1,
	ITC_BARCODE_LENGTH_NO_CHANGE	= 255
    }	ITC_BARCODE_LENGTH_ID;


EXTERN_C const IID IID_IS9CConfig;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    interface DECLSPEC_UUID("C6AC9214-FC9F-40F1-8899-01FC81B01D7D")
    IS9CConfig : public IBarCodeReaderConfig
    {
    public:
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetCode39( 
            /* [out] */ ITC_CODE39_DECODING __RPC_FAR *c39Decode,
            /* [out] */ ITC_CODE39_FORMAT __RPC_FAR *c39Format,
            /* [out] */ ITC_CODE39_START_STOP __RPC_FAR *c39SS,
            /* [out] */ ITC_CODE39_SS_CHARS __RPC_FAR *c39SSChars,
            /* [out] */ ITC_CODE39_CHECK_DIGIT __RPC_FAR *c39Check,
            /* [out] */ DWORD __RPC_FAR *c39Length) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetCode39( 
            /* [in] */ ITC_CODE39_DECODING c39Decode,
            /* [in] */ ITC_CODE39_FORMAT c39Format,
            /* [in] */ ITC_CODE39_START_STOP c39SS,
            /* [in] */ ITC_CODE39_SS_CHARS c39SSChars,
            /* [in] */ ITC_CODE39_CHECK_DIGIT c39Check,
            /* [in] */ DWORD c39Length) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetCodabar( 
            /* [out] */ ITC_CODABAR_DECODING __RPC_FAR *cbarDecode,
            /* [out] */ ITC_CODABAR_START_STOP __RPC_FAR *cbarSS,
            /* [out] */ ITC_CODABAR_CLSI __RPC_FAR *cbarCLSI,
            /* [out] */ ITC_CODABAR_CHECK_DIGIT __RPC_FAR *cbarCheck,
            /* [out] */ ITC_BARCODE_LENGTH_ID __RPC_FAR *eLengthId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [out] */ DWORD __RPC_FAR *pdwNumBytes) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetCodabar( 
            /* [in] */ ITC_CODABAR_DECODING cbarDecode,
            /* [in] */ ITC_CODABAR_START_STOP cbarSS,
            /* [in] */ ITC_CODABAR_CLSI cbarCLSI,
            /* [in] */ ITC_CODABAR_CHECK_DIGIT cbarCheck,
            /* [in] */ ITC_BARCODE_LENGTH_ID eLengthId,
            /* [size_is][in] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [in] */ DWORD dwNumBytes) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetCode93( 
            /* [out] */ ITC_CODE93_DECODING __RPC_FAR *c93Decode,
            /* [out] */ DWORD __RPC_FAR *c93Length) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetCode93( 
            /* [in] */ ITC_CODE93_DECODING c93Decode,
            /* [in] */ DWORD c93Length) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetCode128( 
            /* [out] */ ITC_CODE128_DECODING __RPC_FAR *c128Decode,
            /* [out] */ ITC_EAN128_IDENTIFIER __RPC_FAR *ean128Ident,
            /* [out] */ ITC_CODE128_CIP128 __RPC_FAR *cip128State,
            /* [out] */ BYTE __RPC_FAR *c128FNC1,
            /* [out] */ DWORD __RPC_FAR *c128Length) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetCode128( 
            /* [in] */ ITC_CODE128_DECODING c128Decode,
            /* [in] */ ITC_EAN128_IDENTIFIER ean128Ident,
            /* [in] */ ITC_CODE128_CIP128 cip128State,
            /* [in] */ BYTE c128FNC1,
            /* [in] */ DWORD c128Length) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetI2of5( 
            /* [out] */ ITC_INTERLEAVED2OF5_DECODING __RPC_FAR *i2of5Decode,
            /* [out] */ ITC_INTERLEAVED2OF5_CHECK_DIGIT __RPC_FAR *i2of5Check,
            /* [out] */ ITC_BARCODE_LENGTH_ID __RPC_FAR *eLengthId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [out] */ DWORD __RPC_FAR *pdwNumBytes) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetI2of5( 
            /* [in] */ ITC_INTERLEAVED2OF5_DECODING i2of5Decode,
            /* [in] */ ITC_INTERLEAVED2OF5_CHECK_DIGIT i2of5Check,
            /* [in] */ ITC_BARCODE_LENGTH_ID eLengthId,
            /* [size_is][in] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [in] */ DWORD dwNumBytes) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetMatrix2of5( 
            /* [out] */ ITC_MATRIX2OF5_DECODING __RPC_FAR *m2of5Decode,
            /* [out] */ DWORD __RPC_FAR *m2of5Length) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetMatrix2of5( 
            /* [in] */ ITC_MATRIX2OF5_DECODING m2of5Decode,
            /* [in] */ DWORD m2of5Length) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetMSI( 
            /* [out] */ ITC_MSI_DECODING __RPC_FAR *msiDecode,
            /* [out] */ ITC_MSI_CHECK_DIGIT __RPC_FAR *msiCheck,
            /* [out] */ DWORD __RPC_FAR *msiLength) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetMSI( 
            /* [in] */ ITC_MSI_DECODING msiDecode,
            /* [in] */ ITC_MSI_CHECK_DIGIT msiCheck,
            /* [in] */ DWORD msiLength) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetPDF417( 
            /* [out] */ ITC_PDF417_DECODING __RPC_FAR *pdf417Decode,
            /* [out] */ ITC_PDF417_MACRO_PDF __RPC_FAR *macroPdf,
            /* [out] */ ITC_PDF417_CTRL_HEADER __RPC_FAR *pdfControlHeader,
            /* [out] */ ITC_PDF417_FILE_NAME __RPC_FAR *pdfFileName,
            /* [out] */ ITC_PDF417_SEGMENT_COUNT __RPC_FAR *pdfSegmentCount,
            /* [out] */ ITC_PDF417_TIME_STAMP __RPC_FAR *pdfTimeStamp,
            /* [out] */ ITC_PDF417_SENDER __RPC_FAR *pdfSender,
            /* [out] */ ITC_PDF417_ADDRESSEE __RPC_FAR *pdfAddressee,
            /* [out] */ ITC_PDF417_FILE_SIZE __RPC_FAR *pdfFileSize,
            /* [out] */ ITC_PDF417_CHECKSUM __RPC_FAR *pdfChecksum) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetPDF417( 
            /* [in] */ ITC_PDF417_DECODING pdf417Decode,
            /* [in] */ ITC_PDF417_MACRO_PDF macroPdf,
            /* [in] */ ITC_PDF417_CTRL_HEADER pdfControlHeader,
            /* [in] */ ITC_PDF417_FILE_NAME pdfFileName,
            /* [in] */ ITC_PDF417_SEGMENT_COUNT pdfSegmentCount,
            /* [in] */ ITC_PDF417_TIME_STAMP pdfTimeStamp,
            /* [in] */ ITC_PDF417_SENDER pdfSender,
            /* [in] */ ITC_PDF417_ADDRESSEE pdfAddressee,
            /* [in] */ ITC_PDF417_FILE_SIZE pdfFileSize,
            /* [in] */ ITC_PDF417_CHECKSUM pdfChecksum) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetPlessey( 
            /* [out] */ ITC_PLESSEY_DECODING __RPC_FAR *plesseyDecode,
            /* [out] */ ITC_PLESSEY_CHECK_DIGIT __RPC_FAR *plesseyCheck,
            /* [out] */ DWORD __RPC_FAR *plesseyLength) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetPlessey( 
            /* [in] */ ITC_PLESSEY_DECODING plesseyDecode,
            /* [in] */ ITC_PLESSEY_CHECK_DIGIT plesseyCheck,
            /* [in] */ DWORD plesseyLength) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetStandard2of5( 
            /* [out] */ ITC_STANDARD2OF5_DECODING __RPC_FAR *s2of5Decode,
            /* [out] */ ITC_STANDARD2OF5_FORMAT __RPC_FAR *s2of5Format,
            /* [out] */ ITC_STANDARD2OF5_CHECK_DIGIT __RPC_FAR *s2of5Check,
            /* [out] */ ITC_BARCODE_LENGTH_ID __RPC_FAR *eBarcodeLengthId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [out] */ DWORD __RPC_FAR *pdwNumBytes) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetStandard2of5( 
            /* [in] */ ITC_STANDARD2OF5_DECODING s2of5Decode,
            /* [in] */ ITC_STANDARD2OF5_FORMAT s2of5Format,
            /* [in] */ ITC_STANDARD2OF5_CHECK_DIGIT s2of5Check,
            /* [in] */ ITC_BARCODE_LENGTH_ID eLengthId,
            /* [size_is][in] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [in] */ DWORD dwNumBytes) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetTelepen( 
            /* [out] */ ITC_TELEPEN_DECODING __RPC_FAR *telepenDecode,
            /* [out] */ ITC_TELEPEN_FORMAT __RPC_FAR *telepenFormat) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetTelepen( 
            /* [in] */ ITC_TELEPEN_DECODING telepenDecode,
            /* [in] */ ITC_TELEPEN_FORMAT telepenFormat) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetUpcEan( 
            /* [out] */ ITC_UPCEAN_DECODING __RPC_FAR *upceanDecode,
            /* [out] */ ITC_UPCA_SELECT __RPC_FAR *upcASelect,
            /* [out] */ ITC_UPCE_SELECT __RPC_FAR *upcESelect,
            /* [out] */ ITC_EAN8_SELECT __RPC_FAR *ean8Select,
            /* [out] */ ITC_EAN13_SELECT __RPC_FAR *ean13Select,
            /* [out] */ ITC_UPCEAN_ADDON_DIGITS __RPC_FAR *upcAddOnDigits,
            /* [out] */ ITC_UPCEAN_ADDON_TWO __RPC_FAR *upcAddOn2,
            /* [out] */ ITC_UPCEAN_ADDON_FIVE __RPC_FAR *upcAddOn5,
            /* [out] */ ITC_UPCA_CHECK_DIGIT __RPC_FAR *upcACheck,
            /* [out] */ ITC_UPCE_CHECK_DIGIT __RPC_FAR *upcECheck,
            /* [out] */ ITC_EAN8_CHECK_DIGIT __RPC_FAR *ean8Check,
            /* [out] */ ITC_EAN13_CHECK_DIGIT __RPC_FAR *ean13Check,
            /* [out] */ ITC_UPCA_NUMBER_SYSTEM __RPC_FAR *upcANumSystem,
            /* [out] */ ITC_UPCE_NUMBER_SYSTEM __RPC_FAR *upcENumSystem,
            /* [out] */ ITC_UPCA_REENCODE __RPC_FAR *upcAReencode,
            /* [out] */ ITC_UPCE_REENCODE __RPC_FAR *upcEReencode,
            /* [out] */ ITC_EAN8_REENCODE __RPC_FAR *ean8Reencode) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetUpcEan( 
            /* [in] */ ITC_UPCEAN_DECODING upceanDecode,
            /* [in] */ ITC_UPCA_SELECT upcASelect,
            /* [in] */ ITC_UPCE_SELECT upcESelect,
            /* [in] */ ITC_EAN8_SELECT ean8Select,
            /* [in] */ ITC_EAN13_SELECT ean13Select,
            /* [in] */ ITC_UPCEAN_ADDON_DIGITS upcAddOnDigits,
            /* [in] */ ITC_UPCEAN_ADDON_TWO upcAddOn2,
            /* [in] */ ITC_UPCEAN_ADDON_FIVE upcAddOn5,
            /* [in] */ ITC_UPCA_CHECK_DIGIT upcACheck,
            /* [in] */ ITC_UPCE_CHECK_DIGIT upcECheck,
            /* [in] */ ITC_EAN8_CHECK_DIGIT ean8Check,
            /* [in] */ ITC_EAN13_CHECK_DIGIT ean13Check,
            /* [in] */ ITC_UPCA_NUMBER_SYSTEM upcANumSystem,
            /* [in] */ ITC_UPCE_NUMBER_SYSTEM upcENumSystem,
            /* [in] */ ITC_UPCA_REENCODE upcAReencode,
            /* [in] */ ITC_UPCE_REENCODE upcEReencode,
            /* [in] */ ITC_EAN8_REENCODE ean8Reencode) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IS9CConfigVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IS9CConfig __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IS9CConfig __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Initialize )( 
            IS9CConfig __RPC_FAR * This,
            /* [string][in] */ LPCTSTR pszDeviceName,
            /* [in] */ ITC_DEVICE_FLAGS eDeviceFlags);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Read )( 
            IS9CConfig __RPC_FAR * This,
            /* [size_is][out][in] */ BYTE __RPC_FAR rgbDataBuffer[  ],
            /* [in] */ DWORD dwDataBufferSize,
            /* [out] */ DWORD __RPC_FAR *pnBytesReturned,
            /* [out][in] */ ITC_BARCODE_DATA_DETAILS __RPC_FAR *pBarCodeDataDetails,
            /* [in] */ DWORD dwTimeout);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *CancelReadRequest )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ BOOL FlushBufferedData,
            /* [out][in] */ WORD __RPC_FAR *pwTotalDiscardedMessages,
            /* [out][in] */ DWORD __RPC_FAR *pdwTotalDiscardedBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryAttribute )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ ITC_BARCODEREADER_ATTRIBUTE_ID eAttr,
            /* [size_is][out] */ BYTE __RPC_FAR rgbAttrBuffer[  ],
            /* [in] */ DWORD dwAttrBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetAttribute )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ ITC_BARCODEREADER_ATTRIBUTE_ID eAttr,
            /* [size_is][out] */ BYTE __RPC_FAR rgbAttrBuffer[  ],
            /* [in] */ DWORD dwAttrBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *TriggerScanner )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ BOOL fScannerOn);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *IssueBeep )( 
            IS9CConfig __RPC_FAR * This,
            /* [size_is][in] */ ITC_BEEP_SPEC __RPC_FAR rgBeepRequests[  ],
            /* [in] */ DWORD dwNumberOfBeeps);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Reset )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ BOOL fWarmReset);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ControlLED )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ ITC_BARCODE_LASER_LED_ID eLED,
            /* [in] */ BOOL fLedOn);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetConfig )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ LPCTSTR pszConfig);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetConfig )( 
            IS9CConfig __RPC_FAR * This,
            /* [size_is][out][in] */ TCHAR __RPC_FAR rgszConfig[  ],
            /* [in] */ DWORD ncConfigBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetStatistics )( 
            IS9CConfig __RPC_FAR * This,
            /* [out][in] */ ITC_BARCODEREADER_STATISTICS __RPC_FAR *pStatsBuffer,
            /* [in] */ DWORD dwStatsBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ResetStatistics )( 
            IS9CConfig __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetAnalysis )( 
            IS9CConfig __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ReadAnalysis )( 
            IS9CConfig __RPC_FAR * This,
            /* [size_is][out] */ BYTE __RPC_FAR rgbAnalysisBuffer[  ],
            /* [in] */ DWORD dwAnalysisBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *DownloadBarCodeReader )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ LPCTSTR pszReaderProgramFile);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetSystemInfo )( 
            IS9CConfig __RPC_FAR * This,
            /* [out][in] */ ITC_BARC0DEREADER_SYSTEM_INFO __RPC_FAR *pSysInfoBuffer,
            /* [in] */ DWORD dwSysInfoBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetCode39 )( 
            IS9CConfig __RPC_FAR * This,
            /* [out] */ ITC_CODE39_DECODING __RPC_FAR *c39Decode,
            /* [out] */ ITC_CODE39_FORMAT __RPC_FAR *c39Format,
            /* [out] */ ITC_CODE39_START_STOP __RPC_FAR *c39SS,
            /* [out] */ ITC_CODE39_SS_CHARS __RPC_FAR *c39SSChars,
            /* [out] */ ITC_CODE39_CHECK_DIGIT __RPC_FAR *c39Check,
            /* [out] */ DWORD __RPC_FAR *c39Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetCode39 )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ ITC_CODE39_DECODING c39Decode,
            /* [in] */ ITC_CODE39_FORMAT c39Format,
            /* [in] */ ITC_CODE39_START_STOP c39SS,
            /* [in] */ ITC_CODE39_SS_CHARS c39SSChars,
            /* [in] */ ITC_CODE39_CHECK_DIGIT c39Check,
            /* [in] */ DWORD c39Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetCodabar )( 
            IS9CConfig __RPC_FAR * This,
            /* [out] */ ITC_CODABAR_DECODING __RPC_FAR *cbarDecode,
            /* [out] */ ITC_CODABAR_START_STOP __RPC_FAR *cbarSS,
            /* [out] */ ITC_CODABAR_CLSI __RPC_FAR *cbarCLSI,
            /* [out] */ ITC_CODABAR_CHECK_DIGIT __RPC_FAR *cbarCheck,
            /* [out] */ ITC_BARCODE_LENGTH_ID __RPC_FAR *eLengthId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [out] */ DWORD __RPC_FAR *pdwNumBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetCodabar )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ ITC_CODABAR_DECODING cbarDecode,
            /* [in] */ ITC_CODABAR_START_STOP cbarSS,
            /* [in] */ ITC_CODABAR_CLSI cbarCLSI,
            /* [in] */ ITC_CODABAR_CHECK_DIGIT cbarCheck,
            /* [in] */ ITC_BARCODE_LENGTH_ID eLengthId,
            /* [size_is][in] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [in] */ DWORD dwNumBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetCode93 )( 
            IS9CConfig __RPC_FAR * This,
            /* [out] */ ITC_CODE93_DECODING __RPC_FAR *c93Decode,
            /* [out] */ DWORD __RPC_FAR *c93Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetCode93 )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ ITC_CODE93_DECODING c93Decode,
            /* [in] */ DWORD c93Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetCode128 )( 
            IS9CConfig __RPC_FAR * This,
            /* [out] */ ITC_CODE128_DECODING __RPC_FAR *c128Decode,
            /* [out] */ ITC_EAN128_IDENTIFIER __RPC_FAR *ean128Ident,
            /* [out] */ ITC_CODE128_CIP128 __RPC_FAR *cip128State,
            /* [out] */ BYTE __RPC_FAR *c128FNC1,
            /* [out] */ DWORD __RPC_FAR *c128Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetCode128 )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ ITC_CODE128_DECODING c128Decode,
            /* [in] */ ITC_EAN128_IDENTIFIER ean128Ident,
            /* [in] */ ITC_CODE128_CIP128 cip128State,
            /* [in] */ BYTE c128FNC1,
            /* [in] */ DWORD c128Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetI2of5 )( 
            IS9CConfig __RPC_FAR * This,
            /* [out] */ ITC_INTERLEAVED2OF5_DECODING __RPC_FAR *i2of5Decode,
            /* [out] */ ITC_INTERLEAVED2OF5_CHECK_DIGIT __RPC_FAR *i2of5Check,
            /* [out] */ ITC_BARCODE_LENGTH_ID __RPC_FAR *eLengthId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [out] */ DWORD __RPC_FAR *pdwNumBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetI2of5 )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ ITC_INTERLEAVED2OF5_DECODING i2of5Decode,
            /* [in] */ ITC_INTERLEAVED2OF5_CHECK_DIGIT i2of5Check,
            /* [in] */ ITC_BARCODE_LENGTH_ID eLengthId,
            /* [size_is][in] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [in] */ DWORD dwNumBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetMatrix2of5 )( 
            IS9CConfig __RPC_FAR * This,
            /* [out] */ ITC_MATRIX2OF5_DECODING __RPC_FAR *m2of5Decode,
            /* [out] */ DWORD __RPC_FAR *m2of5Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetMatrix2of5 )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ ITC_MATRIX2OF5_DECODING m2of5Decode,
            /* [in] */ DWORD m2of5Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetMSI )( 
            IS9CConfig __RPC_FAR * This,
            /* [out] */ ITC_MSI_DECODING __RPC_FAR *msiDecode,
            /* [out] */ ITC_MSI_CHECK_DIGIT __RPC_FAR *msiCheck,
            /* [out] */ DWORD __RPC_FAR *msiLength);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetMSI )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ ITC_MSI_DECODING msiDecode,
            /* [in] */ ITC_MSI_CHECK_DIGIT msiCheck,
            /* [in] */ DWORD msiLength);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetPDF417 )( 
            IS9CConfig __RPC_FAR * This,
            /* [out] */ ITC_PDF417_DECODING __RPC_FAR *pdf417Decode,
            /* [out] */ ITC_PDF417_MACRO_PDF __RPC_FAR *macroPdf,
            /* [out] */ ITC_PDF417_CTRL_HEADER __RPC_FAR *pdfControlHeader,
            /* [out] */ ITC_PDF417_FILE_NAME __RPC_FAR *pdfFileName,
            /* [out] */ ITC_PDF417_SEGMENT_COUNT __RPC_FAR *pdfSegmentCount,
            /* [out] */ ITC_PDF417_TIME_STAMP __RPC_FAR *pdfTimeStamp,
            /* [out] */ ITC_PDF417_SENDER __RPC_FAR *pdfSender,
            /* [out] */ ITC_PDF417_ADDRESSEE __RPC_FAR *pdfAddressee,
            /* [out] */ ITC_PDF417_FILE_SIZE __RPC_FAR *pdfFileSize,
            /* [out] */ ITC_PDF417_CHECKSUM __RPC_FAR *pdfChecksum);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetPDF417 )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ ITC_PDF417_DECODING pdf417Decode,
            /* [in] */ ITC_PDF417_MACRO_PDF macroPdf,
            /* [in] */ ITC_PDF417_CTRL_HEADER pdfControlHeader,
            /* [in] */ ITC_PDF417_FILE_NAME pdfFileName,
            /* [in] */ ITC_PDF417_SEGMENT_COUNT pdfSegmentCount,
            /* [in] */ ITC_PDF417_TIME_STAMP pdfTimeStamp,
            /* [in] */ ITC_PDF417_SENDER pdfSender,
            /* [in] */ ITC_PDF417_ADDRESSEE pdfAddressee,
            /* [in] */ ITC_PDF417_FILE_SIZE pdfFileSize,
            /* [in] */ ITC_PDF417_CHECKSUM pdfChecksum);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetPlessey )( 
            IS9CConfig __RPC_FAR * This,
            /* [out] */ ITC_PLESSEY_DECODING __RPC_FAR *plesseyDecode,
            /* [out] */ ITC_PLESSEY_CHECK_DIGIT __RPC_FAR *plesseyCheck,
            /* [out] */ DWORD __RPC_FAR *plesseyLength);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetPlessey )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ ITC_PLESSEY_DECODING plesseyDecode,
            /* [in] */ ITC_PLESSEY_CHECK_DIGIT plesseyCheck,
            /* [in] */ DWORD plesseyLength);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetStandard2of5 )( 
            IS9CConfig __RPC_FAR * This,
            /* [out] */ ITC_STANDARD2OF5_DECODING __RPC_FAR *s2of5Decode,
            /* [out] */ ITC_STANDARD2OF5_FORMAT __RPC_FAR *s2of5Format,
            /* [out] */ ITC_STANDARD2OF5_CHECK_DIGIT __RPC_FAR *s2of5Check,
            /* [out] */ ITC_BARCODE_LENGTH_ID __RPC_FAR *eBarcodeLengthId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [out] */ DWORD __RPC_FAR *pdwNumBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetStandard2of5 )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ ITC_STANDARD2OF5_DECODING s2of5Decode,
            /* [in] */ ITC_STANDARD2OF5_FORMAT s2of5Format,
            /* [in] */ ITC_STANDARD2OF5_CHECK_DIGIT s2of5Check,
            /* [in] */ ITC_BARCODE_LENGTH_ID eLengthId,
            /* [size_is][in] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [in] */ DWORD dwNumBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTelepen )( 
            IS9CConfig __RPC_FAR * This,
            /* [out] */ ITC_TELEPEN_DECODING __RPC_FAR *telepenDecode,
            /* [out] */ ITC_TELEPEN_FORMAT __RPC_FAR *telepenFormat);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetTelepen )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ ITC_TELEPEN_DECODING telepenDecode,
            /* [in] */ ITC_TELEPEN_FORMAT telepenFormat);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetUpcEan )( 
            IS9CConfig __RPC_FAR * This,
            /* [out] */ ITC_UPCEAN_DECODING __RPC_FAR *upceanDecode,
            /* [out] */ ITC_UPCA_SELECT __RPC_FAR *upcASelect,
            /* [out] */ ITC_UPCE_SELECT __RPC_FAR *upcESelect,
            /* [out] */ ITC_EAN8_SELECT __RPC_FAR *ean8Select,
            /* [out] */ ITC_EAN13_SELECT __RPC_FAR *ean13Select,
            /* [out] */ ITC_UPCEAN_ADDON_DIGITS __RPC_FAR *upcAddOnDigits,
            /* [out] */ ITC_UPCEAN_ADDON_TWO __RPC_FAR *upcAddOn2,
            /* [out] */ ITC_UPCEAN_ADDON_FIVE __RPC_FAR *upcAddOn5,
            /* [out] */ ITC_UPCA_CHECK_DIGIT __RPC_FAR *upcACheck,
            /* [out] */ ITC_UPCE_CHECK_DIGIT __RPC_FAR *upcECheck,
            /* [out] */ ITC_EAN8_CHECK_DIGIT __RPC_FAR *ean8Check,
            /* [out] */ ITC_EAN13_CHECK_DIGIT __RPC_FAR *ean13Check,
            /* [out] */ ITC_UPCA_NUMBER_SYSTEM __RPC_FAR *upcANumSystem,
            /* [out] */ ITC_UPCE_NUMBER_SYSTEM __RPC_FAR *upcENumSystem,
            /* [out] */ ITC_UPCA_REENCODE __RPC_FAR *upcAReencode,
            /* [out] */ ITC_UPCE_REENCODE __RPC_FAR *upcEReencode,
            /* [out] */ ITC_EAN8_REENCODE __RPC_FAR *ean8Reencode);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetUpcEan )( 
            IS9CConfig __RPC_FAR * This,
            /* [in] */ ITC_UPCEAN_DECODING upceanDecode,
            /* [in] */ ITC_UPCA_SELECT upcASelect,
            /* [in] */ ITC_UPCE_SELECT upcESelect,
            /* [in] */ ITC_EAN8_SELECT ean8Select,
            /* [in] */ ITC_EAN13_SELECT ean13Select,
            /* [in] */ ITC_UPCEAN_ADDON_DIGITS upcAddOnDigits,
            /* [in] */ ITC_UPCEAN_ADDON_TWO upcAddOn2,
            /* [in] */ ITC_UPCEAN_ADDON_FIVE upcAddOn5,
            /* [in] */ ITC_UPCA_CHECK_DIGIT upcACheck,
            /* [in] */ ITC_UPCE_CHECK_DIGIT upcECheck,
            /* [in] */ ITC_EAN8_CHECK_DIGIT ean8Check,
            /* [in] */ ITC_EAN13_CHECK_DIGIT ean13Check,
            /* [in] */ ITC_UPCA_NUMBER_SYSTEM upcANumSystem,
            /* [in] */ ITC_UPCE_NUMBER_SYSTEM upcENumSystem,
            /* [in] */ ITC_UPCA_REENCODE upcAReencode,
            /* [in] */ ITC_UPCE_REENCODE upcEReencode,
            /* [in] */ ITC_EAN8_REENCODE ean8Reencode);
        
        END_INTERFACE
    } IS9CConfigVtbl;

    interface IS9CConfig
    {
        CONST_VTBL struct IS9CConfigVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IS9CConfig_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IS9CConfig_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IS9CConfig_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IS9CConfig_Initialize(This,pszDeviceName,eDeviceFlags)	\
    (This)->lpVtbl -> Initialize(This,pszDeviceName,eDeviceFlags)

#define IS9CConfig_Read(This,rgbDataBuffer,dwDataBufferSize,pnBytesReturned,pBarCodeDataDetails,dwTimeout)	\
    (This)->lpVtbl -> Read(This,rgbDataBuffer,dwDataBufferSize,pnBytesReturned,pBarCodeDataDetails,dwTimeout)

#define IS9CConfig_CancelReadRequest(This,FlushBufferedData,pwTotalDiscardedMessages,pdwTotalDiscardedBytes)	\
    (This)->lpVtbl -> CancelReadRequest(This,FlushBufferedData,pwTotalDiscardedMessages,pdwTotalDiscardedBytes)

#define IS9CConfig_QueryAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)	\
    (This)->lpVtbl -> QueryAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)

#define IS9CConfig_SetAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)	\
    (This)->lpVtbl -> SetAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)

#define IS9CConfig_TriggerScanner(This,fScannerOn)	\
    (This)->lpVtbl -> TriggerScanner(This,fScannerOn)

#define IS9CConfig_IssueBeep(This,rgBeepRequests,dwNumberOfBeeps)	\
    (This)->lpVtbl -> IssueBeep(This,rgBeepRequests,dwNumberOfBeeps)

#define IS9CConfig_Reset(This,fWarmReset)	\
    (This)->lpVtbl -> Reset(This,fWarmReset)

#define IS9CConfig_ControlLED(This,eLED,fLedOn)	\
    (This)->lpVtbl -> ControlLED(This,eLED,fLedOn)


#define IS9CConfig_SetConfig(This,pszConfig)	\
    (This)->lpVtbl -> SetConfig(This,pszConfig)

#define IS9CConfig_GetConfig(This,rgszConfig,ncConfigBufferSize)	\
    (This)->lpVtbl -> GetConfig(This,rgszConfig,ncConfigBufferSize)

#define IS9CConfig_GetStatistics(This,pStatsBuffer,dwStatsBufferSize)	\
    (This)->lpVtbl -> GetStatistics(This,pStatsBuffer,dwStatsBufferSize)

#define IS9CConfig_ResetStatistics(This)	\
    (This)->lpVtbl -> ResetStatistics(This)

#define IS9CConfig_SetAnalysis(This)	\
    (This)->lpVtbl -> SetAnalysis(This)

#define IS9CConfig_ReadAnalysis(This,rgbAnalysisBuffer,dwAnalysisBufferSize)	\
    (This)->lpVtbl -> ReadAnalysis(This,rgbAnalysisBuffer,dwAnalysisBufferSize)

#define IS9CConfig_DownloadBarCodeReader(This,pszReaderProgramFile)	\
    (This)->lpVtbl -> DownloadBarCodeReader(This,pszReaderProgramFile)

#define IS9CConfig_GetSystemInfo(This,pSysInfoBuffer,dwSysInfoBufferSize)	\
    (This)->lpVtbl -> GetSystemInfo(This,pSysInfoBuffer,dwSysInfoBufferSize)


#define IS9CConfig_GetCode39(This,c39Decode,c39Format,c39SS,c39SSChars,c39Check,c39Length)	\
    (This)->lpVtbl -> GetCode39(This,c39Decode,c39Format,c39SS,c39SSChars,c39Check,c39Length)

#define IS9CConfig_SetCode39(This,c39Decode,c39Format,c39SS,c39SSChars,c39Check,c39Length)	\
    (This)->lpVtbl -> SetCode39(This,c39Decode,c39Format,c39SS,c39SSChars,c39Check,c39Length)

#define IS9CConfig_GetCodabar(This,cbarDecode,cbarSS,cbarCLSI,cbarCheck,eLengthId,rgbLengthBuff,pdwNumBytes)	\
    (This)->lpVtbl -> GetCodabar(This,cbarDecode,cbarSS,cbarCLSI,cbarCheck,eLengthId,rgbLengthBuff,pdwNumBytes)

#define IS9CConfig_SetCodabar(This,cbarDecode,cbarSS,cbarCLSI,cbarCheck,eLengthId,rgbLengthBuff,dwNumBytes)	\
    (This)->lpVtbl -> SetCodabar(This,cbarDecode,cbarSS,cbarCLSI,cbarCheck,eLengthId,rgbLengthBuff,dwNumBytes)

#define IS9CConfig_GetCode93(This,c93Decode,c93Length)	\
    (This)->lpVtbl -> GetCode93(This,c93Decode,c93Length)

#define IS9CConfig_SetCode93(This,c93Decode,c93Length)	\
    (This)->lpVtbl -> SetCode93(This,c93Decode,c93Length)

#define IS9CConfig_GetCode128(This,c128Decode,ean128Ident,cip128State,c128FNC1,c128Length)	\
    (This)->lpVtbl -> GetCode128(This,c128Decode,ean128Ident,cip128State,c128FNC1,c128Length)

#define IS9CConfig_SetCode128(This,c128Decode,ean128Ident,cip128State,c128FNC1,c128Length)	\
    (This)->lpVtbl -> SetCode128(This,c128Decode,ean128Ident,cip128State,c128FNC1,c128Length)

#define IS9CConfig_GetI2of5(This,i2of5Decode,i2of5Check,eLengthId,rgbLengthBuff,pdwNumBytes)	\
    (This)->lpVtbl -> GetI2of5(This,i2of5Decode,i2of5Check,eLengthId,rgbLengthBuff,pdwNumBytes)

#define IS9CConfig_SetI2of5(This,i2of5Decode,i2of5Check,eLengthId,rgbLengthBuff,dwNumBytes)	\
    (This)->lpVtbl -> SetI2of5(This,i2of5Decode,i2of5Check,eLengthId,rgbLengthBuff,dwNumBytes)

#define IS9CConfig_GetMatrix2of5(This,m2of5Decode,m2of5Length)	\
    (This)->lpVtbl -> GetMatrix2of5(This,m2of5Decode,m2of5Length)

#define IS9CConfig_SetMatrix2of5(This,m2of5Decode,m2of5Length)	\
    (This)->lpVtbl -> SetMatrix2of5(This,m2of5Decode,m2of5Length)

#define IS9CConfig_GetMSI(This,msiDecode,msiCheck,msiLength)	\
    (This)->lpVtbl -> GetMSI(This,msiDecode,msiCheck,msiLength)

#define IS9CConfig_SetMSI(This,msiDecode,msiCheck,msiLength)	\
    (This)->lpVtbl -> SetMSI(This,msiDecode,msiCheck,msiLength)

#define IS9CConfig_GetPDF417(This,pdf417Decode,macroPdf,pdfControlHeader,pdfFileName,pdfSegmentCount,pdfTimeStamp,pdfSender,pdfAddressee,pdfFileSize,pdfChecksum)	\
    (This)->lpVtbl -> GetPDF417(This,pdf417Decode,macroPdf,pdfControlHeader,pdfFileName,pdfSegmentCount,pdfTimeStamp,pdfSender,pdfAddressee,pdfFileSize,pdfChecksum)

#define IS9CConfig_SetPDF417(This,pdf417Decode,macroPdf,pdfControlHeader,pdfFileName,pdfSegmentCount,pdfTimeStamp,pdfSender,pdfAddressee,pdfFileSize,pdfChecksum)	\
    (This)->lpVtbl -> SetPDF417(This,pdf417Decode,macroPdf,pdfControlHeader,pdfFileName,pdfSegmentCount,pdfTimeStamp,pdfSender,pdfAddressee,pdfFileSize,pdfChecksum)

#define IS9CConfig_GetPlessey(This,plesseyDecode,plesseyCheck,plesseyLength)	\
    (This)->lpVtbl -> GetPlessey(This,plesseyDecode,plesseyCheck,plesseyLength)

#define IS9CConfig_SetPlessey(This,plesseyDecode,plesseyCheck,plesseyLength)	\
    (This)->lpVtbl -> SetPlessey(This,plesseyDecode,plesseyCheck,plesseyLength)

#define IS9CConfig_GetStandard2of5(This,s2of5Decode,s2of5Format,s2of5Check,eBarcodeLengthId,rgbLengthBuff,pdwNumBytes)	\
    (This)->lpVtbl -> GetStandard2of5(This,s2of5Decode,s2of5Format,s2of5Check,eBarcodeLengthId,rgbLengthBuff,pdwNumBytes)

#define IS9CConfig_SetStandard2of5(This,s2of5Decode,s2of5Format,s2of5Check,eLengthId,rgbLengthBuff,dwNumBytes)	\
    (This)->lpVtbl -> SetStandard2of5(This,s2of5Decode,s2of5Format,s2of5Check,eLengthId,rgbLengthBuff,dwNumBytes)

#define IS9CConfig_GetTelepen(This,telepenDecode,telepenFormat)	\
    (This)->lpVtbl -> GetTelepen(This,telepenDecode,telepenFormat)

#define IS9CConfig_SetTelepen(This,telepenDecode,telepenFormat)	\
    (This)->lpVtbl -> SetTelepen(This,telepenDecode,telepenFormat)

#define IS9CConfig_GetUpcEan(This,upceanDecode,upcASelect,upcESelect,ean8Select,ean13Select,upcAddOnDigits,upcAddOn2,upcAddOn5,upcACheck,upcECheck,ean8Check,ean13Check,upcANumSystem,upcENumSystem,upcAReencode,upcEReencode,ean8Reencode)	\
    (This)->lpVtbl -> GetUpcEan(This,upceanDecode,upcASelect,upcESelect,ean8Select,ean13Select,upcAddOnDigits,upcAddOn2,upcAddOn5,upcACheck,upcECheck,ean8Check,ean13Check,upcANumSystem,upcENumSystem,upcAReencode,upcEReencode,ean8Reencode)

#define IS9CConfig_SetUpcEan(This,upceanDecode,upcASelect,upcESelect,ean8Select,ean13Select,upcAddOnDigits,upcAddOn2,upcAddOn5,upcACheck,upcECheck,ean8Check,ean13Check,upcANumSystem,upcENumSystem,upcAReencode,upcEReencode,ean8Reencode)	\
    (This)->lpVtbl -> SetUpcEan(This,upceanDecode,upcASelect,upcESelect,ean8Select,ean13Select,upcAddOnDigits,upcAddOn2,upcAddOn5,upcACheck,upcECheck,ean8Check,ean13Check,upcANumSystem,upcENumSystem,upcAReencode,upcEReencode,ean8Reencode)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_GetCode39_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [out] */ ITC_CODE39_DECODING __RPC_FAR *c39Decode,
    /* [out] */ ITC_CODE39_FORMAT __RPC_FAR *c39Format,
    /* [out] */ ITC_CODE39_START_STOP __RPC_FAR *c39SS,
    /* [out] */ ITC_CODE39_SS_CHARS __RPC_FAR *c39SSChars,
    /* [out] */ ITC_CODE39_CHECK_DIGIT __RPC_FAR *c39Check,
    /* [out] */ DWORD __RPC_FAR *c39Length);


void __RPC_STUB IS9CConfig_GetCode39_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_SetCode39_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [in] */ ITC_CODE39_DECODING c39Decode,
    /* [in] */ ITC_CODE39_FORMAT c39Format,
    /* [in] */ ITC_CODE39_START_STOP c39SS,
    /* [in] */ ITC_CODE39_SS_CHARS c39SSChars,
    /* [in] */ ITC_CODE39_CHECK_DIGIT c39Check,
    /* [in] */ DWORD c39Length);


void __RPC_STUB IS9CConfig_SetCode39_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_GetCodabar_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [out] */ ITC_CODABAR_DECODING __RPC_FAR *cbarDecode,
    /* [out] */ ITC_CODABAR_START_STOP __RPC_FAR *cbarSS,
    /* [out] */ ITC_CODABAR_CLSI __RPC_FAR *cbarCLSI,
    /* [out] */ ITC_CODABAR_CHECK_DIGIT __RPC_FAR *cbarCheck,
    /* [out] */ ITC_BARCODE_LENGTH_ID __RPC_FAR *eLengthId,
    /* [size_is][out] */ BYTE __RPC_FAR rgbLengthBuff[  ],
    /* [out] */ DWORD __RPC_FAR *pdwNumBytes);


void __RPC_STUB IS9CConfig_GetCodabar_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_SetCodabar_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [in] */ ITC_CODABAR_DECODING cbarDecode,
    /* [in] */ ITC_CODABAR_START_STOP cbarSS,
    /* [in] */ ITC_CODABAR_CLSI cbarCLSI,
    /* [in] */ ITC_CODABAR_CHECK_DIGIT cbarCheck,
    /* [in] */ ITC_BARCODE_LENGTH_ID eLengthId,
    /* [size_is][in] */ BYTE __RPC_FAR rgbLengthBuff[  ],
    /* [in] */ DWORD dwNumBytes);


void __RPC_STUB IS9CConfig_SetCodabar_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_GetCode93_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [out] */ ITC_CODE93_DECODING __RPC_FAR *c93Decode,
    /* [out] */ DWORD __RPC_FAR *c93Length);


void __RPC_STUB IS9CConfig_GetCode93_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_SetCode93_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [in] */ ITC_CODE93_DECODING c93Decode,
    /* [in] */ DWORD c93Length);


void __RPC_STUB IS9CConfig_SetCode93_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_GetCode128_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [out] */ ITC_CODE128_DECODING __RPC_FAR *c128Decode,
    /* [out] */ ITC_EAN128_IDENTIFIER __RPC_FAR *ean128Ident,
    /* [out] */ ITC_CODE128_CIP128 __RPC_FAR *cip128State,
    /* [out] */ BYTE __RPC_FAR *c128FNC1,
    /* [out] */ DWORD __RPC_FAR *c128Length);


void __RPC_STUB IS9CConfig_GetCode128_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_SetCode128_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [in] */ ITC_CODE128_DECODING c128Decode,
    /* [in] */ ITC_EAN128_IDENTIFIER ean128Ident,
    /* [in] */ ITC_CODE128_CIP128 cip128State,
    /* [in] */ BYTE c128FNC1,
    /* [in] */ DWORD c128Length);


void __RPC_STUB IS9CConfig_SetCode128_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_GetI2of5_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [out] */ ITC_INTERLEAVED2OF5_DECODING __RPC_FAR *i2of5Decode,
    /* [out] */ ITC_INTERLEAVED2OF5_CHECK_DIGIT __RPC_FAR *i2of5Check,
    /* [out] */ ITC_BARCODE_LENGTH_ID __RPC_FAR *eLengthId,
    /* [size_is][out] */ BYTE __RPC_FAR rgbLengthBuff[  ],
    /* [out] */ DWORD __RPC_FAR *pdwNumBytes);


void __RPC_STUB IS9CConfig_GetI2of5_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_SetI2of5_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [in] */ ITC_INTERLEAVED2OF5_DECODING i2of5Decode,
    /* [in] */ ITC_INTERLEAVED2OF5_CHECK_DIGIT i2of5Check,
    /* [in] */ ITC_BARCODE_LENGTH_ID eLengthId,
    /* [size_is][in] */ BYTE __RPC_FAR rgbLengthBuff[  ],
    /* [in] */ DWORD dwNumBytes);


void __RPC_STUB IS9CConfig_SetI2of5_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_GetMatrix2of5_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [out] */ ITC_MATRIX2OF5_DECODING __RPC_FAR *m2of5Decode,
    /* [out] */ DWORD __RPC_FAR *m2of5Length);


void __RPC_STUB IS9CConfig_GetMatrix2of5_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_SetMatrix2of5_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [in] */ ITC_MATRIX2OF5_DECODING m2of5Decode,
    /* [in] */ DWORD m2of5Length);


void __RPC_STUB IS9CConfig_SetMatrix2of5_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_GetMSI_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [out] */ ITC_MSI_DECODING __RPC_FAR *msiDecode,
    /* [out] */ ITC_MSI_CHECK_DIGIT __RPC_FAR *msiCheck,
    /* [out] */ DWORD __RPC_FAR *msiLength);


void __RPC_STUB IS9CConfig_GetMSI_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_SetMSI_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [in] */ ITC_MSI_DECODING msiDecode,
    /* [in] */ ITC_MSI_CHECK_DIGIT msiCheck,
    /* [in] */ DWORD msiLength);


void __RPC_STUB IS9CConfig_SetMSI_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_GetPDF417_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [out] */ ITC_PDF417_DECODING __RPC_FAR *pdf417Decode,
    /* [out] */ ITC_PDF417_MACRO_PDF __RPC_FAR *macroPdf,
    /* [out] */ ITC_PDF417_CTRL_HEADER __RPC_FAR *pdfControlHeader,
    /* [out] */ ITC_PDF417_FILE_NAME __RPC_FAR *pdfFileName,
    /* [out] */ ITC_PDF417_SEGMENT_COUNT __RPC_FAR *pdfSegmentCount,
    /* [out] */ ITC_PDF417_TIME_STAMP __RPC_FAR *pdfTimeStamp,
    /* [out] */ ITC_PDF417_SENDER __RPC_FAR *pdfSender,
    /* [out] */ ITC_PDF417_ADDRESSEE __RPC_FAR *pdfAddressee,
    /* [out] */ ITC_PDF417_FILE_SIZE __RPC_FAR *pdfFileSize,
    /* [out] */ ITC_PDF417_CHECKSUM __RPC_FAR *pdfChecksum);


void __RPC_STUB IS9CConfig_GetPDF417_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_SetPDF417_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [in] */ ITC_PDF417_DECODING pdf417Decode,
    /* [in] */ ITC_PDF417_MACRO_PDF macroPdf,
    /* [in] */ ITC_PDF417_CTRL_HEADER pdfControlHeader,
    /* [in] */ ITC_PDF417_FILE_NAME pdfFileName,
    /* [in] */ ITC_PDF417_SEGMENT_COUNT pdfSegmentCount,
    /* [in] */ ITC_PDF417_TIME_STAMP pdfTimeStamp,
    /* [in] */ ITC_PDF417_SENDER pdfSender,
    /* [in] */ ITC_PDF417_ADDRESSEE pdfAddressee,
    /* [in] */ ITC_PDF417_FILE_SIZE pdfFileSize,
    /* [in] */ ITC_PDF417_CHECKSUM pdfChecksum);


void __RPC_STUB IS9CConfig_SetPDF417_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_GetPlessey_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [out] */ ITC_PLESSEY_DECODING __RPC_FAR *plesseyDecode,
    /* [out] */ ITC_PLESSEY_CHECK_DIGIT __RPC_FAR *plesseyCheck,
    /* [out] */ DWORD __RPC_FAR *plesseyLength);


void __RPC_STUB IS9CConfig_GetPlessey_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_SetPlessey_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [in] */ ITC_PLESSEY_DECODING plesseyDecode,
    /* [in] */ ITC_PLESSEY_CHECK_DIGIT plesseyCheck,
    /* [in] */ DWORD plesseyLength);


void __RPC_STUB IS9CConfig_SetPlessey_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_GetStandard2of5_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [out] */ ITC_STANDARD2OF5_DECODING __RPC_FAR *s2of5Decode,
    /* [out] */ ITC_STANDARD2OF5_FORMAT __RPC_FAR *s2of5Format,
    /* [out] */ ITC_STANDARD2OF5_CHECK_DIGIT __RPC_FAR *s2of5Check,
    /* [out] */ ITC_BARCODE_LENGTH_ID __RPC_FAR *eBarcodeLengthId,
    /* [size_is][out] */ BYTE __RPC_FAR rgbLengthBuff[  ],
    /* [out] */ DWORD __RPC_FAR *pdwNumBytes);


void __RPC_STUB IS9CConfig_GetStandard2of5_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_SetStandard2of5_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [in] */ ITC_STANDARD2OF5_DECODING s2of5Decode,
    /* [in] */ ITC_STANDARD2OF5_FORMAT s2of5Format,
    /* [in] */ ITC_STANDARD2OF5_CHECK_DIGIT s2of5Check,
    /* [in] */ ITC_BARCODE_LENGTH_ID eLengthId,
    /* [size_is][in] */ BYTE __RPC_FAR rgbLengthBuff[  ],
    /* [in] */ DWORD dwNumBytes);


void __RPC_STUB IS9CConfig_SetStandard2of5_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_GetTelepen_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [out] */ ITC_TELEPEN_DECODING __RPC_FAR *telepenDecode,
    /* [out] */ ITC_TELEPEN_FORMAT __RPC_FAR *telepenFormat);


void __RPC_STUB IS9CConfig_GetTelepen_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_SetTelepen_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [in] */ ITC_TELEPEN_DECODING telepenDecode,
    /* [in] */ ITC_TELEPEN_FORMAT telepenFormat);


void __RPC_STUB IS9CConfig_SetTelepen_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_GetUpcEan_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [out] */ ITC_UPCEAN_DECODING __RPC_FAR *upceanDecode,
    /* [out] */ ITC_UPCA_SELECT __RPC_FAR *upcASelect,
    /* [out] */ ITC_UPCE_SELECT __RPC_FAR *upcESelect,
    /* [out] */ ITC_EAN8_SELECT __RPC_FAR *ean8Select,
    /* [out] */ ITC_EAN13_SELECT __RPC_FAR *ean13Select,
    /* [out] */ ITC_UPCEAN_ADDON_DIGITS __RPC_FAR *upcAddOnDigits,
    /* [out] */ ITC_UPCEAN_ADDON_TWO __RPC_FAR *upcAddOn2,
    /* [out] */ ITC_UPCEAN_ADDON_FIVE __RPC_FAR *upcAddOn5,
    /* [out] */ ITC_UPCA_CHECK_DIGIT __RPC_FAR *upcACheck,
    /* [out] */ ITC_UPCE_CHECK_DIGIT __RPC_FAR *upcECheck,
    /* [out] */ ITC_EAN8_CHECK_DIGIT __RPC_FAR *ean8Check,
    /* [out] */ ITC_EAN13_CHECK_DIGIT __RPC_FAR *ean13Check,
    /* [out] */ ITC_UPCA_NUMBER_SYSTEM __RPC_FAR *upcANumSystem,
    /* [out] */ ITC_UPCE_NUMBER_SYSTEM __RPC_FAR *upcENumSystem,
    /* [out] */ ITC_UPCA_REENCODE __RPC_FAR *upcAReencode,
    /* [out] */ ITC_UPCE_REENCODE __RPC_FAR *upcEReencode,
    /* [out] */ ITC_EAN8_REENCODE __RPC_FAR *ean8Reencode);


void __RPC_STUB IS9CConfig_GetUpcEan_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig_SetUpcEan_Proxy( 
    IS9CConfig __RPC_FAR * This,
    /* [in] */ ITC_UPCEAN_DECODING upceanDecode,
    /* [in] */ ITC_UPCA_SELECT upcASelect,
    /* [in] */ ITC_UPCE_SELECT upcESelect,
    /* [in] */ ITC_EAN8_SELECT ean8Select,
    /* [in] */ ITC_EAN13_SELECT ean13Select,
    /* [in] */ ITC_UPCEAN_ADDON_DIGITS upcAddOnDigits,
    /* [in] */ ITC_UPCEAN_ADDON_TWO upcAddOn2,
    /* [in] */ ITC_UPCEAN_ADDON_FIVE upcAddOn5,
    /* [in] */ ITC_UPCA_CHECK_DIGIT upcACheck,
    /* [in] */ ITC_UPCE_CHECK_DIGIT upcECheck,
    /* [in] */ ITC_EAN8_CHECK_DIGIT ean8Check,
    /* [in] */ ITC_EAN13_CHECK_DIGIT ean13Check,
    /* [in] */ ITC_UPCA_NUMBER_SYSTEM upcANumSystem,
    /* [in] */ ITC_UPCE_NUMBER_SYSTEM upcENumSystem,
    /* [in] */ ITC_UPCA_REENCODE upcAReencode,
    /* [in] */ ITC_UPCE_REENCODE upcEReencode,
    /* [in] */ ITC_EAN8_REENCODE ean8Reencode);


void __RPC_STUB IS9CConfig_SetUpcEan_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IS9CConfig_INTERFACE_DEFINED__ */


#ifndef __IS9CConfig2_INTERFACE_DEFINED__
#define __IS9CConfig2_INTERFACE_DEFINED__

/****************************************
 * Generated header for interface: IS9CConfig2
 * at Fri Nov 08 13:57:56 2002
 * using MIDL 3.02.88
 ****************************************/
/* [unique][helpstring][uuid][object] */ 


typedef 
enum tagSymbologyIdXmit
    {	ITC_ID_XMIT_DISABLE	= 0,
	ITC_ID_XMIT_CUSTOM	= 1,
	ITC_ID_XMIT_AIM	= 2,
	ITC_ID_XMIT_NO_CHANGE	= 255
    }	ITC_SYMBOLOGY_ID_XMIT;

typedef 
enum tagCustomId
    {	ITC_CUSTOMID_CODABAR	= 0,
	ITC_CUSTOMID_CODE39	= ITC_CUSTOMID_CODABAR + 1,
	ITC_CUSTOMID_CODE93	= ITC_CUSTOMID_CODE39 + 1,
	ITC_CUSTOMID_CODE128_EAN_128	= ITC_CUSTOMID_CODE93 + 1,
	ITC_CUSTOMID_EAN8	= ITC_CUSTOMID_CODE128_EAN_128 + 1,
	ITC_CUSTOMID_EAN13	= ITC_CUSTOMID_EAN8 + 1,
	ITC_CUSTOMID_I2OF5	= ITC_CUSTOMID_EAN13 + 1,
	ITC_CUSTOMID_MATRIX2OF5	= ITC_CUSTOMID_I2OF5 + 1,
	ITC_CUSTOMID_MSI	= ITC_CUSTOMID_MATRIX2OF5 + 1,
	ITC_CUSTOMID_PDF417	= ITC_CUSTOMID_MSI + 1,
	ITC_CUSTOMID_PLESSEY	= ITC_CUSTOMID_PDF417 + 1,
	ITC_CUSTOMID_CODE2OF5	= ITC_CUSTOMID_PLESSEY + 1,
	ITC_CUSTOMID_TELEPEN	= ITC_CUSTOMID_CODE2OF5 + 1,
	ITC_CUSTOMID_UPCA	= ITC_CUSTOMID_TELEPEN + 1,
	ITC_CUSTOMID_UPCE	= ITC_CUSTOMID_UPCA + 1,
	ITC_CUSTOMID_CODE11	= ITC_CUSTOMID_UPCE + 1,
	ITC_CUSTOMID_CODABLOCK_F	= ITC_CUSTOMID_CODE11 + 1,
	ITC_CUSTOMID_CODABLOCK_A	= ITC_CUSTOMID_CODABLOCK_F + 1,
	ITC_CUSTOMID_LAST_ELEMENT	= ITC_CUSTOMID_CODABLOCK_A + 1
    }	ITC_CUSTOM_ID;

typedef 
enum tagTriggerMode
    {	ITC_TRIGGER_CONTINUOUS	= 0,
	ITC_TRIGGER_LEVEL	= 1,
	ITC_TRIGGER_PULSE	= 2,
	ITC_TRIGGER_FLASHING	= 3,
	ITC_TRIGGER_AUTOSTAND	= 4
    }	ITC_TRIGGER_MODE;

typedef 
enum tagSpotterBeamMode
    {	ITC_SPOTTER_BEAM_DISABLE	= 0,
	ITC_SPOTTER_BEAM_MODE_1	= 1,
	ITC_SPOTTER_BEAM_MODE_2	= 2,
	ITC_SPOTTER_BEAM_MODE_3	= 3
    }	ITC_SPOTTER_BEAM_MODE;

typedef 
enum tagTriggerOffAfterGoodRead
    {	ITC_OFF_AFTER_GOOD_READ_DISABLE	= 0,
	ITC_OFF_AFTER_GOOD_READ_ENABLE	= 1
    }	ITC_TRIGGER_OFF_AFTER_GOOD_READ;

typedef struct  tagCustSymbIdPair
    {
    ITC_CUSTOM_ID eSymbology;
    BYTE byteId;
    }	ITC_CUST_SYM_ID_PAIR;

typedef 
enum tagTriggerSettingId
    {	ITC_TRIGGER_MODE_ID	= 0,
	ITC_TRIGGER_TIMEOUT_ID	= ITC_TRIGGER_MODE_ID + 1,
	ITC_SPOTTER_BEAM_MODE_ID	= ITC_TRIGGER_TIMEOUT_ID + 1,
	ITC_SPOTTER_BEAM_DURATION_ID	= ITC_SPOTTER_BEAM_MODE_ID + 1,
	ITC_TRIGGER_OFF_AFTER_GOOD_READ_ID	= ITC_SPOTTER_BEAM_DURATION_ID + 1
    }	ITC_TRIGGER_SETTING_ID;

typedef 
enum tagGlobalAmbleId
    {	ITC_GLOBAL_PREAMBLE_ID	= 0,
	ITC_GLOBAL_POSTAMBLE_ID	= ITC_GLOBAL_PREAMBLE_ID + 1
    }	ITC_GLOBAL_AMBLE_ID;

#define ITC_GLOBAL_AMBLE_MAX_CHARS	20
typedef 
enum tagDecodeSecId
    {	ITC_SEC_NUM_CONSECUTIVE_SAME_READS_ID	= 0,
	ITC_SEC_TIMEOUT_BETWEEN_SAME_SYMBOL_ID	= ITC_SEC_NUM_CONSECUTIVE_SAME_READS_ID + 1,
	ITC_SEC_TIMEOUT_BETWEEN_DIFFERENT_SYMBOL_ID	= ITC_SEC_TIMEOUT_BETWEEN_SAME_SYMBOL_ID + 1
    }	ITC_DECODE_SEC_ID;

#define ITC_VERSION_MAX_CHARS	256
typedef struct  tagScanEngineInfo
    {
    DWORD dwMaxReceptionFrameSize;
    DWORD dwMaxXmitFrameSize;
    DWORD dwHardWareId;
    CHAR rgcVersion[ 255 ];
    DWORD dwVersionSize;
    }	ITC_SCAN_ENGINE_INFO;

typedef 
enum tagCode11Decoding
    {	ITC_CODE11_NOTACTIVE	= 0,
	ITC_CODE11_ACTIVE	= 1,
	ITC_CODE11_NO_CHANGE	= 255
    }	ITC_CODE11_DECODING;

typedef 
enum tagCode11CheckVerification
    {	ITC_CODE11_CHK_VERIFY_ONEDIGIT	= 1,
	ITC_CODE11_CHK_VERIFY_TWODIGIT	= 2,
	ITC_CODE11_CHK_VERIFY_NO_CHANGE	= 255
    }	ITC_CODE11_CHECK_VERIFICATION;

typedef 
enum tagCode11CheckDigit
    {	ITC_CODE11_CHECK_NOTXMIT	= 0,
	ITC_CODE11_CHECK_XMIT	= 1,
	ITC_CODE11_CHECK_NO_CHANGE	= 255
    }	ITC_CODE11_CHECK_DIGIT;

typedef 
enum tagMicroPdf417Decoding
    {	ITC_MICRO_PDF417_NOTACTIVE	= 0,
	ITC_MICRO_PDF417_ACTIVE	= 1,
	ITC_MICRO_PDF417_NO_CHANGE	= 255
    }	ITC_MICRO_PDF417_DECODING;

typedef 
enum tagMicroPdf417Code128Emulation
    {	ITC_MICRO_PDF417_CODE128_NOTACTIVE	= 0,
	ITC_MICRO_PDF417_CODE128_ACTIVE	= 1,
	ITC_MICRO_PDF417_CODE128_NO_CHANGE	= 255
    }	ITC_MICRO_PDF417_CODE128_EMULATION;


EXTERN_C const IID IID_IS9CConfig2;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    interface DECLSPEC_UUID("61174F24-6B13-480B-A8F2-9F79AE0462A0")
    IS9CConfig2 : public IS9CConfig
    {
    public:
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetSymIdXmit( 
            /* [out] */ ITC_SYMBOLOGY_ID_XMIT __RPC_FAR *peSymIdXmit) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetSymIdXmit( 
            /* [in] */ ITC_SYMBOLOGY_ID_XMIT eSymIdXmit) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetCustomSymIds( 
            /* [out] */ ITC_CUST_SYM_ID_PAIR __RPC_FAR *pStructSymIdPair,
            /* [in] */ DWORD dwMaxNumElement,
            /* [out] */ DWORD __RPC_FAR *pdwNumElement) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetCustomSymIds( 
            /* [in] */ ITC_CUST_SYM_ID_PAIR __RPC_FAR *pStructSymIdPair,
            /* [in] */ DWORD dwNumElement) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetTriggerSetting( 
            /* [in] */ ITC_TRIGGER_SETTING_ID eId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetTriggerSetting( 
            /* [in] */ ITC_TRIGGER_SETTING_ID eId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetGlobalAmble( 
            /* [in] */ ITC_GLOBAL_AMBLE_ID eAmbleId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize,
            /* [out] */ DWORD __RPC_FAR *pdwBufferSize) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetGlobalAmble( 
            /* [in] */ ITC_GLOBAL_AMBLE_ID eAmbleId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetDecodeSecurity( 
            /* [in] */ ITC_DECODE_SEC_ID eSecurityId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetDecodeSecurity( 
            /* [in] */ ITC_DECODE_SEC_ID eSecurityId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetScanEngineInfo( 
            /* [out][in] */ ITC_SCAN_ENGINE_INFO __RPC_FAR *pInfoBuffer,
            /* [in] */ DWORD dwInfoBufferSize) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetCode11( 
            /* [out] */ ITC_CODE11_DECODING __RPC_FAR *peDecode,
            /* [out] */ ITC_CODE11_CHECK_DIGIT __RPC_FAR *peCheck,
            /* [out] */ ITC_CODE11_CHECK_VERIFICATION __RPC_FAR *peVer) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetCode11( 
            /* [in] */ ITC_CODE11_DECODING eDecode,
            /* [in] */ ITC_CODE11_CHECK_DIGIT eCheck,
            /* [in] */ ITC_CODE11_CHECK_VERIFICATION eVer) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetPDF417Ext( 
            /* [out] */ ITC_MICRO_PDF417_DECODING __RPC_FAR *peDecode,
            /* [out] */ ITC_MICRO_PDF417_CODE128_EMULATION __RPC_FAR *eCode128) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetPDF417Ext( 
            /* [in] */ ITC_MICRO_PDF417_DECODING eDecode,
            /* [in] */ ITC_MICRO_PDF417_CODE128_EMULATION eCode128) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IS9CConfig2Vtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IS9CConfig2 __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IS9CConfig2 __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Initialize )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [string][in] */ LPCTSTR pszDeviceName,
            /* [in] */ ITC_DEVICE_FLAGS eDeviceFlags);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Read )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [size_is][out][in] */ BYTE __RPC_FAR rgbDataBuffer[  ],
            /* [in] */ DWORD dwDataBufferSize,
            /* [out] */ DWORD __RPC_FAR *pnBytesReturned,
            /* [out][in] */ ITC_BARCODE_DATA_DETAILS __RPC_FAR *pBarCodeDataDetails,
            /* [in] */ DWORD dwTimeout);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *CancelReadRequest )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ BOOL FlushBufferedData,
            /* [out][in] */ WORD __RPC_FAR *pwTotalDiscardedMessages,
            /* [out][in] */ DWORD __RPC_FAR *pdwTotalDiscardedBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryAttribute )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_BARCODEREADER_ATTRIBUTE_ID eAttr,
            /* [size_is][out] */ BYTE __RPC_FAR rgbAttrBuffer[  ],
            /* [in] */ DWORD dwAttrBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetAttribute )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_BARCODEREADER_ATTRIBUTE_ID eAttr,
            /* [size_is][out] */ BYTE __RPC_FAR rgbAttrBuffer[  ],
            /* [in] */ DWORD dwAttrBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *TriggerScanner )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ BOOL fScannerOn);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *IssueBeep )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [size_is][in] */ ITC_BEEP_SPEC __RPC_FAR rgBeepRequests[  ],
            /* [in] */ DWORD dwNumberOfBeeps);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Reset )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ BOOL fWarmReset);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ControlLED )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_BARCODE_LASER_LED_ID eLED,
            /* [in] */ BOOL fLedOn);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetConfig )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ LPCTSTR pszConfig);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetConfig )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [size_is][out][in] */ TCHAR __RPC_FAR rgszConfig[  ],
            /* [in] */ DWORD ncConfigBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetStatistics )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [out][in] */ ITC_BARCODEREADER_STATISTICS __RPC_FAR *pStatsBuffer,
            /* [in] */ DWORD dwStatsBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ResetStatistics )( 
            IS9CConfig2 __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetAnalysis )( 
            IS9CConfig2 __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ReadAnalysis )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [size_is][out] */ BYTE __RPC_FAR rgbAnalysisBuffer[  ],
            /* [in] */ DWORD dwAnalysisBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *DownloadBarCodeReader )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ LPCTSTR pszReaderProgramFile);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetSystemInfo )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [out][in] */ ITC_BARC0DEREADER_SYSTEM_INFO __RPC_FAR *pSysInfoBuffer,
            /* [in] */ DWORD dwSysInfoBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetCode39 )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [out] */ ITC_CODE39_DECODING __RPC_FAR *c39Decode,
            /* [out] */ ITC_CODE39_FORMAT __RPC_FAR *c39Format,
            /* [out] */ ITC_CODE39_START_STOP __RPC_FAR *c39SS,
            /* [out] */ ITC_CODE39_SS_CHARS __RPC_FAR *c39SSChars,
            /* [out] */ ITC_CODE39_CHECK_DIGIT __RPC_FAR *c39Check,
            /* [out] */ DWORD __RPC_FAR *c39Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetCode39 )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_CODE39_DECODING c39Decode,
            /* [in] */ ITC_CODE39_FORMAT c39Format,
            /* [in] */ ITC_CODE39_START_STOP c39SS,
            /* [in] */ ITC_CODE39_SS_CHARS c39SSChars,
            /* [in] */ ITC_CODE39_CHECK_DIGIT c39Check,
            /* [in] */ DWORD c39Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetCodabar )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [out] */ ITC_CODABAR_DECODING __RPC_FAR *cbarDecode,
            /* [out] */ ITC_CODABAR_START_STOP __RPC_FAR *cbarSS,
            /* [out] */ ITC_CODABAR_CLSI __RPC_FAR *cbarCLSI,
            /* [out] */ ITC_CODABAR_CHECK_DIGIT __RPC_FAR *cbarCheck,
            /* [out] */ ITC_BARCODE_LENGTH_ID __RPC_FAR *eLengthId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [out] */ DWORD __RPC_FAR *pdwNumBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetCodabar )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_CODABAR_DECODING cbarDecode,
            /* [in] */ ITC_CODABAR_START_STOP cbarSS,
            /* [in] */ ITC_CODABAR_CLSI cbarCLSI,
            /* [in] */ ITC_CODABAR_CHECK_DIGIT cbarCheck,
            /* [in] */ ITC_BARCODE_LENGTH_ID eLengthId,
            /* [size_is][in] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [in] */ DWORD dwNumBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetCode93 )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [out] */ ITC_CODE93_DECODING __RPC_FAR *c93Decode,
            /* [out] */ DWORD __RPC_FAR *c93Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetCode93 )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_CODE93_DECODING c93Decode,
            /* [in] */ DWORD c93Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetCode128 )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [out] */ ITC_CODE128_DECODING __RPC_FAR *c128Decode,
            /* [out] */ ITC_EAN128_IDENTIFIER __RPC_FAR *ean128Ident,
            /* [out] */ ITC_CODE128_CIP128 __RPC_FAR *cip128State,
            /* [out] */ BYTE __RPC_FAR *c128FNC1,
            /* [out] */ DWORD __RPC_FAR *c128Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetCode128 )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_CODE128_DECODING c128Decode,
            /* [in] */ ITC_EAN128_IDENTIFIER ean128Ident,
            /* [in] */ ITC_CODE128_CIP128 cip128State,
            /* [in] */ BYTE c128FNC1,
            /* [in] */ DWORD c128Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetI2of5 )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [out] */ ITC_INTERLEAVED2OF5_DECODING __RPC_FAR *i2of5Decode,
            /* [out] */ ITC_INTERLEAVED2OF5_CHECK_DIGIT __RPC_FAR *i2of5Check,
            /* [out] */ ITC_BARCODE_LENGTH_ID __RPC_FAR *eLengthId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [out] */ DWORD __RPC_FAR *pdwNumBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetI2of5 )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_INTERLEAVED2OF5_DECODING i2of5Decode,
            /* [in] */ ITC_INTERLEAVED2OF5_CHECK_DIGIT i2of5Check,
            /* [in] */ ITC_BARCODE_LENGTH_ID eLengthId,
            /* [size_is][in] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [in] */ DWORD dwNumBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetMatrix2of5 )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [out] */ ITC_MATRIX2OF5_DECODING __RPC_FAR *m2of5Decode,
            /* [out] */ DWORD __RPC_FAR *m2of5Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetMatrix2of5 )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_MATRIX2OF5_DECODING m2of5Decode,
            /* [in] */ DWORD m2of5Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetMSI )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [out] */ ITC_MSI_DECODING __RPC_FAR *msiDecode,
            /* [out] */ ITC_MSI_CHECK_DIGIT __RPC_FAR *msiCheck,
            /* [out] */ DWORD __RPC_FAR *msiLength);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetMSI )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_MSI_DECODING msiDecode,
            /* [in] */ ITC_MSI_CHECK_DIGIT msiCheck,
            /* [in] */ DWORD msiLength);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetPDF417 )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [out] */ ITC_PDF417_DECODING __RPC_FAR *pdf417Decode,
            /* [out] */ ITC_PDF417_MACRO_PDF __RPC_FAR *macroPdf,
            /* [out] */ ITC_PDF417_CTRL_HEADER __RPC_FAR *pdfControlHeader,
            /* [out] */ ITC_PDF417_FILE_NAME __RPC_FAR *pdfFileName,
            /* [out] */ ITC_PDF417_SEGMENT_COUNT __RPC_FAR *pdfSegmentCount,
            /* [out] */ ITC_PDF417_TIME_STAMP __RPC_FAR *pdfTimeStamp,
            /* [out] */ ITC_PDF417_SENDER __RPC_FAR *pdfSender,
            /* [out] */ ITC_PDF417_ADDRESSEE __RPC_FAR *pdfAddressee,
            /* [out] */ ITC_PDF417_FILE_SIZE __RPC_FAR *pdfFileSize,
            /* [out] */ ITC_PDF417_CHECKSUM __RPC_FAR *pdfChecksum);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetPDF417 )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_PDF417_DECODING pdf417Decode,
            /* [in] */ ITC_PDF417_MACRO_PDF macroPdf,
            /* [in] */ ITC_PDF417_CTRL_HEADER pdfControlHeader,
            /* [in] */ ITC_PDF417_FILE_NAME pdfFileName,
            /* [in] */ ITC_PDF417_SEGMENT_COUNT pdfSegmentCount,
            /* [in] */ ITC_PDF417_TIME_STAMP pdfTimeStamp,
            /* [in] */ ITC_PDF417_SENDER pdfSender,
            /* [in] */ ITC_PDF417_ADDRESSEE pdfAddressee,
            /* [in] */ ITC_PDF417_FILE_SIZE pdfFileSize,
            /* [in] */ ITC_PDF417_CHECKSUM pdfChecksum);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetPlessey )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [out] */ ITC_PLESSEY_DECODING __RPC_FAR *plesseyDecode,
            /* [out] */ ITC_PLESSEY_CHECK_DIGIT __RPC_FAR *plesseyCheck,
            /* [out] */ DWORD __RPC_FAR *plesseyLength);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetPlessey )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_PLESSEY_DECODING plesseyDecode,
            /* [in] */ ITC_PLESSEY_CHECK_DIGIT plesseyCheck,
            /* [in] */ DWORD plesseyLength);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetStandard2of5 )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [out] */ ITC_STANDARD2OF5_DECODING __RPC_FAR *s2of5Decode,
            /* [out] */ ITC_STANDARD2OF5_FORMAT __RPC_FAR *s2of5Format,
            /* [out] */ ITC_STANDARD2OF5_CHECK_DIGIT __RPC_FAR *s2of5Check,
            /* [out] */ ITC_BARCODE_LENGTH_ID __RPC_FAR *eBarcodeLengthId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [out] */ DWORD __RPC_FAR *pdwNumBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetStandard2of5 )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_STANDARD2OF5_DECODING s2of5Decode,
            /* [in] */ ITC_STANDARD2OF5_FORMAT s2of5Format,
            /* [in] */ ITC_STANDARD2OF5_CHECK_DIGIT s2of5Check,
            /* [in] */ ITC_BARCODE_LENGTH_ID eLengthId,
            /* [size_is][in] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [in] */ DWORD dwNumBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTelepen )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [out] */ ITC_TELEPEN_DECODING __RPC_FAR *telepenDecode,
            /* [out] */ ITC_TELEPEN_FORMAT __RPC_FAR *telepenFormat);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetTelepen )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_TELEPEN_DECODING telepenDecode,
            /* [in] */ ITC_TELEPEN_FORMAT telepenFormat);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetUpcEan )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [out] */ ITC_UPCEAN_DECODING __RPC_FAR *upceanDecode,
            /* [out] */ ITC_UPCA_SELECT __RPC_FAR *upcASelect,
            /* [out] */ ITC_UPCE_SELECT __RPC_FAR *upcESelect,
            /* [out] */ ITC_EAN8_SELECT __RPC_FAR *ean8Select,
            /* [out] */ ITC_EAN13_SELECT __RPC_FAR *ean13Select,
            /* [out] */ ITC_UPCEAN_ADDON_DIGITS __RPC_FAR *upcAddOnDigits,
            /* [out] */ ITC_UPCEAN_ADDON_TWO __RPC_FAR *upcAddOn2,
            /* [out] */ ITC_UPCEAN_ADDON_FIVE __RPC_FAR *upcAddOn5,
            /* [out] */ ITC_UPCA_CHECK_DIGIT __RPC_FAR *upcACheck,
            /* [out] */ ITC_UPCE_CHECK_DIGIT __RPC_FAR *upcECheck,
            /* [out] */ ITC_EAN8_CHECK_DIGIT __RPC_FAR *ean8Check,
            /* [out] */ ITC_EAN13_CHECK_DIGIT __RPC_FAR *ean13Check,
            /* [out] */ ITC_UPCA_NUMBER_SYSTEM __RPC_FAR *upcANumSystem,
            /* [out] */ ITC_UPCE_NUMBER_SYSTEM __RPC_FAR *upcENumSystem,
            /* [out] */ ITC_UPCA_REENCODE __RPC_FAR *upcAReencode,
            /* [out] */ ITC_UPCE_REENCODE __RPC_FAR *upcEReencode,
            /* [out] */ ITC_EAN8_REENCODE __RPC_FAR *ean8Reencode);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetUpcEan )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_UPCEAN_DECODING upceanDecode,
            /* [in] */ ITC_UPCA_SELECT upcASelect,
            /* [in] */ ITC_UPCE_SELECT upcESelect,
            /* [in] */ ITC_EAN8_SELECT ean8Select,
            /* [in] */ ITC_EAN13_SELECT ean13Select,
            /* [in] */ ITC_UPCEAN_ADDON_DIGITS upcAddOnDigits,
            /* [in] */ ITC_UPCEAN_ADDON_TWO upcAddOn2,
            /* [in] */ ITC_UPCEAN_ADDON_FIVE upcAddOn5,
            /* [in] */ ITC_UPCA_CHECK_DIGIT upcACheck,
            /* [in] */ ITC_UPCE_CHECK_DIGIT upcECheck,
            /* [in] */ ITC_EAN8_CHECK_DIGIT ean8Check,
            /* [in] */ ITC_EAN13_CHECK_DIGIT ean13Check,
            /* [in] */ ITC_UPCA_NUMBER_SYSTEM upcANumSystem,
            /* [in] */ ITC_UPCE_NUMBER_SYSTEM upcENumSystem,
            /* [in] */ ITC_UPCA_REENCODE upcAReencode,
            /* [in] */ ITC_UPCE_REENCODE upcEReencode,
            /* [in] */ ITC_EAN8_REENCODE ean8Reencode);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetSymIdXmit )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [out] */ ITC_SYMBOLOGY_ID_XMIT __RPC_FAR *peSymIdXmit);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetSymIdXmit )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_SYMBOLOGY_ID_XMIT eSymIdXmit);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetCustomSymIds )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [out] */ ITC_CUST_SYM_ID_PAIR __RPC_FAR *pStructSymIdPair,
            /* [in] */ DWORD dwMaxNumElement,
            /* [out] */ DWORD __RPC_FAR *pdwNumElement);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetCustomSymIds )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_CUST_SYM_ID_PAIR __RPC_FAR *pStructSymIdPair,
            /* [in] */ DWORD dwNumElement);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTriggerSetting )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_TRIGGER_SETTING_ID eId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetTriggerSetting )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_TRIGGER_SETTING_ID eId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetGlobalAmble )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_GLOBAL_AMBLE_ID eAmbleId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize,
            /* [out] */ DWORD __RPC_FAR *pdwBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetGlobalAmble )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_GLOBAL_AMBLE_ID eAmbleId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetDecodeSecurity )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_DECODE_SEC_ID eSecurityId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetDecodeSecurity )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_DECODE_SEC_ID eSecurityId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetScanEngineInfo )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [out][in] */ ITC_SCAN_ENGINE_INFO __RPC_FAR *pInfoBuffer,
            /* [in] */ DWORD dwInfoBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetCode11 )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [out] */ ITC_CODE11_DECODING __RPC_FAR *peDecode,
            /* [out] */ ITC_CODE11_CHECK_DIGIT __RPC_FAR *peCheck,
            /* [out] */ ITC_CODE11_CHECK_VERIFICATION __RPC_FAR *peVer);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetCode11 )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_CODE11_DECODING eDecode,
            /* [in] */ ITC_CODE11_CHECK_DIGIT eCheck,
            /* [in] */ ITC_CODE11_CHECK_VERIFICATION eVer);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetPDF417Ext )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [out] */ ITC_MICRO_PDF417_DECODING __RPC_FAR *peDecode,
            /* [out] */ ITC_MICRO_PDF417_CODE128_EMULATION __RPC_FAR *eCode128);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetPDF417Ext )( 
            IS9CConfig2 __RPC_FAR * This,
            /* [in] */ ITC_MICRO_PDF417_DECODING eDecode,
            /* [in] */ ITC_MICRO_PDF417_CODE128_EMULATION eCode128);
        
        END_INTERFACE
    } IS9CConfig2Vtbl;

    interface IS9CConfig2
    {
        CONST_VTBL struct IS9CConfig2Vtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IS9CConfig2_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IS9CConfig2_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IS9CConfig2_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IS9CConfig2_Initialize(This,pszDeviceName,eDeviceFlags)	\
    (This)->lpVtbl -> Initialize(This,pszDeviceName,eDeviceFlags)

#define IS9CConfig2_Read(This,rgbDataBuffer,dwDataBufferSize,pnBytesReturned,pBarCodeDataDetails,dwTimeout)	\
    (This)->lpVtbl -> Read(This,rgbDataBuffer,dwDataBufferSize,pnBytesReturned,pBarCodeDataDetails,dwTimeout)

#define IS9CConfig2_CancelReadRequest(This,FlushBufferedData,pwTotalDiscardedMessages,pdwTotalDiscardedBytes)	\
    (This)->lpVtbl -> CancelReadRequest(This,FlushBufferedData,pwTotalDiscardedMessages,pdwTotalDiscardedBytes)

#define IS9CConfig2_QueryAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)	\
    (This)->lpVtbl -> QueryAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)

#define IS9CConfig2_SetAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)	\
    (This)->lpVtbl -> SetAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)

#define IS9CConfig2_TriggerScanner(This,fScannerOn)	\
    (This)->lpVtbl -> TriggerScanner(This,fScannerOn)

#define IS9CConfig2_IssueBeep(This,rgBeepRequests,dwNumberOfBeeps)	\
    (This)->lpVtbl -> IssueBeep(This,rgBeepRequests,dwNumberOfBeeps)

#define IS9CConfig2_Reset(This,fWarmReset)	\
    (This)->lpVtbl -> Reset(This,fWarmReset)

#define IS9CConfig2_ControlLED(This,eLED,fLedOn)	\
    (This)->lpVtbl -> ControlLED(This,eLED,fLedOn)


#define IS9CConfig2_SetConfig(This,pszConfig)	\
    (This)->lpVtbl -> SetConfig(This,pszConfig)

#define IS9CConfig2_GetConfig(This,rgszConfig,ncConfigBufferSize)	\
    (This)->lpVtbl -> GetConfig(This,rgszConfig,ncConfigBufferSize)

#define IS9CConfig2_GetStatistics(This,pStatsBuffer,dwStatsBufferSize)	\
    (This)->lpVtbl -> GetStatistics(This,pStatsBuffer,dwStatsBufferSize)

#define IS9CConfig2_ResetStatistics(This)	\
    (This)->lpVtbl -> ResetStatistics(This)

#define IS9CConfig2_SetAnalysis(This)	\
    (This)->lpVtbl -> SetAnalysis(This)

#define IS9CConfig2_ReadAnalysis(This,rgbAnalysisBuffer,dwAnalysisBufferSize)	\
    (This)->lpVtbl -> ReadAnalysis(This,rgbAnalysisBuffer,dwAnalysisBufferSize)

#define IS9CConfig2_DownloadBarCodeReader(This,pszReaderProgramFile)	\
    (This)->lpVtbl -> DownloadBarCodeReader(This,pszReaderProgramFile)

#define IS9CConfig2_GetSystemInfo(This,pSysInfoBuffer,dwSysInfoBufferSize)	\
    (This)->lpVtbl -> GetSystemInfo(This,pSysInfoBuffer,dwSysInfoBufferSize)


#define IS9CConfig2_GetCode39(This,c39Decode,c39Format,c39SS,c39SSChars,c39Check,c39Length)	\
    (This)->lpVtbl -> GetCode39(This,c39Decode,c39Format,c39SS,c39SSChars,c39Check,c39Length)

#define IS9CConfig2_SetCode39(This,c39Decode,c39Format,c39SS,c39SSChars,c39Check,c39Length)	\
    (This)->lpVtbl -> SetCode39(This,c39Decode,c39Format,c39SS,c39SSChars,c39Check,c39Length)

#define IS9CConfig2_GetCodabar(This,cbarDecode,cbarSS,cbarCLSI,cbarCheck,eLengthId,rgbLengthBuff,pdwNumBytes)	\
    (This)->lpVtbl -> GetCodabar(This,cbarDecode,cbarSS,cbarCLSI,cbarCheck,eLengthId,rgbLengthBuff,pdwNumBytes)

#define IS9CConfig2_SetCodabar(This,cbarDecode,cbarSS,cbarCLSI,cbarCheck,eLengthId,rgbLengthBuff,dwNumBytes)	\
    (This)->lpVtbl -> SetCodabar(This,cbarDecode,cbarSS,cbarCLSI,cbarCheck,eLengthId,rgbLengthBuff,dwNumBytes)

#define IS9CConfig2_GetCode93(This,c93Decode,c93Length)	\
    (This)->lpVtbl -> GetCode93(This,c93Decode,c93Length)

#define IS9CConfig2_SetCode93(This,c93Decode,c93Length)	\
    (This)->lpVtbl -> SetCode93(This,c93Decode,c93Length)

#define IS9CConfig2_GetCode128(This,c128Decode,ean128Ident,cip128State,c128FNC1,c128Length)	\
    (This)->lpVtbl -> GetCode128(This,c128Decode,ean128Ident,cip128State,c128FNC1,c128Length)

#define IS9CConfig2_SetCode128(This,c128Decode,ean128Ident,cip128State,c128FNC1,c128Length)	\
    (This)->lpVtbl -> SetCode128(This,c128Decode,ean128Ident,cip128State,c128FNC1,c128Length)

#define IS9CConfig2_GetI2of5(This,i2of5Decode,i2of5Check,eLengthId,rgbLengthBuff,pdwNumBytes)	\
    (This)->lpVtbl -> GetI2of5(This,i2of5Decode,i2of5Check,eLengthId,rgbLengthBuff,pdwNumBytes)

#define IS9CConfig2_SetI2of5(This,i2of5Decode,i2of5Check,eLengthId,rgbLengthBuff,dwNumBytes)	\
    (This)->lpVtbl -> SetI2of5(This,i2of5Decode,i2of5Check,eLengthId,rgbLengthBuff,dwNumBytes)

#define IS9CConfig2_GetMatrix2of5(This,m2of5Decode,m2of5Length)	\
    (This)->lpVtbl -> GetMatrix2of5(This,m2of5Decode,m2of5Length)

#define IS9CConfig2_SetMatrix2of5(This,m2of5Decode,m2of5Length)	\
    (This)->lpVtbl -> SetMatrix2of5(This,m2of5Decode,m2of5Length)

#define IS9CConfig2_GetMSI(This,msiDecode,msiCheck,msiLength)	\
    (This)->lpVtbl -> GetMSI(This,msiDecode,msiCheck,msiLength)

#define IS9CConfig2_SetMSI(This,msiDecode,msiCheck,msiLength)	\
    (This)->lpVtbl -> SetMSI(This,msiDecode,msiCheck,msiLength)

#define IS9CConfig2_GetPDF417(This,pdf417Decode,macroPdf,pdfControlHeader,pdfFileName,pdfSegmentCount,pdfTimeStamp,pdfSender,pdfAddressee,pdfFileSize,pdfChecksum)	\
    (This)->lpVtbl -> GetPDF417(This,pdf417Decode,macroPdf,pdfControlHeader,pdfFileName,pdfSegmentCount,pdfTimeStamp,pdfSender,pdfAddressee,pdfFileSize,pdfChecksum)

#define IS9CConfig2_SetPDF417(This,pdf417Decode,macroPdf,pdfControlHeader,pdfFileName,pdfSegmentCount,pdfTimeStamp,pdfSender,pdfAddressee,pdfFileSize,pdfChecksum)	\
    (This)->lpVtbl -> SetPDF417(This,pdf417Decode,macroPdf,pdfControlHeader,pdfFileName,pdfSegmentCount,pdfTimeStamp,pdfSender,pdfAddressee,pdfFileSize,pdfChecksum)

#define IS9CConfig2_GetPlessey(This,plesseyDecode,plesseyCheck,plesseyLength)	\
    (This)->lpVtbl -> GetPlessey(This,plesseyDecode,plesseyCheck,plesseyLength)

#define IS9CConfig2_SetPlessey(This,plesseyDecode,plesseyCheck,plesseyLength)	\
    (This)->lpVtbl -> SetPlessey(This,plesseyDecode,plesseyCheck,plesseyLength)

#define IS9CConfig2_GetStandard2of5(This,s2of5Decode,s2of5Format,s2of5Check,eBarcodeLengthId,rgbLengthBuff,pdwNumBytes)	\
    (This)->lpVtbl -> GetStandard2of5(This,s2of5Decode,s2of5Format,s2of5Check,eBarcodeLengthId,rgbLengthBuff,pdwNumBytes)

#define IS9CConfig2_SetStandard2of5(This,s2of5Decode,s2of5Format,s2of5Check,eLengthId,rgbLengthBuff,dwNumBytes)	\
    (This)->lpVtbl -> SetStandard2of5(This,s2of5Decode,s2of5Format,s2of5Check,eLengthId,rgbLengthBuff,dwNumBytes)

#define IS9CConfig2_GetTelepen(This,telepenDecode,telepenFormat)	\
    (This)->lpVtbl -> GetTelepen(This,telepenDecode,telepenFormat)

#define IS9CConfig2_SetTelepen(This,telepenDecode,telepenFormat)	\
    (This)->lpVtbl -> SetTelepen(This,telepenDecode,telepenFormat)

#define IS9CConfig2_GetUpcEan(This,upceanDecode,upcASelect,upcESelect,ean8Select,ean13Select,upcAddOnDigits,upcAddOn2,upcAddOn5,upcACheck,upcECheck,ean8Check,ean13Check,upcANumSystem,upcENumSystem,upcAReencode,upcEReencode,ean8Reencode)	\
    (This)->lpVtbl -> GetUpcEan(This,upceanDecode,upcASelect,upcESelect,ean8Select,ean13Select,upcAddOnDigits,upcAddOn2,upcAddOn5,upcACheck,upcECheck,ean8Check,ean13Check,upcANumSystem,upcENumSystem,upcAReencode,upcEReencode,ean8Reencode)

#define IS9CConfig2_SetUpcEan(This,upceanDecode,upcASelect,upcESelect,ean8Select,ean13Select,upcAddOnDigits,upcAddOn2,upcAddOn5,upcACheck,upcECheck,ean8Check,ean13Check,upcANumSystem,upcENumSystem,upcAReencode,upcEReencode,ean8Reencode)	\
    (This)->lpVtbl -> SetUpcEan(This,upceanDecode,upcASelect,upcESelect,ean8Select,ean13Select,upcAddOnDigits,upcAddOn2,upcAddOn5,upcACheck,upcECheck,ean8Check,ean13Check,upcANumSystem,upcENumSystem,upcAReencode,upcEReencode,ean8Reencode)


#define IS9CConfig2_GetSymIdXmit(This,peSymIdXmit)	\
    (This)->lpVtbl -> GetSymIdXmit(This,peSymIdXmit)

#define IS9CConfig2_SetSymIdXmit(This,eSymIdXmit)	\
    (This)->lpVtbl -> SetSymIdXmit(This,eSymIdXmit)

#define IS9CConfig2_GetCustomSymIds(This,pStructSymIdPair,dwMaxNumElement,pdwNumElement)	\
    (This)->lpVtbl -> GetCustomSymIds(This,pStructSymIdPair,dwMaxNumElement,pdwNumElement)

#define IS9CConfig2_SetCustomSymIds(This,pStructSymIdPair,dwNumElement)	\
    (This)->lpVtbl -> SetCustomSymIds(This,pStructSymIdPair,dwNumElement)

#define IS9CConfig2_GetTriggerSetting(This,eId,rgbBuffer,dwBufferSize)	\
    (This)->lpVtbl -> GetTriggerSetting(This,eId,rgbBuffer,dwBufferSize)

#define IS9CConfig2_SetTriggerSetting(This,eId,rgbBuffer,dwBufferSize)	\
    (This)->lpVtbl -> SetTriggerSetting(This,eId,rgbBuffer,dwBufferSize)

#define IS9CConfig2_GetGlobalAmble(This,eAmbleId,rgbBuffer,dwBufferSize,pdwBufferSize)	\
    (This)->lpVtbl -> GetGlobalAmble(This,eAmbleId,rgbBuffer,dwBufferSize,pdwBufferSize)

#define IS9CConfig2_SetGlobalAmble(This,eAmbleId,rgbBuffer,dwBufferSize)	\
    (This)->lpVtbl -> SetGlobalAmble(This,eAmbleId,rgbBuffer,dwBufferSize)

#define IS9CConfig2_GetDecodeSecurity(This,eSecurityId,rgbBuffer,dwBufferSize)	\
    (This)->lpVtbl -> GetDecodeSecurity(This,eSecurityId,rgbBuffer,dwBufferSize)

#define IS9CConfig2_SetDecodeSecurity(This,eSecurityId,rgbBuffer,dwBufferSize)	\
    (This)->lpVtbl -> SetDecodeSecurity(This,eSecurityId,rgbBuffer,dwBufferSize)

#define IS9CConfig2_GetScanEngineInfo(This,pInfoBuffer,dwInfoBufferSize)	\
    (This)->lpVtbl -> GetScanEngineInfo(This,pInfoBuffer,dwInfoBufferSize)

#define IS9CConfig2_GetCode11(This,peDecode,peCheck,peVer)	\
    (This)->lpVtbl -> GetCode11(This,peDecode,peCheck,peVer)

#define IS9CConfig2_SetCode11(This,eDecode,eCheck,eVer)	\
    (This)->lpVtbl -> SetCode11(This,eDecode,eCheck,eVer)

#define IS9CConfig2_GetPDF417Ext(This,peDecode,eCode128)	\
    (This)->lpVtbl -> GetPDF417Ext(This,peDecode,eCode128)

#define IS9CConfig2_SetPDF417Ext(This,eDecode,eCode128)	\
    (This)->lpVtbl -> SetPDF417Ext(This,eDecode,eCode128)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig2_GetSymIdXmit_Proxy( 
    IS9CConfig2 __RPC_FAR * This,
    /* [out] */ ITC_SYMBOLOGY_ID_XMIT __RPC_FAR *peSymIdXmit);


void __RPC_STUB IS9CConfig2_GetSymIdXmit_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig2_SetSymIdXmit_Proxy( 
    IS9CConfig2 __RPC_FAR * This,
    /* [in] */ ITC_SYMBOLOGY_ID_XMIT eSymIdXmit);


void __RPC_STUB IS9CConfig2_SetSymIdXmit_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig2_GetCustomSymIds_Proxy( 
    IS9CConfig2 __RPC_FAR * This,
    /* [out] */ ITC_CUST_SYM_ID_PAIR __RPC_FAR *pStructSymIdPair,
    /* [in] */ DWORD dwMaxNumElement,
    /* [out] */ DWORD __RPC_FAR *pdwNumElement);


void __RPC_STUB IS9CConfig2_GetCustomSymIds_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig2_SetCustomSymIds_Proxy( 
    IS9CConfig2 __RPC_FAR * This,
    /* [in] */ ITC_CUST_SYM_ID_PAIR __RPC_FAR *pStructSymIdPair,
    /* [in] */ DWORD dwNumElement);


void __RPC_STUB IS9CConfig2_SetCustomSymIds_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig2_GetTriggerSetting_Proxy( 
    IS9CConfig2 __RPC_FAR * This,
    /* [in] */ ITC_TRIGGER_SETTING_ID eId,
    /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
    /* [in] */ DWORD dwBufferSize);


void __RPC_STUB IS9CConfig2_GetTriggerSetting_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig2_SetTriggerSetting_Proxy( 
    IS9CConfig2 __RPC_FAR * This,
    /* [in] */ ITC_TRIGGER_SETTING_ID eId,
    /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
    /* [in] */ DWORD dwBufferSize);


void __RPC_STUB IS9CConfig2_SetTriggerSetting_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig2_GetGlobalAmble_Proxy( 
    IS9CConfig2 __RPC_FAR * This,
    /* [in] */ ITC_GLOBAL_AMBLE_ID eAmbleId,
    /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
    /* [in] */ DWORD dwBufferSize,
    /* [out] */ DWORD __RPC_FAR *pdwBufferSize);


void __RPC_STUB IS9CConfig2_GetGlobalAmble_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig2_SetGlobalAmble_Proxy( 
    IS9CConfig2 __RPC_FAR * This,
    /* [in] */ ITC_GLOBAL_AMBLE_ID eAmbleId,
    /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
    /* [in] */ DWORD dwBufferSize);


void __RPC_STUB IS9CConfig2_SetGlobalAmble_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig2_GetDecodeSecurity_Proxy( 
    IS9CConfig2 __RPC_FAR * This,
    /* [in] */ ITC_DECODE_SEC_ID eSecurityId,
    /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
    /* [in] */ DWORD dwBufferSize);


void __RPC_STUB IS9CConfig2_GetDecodeSecurity_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig2_SetDecodeSecurity_Proxy( 
    IS9CConfig2 __RPC_FAR * This,
    /* [in] */ ITC_DECODE_SEC_ID eSecurityId,
    /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
    /* [in] */ DWORD dwBufferSize);


void __RPC_STUB IS9CConfig2_SetDecodeSecurity_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig2_GetScanEngineInfo_Proxy( 
    IS9CConfig2 __RPC_FAR * This,
    /* [out][in] */ ITC_SCAN_ENGINE_INFO __RPC_FAR *pInfoBuffer,
    /* [in] */ DWORD dwInfoBufferSize);


void __RPC_STUB IS9CConfig2_GetScanEngineInfo_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig2_GetCode11_Proxy( 
    IS9CConfig2 __RPC_FAR * This,
    /* [out] */ ITC_CODE11_DECODING __RPC_FAR *peDecode,
    /* [out] */ ITC_CODE11_CHECK_DIGIT __RPC_FAR *peCheck,
    /* [out] */ ITC_CODE11_CHECK_VERIFICATION __RPC_FAR *peVer);


void __RPC_STUB IS9CConfig2_GetCode11_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig2_SetCode11_Proxy( 
    IS9CConfig2 __RPC_FAR * This,
    /* [in] */ ITC_CODE11_DECODING eDecode,
    /* [in] */ ITC_CODE11_CHECK_DIGIT eCheck,
    /* [in] */ ITC_CODE11_CHECK_VERIFICATION eVer);


void __RPC_STUB IS9CConfig2_SetCode11_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig2_GetPDF417Ext_Proxy( 
    IS9CConfig2 __RPC_FAR * This,
    /* [out] */ ITC_MICRO_PDF417_DECODING __RPC_FAR *peDecode,
    /* [out] */ ITC_MICRO_PDF417_CODE128_EMULATION __RPC_FAR *eCode128);


void __RPC_STUB IS9CConfig2_GetPDF417Ext_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig2_SetPDF417Ext_Proxy( 
    IS9CConfig2 __RPC_FAR * This,
    /* [in] */ ITC_MICRO_PDF417_DECODING eDecode,
    /* [in] */ ITC_MICRO_PDF417_CODE128_EMULATION eCode128);


void __RPC_STUB IS9CConfig2_SetPDF417Ext_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IS9CConfig2_INTERFACE_DEFINED__ */


#ifndef __IS9CConfig3_INTERFACE_DEFINED__
#define __IS9CConfig3_INTERFACE_DEFINED__

/****************************************
 * Generated header for interface: IS9CConfig3
 * at Fri Nov 08 13:57:56 2002
 * using MIDL 3.02.88
 ****************************************/
/* [unique][helpstring][uuid][object] */ 


typedef 
enum tagISCPType
    {	ITC_ISCP_SETUP_READ	= 0x40,
	ITC_ISCP_SETUP_WRITE	= 0x41,
	ITC_ISCP_CONTROL_COMMAND	= 0x43,
	ITC_ISCP_STATUS_READ	= 0x44,
	ITC_ISCP_SETUP_REPLY	= 0x50,
	ITC_ISCP_RESULT	= 0x51,
	ITC_ISCP_STATUS_REPLY	= 0x53
    }	ITC_ISCP_TYPE;

typedef 
enum tagISCPSetupGroup
    {	ITC_ISCP_SETUP_GROUP_AZTEC	= 0x53,
	ITC_ISCP_SETUP_GROUP_BCC412	= 0x58,
	ITC_ISCP_SETUP_GROUP_CODABAR	= 0x40,
	ITC_ISCP_SETUP_GROUP_CODABLOCK	= 0x4d,
	ITC_ISCP_SETUP_GROUP_CODE11	= 0x4a,
	ITC_ISCP_SETUP_GROUP_CODE16K	= 0x51,
	ITC_ISCP_SETUP_GROUP_CODE39	= 0x42,
	ITC_ISCP_SETUP_GROUP_CODE49	= 0x50,
	ITC_ISCP_SETUP_GROUP_CODE93	= 0x41,
	ITC_ISCP_SETUP_GROUP_CODE128	= 0x43,
	ITC_ISCP_SETUP_GROUP_DATAMATRIX	= 0x54,
	ITC_ISCP_SETUP_GROUP_INTERLEAVED_2OF5	= 0x44,
	ITC_ISCP_SETUP_GROUP_MATRIX_2OF5	= 0x45,
	ITC_ISCP_SETUP_GROUP_MAXICODE	= 0x52,
	ITC_ISCP_SETUP_GROUP_MSICODE	= 0x46,
	ITC_ISCP_SETUP_GROUP_PDF417	= 0x4c,
	ITC_ISCP_SETUP_GROUP_PLESSYCODE	= 0x47,
	ITC_ISCP_SETUP_GROUP_QRCODE	= 0x55,
	ITC_ISCP_SETUP_GROUP_RSS	= 0x4f,
	ITC_ISCP_SETUP_GROUP_STANDARD_2OF5	= 0x48,
	ITC_ISCP_SETUP_GROUP_TELEPEN	= 0x49,
	ITC_ISCP_SETUP_GROUP_TLC39	= 0x4e,
	ITC_ISCP_SETUP_GROUP_UCCCOMPISITE	= 0x56,
	ITC_ISCP_SETUP_GROUP_UPC_EAN	= 0x4b,
	ITC_ISCP_SETUP_GROUP_MESSAGE_FORMAT	= 0x60,
	ITC_ISCP_SETUP_GROUP_DATA_EDITING	= 0x65,
	ITC_ISCP_SETUP_GROUP_DECODONG_SECIRITY	= 0x71,
	ITC_ISCP_SETUP_GROUP_BEEP_LED_INDICATOR	= 0x72,
	ITC_ISCP_SETUP_GROUP_TRIGGER_SETTINGS	= 0x70,
	ITC_ISCP_SETUP_GROUP_SETUP_CONFIG	= 0x74,
	ITC_ISCP_SETUP_GROUP_IMAGER_SETTINGS	= 0x7b
    }	ITC_ISCP_SETUP_GROUP;

typedef 
enum tagISCPControlGroup
    {	ITC_ISCP_CONTROL_GROUP_DECODING	= 0x20,
	ITC_ISCP_CONTROL_GROUP_HARDWARE	= 0x30,
	ITC_ISCP_CONTROL_GROUP_CONFIGURATION	= 0x40,
	ITC_ISCP_CONTROL_GROUP_OPERATING	= 0x50
    }	ITC_ISCP_CONTROL_GROUP;

typedef 
enum tagISCPStatusGroup
    {	ITC_ISCP_STATUS_GROUP_HARDWARE	= 0x30
    }	ITC_ISCP_STATUS_GROUP;


EXTERN_C const IID IID_IS9CConfig3;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    interface DECLSPEC_UUID("61174F24-6B13-480B-A8F2-9F79AE0462A1")
    IS9CConfig3 : public IS9CConfig2
    {
    public:
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE ISCPGetConfig( 
            /* [size_is][in] */ BYTE __RPC_FAR rgbCommandBuff[  ],
            /* [in] */ DWORD dwCommandBuffSize,
            /* [size_is][out][in] */ BYTE __RPC_FAR rgbReplyBuff[  ],
            /* [in] */ DWORD dwReplyBuffMaxSize,
            /* [out][in] */ DWORD __RPC_FAR *pdwReplyBuffSize) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE ISCPSetConfig( 
            /* [size_is][in] */ BYTE __RPC_FAR rgbCommandBuff[  ],
            /* [in] */ DWORD dwCommandBuffSize,
            /* [size_is][out][in] */ BYTE __RPC_FAR rgbReplyBuff[  ],
            /* [in] */ DWORD dwReplyBuffMaxSize,
            /* [out][in] */ DWORD __RPC_FAR *pdwReplyBuffSize) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE ISCPCommandConfig( 
            /* [size_is][in] */ BYTE __RPC_FAR rgbCommandBuff[  ],
            /* [in] */ DWORD dwCommandBuffSize,
            /* [size_is][out][in] */ BYTE __RPC_FAR rgbReplyBuff[  ],
            /* [in] */ DWORD dwReplyBuffMaxSize,
            /* [out][in] */ DWORD __RPC_FAR *pdwReplyBuffSize) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE ISCPStatusRead( 
            /* [size_is][in] */ BYTE __RPC_FAR rgbCommandBuff[  ],
            /* [in] */ DWORD dwCommandBuffSize,
            /* [size_is][out][in] */ BYTE __RPC_FAR rgbReplyBuff[  ],
            /* [in] */ DWORD dwReplyBuffMaxSize,
            /* [out][in] */ DWORD __RPC_FAR *pdwReplyBuffSize) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IS9CConfig3Vtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IS9CConfig3 __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IS9CConfig3 __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Initialize )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [string][in] */ LPCTSTR pszDeviceName,
            /* [in] */ ITC_DEVICE_FLAGS eDeviceFlags);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Read )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [size_is][out][in] */ BYTE __RPC_FAR rgbDataBuffer[  ],
            /* [in] */ DWORD dwDataBufferSize,
            /* [out] */ DWORD __RPC_FAR *pnBytesReturned,
            /* [out][in] */ ITC_BARCODE_DATA_DETAILS __RPC_FAR *pBarCodeDataDetails,
            /* [in] */ DWORD dwTimeout);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *CancelReadRequest )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ BOOL FlushBufferedData,
            /* [out][in] */ WORD __RPC_FAR *pwTotalDiscardedMessages,
            /* [out][in] */ DWORD __RPC_FAR *pdwTotalDiscardedBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryAttribute )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_BARCODEREADER_ATTRIBUTE_ID eAttr,
            /* [size_is][out] */ BYTE __RPC_FAR rgbAttrBuffer[  ],
            /* [in] */ DWORD dwAttrBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetAttribute )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_BARCODEREADER_ATTRIBUTE_ID eAttr,
            /* [size_is][out] */ BYTE __RPC_FAR rgbAttrBuffer[  ],
            /* [in] */ DWORD dwAttrBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *TriggerScanner )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ BOOL fScannerOn);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *IssueBeep )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [size_is][in] */ ITC_BEEP_SPEC __RPC_FAR rgBeepRequests[  ],
            /* [in] */ DWORD dwNumberOfBeeps);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Reset )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ BOOL fWarmReset);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ControlLED )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_BARCODE_LASER_LED_ID eLED,
            /* [in] */ BOOL fLedOn);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetConfig )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ LPCTSTR pszConfig);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetConfig )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [size_is][out][in] */ TCHAR __RPC_FAR rgszConfig[  ],
            /* [in] */ DWORD ncConfigBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetStatistics )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [out][in] */ ITC_BARCODEREADER_STATISTICS __RPC_FAR *pStatsBuffer,
            /* [in] */ DWORD dwStatsBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ResetStatistics )( 
            IS9CConfig3 __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetAnalysis )( 
            IS9CConfig3 __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ReadAnalysis )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [size_is][out] */ BYTE __RPC_FAR rgbAnalysisBuffer[  ],
            /* [in] */ DWORD dwAnalysisBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *DownloadBarCodeReader )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ LPCTSTR pszReaderProgramFile);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetSystemInfo )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [out][in] */ ITC_BARC0DEREADER_SYSTEM_INFO __RPC_FAR *pSysInfoBuffer,
            /* [in] */ DWORD dwSysInfoBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetCode39 )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [out] */ ITC_CODE39_DECODING __RPC_FAR *c39Decode,
            /* [out] */ ITC_CODE39_FORMAT __RPC_FAR *c39Format,
            /* [out] */ ITC_CODE39_START_STOP __RPC_FAR *c39SS,
            /* [out] */ ITC_CODE39_SS_CHARS __RPC_FAR *c39SSChars,
            /* [out] */ ITC_CODE39_CHECK_DIGIT __RPC_FAR *c39Check,
            /* [out] */ DWORD __RPC_FAR *c39Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetCode39 )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_CODE39_DECODING c39Decode,
            /* [in] */ ITC_CODE39_FORMAT c39Format,
            /* [in] */ ITC_CODE39_START_STOP c39SS,
            /* [in] */ ITC_CODE39_SS_CHARS c39SSChars,
            /* [in] */ ITC_CODE39_CHECK_DIGIT c39Check,
            /* [in] */ DWORD c39Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetCodabar )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [out] */ ITC_CODABAR_DECODING __RPC_FAR *cbarDecode,
            /* [out] */ ITC_CODABAR_START_STOP __RPC_FAR *cbarSS,
            /* [out] */ ITC_CODABAR_CLSI __RPC_FAR *cbarCLSI,
            /* [out] */ ITC_CODABAR_CHECK_DIGIT __RPC_FAR *cbarCheck,
            /* [out] */ ITC_BARCODE_LENGTH_ID __RPC_FAR *eLengthId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [out] */ DWORD __RPC_FAR *pdwNumBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetCodabar )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_CODABAR_DECODING cbarDecode,
            /* [in] */ ITC_CODABAR_START_STOP cbarSS,
            /* [in] */ ITC_CODABAR_CLSI cbarCLSI,
            /* [in] */ ITC_CODABAR_CHECK_DIGIT cbarCheck,
            /* [in] */ ITC_BARCODE_LENGTH_ID eLengthId,
            /* [size_is][in] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [in] */ DWORD dwNumBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetCode93 )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [out] */ ITC_CODE93_DECODING __RPC_FAR *c93Decode,
            /* [out] */ DWORD __RPC_FAR *c93Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetCode93 )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_CODE93_DECODING c93Decode,
            /* [in] */ DWORD c93Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetCode128 )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [out] */ ITC_CODE128_DECODING __RPC_FAR *c128Decode,
            /* [out] */ ITC_EAN128_IDENTIFIER __RPC_FAR *ean128Ident,
            /* [out] */ ITC_CODE128_CIP128 __RPC_FAR *cip128State,
            /* [out] */ BYTE __RPC_FAR *c128FNC1,
            /* [out] */ DWORD __RPC_FAR *c128Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetCode128 )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_CODE128_DECODING c128Decode,
            /* [in] */ ITC_EAN128_IDENTIFIER ean128Ident,
            /* [in] */ ITC_CODE128_CIP128 cip128State,
            /* [in] */ BYTE c128FNC1,
            /* [in] */ DWORD c128Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetI2of5 )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [out] */ ITC_INTERLEAVED2OF5_DECODING __RPC_FAR *i2of5Decode,
            /* [out] */ ITC_INTERLEAVED2OF5_CHECK_DIGIT __RPC_FAR *i2of5Check,
            /* [out] */ ITC_BARCODE_LENGTH_ID __RPC_FAR *eLengthId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [out] */ DWORD __RPC_FAR *pdwNumBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetI2of5 )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_INTERLEAVED2OF5_DECODING i2of5Decode,
            /* [in] */ ITC_INTERLEAVED2OF5_CHECK_DIGIT i2of5Check,
            /* [in] */ ITC_BARCODE_LENGTH_ID eLengthId,
            /* [size_is][in] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [in] */ DWORD dwNumBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetMatrix2of5 )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [out] */ ITC_MATRIX2OF5_DECODING __RPC_FAR *m2of5Decode,
            /* [out] */ DWORD __RPC_FAR *m2of5Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetMatrix2of5 )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_MATRIX2OF5_DECODING m2of5Decode,
            /* [in] */ DWORD m2of5Length);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetMSI )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [out] */ ITC_MSI_DECODING __RPC_FAR *msiDecode,
            /* [out] */ ITC_MSI_CHECK_DIGIT __RPC_FAR *msiCheck,
            /* [out] */ DWORD __RPC_FAR *msiLength);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetMSI )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_MSI_DECODING msiDecode,
            /* [in] */ ITC_MSI_CHECK_DIGIT msiCheck,
            /* [in] */ DWORD msiLength);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetPDF417 )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [out] */ ITC_PDF417_DECODING __RPC_FAR *pdf417Decode,
            /* [out] */ ITC_PDF417_MACRO_PDF __RPC_FAR *macroPdf,
            /* [out] */ ITC_PDF417_CTRL_HEADER __RPC_FAR *pdfControlHeader,
            /* [out] */ ITC_PDF417_FILE_NAME __RPC_FAR *pdfFileName,
            /* [out] */ ITC_PDF417_SEGMENT_COUNT __RPC_FAR *pdfSegmentCount,
            /* [out] */ ITC_PDF417_TIME_STAMP __RPC_FAR *pdfTimeStamp,
            /* [out] */ ITC_PDF417_SENDER __RPC_FAR *pdfSender,
            /* [out] */ ITC_PDF417_ADDRESSEE __RPC_FAR *pdfAddressee,
            /* [out] */ ITC_PDF417_FILE_SIZE __RPC_FAR *pdfFileSize,
            /* [out] */ ITC_PDF417_CHECKSUM __RPC_FAR *pdfChecksum);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetPDF417 )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_PDF417_DECODING pdf417Decode,
            /* [in] */ ITC_PDF417_MACRO_PDF macroPdf,
            /* [in] */ ITC_PDF417_CTRL_HEADER pdfControlHeader,
            /* [in] */ ITC_PDF417_FILE_NAME pdfFileName,
            /* [in] */ ITC_PDF417_SEGMENT_COUNT pdfSegmentCount,
            /* [in] */ ITC_PDF417_TIME_STAMP pdfTimeStamp,
            /* [in] */ ITC_PDF417_SENDER pdfSender,
            /* [in] */ ITC_PDF417_ADDRESSEE pdfAddressee,
            /* [in] */ ITC_PDF417_FILE_SIZE pdfFileSize,
            /* [in] */ ITC_PDF417_CHECKSUM pdfChecksum);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetPlessey )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [out] */ ITC_PLESSEY_DECODING __RPC_FAR *plesseyDecode,
            /* [out] */ ITC_PLESSEY_CHECK_DIGIT __RPC_FAR *plesseyCheck,
            /* [out] */ DWORD __RPC_FAR *plesseyLength);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetPlessey )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_PLESSEY_DECODING plesseyDecode,
            /* [in] */ ITC_PLESSEY_CHECK_DIGIT plesseyCheck,
            /* [in] */ DWORD plesseyLength);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetStandard2of5 )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [out] */ ITC_STANDARD2OF5_DECODING __RPC_FAR *s2of5Decode,
            /* [out] */ ITC_STANDARD2OF5_FORMAT __RPC_FAR *s2of5Format,
            /* [out] */ ITC_STANDARD2OF5_CHECK_DIGIT __RPC_FAR *s2of5Check,
            /* [out] */ ITC_BARCODE_LENGTH_ID __RPC_FAR *eBarcodeLengthId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [out] */ DWORD __RPC_FAR *pdwNumBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetStandard2of5 )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_STANDARD2OF5_DECODING s2of5Decode,
            /* [in] */ ITC_STANDARD2OF5_FORMAT s2of5Format,
            /* [in] */ ITC_STANDARD2OF5_CHECK_DIGIT s2of5Check,
            /* [in] */ ITC_BARCODE_LENGTH_ID eLengthId,
            /* [size_is][in] */ BYTE __RPC_FAR rgbLengthBuff[  ],
            /* [in] */ DWORD dwNumBytes);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTelepen )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [out] */ ITC_TELEPEN_DECODING __RPC_FAR *telepenDecode,
            /* [out] */ ITC_TELEPEN_FORMAT __RPC_FAR *telepenFormat);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetTelepen )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_TELEPEN_DECODING telepenDecode,
            /* [in] */ ITC_TELEPEN_FORMAT telepenFormat);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetUpcEan )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [out] */ ITC_UPCEAN_DECODING __RPC_FAR *upceanDecode,
            /* [out] */ ITC_UPCA_SELECT __RPC_FAR *upcASelect,
            /* [out] */ ITC_UPCE_SELECT __RPC_FAR *upcESelect,
            /* [out] */ ITC_EAN8_SELECT __RPC_FAR *ean8Select,
            /* [out] */ ITC_EAN13_SELECT __RPC_FAR *ean13Select,
            /* [out] */ ITC_UPCEAN_ADDON_DIGITS __RPC_FAR *upcAddOnDigits,
            /* [out] */ ITC_UPCEAN_ADDON_TWO __RPC_FAR *upcAddOn2,
            /* [out] */ ITC_UPCEAN_ADDON_FIVE __RPC_FAR *upcAddOn5,
            /* [out] */ ITC_UPCA_CHECK_DIGIT __RPC_FAR *upcACheck,
            /* [out] */ ITC_UPCE_CHECK_DIGIT __RPC_FAR *upcECheck,
            /* [out] */ ITC_EAN8_CHECK_DIGIT __RPC_FAR *ean8Check,
            /* [out] */ ITC_EAN13_CHECK_DIGIT __RPC_FAR *ean13Check,
            /* [out] */ ITC_UPCA_NUMBER_SYSTEM __RPC_FAR *upcANumSystem,
            /* [out] */ ITC_UPCE_NUMBER_SYSTEM __RPC_FAR *upcENumSystem,
            /* [out] */ ITC_UPCA_REENCODE __RPC_FAR *upcAReencode,
            /* [out] */ ITC_UPCE_REENCODE __RPC_FAR *upcEReencode,
            /* [out] */ ITC_EAN8_REENCODE __RPC_FAR *ean8Reencode);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetUpcEan )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_UPCEAN_DECODING upceanDecode,
            /* [in] */ ITC_UPCA_SELECT upcASelect,
            /* [in] */ ITC_UPCE_SELECT upcESelect,
            /* [in] */ ITC_EAN8_SELECT ean8Select,
            /* [in] */ ITC_EAN13_SELECT ean13Select,
            /* [in] */ ITC_UPCEAN_ADDON_DIGITS upcAddOnDigits,
            /* [in] */ ITC_UPCEAN_ADDON_TWO upcAddOn2,
            /* [in] */ ITC_UPCEAN_ADDON_FIVE upcAddOn5,
            /* [in] */ ITC_UPCA_CHECK_DIGIT upcACheck,
            /* [in] */ ITC_UPCE_CHECK_DIGIT upcECheck,
            /* [in] */ ITC_EAN8_CHECK_DIGIT ean8Check,
            /* [in] */ ITC_EAN13_CHECK_DIGIT ean13Check,
            /* [in] */ ITC_UPCA_NUMBER_SYSTEM upcANumSystem,
            /* [in] */ ITC_UPCE_NUMBER_SYSTEM upcENumSystem,
            /* [in] */ ITC_UPCA_REENCODE upcAReencode,
            /* [in] */ ITC_UPCE_REENCODE upcEReencode,
            /* [in] */ ITC_EAN8_REENCODE ean8Reencode);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetSymIdXmit )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [out] */ ITC_SYMBOLOGY_ID_XMIT __RPC_FAR *peSymIdXmit);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetSymIdXmit )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_SYMBOLOGY_ID_XMIT eSymIdXmit);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetCustomSymIds )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [out] */ ITC_CUST_SYM_ID_PAIR __RPC_FAR *pStructSymIdPair,
            /* [in] */ DWORD dwMaxNumElement,
            /* [out] */ DWORD __RPC_FAR *pdwNumElement);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetCustomSymIds )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_CUST_SYM_ID_PAIR __RPC_FAR *pStructSymIdPair,
            /* [in] */ DWORD dwNumElement);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTriggerSetting )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_TRIGGER_SETTING_ID eId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetTriggerSetting )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_TRIGGER_SETTING_ID eId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetGlobalAmble )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_GLOBAL_AMBLE_ID eAmbleId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize,
            /* [out] */ DWORD __RPC_FAR *pdwBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetGlobalAmble )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_GLOBAL_AMBLE_ID eAmbleId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetDecodeSecurity )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_DECODE_SEC_ID eSecurityId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetDecodeSecurity )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_DECODE_SEC_ID eSecurityId,
            /* [size_is][out] */ BYTE __RPC_FAR rgbBuffer[  ],
            /* [in] */ DWORD dwBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetScanEngineInfo )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [out][in] */ ITC_SCAN_ENGINE_INFO __RPC_FAR *pInfoBuffer,
            /* [in] */ DWORD dwInfoBufferSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetCode11 )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [out] */ ITC_CODE11_DECODING __RPC_FAR *peDecode,
            /* [out] */ ITC_CODE11_CHECK_DIGIT __RPC_FAR *peCheck,
            /* [out] */ ITC_CODE11_CHECK_VERIFICATION __RPC_FAR *peVer);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetCode11 )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_CODE11_DECODING eDecode,
            /* [in] */ ITC_CODE11_CHECK_DIGIT eCheck,
            /* [in] */ ITC_CODE11_CHECK_VERIFICATION eVer);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetPDF417Ext )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [out] */ ITC_MICRO_PDF417_DECODING __RPC_FAR *peDecode,
            /* [out] */ ITC_MICRO_PDF417_CODE128_EMULATION __RPC_FAR *eCode128);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetPDF417Ext )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [in] */ ITC_MICRO_PDF417_DECODING eDecode,
            /* [in] */ ITC_MICRO_PDF417_CODE128_EMULATION eCode128);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ISCPGetConfig )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [size_is][in] */ BYTE __RPC_FAR rgbCommandBuff[  ],
            /* [in] */ DWORD dwCommandBuffSize,
            /* [size_is][out][in] */ BYTE __RPC_FAR rgbReplyBuff[  ],
            /* [in] */ DWORD dwReplyBuffMaxSize,
            /* [out][in] */ DWORD __RPC_FAR *pdwReplyBuffSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ISCPSetConfig )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [size_is][in] */ BYTE __RPC_FAR rgbCommandBuff[  ],
            /* [in] */ DWORD dwCommandBuffSize,
            /* [size_is][out][in] */ BYTE __RPC_FAR rgbReplyBuff[  ],
            /* [in] */ DWORD dwReplyBuffMaxSize,
            /* [out][in] */ DWORD __RPC_FAR *pdwReplyBuffSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ISCPCommandConfig )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [size_is][in] */ BYTE __RPC_FAR rgbCommandBuff[  ],
            /* [in] */ DWORD dwCommandBuffSize,
            /* [size_is][out][in] */ BYTE __RPC_FAR rgbReplyBuff[  ],
            /* [in] */ DWORD dwReplyBuffMaxSize,
            /* [out][in] */ DWORD __RPC_FAR *pdwReplyBuffSize);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ISCPStatusRead )( 
            IS9CConfig3 __RPC_FAR * This,
            /* [size_is][in] */ BYTE __RPC_FAR rgbCommandBuff[  ],
            /* [in] */ DWORD dwCommandBuffSize,
            /* [size_is][out][in] */ BYTE __RPC_FAR rgbReplyBuff[  ],
            /* [in] */ DWORD dwReplyBuffMaxSize,
            /* [out][in] */ DWORD __RPC_FAR *pdwReplyBuffSize);
        
        END_INTERFACE
    } IS9CConfig3Vtbl;

    interface IS9CConfig3
    {
        CONST_VTBL struct IS9CConfig3Vtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IS9CConfig3_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IS9CConfig3_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IS9CConfig3_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IS9CConfig3_Initialize(This,pszDeviceName,eDeviceFlags)	\
    (This)->lpVtbl -> Initialize(This,pszDeviceName,eDeviceFlags)

#define IS9CConfig3_Read(This,rgbDataBuffer,dwDataBufferSize,pnBytesReturned,pBarCodeDataDetails,dwTimeout)	\
    (This)->lpVtbl -> Read(This,rgbDataBuffer,dwDataBufferSize,pnBytesReturned,pBarCodeDataDetails,dwTimeout)

#define IS9CConfig3_CancelReadRequest(This,FlushBufferedData,pwTotalDiscardedMessages,pdwTotalDiscardedBytes)	\
    (This)->lpVtbl -> CancelReadRequest(This,FlushBufferedData,pwTotalDiscardedMessages,pdwTotalDiscardedBytes)

#define IS9CConfig3_QueryAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)	\
    (This)->lpVtbl -> QueryAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)

#define IS9CConfig3_SetAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)	\
    (This)->lpVtbl -> SetAttribute(This,eAttr,rgbAttrBuffer,dwAttrBufferSize)

#define IS9CConfig3_TriggerScanner(This,fScannerOn)	\
    (This)->lpVtbl -> TriggerScanner(This,fScannerOn)

#define IS9CConfig3_IssueBeep(This,rgBeepRequests,dwNumberOfBeeps)	\
    (This)->lpVtbl -> IssueBeep(This,rgBeepRequests,dwNumberOfBeeps)

#define IS9CConfig3_Reset(This,fWarmReset)	\
    (This)->lpVtbl -> Reset(This,fWarmReset)

#define IS9CConfig3_ControlLED(This,eLED,fLedOn)	\
    (This)->lpVtbl -> ControlLED(This,eLED,fLedOn)


#define IS9CConfig3_SetConfig(This,pszConfig)	\
    (This)->lpVtbl -> SetConfig(This,pszConfig)

#define IS9CConfig3_GetConfig(This,rgszConfig,ncConfigBufferSize)	\
    (This)->lpVtbl -> GetConfig(This,rgszConfig,ncConfigBufferSize)

#define IS9CConfig3_GetStatistics(This,pStatsBuffer,dwStatsBufferSize)	\
    (This)->lpVtbl -> GetStatistics(This,pStatsBuffer,dwStatsBufferSize)

#define IS9CConfig3_ResetStatistics(This)	\
    (This)->lpVtbl -> ResetStatistics(This)

#define IS9CConfig3_SetAnalysis(This)	\
    (This)->lpVtbl -> SetAnalysis(This)

#define IS9CConfig3_ReadAnalysis(This,rgbAnalysisBuffer,dwAnalysisBufferSize)	\
    (This)->lpVtbl -> ReadAnalysis(This,rgbAnalysisBuffer,dwAnalysisBufferSize)

#define IS9CConfig3_DownloadBarCodeReader(This,pszReaderProgramFile)	\
    (This)->lpVtbl -> DownloadBarCodeReader(This,pszReaderProgramFile)

#define IS9CConfig3_GetSystemInfo(This,pSysInfoBuffer,dwSysInfoBufferSize)	\
    (This)->lpVtbl -> GetSystemInfo(This,pSysInfoBuffer,dwSysInfoBufferSize)


#define IS9CConfig3_GetCode39(This,c39Decode,c39Format,c39SS,c39SSChars,c39Check,c39Length)	\
    (This)->lpVtbl -> GetCode39(This,c39Decode,c39Format,c39SS,c39SSChars,c39Check,c39Length)

#define IS9CConfig3_SetCode39(This,c39Decode,c39Format,c39SS,c39SSChars,c39Check,c39Length)	\
    (This)->lpVtbl -> SetCode39(This,c39Decode,c39Format,c39SS,c39SSChars,c39Check,c39Length)

#define IS9CConfig3_GetCodabar(This,cbarDecode,cbarSS,cbarCLSI,cbarCheck,eLengthId,rgbLengthBuff,pdwNumBytes)	\
    (This)->lpVtbl -> GetCodabar(This,cbarDecode,cbarSS,cbarCLSI,cbarCheck,eLengthId,rgbLengthBuff,pdwNumBytes)

#define IS9CConfig3_SetCodabar(This,cbarDecode,cbarSS,cbarCLSI,cbarCheck,eLengthId,rgbLengthBuff,dwNumBytes)	\
    (This)->lpVtbl -> SetCodabar(This,cbarDecode,cbarSS,cbarCLSI,cbarCheck,eLengthId,rgbLengthBuff,dwNumBytes)

#define IS9CConfig3_GetCode93(This,c93Decode,c93Length)	\
    (This)->lpVtbl -> GetCode93(This,c93Decode,c93Length)

#define IS9CConfig3_SetCode93(This,c93Decode,c93Length)	\
    (This)->lpVtbl -> SetCode93(This,c93Decode,c93Length)

#define IS9CConfig3_GetCode128(This,c128Decode,ean128Ident,cip128State,c128FNC1,c128Length)	\
    (This)->lpVtbl -> GetCode128(This,c128Decode,ean128Ident,cip128State,c128FNC1,c128Length)

#define IS9CConfig3_SetCode128(This,c128Decode,ean128Ident,cip128State,c128FNC1,c128Length)	\
    (This)->lpVtbl -> SetCode128(This,c128Decode,ean128Ident,cip128State,c128FNC1,c128Length)

#define IS9CConfig3_GetI2of5(This,i2of5Decode,i2of5Check,eLengthId,rgbLengthBuff,pdwNumBytes)	\
    (This)->lpVtbl -> GetI2of5(This,i2of5Decode,i2of5Check,eLengthId,rgbLengthBuff,pdwNumBytes)

#define IS9CConfig3_SetI2of5(This,i2of5Decode,i2of5Check,eLengthId,rgbLengthBuff,dwNumBytes)	\
    (This)->lpVtbl -> SetI2of5(This,i2of5Decode,i2of5Check,eLengthId,rgbLengthBuff,dwNumBytes)

#define IS9CConfig3_GetMatrix2of5(This,m2of5Decode,m2of5Length)	\
    (This)->lpVtbl -> GetMatrix2of5(This,m2of5Decode,m2of5Length)

#define IS9CConfig3_SetMatrix2of5(This,m2of5Decode,m2of5Length)	\
    (This)->lpVtbl -> SetMatrix2of5(This,m2of5Decode,m2of5Length)

#define IS9CConfig3_GetMSI(This,msiDecode,msiCheck,msiLength)	\
    (This)->lpVtbl -> GetMSI(This,msiDecode,msiCheck,msiLength)

#define IS9CConfig3_SetMSI(This,msiDecode,msiCheck,msiLength)	\
    (This)->lpVtbl -> SetMSI(This,msiDecode,msiCheck,msiLength)

#define IS9CConfig3_GetPDF417(This,pdf417Decode,macroPdf,pdfControlHeader,pdfFileName,pdfSegmentCount,pdfTimeStamp,pdfSender,pdfAddressee,pdfFileSize,pdfChecksum)	\
    (This)->lpVtbl -> GetPDF417(This,pdf417Decode,macroPdf,pdfControlHeader,pdfFileName,pdfSegmentCount,pdfTimeStamp,pdfSender,pdfAddressee,pdfFileSize,pdfChecksum)

#define IS9CConfig3_SetPDF417(This,pdf417Decode,macroPdf,pdfControlHeader,pdfFileName,pdfSegmentCount,pdfTimeStamp,pdfSender,pdfAddressee,pdfFileSize,pdfChecksum)	\
    (This)->lpVtbl -> SetPDF417(This,pdf417Decode,macroPdf,pdfControlHeader,pdfFileName,pdfSegmentCount,pdfTimeStamp,pdfSender,pdfAddressee,pdfFileSize,pdfChecksum)

#define IS9CConfig3_GetPlessey(This,plesseyDecode,plesseyCheck,plesseyLength)	\
    (This)->lpVtbl -> GetPlessey(This,plesseyDecode,plesseyCheck,plesseyLength)

#define IS9CConfig3_SetPlessey(This,plesseyDecode,plesseyCheck,plesseyLength)	\
    (This)->lpVtbl -> SetPlessey(This,plesseyDecode,plesseyCheck,plesseyLength)

#define IS9CConfig3_GetStandard2of5(This,s2of5Decode,s2of5Format,s2of5Check,eBarcodeLengthId,rgbLengthBuff,pdwNumBytes)	\
    (This)->lpVtbl -> GetStandard2of5(This,s2of5Decode,s2of5Format,s2of5Check,eBarcodeLengthId,rgbLengthBuff,pdwNumBytes)

#define IS9CConfig3_SetStandard2of5(This,s2of5Decode,s2of5Format,s2of5Check,eLengthId,rgbLengthBuff,dwNumBytes)	\
    (This)->lpVtbl -> SetStandard2of5(This,s2of5Decode,s2of5Format,s2of5Check,eLengthId,rgbLengthBuff,dwNumBytes)

#define IS9CConfig3_GetTelepen(This,telepenDecode,telepenFormat)	\
    (This)->lpVtbl -> GetTelepen(This,telepenDecode,telepenFormat)

#define IS9CConfig3_SetTelepen(This,telepenDecode,telepenFormat)	\
    (This)->lpVtbl -> SetTelepen(This,telepenDecode,telepenFormat)

#define IS9CConfig3_GetUpcEan(This,upceanDecode,upcASelect,upcESelect,ean8Select,ean13Select,upcAddOnDigits,upcAddOn2,upcAddOn5,upcACheck,upcECheck,ean8Check,ean13Check,upcANumSystem,upcENumSystem,upcAReencode,upcEReencode,ean8Reencode)	\
    (This)->lpVtbl -> GetUpcEan(This,upceanDecode,upcASelect,upcESelect,ean8Select,ean13Select,upcAddOnDigits,upcAddOn2,upcAddOn5,upcACheck,upcECheck,ean8Check,ean13Check,upcANumSystem,upcENumSystem,upcAReencode,upcEReencode,ean8Reencode)

#define IS9CConfig3_SetUpcEan(This,upceanDecode,upcASelect,upcESelect,ean8Select,ean13Select,upcAddOnDigits,upcAddOn2,upcAddOn5,upcACheck,upcECheck,ean8Check,ean13Check,upcANumSystem,upcENumSystem,upcAReencode,upcEReencode,ean8Reencode)	\
    (This)->lpVtbl -> SetUpcEan(This,upceanDecode,upcASelect,upcESelect,ean8Select,ean13Select,upcAddOnDigits,upcAddOn2,upcAddOn5,upcACheck,upcECheck,ean8Check,ean13Check,upcANumSystem,upcENumSystem,upcAReencode,upcEReencode,ean8Reencode)


#define IS9CConfig3_GetSymIdXmit(This,peSymIdXmit)	\
    (This)->lpVtbl -> GetSymIdXmit(This,peSymIdXmit)

#define IS9CConfig3_SetSymIdXmit(This,eSymIdXmit)	\
    (This)->lpVtbl -> SetSymIdXmit(This,eSymIdXmit)

#define IS9CConfig3_GetCustomSymIds(This,pStructSymIdPair,dwMaxNumElement,pdwNumElement)	\
    (This)->lpVtbl -> GetCustomSymIds(This,pStructSymIdPair,dwMaxNumElement,pdwNumElement)

#define IS9CConfig3_SetCustomSymIds(This,pStructSymIdPair,dwNumElement)	\
    (This)->lpVtbl -> SetCustomSymIds(This,pStructSymIdPair,dwNumElement)

#define IS9CConfig3_GetTriggerSetting(This,eId,rgbBuffer,dwBufferSize)	\
    (This)->lpVtbl -> GetTriggerSetting(This,eId,rgbBuffer,dwBufferSize)

#define IS9CConfig3_SetTriggerSetting(This,eId,rgbBuffer,dwBufferSize)	\
    (This)->lpVtbl -> SetTriggerSetting(This,eId,rgbBuffer,dwBufferSize)

#define IS9CConfig3_GetGlobalAmble(This,eAmbleId,rgbBuffer,dwBufferSize,pdwBufferSize)	\
    (This)->lpVtbl -> GetGlobalAmble(This,eAmbleId,rgbBuffer,dwBufferSize,pdwBufferSize)

#define IS9CConfig3_SetGlobalAmble(This,eAmbleId,rgbBuffer,dwBufferSize)	\
    (This)->lpVtbl -> SetGlobalAmble(This,eAmbleId,rgbBuffer,dwBufferSize)

#define IS9CConfig3_GetDecodeSecurity(This,eSecurityId,rgbBuffer,dwBufferSize)	\
    (This)->lpVtbl -> GetDecodeSecurity(This,eSecurityId,rgbBuffer,dwBufferSize)

#define IS9CConfig3_SetDecodeSecurity(This,eSecurityId,rgbBuffer,dwBufferSize)	\
    (This)->lpVtbl -> SetDecodeSecurity(This,eSecurityId,rgbBuffer,dwBufferSize)

#define IS9CConfig3_GetScanEngineInfo(This,pInfoBuffer,dwInfoBufferSize)	\
    (This)->lpVtbl -> GetScanEngineInfo(This,pInfoBuffer,dwInfoBufferSize)

#define IS9CConfig3_GetCode11(This,peDecode,peCheck,peVer)	\
    (This)->lpVtbl -> GetCode11(This,peDecode,peCheck,peVer)

#define IS9CConfig3_SetCode11(This,eDecode,eCheck,eVer)	\
    (This)->lpVtbl -> SetCode11(This,eDecode,eCheck,eVer)

#define IS9CConfig3_GetPDF417Ext(This,peDecode,eCode128)	\
    (This)->lpVtbl -> GetPDF417Ext(This,peDecode,eCode128)

#define IS9CConfig3_SetPDF417Ext(This,eDecode,eCode128)	\
    (This)->lpVtbl -> SetPDF417Ext(This,eDecode,eCode128)


#define IS9CConfig3_ISCPGetConfig(This,rgbCommandBuff,dwCommandBuffSize,rgbReplyBuff,dwReplyBuffMaxSize,pdwReplyBuffSize)	\
    (This)->lpVtbl -> ISCPGetConfig(This,rgbCommandBuff,dwCommandBuffSize,rgbReplyBuff,dwReplyBuffMaxSize,pdwReplyBuffSize)

#define IS9CConfig3_ISCPSetConfig(This,rgbCommandBuff,dwCommandBuffSize,rgbReplyBuff,dwReplyBuffMaxSize,pdwReplyBuffSize)	\
    (This)->lpVtbl -> ISCPSetConfig(This,rgbCommandBuff,dwCommandBuffSize,rgbReplyBuff,dwReplyBuffMaxSize,pdwReplyBuffSize)

#define IS9CConfig3_ISCPCommandConfig(This,rgbCommandBuff,dwCommandBuffSize,rgbReplyBuff,dwReplyBuffMaxSize,pdwReplyBuffSize)	\
    (This)->lpVtbl -> ISCPCommandConfig(This,rgbCommandBuff,dwCommandBuffSize,rgbReplyBuff,dwReplyBuffMaxSize,pdwReplyBuffSize)

#define IS9CConfig3_ISCPStatusRead(This,rgbCommandBuff,dwCommandBuffSize,rgbReplyBuff,dwReplyBuffMaxSize,pdwReplyBuffSize)	\
    (This)->lpVtbl -> ISCPStatusRead(This,rgbCommandBuff,dwCommandBuffSize,rgbReplyBuff,dwReplyBuffMaxSize,pdwReplyBuffSize)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig3_ISCPGetConfig_Proxy( 
    IS9CConfig3 __RPC_FAR * This,
    /* [size_is][in] */ BYTE __RPC_FAR rgbCommandBuff[  ],
    /* [in] */ DWORD dwCommandBuffSize,
    /* [size_is][out][in] */ BYTE __RPC_FAR rgbReplyBuff[  ],
    /* [in] */ DWORD dwReplyBuffMaxSize,
    /* [out][in] */ DWORD __RPC_FAR *pdwReplyBuffSize);


void __RPC_STUB IS9CConfig3_ISCPGetConfig_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig3_ISCPSetConfig_Proxy( 
    IS9CConfig3 __RPC_FAR * This,
    /* [size_is][in] */ BYTE __RPC_FAR rgbCommandBuff[  ],
    /* [in] */ DWORD dwCommandBuffSize,
    /* [size_is][out][in] */ BYTE __RPC_FAR rgbReplyBuff[  ],
    /* [in] */ DWORD dwReplyBuffMaxSize,
    /* [out][in] */ DWORD __RPC_FAR *pdwReplyBuffSize);


void __RPC_STUB IS9CConfig3_ISCPSetConfig_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig3_ISCPCommandConfig_Proxy( 
    IS9CConfig3 __RPC_FAR * This,
    /* [size_is][in] */ BYTE __RPC_FAR rgbCommandBuff[  ],
    /* [in] */ DWORD dwCommandBuffSize,
    /* [size_is][out][in] */ BYTE __RPC_FAR rgbReplyBuff[  ],
    /* [in] */ DWORD dwReplyBuffMaxSize,
    /* [out][in] */ DWORD __RPC_FAR *pdwReplyBuffSize);


void __RPC_STUB IS9CConfig3_ISCPCommandConfig_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IS9CConfig3_ISCPStatusRead_Proxy( 
    IS9CConfig3 __RPC_FAR * This,
    /* [size_is][in] */ BYTE __RPC_FAR rgbCommandBuff[  ],
    /* [in] */ DWORD dwCommandBuffSize,
    /* [size_is][out][in] */ BYTE __RPC_FAR rgbReplyBuff[  ],
    /* [in] */ DWORD dwReplyBuffMaxSize,
    /* [out][in] */ DWORD __RPC_FAR *pdwReplyBuffSize);


void __RPC_STUB IS9CConfig3_ISCPStatusRead_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IS9CConfig3_INTERFACE_DEFINED__ */


/****************************************
 * Generated header for interface: __MIDL_itf_IS9CConfig_0165
 * at Fri Nov 08 13:57:56 2002
 * using MIDL 3.02.88
 ****************************************/
/* [local] */ 



#pragma pack(pop, IS9CConfig_IDL)


extern RPC_IF_HANDLE __MIDL_itf_IS9CConfig_0165_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_IS9CConfig_0165_v0_0_s_ifspec;

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif
