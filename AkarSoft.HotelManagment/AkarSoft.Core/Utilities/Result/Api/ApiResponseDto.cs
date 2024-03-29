﻿using AkarSoft.Core.Utilities.Result.Api.ComplexTypes;
using System.Text.Json.Serialization;

namespace AkarSoft.Core.Utilities.Result.Api
{
    // Generic olarak bir data alsın.
    public class ApiResponseDto<T>
    {
        [JsonIgnore] // Json a dönüşte bunu ekleme diyoruz. // serialize edilirken Status code çıkmasın biz bunlar result yapısında kullanacağız 
        public int StatusCode { get; set; } // Statü kodunu tutacağız
                                            // bu status code ü dış dünyaya açmak istemiyorum.
                                            // yani client lere endpointlere istekler sonucunda status code dönmek istemiyorum
                                            // clientler ilgili status code una sahip oluyorlar zaten 
                                            // illaki döneceğiniz response un bodysinde dönmeyeceğim 
        public string Message { get; set; }
        public List<string> ErrorMessage { get; set; }
        public T Data { get; set; }


        ///  Methods (new anahtar sözcüğü yerine ilgili methodlar vastıası ile oluşturabilirsiniz. Tercih sizin.)
        public static ApiResponseDto<T> SuccessResult(ApiResponseStatus statuscode, T data) // verileri listelemek gibi 
        {
            return new ApiResponseDto<T>() { Data = data, StatusCode = Convert.ToInt32(statuscode) };
        }
        public static ApiResponseDto<T> SuccessResult(ApiResponseStatus statuscode) // illaki data dönmem gerekmeyen bir durum olabilir // Update işlemi gibi yada delete işlemi gibi geriye data dönülmez.
        {
            return new ApiResponseDto<T>() { StatusCode = Convert.ToInt32(statuscode) };
        }
        public static ApiResponseDto<T> FailResult(List<string> Error, ApiResponseStatus statuscode) // hataları döneceğim alan. 
        {
            return new ApiResponseDto<T>() { StatusCode = Convert.ToInt32(statuscode), ErrorMessage = Error };
        }

        public static ApiResponseDto<T> FailResult(string Error, ApiResponseStatus statuscode) // Bazen tek bir hata gelebilir (yani operasyonel bir süreç olabilir validasyon hatasından ziyade)
        {
            return new ApiResponseDto<T>() { StatusCode = Convert.ToInt32(statuscode), ErrorMessage = new() { Error } };
        }


    }


}
