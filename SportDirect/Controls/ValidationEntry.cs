using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SportDirect.Controls
{
    public class ValidationEntry : Entry
    {
        public static readonly BindableProperty IsValidProperty =
         BindableProperty.Create("IsValid", typeof(bool), typeof(ValidationEntry), false);
        public bool IsValid { get; set; }
    }
}
