using System;
using algorithon_server.Models;

namespace algorithon_server.Utils.Languages
{
    public class LanguagesTable
    {
        private Language[] Languages = new Language[]
        {
            new Language()
            {
                Lang = "java",
                Version = "JDK 11.0.4",
                Name = "Java",
                Index = "3"
            },
            new Language()
            {
                Lang = "c",
                Version = "GCC 8.1.0",
                Name = "C",
                Index = "3"
            },
            new Language()
            {
                Lang = "nodejs",
                Version = "12.11.1",
                Name = "NodeJS",
                Index = "3"
            }, 
            new Language()
            {
                Lang = "python2",
                Version = "2.7.16",
                Name = "Python 2",
                Index = "2"
            },
            new Language()
            {
                Lang = "python3",
                Version = "3.7.4",
                Name = "Python 3",
                Index = "3"
            }, 
            new Language()
            {
                Lang = "ruby",
                Version = "2.6.5",
                Name = "Ruby",
                Index = "3"
            }, 
            new Language()
            {
                Lang = "go",
                Version = "1.13.1",
                Name = "GO Lang",
                Index = "3"
            }, 
            new Language()
            {
                Lang = "pascal",
                Version = "fpc-3.0.4",
                Name = "Pascal",
                Index = "2"
            }, 
            new Language()
            {
                Lang = "csharp",
                Version = "mono 6.0.0",
                Name = "C#",
                Index = "3"
            }, 
            new Language()
            {
                Lang = "swift",
                Version = "5.1",
                Name = "Swift",
                Index = "3"
            }, 
            new Language()
            {
                Lang = "dart",
                Version = "2.5.1",
                Name = "Dart",
                Index = "3"
            }, 
            new Language()
            {
                Lang = "kotlin",
                Version = "1.3.50 (JRE 11.0.4)",
                Name = "Kotlin",
                Index = "2"
            }, 
        };

        public Language[] getLanguagesTable()
        {
            return this.Languages;
        }
    }
}