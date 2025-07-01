using System.ComponentModel.DataAnnotations;

namespace DamascusComplaintSystem.Api.DTOs
{
    public class ComplaintDto
    {
        public  int Id { get; set; }

        [Required(ErrorMessage = "الاسم الكامل مطلوب")]
        [StringLength(100, ErrorMessage = "الاسم لا يمكن أن يزيد عن 100 حرف")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "الرقم الوطني مطلوب")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "الرقم الوطني يجب أن يتكون من 11 رقم")]
        public string NationalId { get; set; }

        // (رقم العقار (اختياري.
        public string? PropertyNumber { get; set; }

         // -المنطقة العقارية -اختياري
        public string? CadastralZone { get; set; }

        // (رقم المقسم داخل المنطقة العقارية (اختياري

        public string? ParcelNumber { get; set; }

        // (وصف موقع العقار (مطلوب
        
        [Required(ErrorMessage = "وصف موقع العقار مطلوب")]
        public string PropertyLocationDescription { get; set; }

        
        // (نص الشكوى (مطلوب
        
        [Required(ErrorMessage = "محتوى الشكوى مطلوب")]
        public string ComplaintText { get; set; }

        [Required(ErrorMessage = "نوع الشكوى مطلوب")]
        public int ComplaintTypeId { get; set; }   // المفتاح الأجنبي


        // عدد مرات تكرار الشكوى
        [Required(ErrorMessage = "عدد مرات تكرار الشكوى مطلوب")]
        [Range(0, 100, ErrorMessage = "عدد التكرارات يجب أن يكون بين 0 و 100")]
        public int? ComplaintRepeatCount { get; set; }

        // رقم الشكوى السابقة .
        public string? PreviousComplaintNumber { get; set; }
 
        // تاريخ الشكوى السابقة 
        public DateTime? PreviousComplaintDate { get; set; }

        [Required(ErrorMessage = "حالة الشكوى مطلوبة")]
        public int ComplaintStatusId { get; set; }  

       

    }
}
