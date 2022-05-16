$(document).ready(function () {
	$("#toast-success").on("click", function () {
		toastr.success("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است!", "معجزه ماکس می گوید", {
			timeOut: "50000"
		})
	}), $("#toast-info").on("click", function () {
		toastr.info("ما مجموعه کاپوایی موجود داریم.", "لاک پشت خلیج توچال")
	}), $("#toast-warning").on("click", function () {
		toastr.warning("نام من ... است اینیگو مونتویا است. پدرت را کشتی، آماده مرگ خواهی شد!")
	}), $("#toast-error").on("click", function () {
		toastr.error("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است.", "غیر قابل تصور است!")
	}), $("#toast-position-top-left").on("click", function () {
		toastr.info("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است.", "بالا چپ!", {
			positionClass: "toast-top-left",
			containerId: "toast-top-left",
			timeOut: "50000"
		})
	}), $("#toast-position-top-center").on("click", function () {
		toastr.info("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است.", "بالا مرکز!", {
			positionClass: "toast-top-center",
			containerId: "toast-top-center"
		})
	}), $("#toast-position-top-right").on("click", function () {
		toastr.info("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است.", "بالا راست!", {
			positionClass: "toast-top-right",
			containerId: "toast-top-right"
		})
	}), $("#toast-position-top-full").on("click", function () {
		toastr.info("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است.", "بالا تمام عرض!", {
			positionClass: "toast-top-full-width",
			containerId: "toast-top-full-width"
		})
	}), $("#toast-position-bottom-left").on("click", function () {
		toastr.info("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است.", "پایین چپ!", {
			positionClass: "toast-bottom-left",
			containerId: "toast-bottom-left"
		})
	}), $("#toast-position-bottom-center").on("click", function () {
		toastr.info("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است.", "پایین مرکز!", {
			positionClass: "toast-bottom-center",
			containerId: "toast-bottom-center"
		})
	}), $("#toast-position-bottom-right").on("click", function () {
		toastr.info("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است.", "پایین راست!", {
			positionClass: "toast-bottom-right",
			containerId: "toast-bottom-right"
		})
	}), $("#toast-position-bottom-full").on("click", function () {
		toastr.info("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است.", "پایین تمام عرض!", {
			positionClass: "toast-bottom-full-width",
			containerId: "toast-bottom-full-width"
		})
	}), $("#toast-text-notification").on("click", function () {
		toastr.info("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است!", "معجزه ماکس می گوید")
	}), $("#toast-close-button").on("click", function () {
		toastr.success("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است!", "با دکمه بستن", {
			closeButton: !0
		})
	}), $("#toast-progress-bar").on("click", function () {
		toastr.warning("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است!", "نوار پیشرفت", {
			progressBar: !0
		})
	}), $("#toast-clear-btn").on("click", function () {
		toastr.error('پاک خود را؟<br /><br /><button type="button" class="btn btn-secondary clear">بله</button>', "دکمه تست پاک کردن")
	}), $("#toast-show-remove").on("click", function () {
		toastr.info("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است!", "معجزه ماکس می گوید")
	}), $("#toast-remove").on("click", function () {
		toastr.remove()
	}), $("#toast-show-clear").on("click", function () {
		toastr.info("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است!", "معجزه ماکس می گوید")
	}), $("#toast-clear").on("click", function () {
		toastr.clear()
	}), $("#toast-fast-duration").on("click", function () {
		toastr.success("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است!", "مدت زمان طولانی", {
			showDuration: 500
		})
	}), $("#toast-slow-duration").on("click", function () {
		toastr.warning("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است!", "مدت زمان کوتاه", {
			hideDuration: 3e3
		})
	}), $("#toast-timeout").on("click", function () {
		toastr.error("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است.", "وقفه!", {
			timeOut: 6e3
		})
	}), $("#toast-sticky").on("click", function () {
		toastr.info("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است.", "چسبنده!", {
			timeOut: 0
		})
	}), $("#toast-slide").on("click", function () {
		toastr.success("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است.", "Slide Down / Slide Up!", {
			showMethod: "slideDown",
			hideMethod: "slideUp",
			timeOut: 2e3
		})
	}), $("#toast-fade").on("click", function () {
		toastr.success("تستر یک کتابخانه جاوا اسکریپت برای اطلاعیه های غیر بلوک است. جی کوئری مورد نیاز است.", "Slide Down / Slide Up!", {
			showMethod: "fadeIn",
			hideMethod: "fadeOut",
			timeOut: 2e3
		})
	})
});
