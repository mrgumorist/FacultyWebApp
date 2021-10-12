using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace FacultyWebApp.DAL.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class PhoneMaskAttribute : ValidationAttribute
    {
        readonly string _mask;

        public string Mask
        {
            get { return _mask; }
        }

        public PhoneMaskAttribute(string mask)
        {
            _mask = mask;
        }


        public override bool IsValid(object value)
        {
            var phoneNumber = (String)value;
            bool result = true;
            if (this.Mask != null)
            {
                result = MatchesMask(this.Mask, phoneNumber);
            }
            return result;
        }

        internal bool MatchesMask(string mask, string phoneNumber)
        {
            //TODO: Add regual expression
            if (mask.Length != phoneNumber.Trim().Length)
            {
                return false;
            }
            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i] == 'd' && char.IsDigit(phoneNumber[i]) == false)
                {
                    return false;
                }
                if (mask[i] == '+' && phoneNumber[i] != '+')
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
