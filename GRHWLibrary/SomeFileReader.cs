﻿using System.Security;

namespace GRHWLibrary
{
    public class SomeFileReader : ISomeFileReader
    {
        private string _filePath;

        public SomeFileReader(string filePath)
        {
            _filePath = filePath;

        }

        public string[] OpenFile()
        {
            string[] result = null;
            if (File.Exists(_filePath))
            {
                try
                {
                    result = File.ReadAllLines(_filePath);
                }
                // catch and log exception and return generic error message
                catch (ArgumentException)
                {
                    throw;
                }
                catch (PathTooLongException)
                {
                    throw;
                }
                catch (DirectoryNotFoundException)
                {
                    throw;
                }
                //catch (FileNotFoundException)
                //{
                //    throw;
                //}
                catch (IOException)
                {
                    throw;
                }
                catch (UnauthorizedAccessException)
                {
                    throw;
                }
                catch (NotSupportedException)
                {
                    throw;
                }
                catch (SecurityException)
                {
                    throw;
                } 
            }
            else
            {
                Console.WriteLine("File not found");
            }
            return result;
        }
    }
}
