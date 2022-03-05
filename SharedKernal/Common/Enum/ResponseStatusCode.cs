namespace SharedKernal.Common.Enum
{
    /// <summary>
    /// 
    /// </summary>
    public enum ResponseStatusCode
    {
        [EnumMessage("تمت العمليه بنجاح")]
        Successfully = 1,
        [EnumMessage("لا نوجد بيانات")]
        NotFound = 2,
        [EnumMessage("العملية غير صالحة")]
        NotAccept = 3,
        [EnumMessage("خطأ, برجاء التأكد من البيانات")]
        MultiError = 4,
        [EnumMessage("حركة غير صالحة")]
        MoveNotAccept = 5,
        [EnumMessage("خطأ في النظام")]
        SystemInternalError = 6,
        [EnumMessage("تكرار في البيانات")]
        Dublicate = 7,
        [EnumMessage("خطأ في البيانات")]
        InvalidData = 8,
        [EnumMessage("تمت عملية الحذف بنجاح")]
        DeleteSuccessfully = 9,
        [EnumMessage("لا يمكن إتمام عملية الحذف لإرتباطة ببيانات أخرى")]
        DeleteNotAccept = 10
    }

}
