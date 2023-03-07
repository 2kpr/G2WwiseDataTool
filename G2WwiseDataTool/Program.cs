﻿using System.Diagnostics;
using CommandLine;

namespace G2WwiseDataTool
{
    public class Program
    {
        public static List<string> errorLogs = new List<string>();

        static void Main(string[] args)
        {
            var bufferedListener = new BufferedTraceListener();
            Trace.Listeners.Add(bufferedListener);

            var parser = Parser.Default.ParseArguments<Options>(args);

            parser
                .WithParsed(options =>
                {
                    if (options.inputPath != null)
                    {
                        if (Path.GetFileName(options.inputPath) != "SoundbanksInfo.xml")
                        {
                            Console.WriteLine("Input file specified must be SoundBanksInfo.xml");
                            return;
                        }
                        else
                        {
                            SoundbanksInfoParser.ReadSoundbankInfo(options.inputPath, Path.TrimEndingDirectorySeparator(options.outputPath) + "\\", options.outputToFolderStructure, options.rpkgPath, options.verbose);
                        }
                    }

                    if (options.licenses)
                    {
                        Licenses.PrintLicenses();
                    }

                });

            bufferedListener.WriteBufferedMessages();
        }

    }
}