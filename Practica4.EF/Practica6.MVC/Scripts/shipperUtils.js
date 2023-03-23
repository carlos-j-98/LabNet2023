$(document).ready(function () {
    const searchParams = new URLSearchParams(window.location.search);
    var id = searchParams.get("parameter");
    if (id) {
        $("#shipperList").val(id);
        GetShippers(id);
    } else {
        SetDefaultValues();
    }
    $("#shipperList").change(function () {
        const selectedValue = $(this).val();
        if (selectedValue != -1) {
            GetShippers(selectedValue);
        } else {
            SetDefaultValues();
        }
    });
});
function GetShippers(id) {
    $.ajax({
        url: '/Shippers/GetByID?id='+id,
        type: 'GET',
        success: function (result) {
            $("#idShipper").val(result.ID);
            $("#companyName").val(result.CompanyName);
            $("#phone").val(result.Phone);
        }
    });
}
function GetNextId() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: '/Shippers/GetLastId',
            type: 'GET',
            success: function (result) {
                resolve(result);
            },
            error: function (error) {
                reject(error);
            }
        });
    });
}
function SetDefaultValues() {
    GetNextId().then(function (result) {
        $("#idShipper").val(result);
    })
    $("#companyName").val("");
    $("#phone").val("");
}

