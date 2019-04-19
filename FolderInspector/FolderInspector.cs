/*
 * Author:  Clyde D'Souza
 * Project: Folder Inspector
 * Twitter: @ClydeDz
 * GitHub:  @ClydeDz 
 */

using System;
using System.Configuration;
using System.IO;
using FolderInspector.Constants;
using FolderInspector.Helper;
using FolderInspector.Utilities;

namespace FolderInspector
{
    internal class FolderInspector
    {
        /// <summary>
        /// Applications entry point.
        /// </summary>
        /// <param name="args">Optionally supply command line arguments</param>
        internal static void Main(string[] args)
        {
            try
            {
                //Print mandatory application meta information on console
                CommandLineHelper.PrintHeader();

                //Process command line arguments if any and set configuration settings
                var settings = ProcessCommandLineArguments(args);
                var config = SetApplicationConfiguration(settings);
                if (settings.VanityCommandRequested)
                {
                    return;
                }

                //Initiate file processing
                IFolderUtility _folderUtility = new FolderUtility(new WordUtility(), new ExcelUtility(), new AppSettingsUtility(config));
                _folderUtility.StartFileProcessing();

            }
            catch (Exception ex)
            {
                CommandLineHelper.WriteError($"Error: {ex.Message}");
            }
            finally
            {
                Console.ResetColor();
#if DEBUG
                CommandLineHelper.WriteLog("\nProgram ended");
                Console.Read();
#endif
            }
        }

        static Configuration SetApplicationConfiguration(CommandLineSettings settings)
        { 
            if (settings.ConfigSupplied && string.IsNullOrEmpty(settings.ConfigFilePath))
            {
                throw new ConfigurationErrorsException("Please supply a configuration file");
            }

            try
            {
                var configMap = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = string.IsNullOrEmpty(settings.ConfigFilePath) ? AppConstants.DefaultConfigFile : settings.ConfigFilePath
                };
                return ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            }
            catch
            {
                throw new ConfigurationErrorsException("Invalid or no configuration file");
            }
        }

        static CommandLineSettings ProcessCommandLineArguments(string[] arguments)
        {
            var settings = new CommandLineSettings();
            IFolderUtility _folderUtility = new FolderUtility();

            //Where only single arguments will be catered to
            for (var index = 0; index < arguments.Length; index++)
            {
                var currentArgument = arguments[index];

                if (_folderUtility.IsHelpCommand(currentArgument))
                {
                    CommandLineHelper.PrintHelp();
                    settings.VanityCommandRequested = true;
                    return settings;
                }

                if (_folderUtility.IsVersionCommand(currentArgument))
                {
                    CommandLineHelper.PrintVersion();
                    settings.VanityCommandRequested = true;
                    return settings;
                }
            }

            //Where multiple arguments are allowed
            for (var index = 0; index < arguments.Length; index++)
            {
                var currentArgument = arguments[index];

                if (_folderUtility.IsConfigCommand(currentArgument))
                {
                    settings.ConfigFilePath = _folderUtility.DoesArrayContentExists(arguments, index + 1) ? arguments[index + 1] : null;
                    settings.ConfigSupplied = true;
                }
            }

            return settings;
        }
    }
}

