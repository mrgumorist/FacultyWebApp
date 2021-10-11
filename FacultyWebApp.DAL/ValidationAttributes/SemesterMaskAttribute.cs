using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace FacultyWebApp.DAL.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class SemesterMaskAttribute : ValidationAttribute
    {
        readonly string _mask;

        public string Mask
        {
            get { return _mask; }
        }

        public SemesterMaskAttribute(string mask)
        {
            _mask = mask;
        }

        public override bool IsValid(object value)
        {
            var specialCode = (String)value;
            bool result = true;
            if (this.Mask != null)
            {
                result = MatchesMask(this.Mask, specialCode);
            }
            return result;
        }

        internal bool MatchesMask(string mask, string specialCode)
        {
            if (mask.Length != specialCode.Trim().Length)
            {
                return false;
            }
            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i] == 'd' && char.IsDigit(specialCode[i]) == false)
                {
                    return false;
                }
                if (mask[i] == '_' && specialCode[i] != '_')
                {
                    return false;
                }
            }
            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name, this.Mask);
        }
    }
}
