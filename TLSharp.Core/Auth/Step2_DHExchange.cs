using System;
using System.Collections.Generic;
using System.IO;
using TLSharp.Core.MTProto;
using TLSharp.Core.MTProto.Crypto;

namespace TLSharp.Core.Auth
{
    public class Step2_Response
    {
        public byte[] Nonce { get; set; }
        public byte[] ServerNonce { get; set; }
        public byte[] NewNonce { get; set; }
        public byte[] EncryptedAnswer { get; set; }
    }

    public class Step2_DHExchange
    {
        public byte[] NewNonce { get; }

        public Step2_DHExchange()
        {
            NewNonce = new byte[32];
        }

        public byte[] ToBytes(byte[] nonce, byte[] serverNonce, List<byte[]> fingerprints, BigInteger pq)
        {
            new Random().NextBytes(NewNonce);

            var pqPair = Factorizator.Factorize(pq);

            byte[] reqDhParamsBytes;

            using (var pqInnerData = new MemoryStream(255))
            {
                using (var pqInnerDataWriter = new BinaryWriter(pqInnerData))
                {
                    pqInnerDataWriter.Write(0x83c95aec); // pq_inner_data
                    Serializers.Bytes.Write(pqInnerDataWriter, pq.ToByteArrayUnsigned());
                    Serializers.Bytes.Write(pqInnerDataWriter, pqPair.Min.ToByteArrayUnsigned());
                    Serializers.Bytes.Write(pqInnerDataWriter, pqPair.Max.ToByteArrayUnsigned());
                    pqInnerDataWriter.Write(nonce);
                    pqInnerDataWriter.Write(serverNonce);
                    pqInnerDataWriter.Write(NewNonce);

                    byte[] cipherText = null;
                    byte[] targetFingerprint = null;
                    foreach (var fingerprint in fingerprints)
                    {
                        cipherText = RSA.Encrypt(BitConverter.ToString(fingerprint).Replace("-", string.Empty),
                                                 pqInnerData.GetBuffer(), 0, (int)pqInnerData.Position);
                        if (cipherText != null)
                        {
                            targetFingerprint = fingerprint;
                            break;
                        }
                    }

                    if (cipherText == null)
                    {
                        throw new InvalidOperationException(
                            $"not found valid key for fingerprints: {string.Join(", ", fingerprints)}");
                    }

                    using (var reqDhParams = new MemoryStream(1024))
                    {
                        using (var reqDhParamsWriter = new BinaryWriter(reqDhParams))
                        {
                            reqDhParamsWriter.Write(0xd712e4be); // req_dh_params
                            reqDhParamsWriter.Write(nonce);
                            reqDhParamsWriter.Write(serverNonce);
                            Serializers.Bytes.Write(reqDhParamsWriter, pqPair.Min.ToByteArrayUnsigned());
                            Serializers.Bytes.Write(reqDhParamsWriter, pqPair.Max.ToByteArrayUnsigned());
                            reqDhParamsWriter.Write(targetFingerprint);
                            Serializers.Bytes.Write(reqDhParamsWriter, cipherText);

                            reqDhParamsBytes = reqDhParams.ToArray();
                        }
                    }
                }
                return reqDhParamsBytes;
            }
        }

        public Step2_Response FromBytes(byte[] response)
        {
            using (var responseStream = new MemoryStream(response, false))
            {
                using (var responseReader = new BinaryReader(responseStream))
                {
                    var responseCode = responseReader.ReadUInt32();

                    if (responseCode == 0x79cb045d)
                    {
                        // server_DH_params_fail
                        throw new InvalidOperationException("server_DH_params_fail: TODO");
                    }

                    if (responseCode != 0xd0e8075c)
                    {
                        throw new InvalidOperationException($"invalid response code: {responseCode}");
                    }

                    var nonceFromServer = responseReader.ReadBytes(16);

                    // TODO:!
                    /*
					if (!nonceFromServer.SequenceEqual(nonce))
					{
						logger.debug("invalid nonce from server");
						return null;
					}
					*/


                    var serverNonceFromServer = responseReader.ReadBytes(16);

                    // TODO: !
                    /*
					if (!serverNonceFromServer.SequenceEqual(serverNonce))
					{
						logger.error("invalid server nonce from server");
						return null;
					}
					*/

                    var encryptedAnswer = Serializers.Bytes.Read(responseReader);

                    return new Step2_Response
                    {
                        EncryptedAnswer = encryptedAnswer,
                        ServerNonce = serverNonceFromServer,
                        Nonce = nonceFromServer,
                        NewNonce = NewNonce
                    };
                }
            }
        }
    }
}
