// <copyright file="Program.cs" company="ProcessingTools">
// Copyright (c) 2020 ProcessingTools. All rights reserved.
// </copyright>

namespace ProcessingTools.Console.XslTransformer
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Xsl;

    /// <summary>
    /// Main program class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args">Arguments.</param>
        public static void Main(string[] args)
        {
            if (args is null || args.Length < 2)
            {
                PrintHelp();
                Environment.Exit(1);
                return;
            }

            string xsltFileName = args[0];
            string inputFileName = args[1];
            string outFileName = args.Last();

            if (outFileName == inputFileName)
            {
                outFileName = $"{Path.GetFileNameWithoutExtension(inputFileName)}.{DateTime.Now:yyyyMMddHHmmssffffff}.{Path.GetExtension(inputFileName).Trim('.')}";
            }

            XslCompiledTransform xsl = new XslCompiledTransform();
            xsl.Load(xsltFileName);
            xsl.Transform(inputFileName, outFileName);
        }

        private static void PrintHelp()
        {
            Console.WriteLine($"Usage: {AppDomain.CurrentDomain.FriendlyName} <XSLT file name> <input file name>[ <output file name>]");
        }
    }
}
