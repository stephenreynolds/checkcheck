using System;
using System.IO;
using System.Security.Cryptography;
using CommandLine;

namespace CheckCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            // Parse the arguments and compare file and hash using given algorithm.
            ParserResult<Options> result = Parser.Default.ParseArguments<Options>(args);
            result.WithParsed<Options>(o => CompareHash(o.InputFile, o.Hash, o.Algorithm));
        }

        static void CompareHash(string filePath, string hash, AlgorithmEnum algorithm)
        {
            string fileHash = ComputeHash(filePath, algorithm);

            // Make sure file hash was computed successfully and compare with given hash.
            if (fileHash == null)
            {
                Console.WriteLine("Invalid hashing algorithm given. Valid options are: MD5, SHA1, SHA256, SHA384, and SHA512.");
            }
            else if (fileHash == hash)
            {
                Console.WriteLine($"{Path.GetFileName(filePath)} validated succcessfully.");
            }
            else
            {
                Console.WriteLine($"{algorithm.ToString()} validation FAILED!");
                Console.WriteLine($"File hash is: \t\t\t{fileHash}\nBut the hash given was: \t{hash}");
            }
        }

        static string ComputeHash(string filePath, AlgorithmEnum algorithm)
        {
            // Read the file.
            using(var stream = new BufferedStream(File.OpenRead(filePath), 1200000))
            {
                HashAlgorithm hashAlgorithm;

                switch (algorithm)
                {
                    case AlgorithmEnum.MD5:
                        hashAlgorithm = MD5.Create();
                        break;
                    case AlgorithmEnum.SHA1:
                        hashAlgorithm = new SHA1Managed();
                        break;
                    case AlgorithmEnum.SHA256:
                        hashAlgorithm = new SHA256Managed();
                        break;
                    case AlgorithmEnum.SHA384:
                        hashAlgorithm = new SHA384Managed();
                        break;
                    case AlgorithmEnum.SHA512:
                        hashAlgorithm = new SHA512Managed();
                        break;
                    default:
                        return null;
                }

                byte[] fileHash = hashAlgorithm.ComputeHash(stream);
                return BitConverter.ToString(fileHash).Replace("-", string.Empty);
            }
        }
    }
}
