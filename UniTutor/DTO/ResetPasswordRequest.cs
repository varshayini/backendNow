namespace UniTutor.DTO
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }
        public int? VerificationCode { get; set; }
        public string NewPassword { get; set; }

    }
}
