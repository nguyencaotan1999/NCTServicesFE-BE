(function ($) {
  $(document).ready(function ($) {
    $("#cartTable").on("input", "tbody tr td:nth-child(5) input", function () {
      // Lấy giá trị số lượng mới
      var subtotal = 0;
      $("#cartTable .Card-order-body tr").each(function (index, value) {
        if (index >= 0) {
          // Get the value of the second column and remove the dollar sign before converting to a number
          var price = parseFloat(
            $(this).find("td:eq(3)").text().replace("VNĐ", "")
          );
          var quantity = parseInt(
            $(this).find(".product-quantity input").val()
          );
          var sum = price * quantity;
          // Add the price to the total
          subtotal = subtotal + sum;
        }
      });
      $("#IdSubtotal").text(subtotal + ",000 VNĐ");
      var shippingA =
        parseFloat($("#IDShipping").text().replace("VNĐ", "")) + subtotal;
      $("#TotalCart").text(shippingA + ",000 VNĐ");
      if (subtotal == 0) {
        $("#TotalCart").text("0,000 VNĐ");
      }
    });
  });

  jQuery(window).on("load", function () {
    jQuery(".loader").fadeOut(1000);
  });
})(jQuery);
