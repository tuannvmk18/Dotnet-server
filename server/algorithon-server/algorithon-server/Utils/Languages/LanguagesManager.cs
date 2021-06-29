using System;
using System.Collections.Generic;
using algorithon_server.Models;

namespace algorithon_server.Utils.Languages
{
    public class LanguagesManager
    {
        private Language[] _languagesMap = new LanguagesTable().getLanguagesTable();
        
        public bool IsLangSupported(String lang, String version)
        {
            foreach (var language in this._languagesMap)
            {
                if (language.Lang == lang)
                {
                    return true;
                }
            }

            return false;
        }
    }
}