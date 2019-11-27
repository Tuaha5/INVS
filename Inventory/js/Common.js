function msgbox(msgType, title, Msg) {
    var typeClass = "alert-info"
    switch (msgType) {
        case 1:
            typeClass = "alert-success";
            break;
        case 2:
            typeClass = "alert-info";
            break;
        case 3:
            typeClass = "alert-warning";
            break;
        case 4:
            typeClass = "alert-danger";
            break;
        default:
            typeClass = "alert-info";
            break;
    }

    var elem;

    if ($.find(".alert." + typeClass).length) {
        elem = $.find(".alert." + typeClass)[0];
    }
    else {
        elem = $("<div/>", { class: "alert " + typeClass });

        if ($("#createuser").is(":visible")) {
            $("#createuser:visible .modal-body").append(elem);
        }
        else {
            if ($(".Pagecontainer").length)
                $(".Pagecontainer").append(elem);
            else if ($(".inset").length)
                $(".inset").append(elem);
            else
                $("body").append(elem);
        }
    }

    $(elem).html("<strong>" + title + "</strong> " + Msg).slideDown();

    setTimeout(function () { $(elem).slideUp(); }, 3000);
}