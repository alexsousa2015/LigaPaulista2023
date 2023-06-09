﻿using System.Collections.Generic;

namespace LigaPaulista.Core.SDK.Utils
{
    public class SpecialCharacters
    {
        public string RemoveSpecialCharacters(string self)
        {
            var normalizedString = self;

            // Prepara a tabela de símbolos.
            var symbolTable = new Dictionary<char, char[]>();
            symbolTable.Add('a', new char[] { 'à', 'á', 'ä', 'â', 'ã' });
            symbolTable.Add('c', new char[] { 'ç' });
            symbolTable.Add('e', new char[] { 'è', 'é', 'ë', 'ê' });
            symbolTable.Add('i', new char[] { 'ì', 'í', 'ï', 'î' });
            symbolTable.Add('o', new char[] { 'ò', 'ó', 'ö', 'ô', 'õ' });
            symbolTable.Add('u', new char[] { 'ù', 'ú', 'ü', 'û' });

            // Substitui os símbolos.
            foreach (var key in symbolTable.Keys)
            {
                foreach (var symbol in symbolTable[key])
                {
                    normalizedString = normalizedString.Replace(symbol, key).Replace(",", "");
                    //normalizedString = normalizedString.Replace(string.Format("{0}", '"'), "");
                }
            }

            // Remove os outros caracteres especiais.
            //normalizedString = Regex.Replace(normalizedString, "[^0-9a-zA-Z._]+?", "");
            return normalizedString;
        }
    }
}
