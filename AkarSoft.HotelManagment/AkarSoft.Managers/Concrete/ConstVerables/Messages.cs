using AkarSoft.Dtos.Concrete.Rooms;
using AkarSoft.Entities.Concrete.Hotels;

namespace AkarSoft.Managers.Concrete.ConstVerables
{
    public static class Messages
    {
        public static class CRUD
        {
            public const string Created = "Kayıt Olusturuldu.";
            public const string Updated = "Kayıt Güncellendi.";
            public const string Deleted = "Kayıt Silindi";
            public const string SoftDeleted = "Kayıt Silindi";
        }

        public static class Status
        {
            public const string Success = "İşlem Başarılı.";
            public const string NotFound = "Kayıt Bulunamadı.";
            public const string NotCreated = "Kayıt Oluşturulamadı.";

            public const string MediaUploadError = "Media yüklemesi gerçekleştirilirken bir hata meydana geldi : ";
        }
        //public static string GetMessageForType(Type typereferences)
        //{
             


        //    switch (type)
        //    {
        //        case RoomListDto :
        //            return Status.NotFound;
        //        default:
        //            return Status.Success; // Varsayılan olarak başarı mesajını döndürür.
        //    }
        //}

        //private static string GetEntityOrDtoName(Type type)
        //{
        //    if (type == typeof(RoomListDto))
        //    {
        //        return "Otel Odası";
        //    }
        //}
    }
}
