var tour;
$(document).ready(function () {
	tour = {
		id: "demo-tour",
		showPrevButton: !0,
		steps: [{
			title: "اطلاعیه",
			content: "این اطلاع رسانی برای موضوع است که شما می توانید اعلان را بررسی کنید.",
			target: "dropdownMenuButton",
			placement: "left"
		}, {
			title: "نوار جستجو",
			content: "برای هر چیزی جستجو کنید",
			target: "search-bar",
			placement: "bottom"
		}, {
			title: "تور خود را ایجاد کنید",
			content: "تور جدید را به آسانی ایجاد کنید",
			target: "create-tour",
			placement: "top"
		}]
	}
}), $("#startTourBtn").on("click", function (t) {
	hopscotch.startTour(tour)
});
