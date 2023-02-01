

namespace DtoLayer.DTOs.ApUserDTOs
{
    public class AppUserRegisterAddDTO
    {
       
        public string Name { get; set; }
               
        public string SurName { get; set; }
               
        public string UserName { get; set; }
        
        public string? Gender { get; set; }
                
        public string? ImageUrl { get; set; }
              
        public string Email { get; set; }
               
        public string Password { get; set; }
                
        public string ConfirmPassword { get; set; }
    }
}
