using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Cf.Libs.Core.Cryption
{
    public class RSACrypto
    {
        public static void GenPairKey(out string psPrivateKey, out string psPublicKey)
        {
            var lCspParam = new CspParameters();
            lCspParam.Flags = CspProviderFlags.UseMachineKeyStore;
            var lRSA = new RSACryptoServiceProvider(lCspParam);

            psPrivateKey = lRSA.ToXmlString(true);
            psPublicKey = lRSA.ToXmlString(false);
        }

        public static string Encrypt(string psData, string psPublicKey)
        {
            // This is the variable that will be returned to the user
            var encryptedValue = string.Empty;


            //Create new RSA object passing our key info
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(psPublicKey);

            // Before encrypting the value we must convert it over to byte array
            var bytesToEncrypt = System.Text.Encoding.UTF8.GetBytes(psData);

            // Encrypt our byte array. The false parameter has to do with 
            // padding (not to clear on this point but you can
            // look it up and decide which is better for your use)
            //byte[] bytesEncrypted = rsa.Encrypt(bytesToEncrypt, false);

            var bytesEncrypted = BlockEncrypt(rsa, bytesToEncrypt);

            // Extract our encrypted byte array into a string value to return to our user
            encryptedValue = Convert.ToBase64String(bytesEncrypted);

            return encryptedValue;
        }

        public static string Decrypt(string psDecryptValue, string psPrivateKey)
        {

            // This is the variable that will be returned to the user
            var decryptedValue = string.Empty;


            //Create new RSA object passing our key info
            var rsa = new RSACryptoServiceProvider();

            rsa.FromXmlString(psPrivateKey);


            // Before decryption we must convert this ugly string into a byte array
            var valueToDecrypt = Convert.FromBase64String(psDecryptValue);

            // Decrypt the passed in string value -
            // Again the false value has to do with padding
            //byte[] plainTextValue = rsa.Decrypt(valueToDecrypt, false);

            var plainTextValue = BlockDecrypt(rsa, valueToDecrypt);


            // Extract our decrypted byte array into
            // a string value to return to our user
            decryptedValue = System.Text.Encoding.UTF8.GetString(plainTextValue);


            return decryptedValue;
        }

        public static string SignData(string psData, string psPrivateKey)
        {
            //Create new RSA object passing our key info
            var lParams = new CspParameters();
            lParams.Flags = CspProviderFlags.UseMachineKeyStore;

            var rsa = new RSACryptoServiceProvider(lParams);
            rsa.FromXmlString(psPrivateKey);


            var lArrData = System.Text.Encoding.UTF8.GetBytes(psData);
            object hasher = SHA1.Create();

            var lArrSignature = rsa.SignData(lArrData, hasher);
            var lsSign = BitConverter.ToString(lArrSignature);
            return lsSign.Replace("-", "");
        }

        public static bool VerifyData(string psData, string psPublicKey, string psSignature)
        {
            //Create new RSA object passing our key info
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(psPublicKey);

            var lArrData = System.Text.Encoding.UTF8.GetBytes(psData);
            object hasher = SHA1.Create();
            var lArrSignature = GetHexByteArray(psSignature);

            return rsa.VerifyData(lArrData, hasher, lArrSignature);
        }

        #region Encryption Helpers

        /// <summary>
        /// Encrypts a block of memory by breaking it into chunks and
        /// encrypting each chunk. The maximum cipher length is used
        /// for each chunk.
        /// </summary>
        /// <param name="RSA">RSA encryption method.</param>
        /// <param name="pbBuffer">Byte buffer to encrypt.</param>
        /// <returns>Encrypted data.</returns>
        private static byte[] BlockEncrypt(RSACryptoServiceProvider RSA, byte[] pbBuffer)
        {
            // Setup the return buffer
            var stream = new System.IO.MemoryStream();

            // The maximum block size is the length of the modulus in bytes
            // minus 11 bytes for padding.
            var nMaxBlockSize = RSA.ExportParameters(false).Modulus.Length - 11;
            var nLength = pbBuffer.Length;
            var nBlocks = ((nLength % nMaxBlockSize) == 0) ? nLength / nMaxBlockSize : nLength / nMaxBlockSize + 1;
            var nTotalBytes = 0;

            for (var i = 0; i < nBlocks; i++)
            {
                // Calculate the block length
                var nBlockLength = (i == (nBlocks - 1) ? nLength - (i * nMaxBlockSize) : nMaxBlockSize);

                // Allocate a new block and copy data from the main buffer
                var pbBlock = new byte[nBlockLength];
                Array.Copy(pbBuffer, i * nMaxBlockSize, pbBlock, 0, nBlockLength);

                // Encrypt the block
                var pbOut = RSA.Encrypt(pbBlock, false);

                // Copy the block to the output stream
                stream.Write(pbOut, 0, pbOut.Length);

                // Keep a count of the encrypted bytes
                nTotalBytes += pbOut.Length;
            }

            // Create an output buffer
            var pbReturn = new byte[nTotalBytes];
            stream.Seek(0, System.IO.SeekOrigin.Begin);
            stream.Read(pbReturn, 0, nTotalBytes);

            // Return the data
            return pbReturn;
        }

        /// <summary>
        /// Decrypts a block of memory by breaking it into chunks and
        /// decrypting each chunk. The maximum plain text length is used
        /// for each chunk.
        /// </summary>
        /// <param name="RSA">RSA decryption method.</param>
        /// <param name="pbBuffer">Byte buffer to decrypt.</param>
        /// <returns>Decrypted data.</returns>
        private static byte[] BlockDecrypt(RSACryptoServiceProvider RSA, byte[] pbBuffer)
        {
            // Setup the return buffer
            var stream = new System.IO.MemoryStream();

            // The maximum block size is the length of the modulus in bytes
            var nMaxBlockSize = RSA.ExportParameters(false).Modulus.Length;
            var nLength = pbBuffer.Length;
            var nBlocks = ((nLength % nMaxBlockSize) == 0) ? nLength / nMaxBlockSize : nLength / nMaxBlockSize + 1;
            var nTotalBytes = 0;

            for (var i = 0; i < nBlocks; i++)
            {
                // Calculate the block length
                var nBlockLength = (i == (nBlocks - 1) ? nLength - (i * nMaxBlockSize) : nMaxBlockSize);

                // Allocate a new block and copy data from the main buffer
                var pbBlock = new byte[nBlockLength];
                Array.Copy(pbBuffer, i * nMaxBlockSize, pbBlock, 0, nBlockLength);

                // Encrypt the block
                var pbOut = RSA.Decrypt(pbBlock, false);

                // Copy the block to the output stream
                stream.Write(pbOut, 0, pbOut.Length);

                // Keep a count of the encrypted bytes
                nTotalBytes += pbOut.Length;
            }

            // Create an output buffer
            var pbReturn = new byte[nTotalBytes];
            stream.Seek(0, System.IO.SeekOrigin.Begin);
            stream.Read(pbReturn, 0, nTotalBytes);

            // Return the data
            return pbReturn;
        }

        private static byte[] GetHexByteArray(String psHexString)
        {
            var lsHexString = psHexString.Replace("-", "");
            var liNumberChars = lsHexString.Length;
            var bytes = new byte[liNumberChars / 2];
            for (var i = 0; i < liNumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(lsHexString.Substring(i, 2), 16);
            }
            return bytes;
        }

        #endregion
    }
}
