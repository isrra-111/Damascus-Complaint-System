namespace DamascusComplaintSystem.Api.DTOs
{
    public class ComplaintReadDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string NationalId { get; set; }

        public string PropertyNumber { get; set; }

        public string CadastralZone { get; set; }

        public string ParcelNumber { get; set; }

        public string PropertyLocationDescription { get; set; }

        public string ComplaintText { get; set; }

        public int ComplaintTypeId { get; set; }

        public string ComplaintTypeName { get; set; }

        public string ComplaintTypeArabicName { get; set; }

        public int ComplaintRepeatCount { get; set; }

        public int? PreviousComplaintNumber { get; set; }

        public DateTime? PreviousComplaintDate { get; set; }

        public DateTime SubmittedAt { get; set; }

    }
}
