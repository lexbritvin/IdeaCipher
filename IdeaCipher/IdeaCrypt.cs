using System;
using System.IO;

namespace IdeaCipher
{
    /**
     * Creates an instance of the IDEA processor, initialized with a 16-byte binary key.
     *
     * @param key
     *    A 16-byte binary key.
     * @param encrypt
     *    true to encrypt, false to decrypt.
     */
    public class IdeaCrypt
    {
        private static int blockSize = 8;

        /**
         * Encrypts or decrypts a file.
         *
         * @param inputFileName
         *    Name of the input file.
         * @param outputFileName
         *    Name of the output file.
         * @param charKey
         *    The encryption key. A string of ASCII characters within the range 0x21 .. 0x7E.
         * @param encrypt
         *    true to encrypt, false to decrypt.
         * @param mode
         *    Mode of operation.
         */
        public static void cryptFile(String inputFileName, String outputFileName, String charKey, bool encrypt)
        {
            FileStream inStream = null;
            FileStream outStream = null;
            try
            {
                Idea idea = new Idea(charKey, encrypt);
                BlockStreamCrypter bsc = new BlockStreamCrypter(idea, encrypt);
                inStream = new FileStream(inputFileName, FileMode.Open, FileAccess.ReadWrite);
                long inFileSize = inStream.Length;
                long inDataLen;
                long outDataLen;
                if (encrypt)
                {
                    inDataLen = inFileSize;
                    outDataLen = (inDataLen + blockSize - 1) / blockSize * blockSize;
                }
                else
                {
                    if (inFileSize == 0)
                    {
                        throw new IOException("Input file is empty.");
                    }
                    if (inFileSize % blockSize != 0)
                    {
                        throw new IOException("Input file size is not a multiple of " + blockSize + ".");
                    }
                    inDataLen = inFileSize - blockSize;
                    outDataLen = inDataLen;
                }
                outStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write);
                processData(inStream, inDataLen, outStream, outDataLen, bsc);
                if (encrypt)
                {
                    writeDataLength(outStream, inDataLen, bsc);
                }
                else
                {
                    long outFileSize = readDataLength(inStream, bsc);
                    if (outFileSize < 0 || outFileSize > inDataLen || outFileSize < inDataLen - blockSize + 1)
                    {
                        throw new IOException("Input file is not a valid cryptogram.");
                    }
                    if (outFileSize != outDataLen)
                    {
                        outStream.SetLength(outFileSize);
                    }
                }
                outStream.Close();
            }
            finally
            {
                if (inStream != null)
                {
                    inStream.Close();
                }
                if (outStream != null)
                {
                    outStream.Close();
                }
            }
        }

        private class BlockStreamCrypter
        {
            Idea idea;
            bool encrypt;
            // data of the previous ciphertext block
            byte[] prev;
            byte[] newPrev;
            public BlockStreamCrypter(Idea idea, bool encrypt)
            {
                this.idea = idea;
                this.encrypt = encrypt;
                prev = new byte[blockSize];
                newPrev = new byte[blockSize];
            }
            public void crypt(byte[] data, int pos)
            {
                if (encrypt)
                {
                    xor(data, pos, prev);
                    idea.crypt(data, pos);
                    Array.Copy(data, pos, prev, 0, blockSize);
                }
                else
                {
                    Array.Copy(data, pos, newPrev, 0, blockSize);
                    idea.crypt(data, pos);
                    xor(data, pos, prev);
                    byte[] temp = prev;
                    prev = newPrev;
                    newPrev = temp;
                }
            }
        }

        private static void processData(FileStream inStream, long inDataLen, FileStream outStream, long outDataLen, BlockStreamCrypter bsc)
        {
            int bufSize = 0x200000;
            byte[] buf = new byte[bufSize];
            long filePos = 0;
            while (filePos < inDataLen)
            {
                int reqLen = (int)Math.Min(inDataLen - filePos, bufSize);
                int trLen = inStream.Read(buf, 0, reqLen);
                if (trLen != reqLen)
                {
                    throw new Exception("Incomplete data chunk read from file.");
                }
                int chunkLen = (trLen + blockSize - 1) / blockSize * blockSize;
                for (int i = trLen; i <= chunkLen; i++)
                {
                    buf[i] = 0;
                }
                for (int pos = 0; pos < chunkLen; pos += blockSize)
                {
                    bsc.crypt(buf, pos);
                }
                reqLen = (int)Math.Min(outDataLen - filePos, chunkLen);

                outStream.Write(buf, 0, reqLen);

                filePos += chunkLen;
            }
        }

        private static void xor(byte[] a, int pos, byte[] b)
        {
            for (int p = 0; p < blockSize; p++)
            {
                a[pos + p] ^= b[p];
            }
        }

        private static long readDataLength(FileStream stream, BlockStreamCrypter bsc)
        {
            byte[] buf = new byte[blockSize];
            int trLen = stream.Read(buf, 0, blockSize);
            if (trLen != blockSize)
            {
                throw new Exception("Unable to read data length suffix.");
            }
            bsc.crypt(buf, 0);
            return unpackDataLength(buf);
        }

        private static void writeDataLength(FileStream stream, long dataLength, BlockStreamCrypter bsc)
        {
            byte[] a = packDataLength(dataLength);
            bsc.crypt(a, 0);
            stream.Write(a, 0, blockSize);
        }

        // Packs an integer into an 8-byte block. Used to encode the file size.
        // To support larger files, we allow 13 more bits than the original IDEA V1.1 implementation.
        // But files larger than 4GB are no longer backward compatible with the old IDEA V1.1 file structure.
        private static byte[] packDataLength(long i)
        {
            if (i > 0x1FFFFFFFFFFFL) // 45 bits
            {
                throw new ArgumentException("Text too long.");
            }
            byte[] b = new byte[blockSize];
            b[7] = (byte)(i << 3);
            b[6] = (byte)(i >> 5);
            b[5] = (byte)(i >> 13);
            b[4] = (byte)(i >> 21);
            b[3] = (byte)(i >> 29);
            b[2] = (byte)(i >> 37);
            return b;
        }

        // Extracts an integer from an 8-byte block. Used to decode the file size.
        // Returns -1 if the encoded value is invalid. This means that the input file is not a valid cryptogram.
        private static long unpackDataLength(byte[] b)
        {
            if (b[0] != 0 || b[1] != 0 || (b[7] & 7) != 0)
            {
                return -1;
            }
            return
               (long)(b[7] & 0xFF) >> 3 |
               (long)(b[6] & 0xFF) << 5 |
               (long)(b[5] & 0xFF) << 13 |
               (long)(b[4] & 0xFF) << 21 |
               (long)(b[3] & 0xFF) << 29 |
               (long)(b[2] & 0xFF) << 37;
        }
    }
}
