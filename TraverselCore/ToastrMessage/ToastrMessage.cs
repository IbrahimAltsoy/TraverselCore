﻿namespace TraverselCore.ToastrMessage
{
    public class ToastrMessage
    {
        public static class MessajeToastr
        {
            public static string ToastrLoginSuccesfull(string username)
            {
                return $"{username} kullanıcısı başarılı bir şekilde giriş yaptı";

            }
            public static string ToastrLoginUnSuccesfull(string username)
            {
                return $"{username} kullanıcısı girişi başarısız oldu";

            }
            public static string ToastrAddSuccesfull(string title)
            {
                return $"{title} başlıklı içerik başarıyla eklendi.";
            }
            public static string ToastrUpdateSuccesfull(string title)
            {
                return $"{title} başlıklı içerik başarıyla güncellendi.";
            }
            public static string ToastrAddUnSuccessfull(string title)
            {
                return $"{title} başlıklı içerik eklenemedi!!!.";
            }
            public static string ToastrUpdateUnSuccessfull(string title)
            {
                return $"{title} başlıklı içerik başarıyla güncellenemedi!!!";
            }
            public static string ToastrDeleteSuccessful(string title)
            {
                return $"{title} başlıklı içerik başarıyla silindi!!!";
            }
            public static string ToastrMailSuccessful(string title)
            {
                return $"{title} başlıklı içerik başarıyla mail gönderildi!!!";
            }
        }
    }
}
