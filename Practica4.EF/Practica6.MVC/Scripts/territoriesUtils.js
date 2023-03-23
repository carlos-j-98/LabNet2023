$(document).ready(function () {
    const searchParams = new URLSearchParams(window.location.search);
    let id = searchParams.get("parameter");
    if (id) {
        $("#territoriesList").val(id);
        GetTerritories(id);
    } else {
        SetDefaultValues();
    }
    $("#territoriesList").change(function () {
        const selectedValue = $(this).val();
        if (selectedValue != -1) {
            GetTerritories(selectedValue);
        } else {
            SetDefaultValues();
        }
    });
});
function GetTerritories(id) {
    $.ajax({
        url: '/Territories/GetByID?id=' + id,
        type: 'GET',
        success: function (result) {
            $("#idTerritories").val(result.ID);
            $("#description").val(result.Description);
            $("#region").val(result.RegionID);
        }
    });
}

function GetNextId() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: '/Territories/GetLastId',
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

        $("#idTerritories").val(result);
    })
    $("#description").val("");
    $("#region").val("");
}
