$(document).ready(function () {
	$("#zero_configuration_table").DataTable(), $("#feature_disable_table").DataTable({
		paging: !1,
		ordering: !1,
		info: !1
	}), $("#deafult_ordering_table").DataTable({
		order: [[3, "desc"]]
	}), $("#multicolumn_ordering_table").DataTable({
		columnDefs: [{
			targets: [0],
			orderData: [0, 1]
		}, {
			targets: [1],
			orderData: [1, 0]
		}, {
			targets: [4],
			orderData: [4, 0]
		}]
	}), $("#hidden_column_table").DataTable({
		responsive: !0,
		columnDefs: [{
			targets: [2],
			visible: !1,
			searchable: !1
		}, {
			targets: [3],
			visible: !1
		}]
	}), $("#complex_header_table").DataTable(), $("#dom_positioning_table").DataTable({
		dom: '<"top"i>rt<"bottom"flp><"clear">'
	}), $("#alternative_pagination_table").DataTable({
		pagingType: "full_numbers"
	}), $("#scroll_vertical_table").DataTable({
		scrollY: "200px",
		scrollCollapse: !0,
		paging: !1
	}), $("#scroll_horizontal_table").DataTable({
		scrollX: !0
	}), $("#scroll_vertical_dynamic_height_table").DataTable({
		scrollY: "50vh",
		scrollCollapse: !0,
		paging: !1
	}), $("#scroll_horizontal_vertical_table").DataTable({
		scrollY: 200,
		scrollX: !0
	}), $("#comma_decimal_table").DataTable({
		language: {
			decimal: ",",
			thousands: "."
		}
	}), $("#language_option_table").DataTable({
		language: {
			lengthMenu: "نمایش دادن _MENU_ سوابق هر صفحه",
			zeroRecords: "چیزی یافت نشد - متاسفم",
			info: "نمایش صفحه _PAGE_ از _PAGES_",
			infoEmpty: "هیچ رکوردی موجود نیست",
			infoFiltered: "(فیلتر شده از _MAX_ تعداد کل رکوردها)"
		}
	})
});
