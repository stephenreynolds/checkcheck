using System.Collections.Generic;
using CommandLine;

namespace CheckCheck
{
    class Options
    {
        [Option('f', "file", Required = true, HelpText = "File to be checked.")]
        public string InputFile { get; set; }

        [Option('h', "hash", Required = true, HelpText = "Hash to compare against file.")]
        public string Hash { get; set; }

        [Option('a', "algorithm", Required = true, HelpText = "Algorithm that was used to generate the hash (MD5, SHA1, SHA256, SHA384, or SHA512).")]
        public AlgorithmEnum Algorithm { get; set; }
    }
}
