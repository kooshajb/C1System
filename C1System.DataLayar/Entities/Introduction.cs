using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.DataLayar.Entities
{
    public class Introduction
    {
        [Key]
        public Guid IntroductionId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
        [MinLength(15, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
        [MaxLength(200, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
        public string Title { get; set; }
        
        [Display(Name = "عنوان فرعی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
        [MinLength(30, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
        [MaxLength(200, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
        public string? SubTitle { get; set; }
        
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
        public string Desc { get; set; }
        
        [Display(Name = "ویدئو")]
        public string Video { get; set; }
        
        [Display(Name = "تصویر کاور ویدئو")]
        public string? VideoCoverImage { get; set; }
    }
}
