namespace MailManagement.Models
{
    public class Mail_D_BIT_22_0015
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int SenderDepartmentId { get; set; }
        public int RecipientDepartmentId { get; set; }
        public MailStatus_D_BIT_22_0015 Status { get; set; }
    }
}
