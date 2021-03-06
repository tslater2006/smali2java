﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smali2Java
{
    public static class SmaliUtils
    {
        public static class General
        {
            public static String Eat(ref String s, String until, bool addLength = false)
            {
                String rv = s.Substring(0, s.IndexOf(until));
                s = s.Substring(rv.Length + (addLength ? until.Length : 0));
                return rv;
            }

            public static String Eat(ref String s, char until, bool addLength = false)
            {
                String rv = s.Substring(0, s.IndexOf(until));
                s = s.Substring(rv.Length + (addLength ? 1 : 0));
                return rv;
            }

            public static String Name2Java(String smaliName)
            {
                if (smaliName.StartsWith("L"))
                    smaliName = smaliName.Substring(1);
                if (smaliName.EndsWith(";"))
                    smaliName = smaliName.Remove(smaliName.Length - 1, 1);
                smaliName = smaliName.Replace("/", ".");
                return smaliName;
            }

            public static String Modifiers2Java(SmaliLine.EAccessMod eAccessMod, SmaliLine.ENonAccessMod eNonAccessMod)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(eAccessMod == 0 ? "" : eAccessMod.ToString().ToLowerInvariant().Replace(",", ""));
                sb.Append(eNonAccessMod == 0 ? "" : eNonAccessMod.ToString().ToLowerInvariant().Replace(",", ""));
                return sb.ToString();
            }

            public static String ReturnType2Java(SmaliLine.LineReturnType rt, String customType)
            {
                if (rt != SmaliLine.LineReturnType.Custom)
                    return Name2Java(rt.ToString().ToLowerInvariant().Trim());
                else
                    return customType;
            }

            public static SmaliLine.LineReturnType GetReturnType(String s)
            {
                String rt = s.ToLowerInvariant().Trim();
                switch(rt)
                {
                    case "v":
                        return SmaliLine.LineReturnType.Void;
                    case "i":
                        return SmaliLine.LineReturnType.Int;
                    default: 
                        return SmaliLine.LineReturnType.Custom;
                }                
            }
        }
    }
}
