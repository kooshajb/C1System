$(document).ready(function () {
	$("#basic-alert").on("click", function () {
		swal("در اینجا یک پیام است!")
	}), $("#with-title").on("click", function () {
		swal("اینترنت؟", "این چیز هنوز در اطراف است؟")
	}), $("#with-html").on("click", function () {
		swal({
			title: "عنوان <small>HTML</small>!",
			text: 'یک پیام <span style="color:#F6BB42">html<span> سفارشی.',
			html: !0,
			buttonsStyling: !1,
			confirmButtonClass: "btn btn-lg btn-primary"
		})
	}), $("#alert-success").on("click", function () {
		swal({
			type: "success",
			title: "موفقیت!",
			text: "کار شما ذخیره شده است",
			buttonsStyling: !1,
			confirmButtonClass: "btn btn-lg btn-success"
		})
	}), $("#alert-info").on("click", function () {
		swal({
			type: "info",
			title: "هشدار اطلاعات!",
			text: "در اینجا متن هشدار اطلاعات است",
			buttonsStyling: !1,
			confirmButtonClass: "btn btn-lg btn-info"
		})
	}), $("#alert-warning").on("click", function () {
		swal({
			type: "warning",
			title: "هشدار",
			text: "در اینجا متن هشدار هشدار است",
			buttonsStyling: !1,
			confirmButtonClass: "btn btn-lg btn-warning"
		})
	}), $("#alert-error").on("click", function () {
		swal({
			type: "error",
			title: "ارور!",
			text: "چیزی اشتباه رفت!",
			confirmButtonText: "رد کردن",
			buttonsStyling: !1,
			confirmButtonClass: "btn btn-lg btn-danger"
		})
	}), $("#with-image").on("click", function () {
		swal({
			title: "شیرین!",
			text: "مدال با یک تصویر سفارشی.",
			imageUrl: "https://unsplash.it/400/200",
			imageWidth: 400,
			imageHeight: 200,
			imageAlt: "Custom image",
			buttonsStyling: !1,
			confirmButtonClass: "btn btn-lg btn-primary"
		})
	}), $("#with-timer").on("click", function () {
		swal({
			title: "هشدار بسته شدن خودکار!",
			html: "من در عرض <strong>2</strong> ثانیه بسته خواهم شد.",
			timer: 2e3
		}).then(t => {
			t.dismiss === swal.DismissReason.timer && console.log("من با تایمر بسته شدم")
		})
	}), $("#with-input").on("click", function () {
		swal({
			title: "یک ورودی!",
			text: "چیزی بنویسید:",
			input: "text",
			showCancelButton: !0,
			closeOnConfirm: !1,
			inputPlaceholder: "چیزی بنویسید"
		}).then(function (t) {
			return !1 !== t && ("" !== t && void swal("فوق العاده!", "تو نوشتی: " + t, "success"))
		})
	}), $("#alert-confirm").on("click", function () {
		swal({
			title: "شما مطمئن هستید؟",
			text: "شما نمیتوانید این را بازخوانی کنید!",
			type: "warning",
			showCancelButton: !0,
			confirmButtonColor: "#0CC27E",
			cancelButtonColor: "#FF586B",
			confirmButtonText: "بله، آن را حذف کنید!",
			cancelButtonText: "نه لغو کنید!",
			confirmButtonClass: "btn btn-success mr-5",
			cancelButtonClass: "btn btn-danger",
			buttonsStyling: !1
		}).then(function () {
			swal("حذف شد!", "فایل خیالی شما حذف شده است.", "success")
		}, function (t) {
			"cancel" === t && swal("لغو شد", "فایل خیالی شما امن است :)", "error")
		})
	})
});
