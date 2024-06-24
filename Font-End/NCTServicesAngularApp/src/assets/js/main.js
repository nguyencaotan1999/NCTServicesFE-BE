(function ($) {
  "use strict";

  $(document).ready(function ($) {
    var Subtotal = 0;
    var shipping = 0;
    var totalcheckout = 0;
    // Loop through each row in the table body with class "order-details-body"
    $("#tableCheckout .order-details-body tr").each(function (index, value) {
      if (index >= 0) {
        // Get the value of the second column and remove the dollar sign before converting to a number
        var price = parseFloat(
          $(this).find("td:eq(2)").text().replace("VNĐ", "")
        );
        // Add the price to the total
        Subtotal = Subtotal + price;
      }
    });
    // Set the total value in the Total cell
    $("#SubtotalCheckout").text(Subtotal.toFixed(2) + "0 VNĐ");
    shipping = parseFloat($("#ShippingCheckout").text().replace("$", ""));
    totalcheckout = Subtotal + shipping;
    $("#totalCheckout").text(totalcheckout.toFixed(2) + "0 VNĐ");
    // testimonial sliders
    $(".testimonial-sliders").owlCarousel({
      items: 1,
      loop: true,
      autoplay: true,
      responsive: {
        0: {
          items: 1,
          nav: false,
        },
        600: {
          items: 1,
          nav: false,
        },
        1000: {
          items: 1,
          nav: false,
          loop: true,
        },
      },
    });

    // homepage slider
    $(".homepage-slider").owlCarousel({
      items: 1,
      loop: true,
      autoplay: true,
      nav: true,
      dots: false,
      navText: [
        '<i class="fas fa-angle-left"></i>',
        '<i class="fas fa-angle-right"></i>',
      ],
      responsive: {
        0: {
          items: 1,
          nav: false,
          loop: true,
        },
        600: {
          items: 1,
          nav: true,
          loop: true,
        },
        1000: {
          items: 1,
          nav: true,
          loop: true,
        },
      },
    });

    // logo carousel
    $(".logo-carousel-inner").owlCarousel({
      items: 4,
      loop: true,
      autoplay: true,
      margin: 30,
      responsive: {
        0: {
          items: 1,
          nav: false,
        },
        600: {
          items: 3,
          nav: false,
        },
        1000: {
          items: 4,
          nav: false,
          loop: true,
        },
      },
    });

    // count down
    if ($(".time-countdown").length) {
      $(".time-countdown").each(function () {
        var $this = $(this),
          finalDate = $(this).data("countdown");
        $this.countdown(finalDate, function (event) {
          var $this = $(this).html(
            event.strftime(
              "" +
                '<div class="counter-column"><div class="inner"><span class="count">%D</span>Days</div></div> ' +
                '<div class="counter-column"><div class="inner"><span class="count">%H</span>Hours</div></div>  ' +
                '<div class="counter-column"><div class="inner"><span class="count">%M</span>Mins</div></div>  ' +
                '<div class="counter-column"><div class="inner"><span class="count">%S</span>Secs</div></div>'
            )
          );
        });
      });
    }

    // projects filters isotop
    $(".product-filters li").on("click", function () {
      $(".product-filters li").removeClass("active");
      $(this).addClass("active");

      var selector = $(this).attr("data-filter");

      $(".product-lists").isotope({
        filter: selector,
      });
    });

    // isotop inner
    $(".product-lists").isotope();

    // magnific popup
    $(".popup-youtube").magnificPopup({
      disableOn: 700,
      type: "iframe",
      mainClass: "mfp-fade",
      removalDelay: 160,
      preloader: false,
      fixedContentPos: false,
    });

    // light box
    $(".image-popup-vertical-fit").magnificPopup({
      type: "image",
      closeOnContentClick: true,
      mainClass: "mfp-img-mobile",
      image: {
        verticalFit: true,
      },
    });

    $("#liveToastBtn").on("click", function () {
      $("#liveToast").toast("show");

      // Tự đóng toast sau 4 giây
      setTimeout(function () {
        $("#liveToast").toast("hide");
      }, 3500);
    });

    // homepage slides animations
    $(".homepage-slider").on("translate.owl.carousel", function () {
      $(".hero-text-tablecell .subtitle")
        .removeClass("animated fadeInUp")
        .css({ opacity: "0" });
      $(".hero-text-tablecell h1")
        .removeClass("animated fadeInUp")
        .css({ opacity: "0", "animation-delay": "0.3s" });
      $(".hero-btns")
        .removeClass("animated fadeInUp")
        .css({ opacity: "0", "animation-delay": "0.5s" });
    });

    $(".homepage-slider").on("translated.owl.carousel", function () {
      $(".hero-text-tablecell .subtitle")
        .addClass("animated fadeInUp")
        .css({ opacity: "0" });
      $(".hero-text-tablecell h1")
        .addClass("animated fadeInUp")
        .css({ opacity: "0", "animation-delay": "0.3s" });
      $(".hero-btns")
        .addClass("animated fadeInUp")
        .css({ opacity: "0", "animation-delay": "0.5s" });
    });

    // stikcy js
    $("#sticker").sticky({
      topSpacing: 0,
    });

    //mean menu
    $(".main-menu").meanmenu({
      meanMenuContainer: ".mobile-menu",
      meanScreenWidth: "992",
    });

    // search form
    $(".search-bar-icon").on("click", function () {
      $(".search-area").addClass("search-active");
    });

    $(".close-btn").on("click", function () {
      $(".search-area").removeClass("search-active");
    });
  });

  jQuery(window).on("load", function () {
    jQuery(".loader").fadeOut(1000);
  });
})(jQuery);
