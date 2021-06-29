using System;
using System.ComponentModel.DataAnnotations;

namespace algorithon_server.Models
{
    public class Language
    {
        [Required]
        public string Lang { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Version { get; set; }
        
        [Required]
        public string Index { get; set; }
    }
    
    public class LanguageResponse
    {
        [Required]
        public String Message { get; set; }
        
        [Required]
        public String Error { get; set; }
        
        [Required]
        public Array Data {get; set; }
    }
}