$(document).ready(function () {
	var s = $("[data-sidebar-container]").addClass("sidebar-container");
	$("[data-sidebar-content]").addClass("sidebar-content"), $("[data-sidebar]").addClass("sidebar");
	s.each(function (s) {
		var i, t, a, l, e, r, n = $(this);

		function c() {
			i = n.data("sidebar-container"), t = $('[data-sidebar-content="' + i + '"]'), a = $('[data-sidebar="' + i + '"]'), l = $('[data-sidebar-toggle="' + i + '"]'), e = a.outerWidth(), "right" === (r = a.data("sidebar-position")) ? (gullUtils.isMobile() ? t.css("margin-left", 0) : t.css("margin-left", e), gullUtils.isMobile() ? a.css("left", -e) : a.css("left", 0)) : (gullUtils.isMobile() ? t.css("margin-right", 0) : t.css("margin-right", e), gullUtils.isMobile() ? a.css("right", -e) : a.css("right", 0))
		}
		c(), $(window).on("resize", function (s) {
			setTimeout(function () {
				c()
			}, 300)
		}), l.on("click", function (s) {
			"right" === r ? "0px" == a.css("right") ? (a.css("right", -e), !gullUtils.isMobile() && t.css("margin-right", 0)) : (a.css("right", 0), !gullUtils.isMobile() && t.css("margin-right", e)) : "0px" == a.css("left") ? (a.css("left", -e), !gullUtils.isMobile() && t.css("margin-left", 0)) : (a.css("left", 0), !gullUtils.isMobile() && t.css("margin-left", e))
		})
	})
});
