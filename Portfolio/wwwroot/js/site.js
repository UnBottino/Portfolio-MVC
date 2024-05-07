//Change Navbar on scroll (Navbar)
$(function () {
	var nowScrollTop = 0;
	$(window).on("scroll", function () {
		nowScrollTop = $(this).scrollTop();

		if (nowScrollTop > 0) {
			$(".navbar, #logo-text, .nav-link, .navbar-toggler-icon i").css('color', '#d2d2d2');
			$(".navbar").addClass('scrolled');
			$(".navbar-collapse").removeClass('show');
		} else {
			$(".navbar, #logo-text, .nav-link, .navbar-toggler-icon i").css('color', '');
			$(".navbar").removeClass('scrolled');
		}
	});
});

$(".navbar-toggler").on("click", function () {
	$(".navbar, #logo-text, .nav-link, .navbar-toggler-icon i").css('color', '#d2d2d2');
	$(".navbar").addClass('scrolled');
});

//Navbar navigation
$('.nav-link').on("click", function () {
	$(".navbar-collapse").removeClass('show');
});

$("#nav-about").on("click", function () {
	$([document.documentElement, document.body]).animate({
		scrollTop: $("#about").offset().top - $("#navbar").outerHeight(true)
	}, 100);
});

$("#nav-skills").on("click", function () {
	$([document.documentElement, document.body]).animate({
		scrollTop: $("#skills").offset().top - $("#navbar").outerHeight(true)
	}, 100);
});

$("#nav-experience").on("click", function () {
	$([document.documentElement, document.body]).animate({
		scrollTop: $("#experience").offset().top - $("#navbar").outerHeight(true)
	}, 100);
});

$("#nav-projects").on("click", function () {
	$([document.documentElement, document.body]).animate({
		scrollTop: $("#projects").offset().top - $("#navbar").outerHeight(true)
	}, 100);
});

$("#nav-contact").on("click", function () {
	$([document.documentElement, document.body]).animate({
		scrollTop: $("#contact").offset().top - $("#navbar").outerHeight(true)
	}, 100);
});

//Contact Modal
$('a#submit-modal').on('click', function () {
	$.ajax({
		url: "/Home/Contact",
		type: "POST",
		dataType: "json",
		data: $("#contact-form").serialize(),
		contentType: "application/x-www-form-urlencoded; charset=utf-8",
		success: function (response) {
			if (response.success) {

			} else {

			}
		},
		error: function (response) {

		}
	});
});

//Scroll to top (Footer)
$("#scrollToTop").on("click", function () {
	document.body.scrollTop = 0; // For Safari
	document.documentElement.scrollTop = 0;
});

const sections = document.querySelectorAll("section[id]");

window.addEventListener("scroll", navHighlighter);

function navHighlighter() {
	// Get current scroll position
	let scrollY = window.scrollY;

	// Now we loop through sections to get height, top and ID values for each
	sections.forEach(current => {
		const sectionHeight = current.offsetHeight;
		const sectionTop = current.offsetTop - $("#navbar").outerHeight(true) -30;
		sectionId = current.getAttribute("id");

		/*
		- If our current scroll position enters the space where current section on screen is, add .active class to corresponding navigation link, else remove it
		- To know which link needs an active class, we use sectionId variable we are getting while looping through sections as an selector
		*/
		if (
			scrollY > sectionTop &&
			scrollY <= sectionTop + sectionHeight
		) {
			document.querySelector("li#nav-" + sectionId).classList.add("active");
		} else {
			document.querySelector("li#nav-" + sectionId).classList.remove("active");
		}
	});
}