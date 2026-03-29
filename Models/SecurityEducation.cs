using System;
using System.Collections.Generic;

namespace Models
{
    public class SecurityEducation
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Importance { get; set; }

        public List<string> GetSecurityTips()
        {
            return new List<string>
            {
                "تأكد من تغيير كلمات المرور الافتراضية على أجهزة الشبكة.",
                "استخدم تشفير WPA3 إذا كان متاحًا.",
                "قم بتحديث البرامج الثابتة لجهاز التوجيه بانتظام.",
                "تجنب استخدام معلومات شخصية في كلمة المرور."
            };
        }

        public List<string> GetPasswordStrengthTips()
        {
            return new List<string>
            {
                "استخدم كلمات مرور تتكون من 12 حرفًا على الأقل.",
                "اجمع بين الحروف الكبيرة والصغيرة والأرقام والرموز.",
                "لا تستخدم نفس كلمة المرور لأكثر من حساب."
            };
        }

        public List<string> GetWiFiBasics()
        {
            return new List<string>
            {
                "حافظ على جهاز التوجيه في موقع مركزي لمنطقة التغطية المثلى.",
                "استخدم أسماء شبكات خاصة ولا تستخدم الأسماء الشائعة.",
                "قم بتعطيل WPS لتحسين الأمان."
            };
        }
    }
}