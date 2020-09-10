using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SportDirect.Behaviors
{
    public class RegexBehavior
    {
        public static Regex userNameRegex() => new Regex(@"^[a-zA-Z]*$");
        /*public static Regex emailRegex() => new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");*/
        public static Regex emailRegex() => new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public static Regex phoneNumberRegex() => new Regex(@"[0-9]");
        //public static Regex passwordRegex() => new Regex(@" (?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$");
        // public static Regex passwordRegex() => new Regex(@" ^ ((?=.*\d)(?=.*[A-Z])(?=.*\W).{8,8})$");
        public static Regex passwordRegex() => new Regex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$");
    }
}