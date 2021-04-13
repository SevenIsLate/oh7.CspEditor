function updateItem(e) {
    const directiveId = e.getAttribute("directiveId");
    const checked = $(e).prop("checked");
    const propertyToChange = $(e).attr("id");
    const postData = JSON.stringify({
        directiveId: directiveId,
        propertyToChange: propertyToChange,
        value: checked
    });
    const uri = "/Directive/Index?handler=Send";
    const xsrfToken = $('input:hidden[name="__RequestVerificationToken"]').val();

    $.ajax({
        type: "POST",
        url: uri,
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN", xsrfToken);
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: postData,
        success: function (response) {
            //console.log(response);
        },
        failure: function (response) {
            alert(response);
        }
    });
}

function setCookie(cname, cvalue, expireDays) {
    const d = new Date();
    d.setTime(d.getTime() + (expireDays * 24 * 60 * 60 * 1000));
    const expires = `expires=${d.toUTCString()}`;
    document.cookie = `${cname}=${cvalue};${expires};path=/`;
}

function getCookie(cname) {
    const name = `${cname}=`;
    const decodedCookie = decodeURIComponent(document.cookie);
    const ca = decodedCookie.split(";");
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) === " ") {
            c = c.substring(1);
        }
        if (c.indexOf(name) === 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

$(function () {
    const last = getCookie("activeAccordionGroup");
    if (last != null && last !== "") {
        $("#accordion .collapse").removeClass("in"); // in
        $(`#${last}`).collapse("show");
    }

    $("#accordion").on("shown.bs.collapse",
        function (e) {
            const active = e.target.id;
            setCookie("activeAccordionGroup", active, 14);
        });

    $("#accordion").on("hidden.bs.collapse",
        function () {
            setCookie("activeAccordionGroup", null, -1);
        });
});