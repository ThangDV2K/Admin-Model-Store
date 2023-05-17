/*!
 * AdminuxPRO script v1.0.0 (https://www.maxartkiller.com/)
 * Copyright 2019-2019 The Maxartkiller Authors
 * Copyright 2019-2019 Maxartkiller.com
 * Licensed: You must have a valid license purchased only from maxartkiller.com in order to legally use the theme for your project.
 */

$(document).ready(function () {
  /* page navigation on load */

  var url = window.location.href.split("#")[0];
  if ($("body").hasClass("horizontal-menu") === true) {
    var element = $(".sidebar-left #side-menu li a")
      .filter(function () {
        return this.href == url;
      })
      .addClass("active")
      .parent("li")
      .addClass("active")
      .closest(".nav")
      .slideDown()
      .parent()
      .addClass("show")
      .closest(".nav")
      .slideDown()
      .addClass("in")
      .prev()
      .addClass("show");

    $(".sidebar-left .nav li a").on("click", function () {
      if ($(this).hasClass("menudropdown") === true) {
        $(this)
          .toggleClass("show")
          .next()
          .slideToggle()
          .parent()
          .addClass("in");
      }
    });
  } else {
    var element = $(".sidebar .nav .nav-link")
      .filter(function () {
        return this.href == url;
        alert(url);
      })
      .addClass("active")
      .parent(".nav-item")
      .addClass("active")
      .parents(".nav")
      .slideDown()
      .parents(".dropdown")
      .addClass("show");
  }

  /* menu open close wrapper screen click close menu */
  $(".menu-btn").on("click", function (e) {
    e.stopPropagation();
    if ($("body").hasClass("sidemenu-open") == true) {
      $("body").removeClass("sidemenu-open");
    } else {
      $("body").addClass("sidemenu-open");
    }
  });

  if ($(document).width() <= 992) {
    $("body").removeClass("sidemenu-open");
    $(".wrapper").on("click", function () {
      if ($("body").hasClass("sidemenu-open") == true) {
        $("body").removeClass("sidemenu-open");
      }
    });
  }

  /* Sidebar navigation expand collapse */
  $(".sidebar .nav .dropdown-toggle").on("click", function () {
    if ($(this).closest(".dropdown").hasClass("show") === true) {
      $(this).next().slideToggle().closest(".dropdown").removeClass("show");
    } else {
      $(this)
        .closest(".nav")
        .find(".dropdown")
        .removeClass("show")
        .find(".nav")
        .slideUp();
      $(this).next().slideToggle().closest(".dropdown").addClass("show");
    }
  });
  $(".nav-files .dropdown-toggle").on("click", function () {
    if ($(this).closest(".dropdown").hasClass("show") === true) {
      $(this).next().slideUp().closest(".dropdown").removeClass("show");
    } else {
      $(this).next().slideDown().closest(".dropdown").addClass("show");
    }
  });

  /* stop defualt event in card dropdown */
  $(".no-defaults").on("click", function (e) {
    e.stopPropagation();
  });

  /* select flag */
  $(".select-flag .dropdown-item").on("click", function () {
    var flagname = $(this).find(".flag-icon").attr("class");
    $(this)
      .closest(".select-flag")
      .find(".dropdown-toggle span")
      .attr("class", flagname);
  });

  /* filter click open filter */
  if ($("body").hasClass("filtermenu-open") == true) {
    $(".filter-btn").find("i").html("close");
  }
  $(".filter-btn").on("click", function () {
    if ($("body").hasClass("filtermenu-open") == true) {
      $("body").removeClass("filtermenu-open");
      $(this).find("i").html("filter_list");
    } else {
      $("body").addClass("filtermenu-open");
      $(this).find("i").html("close");
    }
  });

  /* background image to cover */
  $(".background").each(function () {
    var imagewrap = $(this);
    var imagecurrent = $(this).find("img").attr("src");
    imagewrap.css("background-image", 'url("' + imagecurrent + '")');
    $(this).find("img").remove();
  });

  $(".dropdown-toggle").on("click", function () {
    var thisdd = $(this);
    thisdd.removeClass("active");
    setTimeout(function () {
      thisdd.addClass("active");
    }, 100);
    $(".dropdown").on("hidden.bs.dropdown", function () {
      var thisddopen = $(this).find(".dropdown-toggle");
      thisddopen.removeClass("active");
    });
  });

  /* chat btn floating script */
  $(".chat-btn ").on("click", function () {
    if ($(this).hasClass("active") != true) {
      var thiscb = $(this);
      thiscb.addClass("active");
      thiscb.next().addClass("active");
      setTimeout(function () {
        thiscb.next().addClass("show");
      }, 100);
    }
  });
  $(".chat-close").on("click", function () {
    var thisccb = $(this);
    thisccb.closest(".chat-window").removeClass("show");

    setTimeout(function () {
      thisccb.closest(".chat-window").removeClass("active");
      thisccb.closest(".chat-window").prev(".chat-btn").removeClass("active");
    }, 250);
  });

  /* footer and responive sizing */
  var footerheight = $(".footer").outerHeight();
  $(".footer")
    .css("margin-top", -footerheight)
    .prev(".content ")
    .css("padding-bottom", footerheight);

  if ($(window).height() > 767) {
    /* mail-row height */
    $(".login-row-height").css(
      "height",
      $(window).outerHeight() -
        $(".header").outerHeight() -
        $(".footer").outerHeight() -
        50
    );
    $(".compose-row-height").css(
      "height",
      $(window).outerHeight() -
        $(".header-container").outerHeight() -
        $(".footer").outerHeight() -
        170
    );
    $(".mail-row-height").css(
      "height",
      $(window).outerHeight() -
        $(".header-container").outerHeight() -
        $(".mail-header").outerHeight() -
        $(".footer").outerHeight() -
        30
    );
    $(".file-row").css(
      "min-height",
      $(window).outerHeight() -
        $(".header-container").outerHeight() -
        $(".mail-header").outerHeight() -
        $(".footer").outerHeight() -
        30
    );
  }

  /* sidebar compact */
  if ($("body").hasClass("sidebar-compact") == true) {
    $(".sidebar")
      .find(".dropdown")
      .removeClass("show")
      .find(".dropdown-toggle")
      .next()
      .hide();
  }

  /* sidebar small */
  if ($("body").hasClass("sidebar-icon") == true) {
    $(".sidebar")
      .find(".dropdown")
      .removeClass("show")
      .find(".dropdown-toggle")
      .next()
      .hide();
  }
  $(".sidebar").on("mouseleave", function () {
    if (
      $("body").hasClass("sidebar-icon") ||
      $("body").hasClass("sidebar-compact")
    ) {
      $(".sidebar")
        .find(".dropdown")
        .removeClass("show")
        .find(".dropdown-toggle")
        .next()
        .hide();
    }
  });

  /*  fixed header */
  if ($("body").hasClass("header-fixed-top") == true) {
    var headerheight = $(".header-container").outerHeight() + 15;
    $(".wrapper").css("padding-top", headerheight);
  }

  /* task dropdown action */
  $("#tasks a").on("click", function (e) {
    e.preventDefault();
    $(this).tab("show");
  });
});

$(window).on("load", function () {
  $(".loader").fadeOut("slow");

  /* header active on scroll more than 50 px*/
  if ($(this).scrollTop() >= 30) {
    $(".header").addClass("active");
  } else {
    $(".header").removeClass("active");
  }

  $(window).on("scroll", function () {
    /* header active on scroll more than 50 px*/
    if ($(this).scrollTop() >= 30) {
      $(".header").addClass("active");
    } else {
      $(".header").removeClass("active");
    }
  });

  /* calander picker */
  var start = moment().subtract(29, "days");
  var end = moment();

  function cb(start, end) {
    $("#daterangeadminux span").html(
      start.format("MMM D, YY") + " - " + end.format("MMM D, YY")
    );
  }

  $("#daterangeadminux").daterangepicker(
    {
      startDate: start,
      endDate: end,
      opens: "left",
      ranges: {
        Today: [moment(), moment()],
        Yesterday: [moment().subtract(1, "days"), moment().subtract(1, "days")],
        "Last 7 Days": [moment().subtract(6, "days"), moment()],
        "Last 30 Days": [moment().subtract(29, "days"), moment()],
        "This Month": [moment().startOf("month"), moment().endOf("month")],
        "Last Month": [
          moment().subtract(1, "month").startOf("month"),
          moment().subtract(1, "month").endOf("month"),
        ],
      },
    },
    cb
  );

  cb(start, end);
  $("#daterangeadminux").on("show.daterangepicker", function (ev, picker) {
    var thisdp = $(".daterangepicker");
    setTimeout(function () {
      thisdp.addClass("active");
    }, 100);
  });
  $("#daterangeadminux").on("hide.daterangepicker", function (ev, picker) {
    var thisdpc = $(".daterangepicker");
    thisdpc.removeClass("active");
  });
  var path = "../assets/img/background-part.png";
  $(".daterangepicker").append(
    '<div class="background" style="background-image: url(' +
      path +
      '); z-index:-1; height:80px;"><img src="../assets/img/background-part.png" alt="" style="display:none"></div>'
  );
  /* calander picker ends */

  /* sidebar message close */
  $(".close-btn").on("click", function () {
    $(this).closest(".card").fadeOut();
  });
});

$(window).on("resize", function () {
  /* on resize close sidemenu */
  if ($("body").hasClass("no-sidemenu") != true) {
    if ($(document).width() <= 992) {
      $("body").removeClass("sidemenu-open");
    } else {
      $("body").addClass("sidemenu-open");
    }
  }

  /* footer and responive sizing */
  var footerheight = $(".footer").outerHeight();
  $(".footer")
    .css("margin-top", -footerheight)
    .prev(".content ")
    .css("padding-bottom", footerheight);

  if ($(window).height() > 767) {
    /* mail-row height */
    $(".login-row-height").css(
      "height",
      $(window).outerHeight() -
        $(".header").outerHeight() -
        $(".footer").outerHeight() -
        50
    );
    $(".compose-row-height").css(
      "height",
      $(window).outerHeight() -
        $(".header-container").outerHeight() -
        $(".footer").outerHeight() -
        170
    );
    $(".mail-row-height").css(
      "height",
      $(window).outerHeight() -
        $(".header-container").outerHeight() -
        $(".mail-header").outerHeight() -
        $(".footer").outerHeight() -
        30
    );
    $(".file-row").css(
      "min-height",
      $(window).outerHeight() -
        $(".header-container").outerHeight() -
        $(".mail-header").outerHeight() -
        $(".footer").outerHeight() -
        30
    );
  }
});

$(".wrapper").on("scroll", function () {
  /*window scoll event on scroll fill header to avoid overlapping content visible */
  if ($(this).scrollTop() > 20) {
    $(".header-container").addClass("header-fill");
  } else {
    $(".header-container").removeClass("header-fill");
  }
});

// Validation
function validatePhoneNumber(input_str) {
  var re = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/im;

  return re.test(input_str);
}

function validateForm(event) {
  var phone = $("#hotline").value;
  if (!validatePhoneNumber(phone)) {
    $("#phone_error").classList.remove("hidden");
  } else {
    $("#phone_error").classList.add("hidden");
    alert("validation success");
  }
  event.preventDefault();
}
//Call API Insert sản phẩm
var container_form = document.querySelector("#container_form");
var btn_show_product = document.querySelector("#btn-show_product");
var form = document.querySelector("#form");
var is_form_visible = false;

$("#container_form").hide();
btn_show_product.addEventListener("click", function (event) {
  event.stopPropagation(); // Ngăn chặn sự kiện lan ra body
  if (!is_form_visible) {
    $("#container_form").show(500);
    is_form_visible = true;
  } else {
    $("#container_form").hide(500);
    is_form_visible = false;
  }
});

var body = document.getElementsByTagName("body")[0];
var is_click_on_button = false;

btn_show_product.addEventListener("mousedown", function () {
  is_click_on_button = true;
});

body.addEventListener("mouseup", function (event) {
  if (
    is_form_visible &&
    !container_form.contains(event.target) &&
    !is_click_on_button
  ) {
    $("#container_form").hide(500);
    is_form_visible = false;
  }
  is_click_on_button = false;
});

form.addEventListener("submit", function (e) {
  e.preventDefault();
  const filePath = document.querySelector("#Avatar").value;
  const encodedFilePath = filePath.replace(/\//g, "\\");
  var filename = encodedFilePath.split("\\");

  console.log(filename[filename.length - 1]);
  const formData = new FormData(form);
  formData.append("Avatar", filename[filename.length - 1]);
  var object = {};
  formData.forEach(function (value, key) {
    object[key] = value;
  });
  var data = JSON.stringify(object);

  fetch("http://20.231.38.177:8000/api/products", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: data,
  })
    .then((response) => {
      if (response.ok) {
        alert("Thêm sản phẩm thành công!!!");
        $("#container_form").hide(500);
        is_form_visible = false;
        form.reset();
      } else {
        alert("Đã có lỗi xảy ra :(");
        $("#container_form").hide(500);
        is_form_visible = false;
      }
      $("#container_form").hide(1000);
    })
    .then((data) => console.log(data))
    .catch((error) => console.error("Unable to add item.", error));
});

// Call API get sản phẩm
fetch("http://20.231.38.177:8000/api/products")
  // Converting received data to JSON
  .then((response) => response.json())
  .then((data) => {
    let HTML = `<tr><th>ID</th><th>Name Product</th><th>Price</th><th>Sale</th><th>Avatar</th><th>Weight</th><th>Height</th><th>Material</th><th>Status</th><th>Action</th></tr>`;

    data.forEach((product) => {
      HTML += `<tr>
        <td>${product.productID}</td>
        <td>${product.productName} </td>
        <td>${product.priceListed}</td>
        <td>${product.sale}</td>
        <td>${product.avatar}</td>
        <td>${product.weight}</td>
        <td>${product.height}</td>
        <td>${product.material}</td>
        <td>${product.status}</td>
        <td class="d-flex justify-content-center">
            <button type="button" class="btn btn-info mr-3 EditBtn" data-id=${product.productID}>Edit</button>
            <button type="button" class="btn btn-danger">Delete</button>
        </td>
      </tr>`;
    });
    // 4. DOM Display result
    document.getElementById("table-id").innerHTML = HTML;
  });

$(document).on("click", ".EditBtn", function () {
  var ProductID = this.getAttribute("data-id");
  console.log(ProductID);
  var cells = this.parentNode.parentNode.cells;

  // Lấy thông tin từ các ô
  var productName = cells[1].innerText;
  var priceListed = cells[2].innerText;
  var sale = cells[3].innerText;
  var avatar = cells[4].innerText;
  var weight = cells[5].innerText;
  var height = cells[6].innerText;
  var material = cells[7].innerText;
  var status = cells[8].innerText;

  // Gán thông tin vào các trường nhập liệu trên form
  document.getElementById("ProductName").value = productName;
  document.getElementById("PriceListed").value = priceListed;
  document.getElementById("Sale").value = sale;
  document.getElementById("Weight").value = weight;
  document.getElementById("Height").value = height;
  document.getElementById("Material").value = material;
  document.getElementById("Status").value = status;

  document.querySelector("#container_form").style.display = "block";

  // Sự kiện click nút Submit trên form
  var form = document.querySelector("#form");
  form.addEventListener("click", function (e) {
    e.preventDefault();
    // Tạo đối tượng FormData và gửi dữ liệu qua API
    var formData = new FormData();
    formData.append(
      "productName",
      document.getElementById("ProductName").value
    );
    formData.append(
      "priceListed",
      document.getElementById("PriceListed").value
    );
    formData.append("sale", document.getElementById("Sale").value);
    formData.append("weight", document.getElementById("Weight").value);
    formData.append("height", document.getElementById("Height").value);
    formData.append("material", document.getElementById("Material").value);
    formData.append("status", document.getElementById("Status").value);

    // Gọi API để cập nhật dữ liệu
    fetch(`http://20.231.38.177:8000/api/products/${ProductID}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        productName: document.getElementById("ProductName").value,
        priceListed: document.getElementById("PriceListed").value,
        sale: document.getElementById("Sale").value,
        avatar: document.getElementById("Avatar").value,
        weight: document.getElementById("Weight").value,
        height: document.getElementById("Height").value,
        material: document.getElementById("Material").value,
        status: document.getElementById("Status").value,
      }),
    })
      .then(function (response) {
        if (response.ok) {
          // Cập nhật thành công
          alert("Dữ liệu đã được cập nhật thành công!");
        } else {
          // Cập nhật thất bại
          alert("Đã xảy ra lỗi khi cập nhật dữ liệu.");
        }
      })
      .catch(function (error) {
        alert("Đã xảy ra lỗi: ", error);
      });
  });
});
