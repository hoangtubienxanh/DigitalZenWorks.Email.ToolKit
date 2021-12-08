﻿/////////////////////////////////////////////////////////////////////////////
// <copyright file="Program.cs" company="James John McGuire">
// Copyright © 2021 James John McGuire. All Rights Reserved.
// </copyright>
/////////////////////////////////////////////////////////////////////////////

using Common.Logging;
using DbxToPstLibrary;
using DigitalZenWorks.Email.DbxOutlookExpress;
using MsgKit;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;

[assembly: CLSCompliant(true)]

namespace DbxToPst.Test
{
	/// <summary>
	/// Dbx to pst test program class.
	/// </summary>
	public static class Program
	{
		private static readonly ILog Log = LogManager.GetLogger(
#pragma warning disable CS8602 // Dereference of a possibly null reference.
			MethodBase.GetCurrentMethod().DeclaringType);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

		/// <summary>
		/// The program's main entry point.
		/// </summary>
		/// <param name="arguments">The arguments given to the program.</param>
		public static void Main(string[] arguments)
		{
			LogInitialization();

			Log.Info("Test console app");

#if NET5_0_OR_GREATER
			Log.Info("NET 5.0 or greater Supported framworks");
#endif
#if NETCOREAPP3_0_OR_GREATER
			Log.Info("NETCOREAPP 3.0 or greater Supported framworks");
#endif
#if NETSTANDARD1_1_OR_GREATER
			Log.Info("NET Standard 1.1 or greater Supported framworks");
#endif

			if (arguments != null && arguments.Length > 0)
			{
				Encoding.RegisterProvider(
					CodePagesEncodingProvider.Instance);
				Encoding encoding = Encoding.GetEncoding("shift_jis");

				TestStringToStream();

				DbxSet dbxSet = new (arguments[0], encoding);

				dbxSet.List();
			}
			else
			{
				Log.Error("Invalid arguments");
			}
		}

		private static void LogInitialization()
		{
			string applicationDataDirectory = @"DigitalZenWorks\DbxToPst";
			string baseDataDirectory = Environment.GetFolderPath(
				Environment.SpecialFolder.ApplicationData,
				Environment.SpecialFolderOption.Create) + @"\" +
				applicationDataDirectory;

			string logFilePath = baseDataDirectory + "\\DbxToPst.log";
			string outputTemplate =
				"[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] " +
				"{Message:lj}{NewLine}{Exception}";

			LoggerConfiguration configuration = new ();
			LoggerSinkConfiguration sinkConfiguration = configuration.WriteTo;
			sinkConfiguration.Console(LogEventLevel.Verbose, outputTemplate);
			sinkConfiguration.File(
				logFilePath, LogEventLevel.Verbose, outputTemplate);
			Serilog.Log.Logger = configuration.CreateLogger();

			LogManager.Adapter =
				new Common.Logging.Serilog.SerilogFactoryAdapter();
		}

		private static void TestStringToStream()
		{
			string test = "Testing 1-2-3";

			// convert string to stream
			byte[] byteArray = Encoding.UTF8.GetBytes(test);
			MemoryStream stream = new MemoryStream(byteArray);

			TestStream(stream);
		}

		private static void TestStream(Stream stream)
		{
			// convert stream to string
			using StreamReader reader2 = new StreamReader(stream);
			string text2 = reader2.ReadToEnd();
			Log.Info(text2);
		}
	}
}
