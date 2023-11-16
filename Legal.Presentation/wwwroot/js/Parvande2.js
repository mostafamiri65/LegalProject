$("#OstanId").change(function () {

    var ostan = $("#OstanId").val();
    $.ajax({
        url: "/Parvandeh/GetShahrestan",
        type: "GET",
        data: { ostanId: ostan },
        success: function (data) {
            console.log(data);
            $("#ShahrestanId").empty();
            $("#ShahrestanId").append($("<option>انتخاب شهرستان</option>"));
            $.each(data, function (index, value) {
                $("#ShahrestanId").append($("<option></option>")
                    .attr("value", value.id)
                    .text(value.title));
            })

        },
        error: function () {
            console.log("Error occurred while loading Ostan.");
        }
    });

})
$("#NoyehParvandehCode").change(function () {
    var noe = $("#NoyehParvandehCode").val();
    var id = $("#Id").val();
    $.ajax({
        url: "/Parvandeh/GetMarja",
        type: "Get",
        data: { noeId: noe, id: id },
        success: function (res) {
            $("#MarjId").empty();
            $("#MarjId").append($("<option>انتخاب مرجع</option>"));
            $.each(res, function (index, value) {
                $("#MarjId").append($("<option></option>")
                    .attr("value", value.id)
                    .text(value.title)
                );
            })
        }
    })
})

$("#MarjId").change(function () {
    var id = $("#Id").val();
    var marj = $("#MarjId").val();
    $.ajax({
        url: "/Parvandeh/ChangeMarjeParvande",
        type: "Get",
        data: { id: id, marjId: marj },
        success: function (res) {
            console.log(res);
        }
    })
})

$("#ShShobeh").blur(function () {
    var id = $("#Id").val();
    var shobe = $("#ShShobeh").val();
 
    $.ajax({
        url: "/Parvandeh/ChangeShomareShobe",
        type: "Get",
        data: { id: id, shomare: shobe },
        success: function (res) {
            console.log(res);
        }
    })
})
$("#ShParvandeh24").blur(function () {
    var id = $("#Id").val();
    var sh24 = $("#ShParvandeh24").val();
    if (sh24.length != 24) {
        alert('شماره پرونده باید 24 رقمی باشد');
    }
    $.ajax({
        url: "/Parvandeh/ChangeShomare24",
        type: "Get",
        data: { id: id, shomare: sh24 },
        success: function (res) {
            console.log(res);
        }
    })
})

$("#ShahrestanId").change(function () {
    var noe = $("#ShahrestanId").val();
    var id = $("#Id").val();
    $.ajax({
        url: "/Parvandeh/GetMojtamaes",
        type: "Get",
        data: { shahrId: noe, id: id },
        success: function (res) {
            $("#MogId").empty();
            $("#MogId").append($("<option>انتخاب مجتمع</option>"));
            $.each(res, function (index, value) {
                $("#MogId").append($("<option></option>")
                    .attr("value", value.id)
                    .text(value.title)
                );
            })
        }
    })
})


$("#DateIjad").blur(function () {
    var id = $("#Id").val();
    var date = $("#DateIjad").val();
    var mog = $("#MogId").val();
    var shP = $("#ShParvandeh").val();
    var shSho = $("#ShShobeh").val();
    var sh24 = $("#ShParvandeh24").val();
    var shahr = $("#ShahrestanId").val();
    var maj = $("#MarjId").val();
    var noe = $("#NoyehParvandehCode").val();
    console.log(id);

    $.ajax({
        url: "/Parvandeh/CreateParvandeAjax",
        type: "Get",
        data: {
            id: id, noe: noe, marj: maj, shahr: shahr, sh24: sh24, shShobe: shSho,
            shP: shP, mog: mog, date: date
        },
        success: function (res) {
            $("#Id").val(res);
        }
    })


})

function AddKhahan() {
    var id = $("#Id").val();
    $.ajax({
        url: "/Parvandeh/AddKhahan",
        type: "Get",
        data: { id: id }
    }).done(function (result) {
        $('#modal').modal('show');
        $('#title').html(' تعریف خواهان جدید ...');
        $('#body').html(result);
    });
}
