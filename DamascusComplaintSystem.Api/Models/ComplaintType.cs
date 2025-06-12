namespace DamascusComplaintSystem.Api.Models
{
    public class ComplaintType
    {
        public int Id { get; set; }            // نفس قيمة enum
        public string Name { get; set; }       // اسم بالإنجليزي
        public string ArabicName { get; set; } // الاسم العربي

    }
}
