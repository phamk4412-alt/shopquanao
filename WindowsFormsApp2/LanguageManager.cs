using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class LanguageManager
    {
        // Enum ?? ??nh ngh?a các ngôn ng?
        public enum Language
        {
            Vietnamese = 0,
            English = 1
        }

        private static Language currentLanguage = Language.Vietnamese;

        // Dictionary ch?a các câu v?n theo ngôn ng?
        private static Dictionary<string, Dictionary<Language, string>> translations = new Dictionary<string, Dictionary<Language, string>>()
        {
            // Form Setting
            { "Setting_Title", new Dictionary<Language, string> { { Language.Vietnamese, "Cài ??t" }, { Language.English, "Settings" } } },
            { "Setting_StoreInfo", new Dictionary<Language, string> { { Language.Vietnamese, "Thông tin c?a hàng" }, { Language.English, "Store Information" } } },
            { "Setting_StoreNameLabel", new Dictionary<Language, string> { { Language.Vietnamese, "Tên c?a hàng:" }, { Language.English, "Store Name:" } } },
            { "Setting_AddressLabel", new Dictionary<Language, string> { { Language.Vietnamese, "??a ch?:" }, { Language.English, "Address:" } } },
            { "Setting_EmailLabel", new Dictionary<Language, string> { { Language.Vietnamese, "Email:" }, { Language.English, "Email:" } } },
            { "Setting_SystemConfig", new Dictionary<Language, string> { { Language.Vietnamese, "Cài ??t h? th?ng" }, { Language.English, "System Settings" } } },
            { "Setting_Language", new Dictionary<Language, string> { { Language.Vietnamese, "Ngôn ng?:" }, { Language.English, "Language:" } } },
            { "Setting_LightTheme", new Dictionary<Language, string> { { Language.Vietnamese, "Giao di?n sáng" }, { Language.English, "Light Theme" } } },
            { "Setting_DarkTheme", new Dictionary<Language, string> { { Language.Vietnamese, "Giao di?n t?i" }, { Language.English, "Dark Theme" } } },
            { "Setting_Save", new Dictionary<Language, string> { { Language.Vietnamese, "L?u" }, { Language.English, "Save" } } },
            { "Setting_Cancel", new Dictionary<Language, string> { { Language.Vietnamese, "H?y" }, { Language.English, "Cancel" } } },

            // Messages
            { "Msg_LanguageChanged", new Dictionary<Language, string> { { Language.Vietnamese, "?ã thay ??i ngôn ng? thành {0}!" }, { Language.English, "Language changed to {0}!" } } },
            { "Msg_LightThemeEnabled", new Dictionary<Language, string> { { Language.Vietnamese, "?ã chuy?n sang giao di?n sáng!" }, { Language.English, "Switched to light theme!" } } },
            { "Msg_DarkThemeEnabled", new Dictionary<Language, string> { { Language.Vietnamese, "?ã chuy?n sang giao di?n t?i!" }, { Language.English, "Switched to dark theme!" } } },
            { "Msg_Notification", new Dictionary<Language, string> { { Language.Vietnamese, "Thông báo" }, { Language.English, "Notification" } } },
            { "Msg_Error", new Dictionary<Language, string> { { Language.Vietnamese, "L?i" }, { Language.English, "Error" } } },

            // Main Forms
            { "TrangChu_Title", new Dictionary<Language, string> { { Language.Vietnamese, "Trang Ch?" }, { Language.English, "Home" } } },
            { "SanPham_Title", new Dictionary<Language, string> { { Language.Vietnamese, "S?n Ph?m" }, { Language.English, "Products" } } },
            { "HoaDon_Title", new Dictionary<Language, string> { { Language.Vietnamese, "Hóa ??n" }, { Language.English, "Invoice" } } },
            { "KhachHang_Title", new Dictionary<Language, string> { { Language.Vietnamese, "Khách Hàng" }, { Language.English, "Customer" } } },
        };

        // L?y ngôn ng? hi?n t?i
        public static Language GetCurrentLanguage()
        {
            return currentLanguage;
        }

        // ??t ngôn ng?
        public static void SetLanguage(Language language)
        {
            currentLanguage = language;
        }

        // L?y text d?ch theo key
        public static string GetTranslation(string key)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                    return key;

                if (translations.ContainsKey(key))
                {
                    if (translations[key].ContainsKey(currentLanguage))
                    {
                        return translations[key][currentLanguage];
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Translation error for key '" + key + "': " + ex.Message);
            }
            return key; // Tr? v? key n?u không tìm th?y
        }

        // L?y text d?ch v?i format
        public static string GetTranslation(string key, params object[] args)
        {
            string text = GetTranslation(key);
            try
            {
                if (args != null && args.Length > 0)
                {
                    return string.Format(text, args);
                }
                return text;
            }
            catch
            {
                return text;
            }
        }

        // C?p nh?t ngôn ng? cho t?t c? các form m?
        public static void ApplyLanguageToAllForms(Language language)
        {
            SetLanguage(language);

            foreach (Form form in Application.OpenForms)
            {
                try
                {
                    if (form is Setting settingForm)
                    {
                        settingForm.UpdateLanguage();
                    }
                    else if (form is TrangChu trangChuForm)
                    {
                        trangChuForm.UpdateLanguage();
                    }
                    // Thêm các form khác ? ?ây n?u c?n
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error updating language for form: " + ex.Message);
                }
            }
        }

        // L?y tên ngôn ng?
        public static string GetLanguageName(Language language)
        {
            switch (language)
            {
                case Language.Vietnamese:
                    return "Ti?ng Vi?t";
                case Language.English:
                    return "English";
                default:
                    return "Unknown";
            }
        }

        // L?y Language t? tên
        public static Language GetLanguageFromName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return Language.Vietnamese;

            switch (name.Trim())
            {
                case "Ti?ng Vi?t":
                    return Language.Vietnamese;
                case "English":
                    return Language.English;
                default:
                    return Language.Vietnamese;
            }
        }
    }
}
