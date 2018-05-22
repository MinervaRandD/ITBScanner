// Rijndael.h

#pragma once

namespace Rijndael
{

	#define _MAX_KEY_COLUMNS (256/32)
	#define _MAX_ROUNDS      14
	#define MAX_IV_SIZE      16

	// We assume that unsigned int is 32 bits long.... 

	typedef unsigned char  UINT8;
	typedef unsigned int   UINT32;
	typedef unsigned short UINT16;

	// Error codes
	#define RIJNDAEL_SUCCESS 0
	#define RIJNDAEL_UNSUPPORTED_MODE -1
	#define RIJNDAEL_UNSUPPORTED_DIRECTION -2
	#define RIJNDAEL_UNSUPPORTED_KEY_LENGTH -3
	#define RIJNDAEL_BAD_KEY -4
	#define RIJNDAEL_NOT_INITIALIZED -5
	#define RIJNDAEL_BAD_DIRECTION -6
	#define RIJNDAEL_CORRUPTED_DATA -7
	#define	Direction			unsigned char

	#define Direction_Encrypt	1
	#define	Direction_Decrypt	2

	#define	Mode				unsigned char

	#define Mode_ECB			1
	#define	Mode_CBC			2
	#define	Mode_CFB1			4

	#define KeyLength			unsigned char

	#define	KeyLength16Bytes	1
	#define	KeyLength24Bytes	2
	#define	KeyLength32Bytes	3

	#define State				bool

	#define	State_Valid			true
	#define	State_Invalid		false

	UINT8     m_initVector[MAX_IV_SIZE] ;
	UINT8     m_expandedKey[_MAX_ROUNDS+1][4][4];

	public __gc class Rijndael
	{
		public:
			//
			// Creates a Rijndael cipher object
			// You have to call init() before you can encrypt or decrypt stuff
			//
			Rijndael();
			~Rijndael();
		protected:
			// Internal stuff
	
			State     m_state;
			Mode      m_mode;
			Direction m_direction;

			UINT32    m_uRounds;

	
		public:

			int aesEncrypt( const UINT8 *inputBuffer, const int inputLen, unsigned char *outputBuffer, int keyIndex );
			int aesDecrypt( const UINT8 *inputBuffer, const int inputLen, unsigned char *outputBuffer, int keyIndex );

		protected:
						//////////////////////////////////////////////////////////////////////////////////////////
			// API
			//////////////////////////////////////////////////////////////////////////////////////////

			// init(): Initializes the crypt session
			// Returns RIJNDAEL_SUCCESS or an error code
			// mode      : Rijndael::Mode_ECB, Rijndael::Mode_CBC or Rijndael::CFB1
			//             You have to use the same mode for encrypting and decrypting
			// dir       : Rijndael::Encrypt or Rijndael::Decrypt
			//             A cipher instance works only in one direction
			//             (Well , it could be easily modified to work in both
			//             directions with a single init() call, but it looks
			//             useless to me...anyway , it is a matter of generating
			//             two expanded keys)
			// key       : array of unsigned octets , it can be 16 , 24 or 32 bytes long
			//             this CAN be binary data (it is not expected to be null terminated)
			// keyLen    : Rijndael::KeyLength16Bytes , Rijndael::KeyLength24Bytes or Rijndael::KeyLength32Bytes
			// initVector: initialization vector, you will usually use 0 here
			int init(Mode mode,Direction dir,const UINT8 *key,KeyLength keyLen, UINT8 *initVector);
			// Encrypts the input array (can be binary data)
			// The input array length must be a multiple of 16 bytes, the remaining part
			// is DISCARDED.
			// so it actually encrypts inputLen / 128 blocks of input and puts it in outBuffer
			// Input len is in BITS!
			// outBuffer must be at least inputLen / 8 bytes long.
			// Returns the encrypted buffer length in BITS or an error code < 0 in case of error
			int blockEncrypt(const UINT8 *input, int inputLen, UINT8 *outBuffer);
			// Encrypts the input array (can be binary data)
			// The input array can be any length , it is automatically padded on a 16 byte boundary.
			// Input len is in BYTES!
			// outBuffer must be at least (inputLen + 16) bytes long
			// Returns the encrypted buffer length in BYTES or an error code < 0 in case of error
			int padEncrypt(const UINT8 *input, int inputOctets, UINT8 *outBuffer);
			// Decrypts the input vector
			// Input len is in BITS!
			// outBuffer must be at least inputLen / 8 bytes long
			// Returns the decrypted buffer length in BITS and an error code < 0 in case of error
			int blockDecrypt(const UINT8 *input, int inputLen, UINT8 *outBuffer);
			// Decrypts the input vector
			// Input len is in BYTES!
			// outBuffer must be at least inputLen bytes long
			// Returns the decrypted buffer length in BYTES and an error code < 0 in case of error
			int padDecrypt(const UINT8 *input, int inputOctets, UINT8 *outBuffer);

			void BuildKey(int keyIndex) ;
			void keySched();
			void keyEncToDec();
			void encrypt(const UINT8 *a, UINT8 *b);
			void decrypt(const UINT8 *a, UINT8 *b);
			/*void encrypt(const UINT8 a[16], UINT8 b[16]);
			void decrypt(const UINT8 a[16], UINT8 b[16]);*/

			int strcmp(const char *s1, const char *s2)
			{
				char c1 = s1[0] ;
				char c2 = s2[0] ;

				for ( int i = 1 ; c1 && c2 ; i++ )
				{
					if ( c1 > c2 ) return  1 ;
					if ( c1 < c2 ) return -1 ;

					c1 = s1[i] ; c2 = s2[i] ;
				}

				if ( c1 == 0 && c2 != 0 ) return -1 ;
				if ( c1 != 0 && c2 == 0 ) return  1 ;

				return 0 ;
			
			}

			void *memcpy(void *dest, const void *src, size_t n)
			{
				unsigned char *d = (unsigned char *) dest ;
				unsigned char *s = (unsigned char *) src  ;

				for ( size_t i = 0 ; i < n ; i++ ) d[i] = s[i] ;

				return dest ;
			}

			void *memset(void *s, int c, size_t n)
			{
				char *ss = (char *) s ;

				for ( size_t i = 0 ; i < n ; i++ ) ss[i] = c ;

				return s ;
			}
		};
}
